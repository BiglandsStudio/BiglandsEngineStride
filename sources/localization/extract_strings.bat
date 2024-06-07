@set SOURCES_DIR=%~dp0..
@set MSGMERGE=%~dp0..\..\deps\gettext\msgmerge
@set OUTPUT_DIR=%SOURCES_DIR%\localization
@set TOOL_DIR=%SOURCES_DIR%\tools\BiglandsEngine.Core.Translation.Extractor\bin\Debug\net472

@cd %OUTPUT_DIR%

rem BiglandsEngine.Core.Presentation.pot
%TOOL_DIR%\BiglandsEngine.Core.Translation.Extractor.exe --directory=%SOURCES_DIR%\presentation\BiglandsEngine.Core.Presentation --domain-name=BiglandsEngine.Core.Presentation --recursive --preserve-comments --exclude=*.Designer.cs --verbose *.xaml *.cs

rem BiglandsEngine.Assets.Presentation.pot
%TOOL_DIR%\BiglandsEngine.Core.Translation.Extractor.exe --directory=%SOURCES_DIR%\editor\BiglandsEngine.Assets.Presentation --domain-name=BiglandsEngine.Assets.Presentation --recursive --preserve-comments --exclude=*.Designer.cs --verbose *.xaml *.cs

rem BiglandsEngine.Core.Assets.Editor.pot
%TOOL_DIR%\BiglandsEngine.Core.Translation.Extractor.exe --directory=%SOURCES_DIR%\editor\BiglandsEngine.Core.Assets.Editor --domain-name=BiglandsEngine.Core.Assets.Editor --recursive --preserve-comments --exclude=*.Designer.cs --verbose *.xaml *.cs

rem BiglandsEngine.GameStudio.pot
%TOOL_DIR%\BiglandsEngine.Core.Translation.Extractor.exe --directory=%SOURCES_DIR%\editor\BiglandsEngine.GameStudio --domain-name=BiglandsEngine.GameStudio --recursive --preserve-comments --exclude=*.Designer.cs --verbose *.xaml *.cs

rem Update po files
FOR %%B IN (BiglandsEngine.Core.Presentation BiglandsEngine.Assets.Presentation BiglandsEngine.Core.Assets.Editor BiglandsEngine.GameStudio) DO (
  FOR %%A IN (ja fr es de ru zh_HANS-CN it ko) DO (
    %MSGMERGE% -U %%A\%%B.%%A.po %%B.pot
  )
)
