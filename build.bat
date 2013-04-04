@echo Off
set config=%1
if "%config%" == "" (
   set config=Release
)
 
set version=1.0.0
if not "%PackageVersion%" == "" (
   set version=%PackageVersion%
)

set nuget=
if "%nuget%" == "" (
	set nuget=nuget
)

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ReSharper.RazorExtensions.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
 
mkdir Build
mkdir Build\v8.0

%nuget% pack "ReSharper.RazorExtensions\ReSharper.RazorExtensions.nuspec" -symbols -verbosity detailed -o Build\v8.0 -Version %version% -p Configuration="%config%"
copy ReSharper.RazorExtensions\bin\%config%\*.dll Build\v8.0
copy ReSharper.RazorExtensions\bin\%config%\*.pdb Build\v8.0