@echo off

echo Processing Runtime (currently using Linux as template)
..\sources\tools\BiglandsEngine.ProjectGenerator\bin\Debug\net472\BiglandsEngine.ProjectGenerator.exe solution BiglandsEngine.sln -o BiglandsEngine.Runtime.sln -p Linux
echo.

echo Processing Android
..\sources\tools\BiglandsEngine.ProjectGenerator\bin\Debug\net472\BiglandsEngine.ProjectGenerator.exe solution BiglandsEngine.sln -o BiglandsEngine.Android.sln -p Android
echo.

echo Processing iOS
..\sources\tools\BiglandsEngine.ProjectGenerator\bin\Debug\net472\BiglandsEngine.ProjectGenerator.exe solution BiglandsEngine.sln -o BiglandsEngine.iOS.sln -p iOS
echo.
