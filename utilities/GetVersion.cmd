@echo off
REM It would be much simpler to write this script in PowerShell, but a batch script is much faster (PowerShell can have a noticeable start delay)
REM and it has greater chances to successfully run on a majority of developer machines and build servers.
REM First parameter must be $(ConfigurationName) - https://docs.microsoft.com/en-us/visualstudio/ide/reference/pre-build-event-post-build-event-command-line-dialog-box?view=vs-2022

REM Note: I would love to use var=value output syntax, without empty lines after =, but it is such a pain to avoid echoing empty lines in the batch
REM scripts that I decided to make this script simpler and parser a bit sophisticated (doing logic in C# is much more pleasurable).

REM Set the working directory to the current script containing folder. It is important because VS or build server can have their thoughts or the working folder.
pushd %~dp0

set f=Version.txt

REM Create an empty file. It is really important to get the file created because without the txt file VS build will fail. "> NUL" silences the chatty copy command.
copy NUL %f% > NUL


echo git_branch: >> %f%
REM 2>&1 ensures we redirect stderr to the file, so we can see the error in case there is a problem.
git branch --show-current >> %f% 2>&1
REM This is how empty lines can be output in batch script
echo.>> %f%


echo git_hash: >> %f%
git rev-parse HEAD >> %f% 2>&1
echo.>> %f%


echo build_date: >> %f%
for /f "tokens=2 delims==" %%G in ('wmic os get localdatetime /value') do set datetime=%%G
echo.%datetime% >> %f%
echo.>> %f%


echo build_configuration: >> %f%
echo.%1 >> %f%

popd

REM Explicitly exit with 0 exit code, so we don't mess up build on developers workstation in case our script has issues.
REM When we get more confidence in our script, we can allow it to fail when it fails, but not for now.
exit 0