namespace McFly.Server.Data
{
    public interface INoteAccess
    {
        void AddNote(string content);
        void AddNote(string content, int keyMajor, int keyMinor, int threadIndex);
    }
}