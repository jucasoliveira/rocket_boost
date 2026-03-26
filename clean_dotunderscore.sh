#!/bin/bash
# Removes all ._ (macOS resource fork) files from the current directory tree
find . -name "._*" -type f -delete -print
