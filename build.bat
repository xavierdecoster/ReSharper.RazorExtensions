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

%nuget% install ReSharper.RazorExtensions.v81\packages.config -OutputDirectory %cd%\packages -NonInteractive -Prerelease

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ReSharper.RazorExtensions.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\v7.1
copy ReSharper.RazorExtensions.v71\bin\%config%\*.dll Build\v7.1
copy ReSharper.RazorExtensions.v71\bin\%config%\*.pdb Build\v7.1
mkdir Build\v8.0
copy ReSharper.RazorExtensions.v80\bin\%config%\*.dll Build\v8.0
copy ReSharper.RazorExtensions.v80\bin\%config%\*.pdb Build\v8.0
mkdir Build\v8.1
copy ReSharper.RazorExtensions.v81\bin\%config%\*.dll Build\v8.1
copy ReSharper.RazorExtensions.v81\bin\%config%\*.pdb Build\v8.1

%nuget% pack ".nuget\ReSharper.RazorExtensions.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"
