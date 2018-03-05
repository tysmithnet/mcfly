using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using McFly.Core;
using McFly.Debugger;

namespace McFly
{
    public class DbgEngProxy : IDbgEngProxy, IDisposable
    {
        private IDebugControl5 Control { get; set; }
        private IDebugClient5 Client { get; set; }
        private ExecuteWrapper ExecuteWrapper { get; set; }
        private IDebugRegisters2 Registers { get; set; }
        private bool Is32Bit;
        public DbgEngProxy(IDebugControl5 control, IDebugClient5 client, IDebugRegisters2 registers)
        {
            Control = control;
            Client = client;
            Registers = registers;
            ExecuteWrapper = new ExecuteWrapper(Client);
            Is32Bit =
                Regex.Match(ExecuteWrapper.Execute("!peb"), @"PEB at (?<peb>[a-fA-F0-9]+)").Groups["peb"].Value.Length == 8;
        }

        public void Dispose()
        {
            ExecuteWrapper?.Dispose();
        }

        public void RunUntilBreak()
        {
            DEBUG_STATUS status;
            var goStatuses = new[]
            {
                DEBUG_STATUS.GO, DEBUG_STATUS.STEP_BRANCH, DEBUG_STATUS.STEP_INTO, DEBUG_STATUS.STEP_OVER,
                DEBUG_STATUS.REVERSE_STEP_BRANCH, DEBUG_STATUS.REVERSE_STEP_INTO, DEBUG_STATUS.REVERSE_GO,
                DEBUG_STATUS.REVERSE_STEP_OVER
            };
            Control.SetExecutionStatus(DEBUG_STATUS.GO);
            while (true)
            {
                Control.GetExecutionStatus(out status);
                if (goStatuses.Contains(status))
                {
                    Control.WaitForEvent(DEBUG_WAIT.DEFAULT,
                        uint.MaxValue); // todo: make reasonable and add counter.. shouldn't wait more than 10s
                    continue;
                }

                if (status == DEBUG_STATUS.BREAK)
                    break;
            }
        }

        public string Execute(string command)
        {
            return ExecuteWrapper.Execute(command);
        }

        public RegisterSet GetRegisters(int threadId, IEnumerable<Register> registers)
        {
            var list = registers.ToList();
            if(list.Count == 0)
                return new RegisterSet();
            var registerSet = new RegisterSet();
            string registerNames = string.Join(",", list.Select(x => x.Name));
            string registerText = Execute($"~~[{threadId:X}] r {registerNames}");
            foreach (var register in list)
            {
                int numChars = register.NumBits / 2;
                var match = Regex.Match(registerText, $"{register.Name}=(?<val>[a-fA-F0-9]{{{numChars}}})");
                var val = match.Groups["val"].Value;
                registerSet.Process(register.Name, val, 16);
            }
            return registerSet;
        }
    }
}