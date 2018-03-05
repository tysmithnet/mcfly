using System.Threading.Tasks;

namespace McFly
{
    public interface IMcFlyMethod : IInjectable
    {
        string Name { get; }
        Task Process(string[] args);
    }
}