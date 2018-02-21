using System;
using System.Collections.Generic;
using System.Text;

namespace McFly.Server.Data
{
    public abstract class DataAccess
    {
        public static string ConnectionString { get; set; }
    }

    public static class DataExtensions
    {
        public static (int, int) ToTuple(this string key)
        {
            var split = key?.Split(':');
            if (split?.Length != 2 || !Int32.TryParse(split[0], out var major) || !Int32.TryParse(split[1], out var minor))
                throw new ArgumentException($"Invalid key: {key}");
            if (major < 0)
                throw new ArgumentException($"Invalid key, major is negative: {key}");
            if (minor < 0)
                throw new ArgumentException($"Invalid key, minor is negative: {key}");
            return (major, minor);
        }
    }
}
