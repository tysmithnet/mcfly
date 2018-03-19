using McFly.Core;

namespace McFly
{
    public interface IStackFacade
    {
        StackTrace GetCurrentStackTrace();

        StackTrace GetCurrentStackTrace(int threadId);
    }
}