using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace McFly
{
    public class ByteArrayBuilder
    {
        private List<byte> _bytes = new List<byte>();

        public ByteArrayBuilder AppdendHexString(string hexString)
        {
            _bytes.AddRange(StringToByteArray(hexString));
            return this;
        }

        public static byte[] StringToByteArray(string hex)
        {
            if(string.IsNullOrWhiteSpace(hex))
                return new byte[0];
            var match = Regex.Match(hex, @"^\s*(0x)?(?<bytes>[a-f0-9]+)\s*$", RegexOptions.IgnoreCase);
            if(!match.Success)
                throw new FormatException($"{nameof(hex)} was not in a valid format. Must be a valid hex string");
            var byteString = match.Groups["bytes"].Value;
            if(byteString.Length % 2 == 1)
                throw new FormatException($"{nameof(hex)} must have an even number of hexademical characters");

            var numberChars = hex.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
            return bytes;
        }

        public byte[] Build()
        {
            return _bytes.ToArray();
        }
    }
}