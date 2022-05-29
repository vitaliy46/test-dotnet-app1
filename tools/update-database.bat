@echo off
chcp 1251>nul
rem set start_red=0C
rem%start_red% "ERROR"

cd ..
set PathRoot=%cd%
echo PathRoot=%PathRoot%
set ok=true

set Kis.Entity="%PathRoot%\aspnet-core\src\Kis.EntityFrameworkCore"
set General="%PathRoot%\aspnet-core\src\modules\General\Kis.General"
set TaskTrecker="%PathRoot%\aspnet-core\src\modules\TaskTrecker\Kis.TaskTrecker"
set Voting="%PathRoot%\aspnet-core\src\modules\Voting\Kis.Voting"
set Organization="%PathRoot%\aspnet-core\src\modules\Organization\Kis.Organization"
set Investors="%PathRoot%\aspnet-core\src\modules\Investors\Kis.Investors"
set WebHost="%PathRoot%\aspnet-core\src\modules\Investors\Kis.Investors.WebHost\Kis.Investors.WebHost.csproj"

call:doMigrate

:breake

IF %ok%==false  (
echo ���-�� ����� �� ���, ����� ����������� ���� ������, ������� ������...
dropdb -h localhost -U postgres -W Kis
set ok=true
call:doMigrate
 ) ELSE (
echo good!!!!!!!) 


echo.&pause&goto:eof
------------------------------------------------

:doMigrate
cd %Kis.Entity%
echo ����������� �������� %Kis.Entity%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
) ELSE (
set ok=false
goto:breake)  

cd %General%
echo ����������� �������� %General%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %TaskTrecker%
echo ����������� �������� %TaskTrecker%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %Voting%
echo ����������� �������� %Voting%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %Organization%
echo ����������� �������� %Organization%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %Investors%
echo ����������� �������� %Investors%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

goto:eof