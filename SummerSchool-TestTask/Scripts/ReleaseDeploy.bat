%echo off

xcopy ..\TestTask.MathLibrary\bin\Release\TestTask.MathLibrary.dll ..\DeployItems\TestTask.MathLibrary.dll /y /q

xcopy ..\TestTask.Executable\bin\Release\TestTask.Executable.exe ..\DeployItems\TestTask.Executable.exe /y /q