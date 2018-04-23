# McFly
WinDbg Time Debugging Analysis Extension

The new Windbg from Microsoft comes with a powerful extension to allow for forward stepping and backward stepping. This allows the user to effectively
go both foward and backward through time, hence the name McFly.

### Features
1. Index register and memory values before and after any instruction
1. Search for changes in memory over time
1. Find most commonly used modules/functions/instructions
1. Get statistical analysis on memory, syscalls, function calls, etc

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
