using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Core.Registers
{
    public partial class Register
    {
        public class IoplRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "iopl";

            /// <inheritdoc />
            public override int NumBits { get; } = 2;
        }
        public static IoplRegister Iopl { get; } = new IoplRegister();

        public class OfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Of";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static OfRegister Of { get; } = new OfRegister();

        public class DfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Df";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static DfRegister Df { get; } = new DfRegister();
        public class IfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "If";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static IfRegister If { get; } = new IfRegister();
        public class TfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Tf";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static TfRegister Tf { get; } = new TfRegister();
        public class SfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Sf";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static SfRegister Sf { get; } = new SfRegister();
        public class ZfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Zf";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static ZfRegister Zf { get; } = new ZfRegister();
        public class AfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Af";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static AfRegister Af { get; } = new AfRegister();
        public class PfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Pf";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static PfRegister Pf { get; } = new PfRegister();
        public class CfRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Cf";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static CfRegister Cf { get; } = new CfRegister();

        public class VipRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Vip";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static VipRegister Vip { get; } = new VipRegister();

        public class VifRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Vif";

            /// <inheritdoc />
            public override int NumBits { get; } = 1;
        }
        public static VifRegister Vif { get; } = new VifRegister();
    }
}
