using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using McFly.Core;
using McFly.Core.Registers;
using McFly.Debugger;

namespace McFly
{
    [Export(typeof(IRegisterEngine))]
    public class RegisterEngine : IRegisterEngine
    {                                                           
        /// <inheritdoc />
        public byte[] GetRegisterValue(int threadId, Register register, IDebugRegisters2 registers, IDebugEngineProxy debugEngine)
        {
            int save = debugEngine.GetCurrentThreadId();
            debugEngine.SwitchToThread(threadId);
            if (debugEngine.Is32Bit)
                return GetRegisterValue32(register, registers);
            debugEngine.SwitchToThread(save);
            return GetRegisterValue64(register, registers);
        }

        private unsafe byte[] GetRegisterValue32(Register register, IDebugRegisters2 registers)
        {
            if (register == Register.Ymm0)
            {
                var hr = registers.GetValue(Register.Ymm0.X86Index.Value.ToUInt(), out var ymm0);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm0.X86Index.Value.ToUInt(), out var xmm0);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm0.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm0.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm1)
            {
                var hr = registers.GetValue(Register.Ymm1.X86Index.Value.ToUInt(), out var ymm1);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm1.X86Index.Value.ToUInt(), out var xmm1);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm1.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm1.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm2)
            {
                var hr = registers.GetValue(Register.Ymm2.X86Index.Value.ToUInt(), out var ymm2);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm2.X86Index.Value.ToUInt(), out var xmm2);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm2.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm2.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm3)
            {
                var hr = registers.GetValue(Register.Ymm3.X86Index.Value.ToUInt(), out var ymm3);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm3.X86Index.Value.ToUInt(), out var xmm3);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm3.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm3.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm4)
            {
                var hr = registers.GetValue(Register.Ymm4.X86Index.Value.ToUInt(), out var ymm4);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm4.X86Index.Value.ToUInt(), out var xmm4);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm4.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm4.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm5)
            {
                var hr = registers.GetValue(Register.Ymm5.X86Index.Value.ToUInt(), out var ymm5);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm5.X86Index.Value.ToUInt(), out var xmm5);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm5.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm5.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm6)
            {
                var hr = registers.GetValue(Register.Ymm6.X86Index.Value.ToUInt(), out var ymm6);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm6.X86Index.Value.ToUInt(), out var xmm6);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm6.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm6.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm7)
            {
                var hr = registers.GetValue(Register.Ymm7.X86Index.Value.ToUInt(), out var ymm7);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm7.X86Index.Value.ToUInt(), out var xmm7);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm7.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm7.F128Bytes[i]);
                return list.ToArray();
            }
            
            var bytes = new List<byte>();
            var hr3 = registers.GetValue(register.X86Index.Value.ToUInt(), out var val);
            if (hr3 != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr3}");

            for (int i = 0; i < register.X86NumBits.Value; i++)
            {
                bytes.Add(val.F128Bytes[i]);
            }

            return bytes.Take(register.NumBits / 8  + Math.Min(register.NumBits % 8, 1)).ToArray();
        }

        private unsafe byte[] GetRegisterValue64(Register register, IDebugRegisters2 registers)
        {
            if (register == Register.Ymm0)
            {
                var hr = registers.GetValue(Register.Ymm0.X64Index.Value.ToUInt(), out var ymm0);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm0.X64Index.Value.ToUInt(), out var xmm0);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm0.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm0.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm1)
            {
                var hr = registers.GetValue(Register.Ymm1.X64Index.Value.ToUInt(), out var ymm1);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm1.X64Index.Value.ToUInt(), out var xmm1);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm1.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm1.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm2)
            {
                var hr = registers.GetValue(Register.Ymm2.X64Index.Value.ToUInt(), out var ymm2);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm2.X64Index.Value.ToUInt(), out var xmm2);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm2.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm2.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm3)
            {
                var hr = registers.GetValue(Register.Ymm3.X64Index.Value.ToUInt(), out var ymm3);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm3.X64Index.Value.ToUInt(), out var xmm3);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm3.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm3.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm4)
            {
                var hr = registers.GetValue(Register.Ymm4.X64Index.Value.ToUInt(), out var ymm4);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm4.X64Index.Value.ToUInt(), out var xmm4);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm4.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm4.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm5)
            {
                var hr = registers.GetValue(Register.Ymm5.X64Index.Value.ToUInt(), out var ymm5);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm5.X64Index.Value.ToUInt(), out var xmm5);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm5.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm5.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm6)
            {
                var hr = registers.GetValue(Register.Ymm6.X64Index.Value.ToUInt(), out var ymm6);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm6.X64Index.Value.ToUInt(), out var xmm6);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm6.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm6.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm7)
            {
                var hr = registers.GetValue(Register.Ymm7.X64Index.Value.ToUInt(), out var ymm7);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm7.X64Index.Value.ToUInt(), out var xmm7);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm7.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm7.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm8)
            {
                var hr = registers.GetValue(Register.Ymm8.X64Index.Value.ToUInt(), out var ymm8);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm8.X64Index.Value.ToUInt(), out var xmm8);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm8.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm8.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm9)
            {
                var hr = registers.GetValue(Register.Ymm9.X64Index.Value.ToUInt(), out var ymm9);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm9.X64Index.Value.ToUInt(), out var xmm9);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm9.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm9.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm10)
            {
                var hr = registers.GetValue(Register.Ymm10.X64Index.Value.ToUInt(), out var ymm10);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm10.X64Index.Value.ToUInt(), out var xmm10);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm10.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm10.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm11)
            {
                var hr = registers.GetValue(Register.Ymm11.X64Index.Value.ToUInt(), out var ymm11);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm11.X64Index.Value.ToUInt(), out var xmm11);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm11.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm11.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm12)
            {
                var hr = registers.GetValue(Register.Ymm12.X64Index.Value.ToUInt(), out var ymm12);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm12.X64Index.Value.ToUInt(), out var xmm12);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm12.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm12.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm13)
            {
                var hr = registers.GetValue(Register.Ymm13.X64Index.Value.ToUInt(), out var ymm13);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm13.X64Index.Value.ToUInt(), out var xmm13);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm13.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm13.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm14)
            {
                var hr = registers.GetValue(Register.Ymm14.X64Index.Value.ToUInt(), out var ymm14);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm14.X64Index.Value.ToUInt(), out var xmm14);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm14.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm14.F128Bytes[i]);
                return list.ToArray();
            }
            if (register == Register.Ymm15)
            {
                var hr = registers.GetValue(Register.Ymm15.X64Index.Value.ToUInt(), out var ymm15);
                if (hr != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr}");
                var hr2 = registers.GetValue(Register.Xmm15.X64Index.Value.ToUInt(), out var xmm15);
                if (hr2 != 0)
                    throw new ApplicationException(
                        $"Unable to get register value for register {register.Name}, error code is {hr2}");
                var list = new List<byte>();
                for (int i = 0; i < 16; i++)
                    list.Add(xmm15.F128Bytes[i]);
                for (int i = 0; i < 16; i++)
                    list.Add(ymm15.F128Bytes[i]);
                return list.ToArray();
            }

            var bytes = new List<byte>();
            var hr3 = registers.GetValue(register.X64Index.Value.ToUInt(), out var val);
            if (hr3 != 0)
                throw new ApplicationException(
                    $"Unable to get register value for register {register.Name}, error code is {hr3}");

            for (int i = 0; i < register.X64NumBits.Value; i++)
            {
                bytes.Add(val.F128Bytes[i]);
            }
            
            return bytes.Take(register.NumBits / 8 + Math.Min(register.NumBits % 8, 1)).ToArray();
        }
    }
}