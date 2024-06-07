setlocal
set BiglandsEngine_PATH=%~dp0..\..\..
set NUGET=%BiglandsEngine_PATH%\build\.nuget\Nuget.exe
set LAUNCHER_PATH=%~dp0bin\Debug\publish
pushd %LAUNCHER_PATH%
%NUGET% pack %~dp0BiglandsEngine.Launcher.nuspec -BasePath %LAUNCHER_PATH%
popd