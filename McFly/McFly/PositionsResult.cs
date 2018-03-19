using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace McFly
{
    public class PositionsResult : IEnumerable<PositionsRecord>
    {
        private IEnumerable<PositionsRecord> PositionsRecords { get; set; }

        public PositionsResult(IEnumerable<PositionsRecord> positionsRecords)
        {
            PositionsRecords = positionsRecords?.ToList() ?? throw new ArgumentNullException(nameof(positionsRecords));
        }

        public PositionsRecord CurrentThread => PositionsRecords.Single(x => x.IsThreadWithBreak);

        public IEnumerator<PositionsRecord> GetEnumerator()
        {
            return PositionsRecords.GetEnumerator();
        }

        [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}