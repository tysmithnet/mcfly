# McFly
*A time travel extension for Windows*

The new Windbg from Microsoft comes with a powerful extension to allow for forward stepping and backward stepping. This allows the user to effectively
go both foward and backward through time, hence the name McFly. 

### Motivation
The introduction of time-travel debugging radically changed the capabilities of the Windows debugger. By using the existing powerful capabilities
of Windbg along with the new time travel features, we can create a timeline of interesting changes inside the process during execution. It can help
answer questions like:
1. What system calls were made?
1. What strings were in memory half way through the trace?
1. How does a hashing algorithm work?
1. What is throwing a null reference exception?

##### Target Audiences
1. Security researchers
1. Application developers
1. The curious

### Features
1. Index register and memory values before and after any instruction
1. Search for changes in memory over time
1. Find most commonly used modules/functions/instructions
1. Get statistical analysis on memory, syscalls, function calls, etc

### Examples
    # load the extension
    .load C:\users\you\Downloads\mcfly.dll

    # get help
    !mf help
    !mf help init
    !mf help start
    !mf help index

    # add settings
    !mf settings list
    !mf settings open
    !mf settings list
    !mf settings reload
    !mf settings list

    # start the server
    !mf start

    # index all kernel32 calls
    !mf index --bm kernel32!*

    # index all reads/writes to abc123 through abc12b
    !mf index --ba rw8:abc123

### Developer Notes
This application is written for cutting edge Microsoft systems, which should be obvious based on the requirement of having the latest Windbg release.

##### Setup
Make sure you match the build bitness to the trace file bitness. You cannot use a build of the extension on a mismatched bitness (32 v 64)

1. Clone the repository and build using MSBuild. If you don't want to use the command line, then get VS2017 and build from there.
1. Open the new Windbg from the Microsoft App store
1. Open a trace file
1. `.load c:\path\to\mcfly.dll` (see the note on matching bitness above)
1. `!mf help`

##### Tools
These are the tools I am using for development. If you use something different your mileage my vary.
1. Windows 10 x64
1. Visual Studio 2017
1. Resharper 2017.3
1. NDepend 2018.1.0
1. GhostDoc Pro 5.9
