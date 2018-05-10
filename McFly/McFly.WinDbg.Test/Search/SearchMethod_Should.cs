using McFly.WinDbg.Search;
using Xunit;

namespace McFly.WinDbg.Test.Search
{
    // !mf search create --index frame --title "test search" --description "testing the search"
    //      abcd1234-abcd-1234-abcdef012345
    // !mf search add-term abcd1234-abcd-1234-abcdef012345 rax -eq 1a
    //      Term Id: 1
    // !mf search add-term abcd1234-abcd-1234-abcdef012345 stack_len -gt 10
    //      Term Id: 2
    // !mf search add-term abcd1234-abcd-1234-abcdef012345 mem[100:200] -like "%00??abcd??1234%"
    //      Term Id: 3
    // !mf search define abcd1234-abcd-1234-abcdef012345 "(1 && 2) || (3 && !1)"
    //      Success
    // !mf search abcd1234-abcd-1234-abcdef012345
    //      1. ...
    //      2. ...
    public class SearchMethod_Should
    {
        [Fact]
        public void Should_Allow_Search_Creation_For_All_Index_Types()
        {
            var searchMethod = new SearchMethod();

            searchMethod.Process(new []{"!mf", "search", "create", "--index", "frame", "--title", "test search", "--description", "testing the search"});
            // verify server client was called correctly
        }
    }
}
