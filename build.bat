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

%nuget% install ReSharper.RazorExtensions\packages.ReSharper.RazorExtensions.v80.config -OutputDirectory %cd%\packages -NonInteractive -Prerelease
%nuget% install ReSharper.RazorExtensions\packages.ReSharper.RazorExtensions.v81.config -OutputDirectory %cd%\packages -NonInteractive -Prerelease
%nuget% install ReSharper.RazorExtensions\packages.ReSharper.RazorExtensions.v82.config -OutputDirectory %cd%\packages -NonInteractive -Prerelease

%WINDIR%\Microsoft.NET\Framework\v4.0.30319\msbuild ReSharper.RazorExtensions.sln /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=diag /nr:false

mkdir Build
mkdir Build\v7.1
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.dll Build\v7.1
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.pdb Build\v7.1
mkdir Build\v8.0
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.8.0.dll Build\v8.0
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.8.0.pdb Build\v8.0
mkdir Build\v8.1
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.8.1.dll Build\v8.1
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.8.1.pdb Build\v8.1
mkdir Build\v8.2
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.8.2.dll Build\v8.2
copy ReSharper.RazorExtensions\bin\%config%\ReSharper.RazorExtensions.8.2.pdb Build\v8.2

%nuget% pack ".nuget\ReSharper.RazorExtensions.nuspec" -NoPackageAnalysis -verbosity detailed -o Build -Version %version% -p Configuration="%config%"