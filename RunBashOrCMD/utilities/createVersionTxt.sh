#!/bin/bash

echo "here is a directory name:"

echo "you are in the shell script"

echo $dirname $0

current_dir=$(dirname "$0")
cd "$current_dir"

f=Version.txt
touch "$f"

echo "git_branch:" > "$f"
git branch --show-current >> "$f" 2>&1
echo >> "$f"

echo "git_hash:" >> "$f"
git rev-parse HEAD >> "$f" 2>&1
echo >> "$f"

echo "build_date:" >> "$f"
datetime=$(date +"%Y-%m-%d %H:%M:%S")
echo "$datetime" >> "$f"
echo >> "$f"

echo "build_configuration:" >> "$f"


echo "Debug" >> "$f"

echo "cool.........."



exit 0This is a new line
This is a new line
This is a new lineThis is a new lineThis is a new lineThis is a new line
This is a new lineThis is a new line
