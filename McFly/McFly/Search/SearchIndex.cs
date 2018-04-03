namespace McFly.Search
{
    public abstract class SearchIndex
    {
        public abstract string ShortName { get; }

        public static readonly SearchIndex Frame = new _Frame();

        private class _Frame : SearchIndex
        {
            /// <inheritdoc />
            public override string ShortName { get; } = "frame";
        }
    }
}