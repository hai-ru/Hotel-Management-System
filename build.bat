@echo off
cd "Hotel Management System"
"C:\Program Files\Microsoft Visual Studio\2022\Community\MSBuild\Current\Bin\MSBuild.exe" "Hotel Management System.csproj" /t:Rebuild /p:Configuration=Debug /v:minimal
