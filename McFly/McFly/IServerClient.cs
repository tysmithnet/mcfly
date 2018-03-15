using System.Collections.Generic;
using McFly.Core;

namespace McFly
{
    public interface IServerClient
    {
        void AddNote(Position position, int threadId, string text);
        void InitializeProject(string projectName, Position start, Position end);
        void UpsertFrames(IEnumerable<Frame> frames);
    }
}