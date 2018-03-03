using McFly.Core;

namespace McFly.Server.Data
{
    public interface IFrameAccess
    {
        void UpsertFrame(string projectName, Frame frame);
    }
}