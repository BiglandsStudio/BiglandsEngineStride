CALL "%VS140COMNTOOLS%VsDevCmd.bat"
msbuild BiglandsEngine.build /p:BiglandsEngineGenerateDoc=true /t:BuildWindows > NUL

