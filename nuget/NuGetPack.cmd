:: -----------------------------------------------------------------------
:: <copyright file="NuGetPack.cmd" company="YamNet">
::   Copyright (c) 2014 YamNet contributors
:: </copyright>
:: -----------------------------------------------------------------------
@ECHO OFF
:: Accept command-line arguments:
::  * [-n] : Package Name
::  * [-v] : Version Number
::  * [-p] : Pause console after execution
:: Example: NuGetPack -n YamNet.Client -v 1.0.0.0 -p

:VarInit -----------------------------------------------------------------
:: Set the variables
SET PackageName=
SET VersionNo=
SET CurrentDir=%~dp0
SET WorkingDir=
SET NuGetDir=.nuget
SET OutputDir=nuget

:: Could currently be in .nuget directory
IF EXIST "%CD%\NuGet.exe" (
    CD ..
    GOTO :ArgsLoop
)

:: Could currently be in nuget or src directory
IF EXIST "%CD%\..\.nuget\NuGet.exe" (
    CD ..
    GOTO :ArgsLoop
)

:: Could currently be in project directory
IF EXIST "%CD%\..\..\.nuget\NuGet.exe" (
    CD ..\..
    GOTO :ArgsLoop
)

:: Cannot find NuGet.exe
ECHO Error, unable to find NuGet.exe
GOTO :IsPause



:ArgsLoop ----------------------------------------------------------------
IF NOT "%1"=="" (
    IF "%1"=="-n" (
        SET PackageName=%2
        SHIFT
    )
    IF "%1"=="-v" (
        SET VersionNo=%2
        SHIFT
    )
    IF "%1"=="-p" (
        SET Pause="TRUE"
    )
    SHIFT
    GOTO :ArgsLoop
)
GOTO :Title



:Title -------------------------------------------------------------------
ECHO ----------------------------------------
ECHO  NuGet Pack
ECHO ----------------------------------------
IF NOT [%PackageName%]==[] (
    ECHO Package Name    : %PackageName%
)
ECHO Version Number  : %VersionNo%
ECHO NuGet Directory : %NuGetDir%
ECHO Output Directory: %OutputDir%
ECHO.
GOTO :PackMain



:PackMain ----------------------------------------------------------------
SET "Packages=YamNet.Client"

:: Throw alert if Version Number is not defined.
:: Otherwise pack a project if defined, or all project if not.
IF NOT [%VersionNo%]==[] (
    IF NOT [%PackageName%]==[] (
        :: Pack specific DLL
        CALL :PackLoop %PackageName% %VersionNo%
    ) ELSE (
        :: Pack all the DLLs
        FOR %%G IN (%Packages%) DO (
            CALL :PackLoop %%G %VersionNo%
        )
    )
    ECHO DLLs have been packaged.
) ELSE (
    ECHO Package Version "-v" value is required.
)
GOTO :IsPause



:PackLoop ----------------------------------------------------------------
:: Pack the DLL(s)
SET _PackageName=%1
SET _VersionNo=%2

:: Create output directory if it doesn't exist, otherwise NuGet will throw an error
IF NOT EXIST "%OutputDir%\%_PackageName%" MKDIR "%OutputDir%\%_PackageName%"

:: Package it!
CALL "%NuGetDir%\NuGet.exe" pack "%OutputDir%\%_PackageName%.nuspec" -OutputDirectory "%OutputDir%\%_PackageName%" -Version %_VersionNo%
ECHO.
GOTO :EOF



:IsPause -----------------------------------------------------------------
:: Pause console if requested.
IF [%Pause%] == "TRUE" (
    PAUSE
)
GOTO :BatchEnd



:BatchEnd ----------------------------------------------------------------
:: Make sure we return to the original directory
CD %CurrentDir%