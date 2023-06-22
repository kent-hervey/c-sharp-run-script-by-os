#!/bin/bash

echo "here is a directory name:"

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
#datetime=$(date +"%Y-%m-%d %H:%M:%S")


random_number=$(((RANDOM % 900000)+100000))

datetime=$(date -u +"%Y%m%d%H%M%S.$random_number-%z")
echo "$datetime" >> "$f"
echo >> "$f"

echo "build_configuration:" >> "$f"

configurationVar=$(grep -E "ConfigurationName" ../../.vs/config/project.config | cut -d '>' -f 2 | cut -d '<' -f 1)
if [[ -n "$configurationVar" ]]; then
  echo "$configurationVar" >> "$f"
else
  echo "Debug" >> "$f"
fi




exit 0