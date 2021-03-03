# MARKDOWN NOTES
![MarkDown logo](https://img.icons8.com/nolan/2x/markdown.png)

# REPOSITORY FOR MOBILE APPS WITH XAMARIN
#### created by: Alexander Araya Vega
***

# GIT COMMANDS

1. **git checkout develop** (navigate between branches)
2. **git pull origin develop** (update the local repository)
3. **git fetch** (to download contents from a remote repository)
4. **git status** (provide a status of the files)
5. **git checkout -b "##+name"** (create a new branch)
6. **Do modifications**
7. **git add .** (Adds a change in the working directory to the staging area)
    *this command do not affect the remote repository*
8. **git commit -m "Update Message"** (Save all staged changes, along with a brief descrp)
    *a commit could be like a snapshot of your project*
9. **git push** (Upload the new version to the remote repository)
10. **Then create pull Request** (in GitHub)

***

# GIT Conflict Troubleshooting
1. git checkout "branch"
2. git pull
3. git rebase develop
4. code . (resolve conflicts)
5. git add .
6. git rebase --continue
7. git commit --amend or git commit -m ""
8. git push or git push -f
9. git merge develop