@echo on
set CompileType=%1
set SourceDir=%2
set SourcePluginFileName=%3
set ProjectName=%4
set BatPath=%~dp0

set ProjectTargetDir=%BatPath%..\..\Project\Assets\Plugins\%ProjectName%\
set StreamingAssetsTargetDir=%BatPath%..\..\Project\Assets\StreamingAssets\%ProjectName%
set ResourcesTargetDir=%BatPath%..\..\Project\Assets\Resources\%ProjectName%
set SourcePluginFilePath=%SourceDir%%SourcePluginFileName%

set ProjectTargetPluginFilePath=%ProjectTargetDir%%SourcePluginFileName%
set SourcePdbFilePath=%SourceDir%%SourcePluginFileName%.pdb
set TargetPdbFilePath=%ProjectTargetDir%%SourcePluginFileName%.pdb

set IgnoreAssetsFileList=%~dp0.\IgnoreAssetsFileList.txt

rem set MonoPath="D:\Program Files\Unity 2021.3.4f1\Editor\Data\MonoBleedingEdge\bin\mono.exe"

if "%CompileType%"=="Debug" (echo f | xcopy /y "%SourcePdbFilePath%" "%TargetPdbFilePath%" ) else (del /q "%TargetPdbFilePath%")

echo f | xcopy /y "%SourcePluginFilePath%.dll" "%ProjectTargetPluginFilePath%.dll" 

rem %MonoPath% "%BatPath%pdb2mdb.exe" "%ProjectTargetPluginFilePath%.dll" 

rem findstr  %ProjectName% %IgnoreAssetsFileList% || call:CopyAssets

rem del /f /s /q "%TargetPdbFilePath%"

rem goto :End

rem :CopyAssets
rem if exist "%SourceDir%..\..\StreamingAssets" (
rem             if not exist "%StreamingAssetsTargetDir%" md "%StreamingAssetsTargetDir%"
rem             echo f | xcopy  /s /e /y /c /h /r /d "%SourceDir%..\..\StreamingAssets" "%StreamingAssetsTargetDir%\"
rem 		)

rem if exist "%SourceDir%..\..\Resources" (
rem             if not exist "%ResourcesTargetDir%" md "%ResourcesTargetDir%"
rem             echo f | xcopy  /s /e /y /c /h /r /d "%SourceDir%..\..\Resources" "%ResourcesTargetDir%\"
rem 		)

rem :End
