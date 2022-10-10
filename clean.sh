#!/usr/bin/env bash

## REMOVE GIT CACHED
for git_cache in $(git ls-files -i --exclude-standard); do
  echo "$git_cache" && git rm -f --cached "$git_cache"
done
