using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace McFly.Tests
{
    public class IndexMethod_Should
    {
        [Fact]
        public void Identify_32_And_64_Bit_Arch()
        {
            // Arrange
            var builder = new DbgEngProxyBuilder();
            builder.WithExecuteResult("!peb", @"PEB at 00000000003b9000
    InheritedAddressSpace:    No
    ReadImageFileExecOptions: No
    BeingDebugged:            No
    ...
    ImageBaseAddress:         0000000140000000        _NT_SYMBOL_PATH=SRV*c:\symbols*http://msdl.microsoft.com/download/symbols");
            var proxy = builder.Build();

            // Act
            var indexMethod = new IndexMethod();
            indexMethod.DbgEngProxy = builder.Build();
            bool is32 = indexMethod.Is32Bit();

            // Assert
            Assert.False(is32);
        }
    }
}
