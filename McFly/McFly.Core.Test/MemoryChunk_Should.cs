using System;
using FluentAssertions;
using Xunit;

namespace McFly.Core.Test
{
    public class MemoryChunk_Should
    {
        private static readonly Guid Guid0 = Guid.NewGuid();

        private static readonly MemoryChunk Chunk0 = new MemoryChunk
        {
            Bytes = new byte[] {0x10, 0x20},
            MemoryRange = new MemoryRange(0, 1),
            Id = Guid0,
            Position = new Position(0, 0)
        };

        private static readonly MemoryChunk Chunk1 = new MemoryChunk
        {
            Bytes = new byte[] {0x10, 0x20},
            MemoryRange = new MemoryRange(0, 1),
            Id = Guid0,
            Position = new Position(0, 0)
        };

        private static readonly MemoryChunk Chunk2 = new MemoryChunk
        {
            Bytes = new byte[] {0x10, 0x20},
            MemoryRange = new MemoryRange(0, 2),
            Id = Guid0,
            Position = new Position(0, 0)
        };

        private static readonly MemoryChunk Chunk3 = new MemoryChunk
        {
            Bytes = new byte[] {0x10, 0x20, 0x30},
            MemoryRange = new MemoryRange(0, 1),
            Id = Guid0,
            Position = new Position(0, 0)
        };

        private static readonly MemoryChunk Chunk4 = new MemoryChunk
        {
            Bytes = new byte[] {0x10, 0x20},
            MemoryRange = new MemoryRange(0, 1),
            Id = Guid0,
            Position = new Position(0, 1)
        };

        private static readonly MemoryChunk Chunk5 = new MemoryChunk
        {
            Bytes = new byte[] {0x10, 0x20},
            MemoryRange = new MemoryRange(0, 1),
            Id = Guid.NewGuid(),
            Position = new Position(0, 0)
        };

        [Fact]
        public void Exhibit_Entity_Equality()
        {
            Chunk0.Equals(null).Should().BeFalse();
            Chunk0.Equals((object) null).Should().BeFalse();
            Chunk0.Equals(Chunk0).Should().BeTrue();
            Chunk0.Equals((object) Chunk0).Should().BeTrue();
            Chunk0.Equals(Chunk1).Should().BeTrue();
        }

        [Fact]
        public void Offer_Value_Equality()
        {
            Chunk0.ValueEquals(null).Should().BeFalse();
            Chunk0.ValueEquals(Chunk0).Should().BeTrue();
            Chunk0.ValueEquals(Chunk1).Should().BeTrue();
            Chunk0.ValueEquals(Chunk2).Should().BeFalse();
            Chunk0.ValueEquals(Chunk3).Should().BeFalse();
            Chunk0.ValueEquals(Chunk4).Should().BeFalse();
            Chunk0.ValueEquals(Chunk5).Should().BeTrue();
        }
    }
}