namespace McFly.Server.Headers
{
    public class FromProjectNameHeaderAttribute : FromHeaderAttribute
    {
        public FromProjectNameHeaderAttribute(string headerName) : base("X-Project-Name")
        {
        }
    }
}
