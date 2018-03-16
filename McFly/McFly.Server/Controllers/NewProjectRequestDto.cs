namespace McFly.Server.Controllers
{
    public class NewProjectRequestDto
    {
        public string ProjectName { get; set; }
        public string StartingPosition { get; set; }
        public string EndingPosition { get; set; }
    }
}