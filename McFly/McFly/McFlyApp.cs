using System.ComponentModel.Composition;

namespace McFly
{
    [Export]
    internal class McFlyApp : IInjectable
    {
        [ImportMany]
        public IMcFlyMethod[] McFlyMethods { get; set; }
    }                                 
}