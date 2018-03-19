using McFly.Core;

namespace McFly
{
    public interface IFrameFacade
    {
        Frame GetCurrentFrame();
        Frame GetCurrentFrame(int threadId);
    }
}