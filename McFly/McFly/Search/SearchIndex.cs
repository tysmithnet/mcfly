namespace McFly.Search
{
    public abstract class SearchIndex
    {
        public static readonly SearchIndex Frame = new _Frame();
        public abstract string ShortName { get; }

        private class _Frame : SearchIndex
        {
            /// <inheritdoc />
            public override string ShortName { get; } = "frame";
        }
    }
}