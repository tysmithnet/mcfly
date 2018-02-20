import sqlite3

import argparse
import sys
try:
    import pykd
except Exception:
    print("Unable to import pykd, run pip install pykd in your configured interpreter")

commands = {}
init_parser = argparse.ArgumentParser("init")

commands["init"] = init_parser


def print_help():
    for command in commands:
        print("{0} --help".format(command))


if __name__ == "__main__":
    argv = sys.argv

    # if help requested
    if [x for x in argv if x in ["-h", "--help"]]:

        # see if command was provided
        if argv[1] in commands:
            commands[argv[1]].print_help()
        else:
            print_help()
