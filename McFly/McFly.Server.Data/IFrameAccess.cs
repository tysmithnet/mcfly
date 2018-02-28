using McFly.Core;

namespace McFly.Server.Data
{
    public interface IFrameAccess
    {
        void UpsertFrame(Frame frame);
    }
}