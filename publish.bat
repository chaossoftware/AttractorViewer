@echo off

set VERSION=%1
set OUT_DIR=%2
set PROJ_PATH=%cd%\src\AttractorViewer\AttractorViewer.csproj

dotnet publish %PROJ_PATH% --configuration Release --framework net6.0-windows --output %OUT_DIR%\attractor-viewer\net6.0-windows -p:VersionPrefix=%VERSION%