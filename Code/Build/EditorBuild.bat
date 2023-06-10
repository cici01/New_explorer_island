@echo off
set CompileType=%1
set SourceDir=%2
set SourcePluginFileName=%3
set SolutionName=%4
set BatPath=%~dp0
set ProjectTargetDir=%BatPath%..\..\Project\Assets\Plugins\%SolutionName%\Editor\
set SourcePluginFilePath=%SourceDir%%SourcePluginFileName%
set ProjectTargetPluginFilePath=%ProjectTargetDir%%SourcePluginFileName%
set SourcePdbFilePath=%SourcePluginFilePath%.pdb
set TargetPdbFilePath=%ProjectTargetDir%%SourcePluginFileName%.pdb

if "%CompileType%"=="Debug" (echo f | xcopy /y "%SourcePdbFilePath%" "%TargetPdbFilePath%" ) else (del /q "%TargetPdbFilePath%")
echo f | xcopy /y "%SourcePluginFilePath%.dll" "%ProjectTargetPluginFilePath%.dll" 
