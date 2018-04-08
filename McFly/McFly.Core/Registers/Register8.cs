using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McFly.Core.Registers
{
    public partial class Register
    {

        public class R8bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R8b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R8bRegister R8b { get; } = new R8bRegister();
        public class R9bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R9b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R9bRegister R9b { get; } = new R9bRegister();
        public class R10bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R10b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R10bRegister R10b { get; } = new R10bRegister();
        public class R11bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R11b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R11bRegister R11b { get; } = new R11bRegister();
        public class R12bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R12b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R12bRegister R12b { get; } = new R12bRegister();
        public class R13bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R13b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R13bRegister R13b { get; } = new R13bRegister();
        public class R14bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R14b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R14bRegister R14b { get; } = new R14bRegister();
        public class R15bRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "R15b";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static R15bRegister R15b { get; } = new R15bRegister();

        public class AhRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Ah";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static AhRegister Ah { get; } = new AhRegister();

        public class BhRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Bh";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static BhRegister Bh { get; } = new BhRegister();

        public class ChRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Ch";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static ChRegister Ch { get; } = new ChRegister();

        public class DhRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Dh";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static DhRegister Dh { get; } = new DhRegister();

        public class AlRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Al";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static AlRegister Al { get; } = new AlRegister();
        public class ClRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Cl";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static ClRegister Cl { get; } = new ClRegister();
        public class DlRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Dl";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static DlRegister Dl { get; } = new DlRegister();
        public class BlRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Bl";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static BlRegister Bl { get; } = new BlRegister();

        public class SplRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Spl";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static SplRegister Spl { get; } = new SplRegister();

        public class BplRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Bpl";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static BplRegister Bpl { get; } = new BplRegister();
        public class SilRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Sil";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static SilRegister Sil { get; } = new SilRegister();
        public class DilRegister : Register
        {
            /// <inheritdoc />
            public override string Name { get; } = "Dil";

            /// <inheritdoc />
            public override int NumBits { get; } = 16;
        }
        public static DilRegister Dil { get; } = new DilRegister();

    }
}
