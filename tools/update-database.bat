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
echo Что-то пошло не так, нужно пересоздать базу данных, введите пароль...
dropdb -h localhost -U postgres -W Kis
set ok=true
call:doMigrate
 ) ELSE (
echo good!!!!!!!) 


echo.&pause&goto:eof
------------------------------------------------

:doMigrate
cd %Kis.Entity%
echo Применяются миграции %Kis.Entity%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
) ELSE (
set ok=false
goto:breake)  

cd %General%
echo Применяются миграции %General%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %TaskTrecker%
echo Применяются миграции %TaskTrecker%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %Voting%
echo Применяются миграции %Voting%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %Organization%
echo Применяются миграции %Organization%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

cd %Investors%
echo Применяются миграции %Investors%
dotnet ef database update -s %WebHost%
IF %errorlevel% == 0  (
echo. command return: %errorlevel%
 ) ELSE (
set ok=false
goto:breake) 

goto:eof