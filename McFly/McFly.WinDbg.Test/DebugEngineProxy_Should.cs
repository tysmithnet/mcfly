using System.Linq;
using FluentAssertions;
using McFly.Core;
using McFly.Core.Registers;
using McFly.WinDbg.Debugger;
using Moq;
using Xunit;

namespace McFly.WinDbg.Test
{
    public class DebugEngineProxy_Should
    {
        [Fact]
        public void Identify_32_vs_64_Bit()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();

            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(@"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No");

            new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object, systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object).Is32Bit.Should().BeFalse();
        }

        [Fact]
        public void Execute_Commands_And_Return_Output()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();

            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.Execute("!peb").Should().Be(Value);
        }

        [Fact]
        public void Execute_Commands_And_Return_Output_On_Specific_Threads()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();

            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.Execute(1, "!peb").Should().Be(Value);
            executeWrapperMock.Verify(wrapper => wrapper.Execute(It.Is<string>(s => s.StartsWith("~~[0x1]e"))));
        }

        [Fact]
        public void Get_The_Current_Thread_Id()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();
            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            uint val = 1;
            systemObjectsMock.Setup(objects => objects.GetCurrentThreadId(out val));
            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.GetCurrentThreadId().Should().Be(1);
        }

        [Fact]
        public void Switch_To_A_Specified_Thread()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();
            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            systemObjectsMock.Setup(objects => objects.SetCurrentThreadId(It.IsAny<uint>()));
            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.SwitchToThread(1);
            systemObjectsMock.Verify(objects => objects.SetCurrentThreadId(1), Times.Once);
        }

        [Fact]
        public void Get_Register_Values()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();
            var registerEngineMock = new Mock<IRegisterEngine>();
            registerEngineMock.Setup(engine => engine.GetRegisterValue(It.IsAny<int>(), It.IsAny<Register>(),
                It.IsAny<IDebugRegisters2>(), It.IsAny<IDebugEngineProxy>())).Returns(new byte[]{0x00});
            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.RegisterEngine = registerEngineMock.Object;
            eng.GetRegisterValue(1, Register.Af).SequenceEqual(new byte[] {0x00}).Should().BeTrue();
        }

        [Fact]
        public void Read_Virtual_Memory()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();
            var memoryEngineMock = new Mock<IMemoryEngine>();

            memoryEngineMock
                .Setup(engine => engine.ReadMemory(It.IsAny<ulong>(), It.IsAny<ulong>(), It.IsAny<IDebugDataSpaces>()))
                .Returns(new byte[] {0x00, 0x11});

            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.MemoryEngine = memoryEngineMock.Object;
            eng.ReadVirtualMemory(new MemoryRange(0, 1));
            memoryEngineMock.Verify(engine => engine.ReadMemory(0, 1, dataSpacesMock.Object), Times.Once);
        }

        [Fact]
        public void Write_Text_To_The_Screen()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();

            controlMock.Setup(control =>
                control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_OUTPUT.NORMAL, It.IsAny<string>()));

            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.WriteLine("hi");
            controlMock.Verify(control => control.ControlledOutput(DEBUG_OUTCTL.ALL_CLIENTS, DEBUG_OUTPUT.NORMAL, "hi\n"), Times.Once);
        }

        [Fact]
        public void Allow_For_Single_Stepping()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();

            controlMock.Setup(control => control.SetExecutionStatus(It.IsAny<DEBUG_STATUS>()));

            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.StepInto();
            controlMock.Verify(control => control.SetExecutionStatus(DEBUG_STATUS.STEP_INTO), Times.Once);
        }

        [Fact]
        public void Be_Able_To_Continue_Execution_Until_A_Break_Occurs()
        {
            var controlMock = new Mock<IDebugControl6>();
            var clientMock = new Mock<IDebugClient5>();
            var registersMock = new Mock<IDebugRegisters2>();
            var systemObjectsMock = new Mock<IDebugSystemObjects>();
            var dataSpacesMock = new Mock<IDebugDataSpaces>();
            var executeWrapperMock = new Mock<IExecuteWrapper>();

            DEBUG_STATUS status = DEBUG_STATUS.GO;
            int i = 0;
            controlMock.Setup(control => control.GetExecutionStatus(out status)).Callback(() =>
            {
                DEBUG_STATUS status2 = DEBUG_STATUS.BREAK;
                if (i > 0)
                    controlMock.Setup(control => control.GetExecutionStatus(out status2));
                i++;
            });
            

            const string Value = @"PEB at 00000041e9154000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No";
            executeWrapperMock.Setup(wrapper => wrapper.Execute(It.IsAny<string>())).Returns(Value);

            var eng = new DebugEngineProxy(controlMock.Object, clientMock.Object, registersMock.Object,
                systemObjectsMock.Object,
                dataSpacesMock.Object, executeWrapperMock.Object);
            eng.RunUntilBreak();
            
            controlMock.Verify(control => control.GetExecutionStatus(out status), Times.Exactly(3));
        }
    }
}