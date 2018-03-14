using System.Data;

namespace McFly.Server.Data
{
    internal class FrameDto
    {
        public DataTable Frames { get; set; }
        public DataTable StackFrames { get; set; }
    }
}