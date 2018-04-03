namespace McFly.Search
{
    internal class NullDisplayStrategy : ISearchResultDisplayStrategy
    {
        /// <inheritdoc />
        public bool CanDisplay(object obj)
        {
            return false;
        }

        /// <inheritdoc />
        public void Display(object obj)
        {
            
        }
    }
}