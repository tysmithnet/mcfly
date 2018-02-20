import sqlite3
import argparse
import sys
import os
try:
    import pykd
except Exception:
    print("Unable to import pykd, run pip install pykd in your configured interpreter")

sqlite_script = """
/*
Represents an instant in time according to the Time Travel Debugging session
Frames are represented by the concat of the major frame and the minor frame. For example,
the trace might start at 35:0 which corresponds to key_major == 35 and key_minor == 0
 */
CREATE TABLE `frame` (
  /* The most significant part of the frame key, e.g. 401:58 => 401 */
  `key_major` INTEGER NOT NULL,

  /* The least significant part of the frame key, e.g. 401:58 => 58 */
  `key_minor` INTEGER NOT NULL,

  /* Optional name for the frame if one is appropriate */
  `name` TEXT, PRIMARY KEY(`key_major`,`key_minor`)
);

/*
A process can have many threads in it, and so at any one instant in time there are potentially many
threads running. This table captures the state of a particular thread at a particular instant in time.
Note that the values here are the values BEFORE the instruction is executed.
 */
CREATE TABLE `frame_thread` (
  /* Major part of the frame id */
	`key_major`	INTEGER NOT NULL,

  /* Minor part of the frame id */
	`key_minor`	INTEGER NOT NULL,

  /* Thread id */
	`thread_id`	INTEGER NOT NULL,

  /* Optional trace thread index */
  `thread_index` INTEGER,

  /* Value of rax */
	`rax`	INTEGER,

  /* Value of rbx */
	`rbx`	INTEGER,

  /* Value of rcx */
	`rcx`	INTEGER,

  /* Value of rdx */
	`rdx`	INTEGER,

  /* Value of rsi */
	`rsi`	INTEGER,

  /* Value of rdi */
	`rdi`	INTEGER,

  /* Value of rsp */
	`rsp`	INTEGER,

  /* Value of rbp */
	`rbp`	INTEGER,

  /* Value of rip */
	`rip`	INTEGER,

  /* Value of efl */
	`efl`	INTEGER,

  /* Value of cs */
	`cs`	INTEGER,

  /* Value of ds */
	`ds`	INTEGER,

  /* Value of es */
	`es`	INTEGER,

  /* Value of fs */
	`fs`	INTEGER,

  /* Value of gs */
	`gs`	INTEGER,

  /* Value of ss */
	`ss`	INTEGER,

  /* Value of r8 */
	`r8`	INTEGER,

  /* Value of r9 */
	`r9`	INTEGER,

  /* Value of r10 */
	`r10`	INTEGER,

  /* Value of r11 */
	`r11`	INTEGER,

  /* Value of r12 */
	`r12`	INTEGER,

  /* Value of r13 */
	`r13`	INTEGER,

  /* Value of r14 */
	`r14`	INTEGER,

  /* Value of r15 */
	`r15`	INTEGER,

  /* Value of dr0 */
	`dr0`	INTEGER,

  /* Value of dr1 */
	`dr1`	INTEGER,

  /* Value of dr2 */
	`dr2`	INTEGER,

  /* Value of dr3 */
	`dr3`	INTEGER,

  /* Value of dr6 */
	`dr6`	INTEGER,

  /* Value of dr7 */
	`dr7`	INTEGER,

  /* Value of exfrom */
	`exfrom`	INTEGER,

  /* Value of exto */
	`exto`	INTEGER,

  /* Value of brfrom */
	`brfrom`	INTEGER,

  /* Value of brto */
	`brto`	INTEGER,

  /* ret, call, mov, sub, etc */
	`opcode_nmemonic`	TEXT,

  /* Address of the current instruction */
	`code_address`	INTEGER,

  /* Module name for the current instruction */
	`module`	TEXT,

  /* Function name for the current instruction */
	`function`	TEXT,

  /* Function offset for the current instruction */
	`function_offset`	INTEGER,

	PRIMARY KEY (`key_major`,`key_minor`,`thread_id`),
  FOREIGN KEY (`key_major`, `key_minor`) REFERENCES `frame` (`key_major`, `key_minor`)
);
"""

class Command:

    def __init__(self):
        self.name = ""
        self.parser = None

    def print_help(self):
        self.parser.print_help()

    def run(self, args):
        pass


class InitCommand(Command):

    def __init__(self):
        self.name = "init"
        self.parser = argparse.ArgumentParser("init")
        self.parser.add_argument("db_filename", nargs=1, help="Database file", default="trace.db")
        self.parser.add_argument("--force", action="count", help="Overwrite existing", default=False)

    def run(self, args):
        options = self.parser.parse_args(args)
        db_filename = options.db_filename[0]
        # does db file already exist?
        if os.path.isfile(db_filename):
            if options.force:
                os.remove(db_filename)
            else:
                print("{0} already exists, use --force to overwrite".format(db_filename))
                exit()

        # create new SQLite database
        connection = sqlite3.connect(db_filename)
        cursor = connection.cursor()
        cursor.executescript(sqlite_script)


class IndexCommand(Command):

    def __init__(self):
        self.name = "index"
        self.parser = argparse.ArgumentParser("index")

    def run(self, args):
        options = self.parser.parse_args(args)



commands = {x.name: x for x in [InitCommand(), IndexCommand()]}


def print_help():

    for c in commands:
        print("{0} --help".format(c))


if __name__ == "__main__":
    argv = sys.argv[::]

    if len(argv) < 2:
        print_help()
        exit()

    if argv[1] in commands:
        command = commands[argv[1]]
        argv.pop(0)
        argv.pop(0)
        command.run(argv)
