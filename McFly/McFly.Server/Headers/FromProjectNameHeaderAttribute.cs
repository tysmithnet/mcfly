namespace McFly.Server.Headers
{
    public class FromProjectNameHeaderAttribute : FromHeaderAttribute
    {
        public FromProjectNameHeaderAttribute(string headerName = null) : base("X-Project-Name")
        {
        }
    }
}
