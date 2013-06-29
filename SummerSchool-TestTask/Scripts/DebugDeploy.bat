%echo off

echo f | xcopy ..\TestTask.MathLibrary\bin\Debug\TestTask.MathLibrary.dll ..\DeployItems\TestTask.MathLibrary.dll /y /q

echo f | xcopy ..\TestTask.Executable\bin\Debug\TestTask.Executable.exe ..\DeployItems\TestTask.Executable.exe /y /q

echo f | xcopy ..\TestTask.MathLibrary\bin\Debug\TestTask.MathLibrary.dll ..\TestTask.Executable\bin\Debug\TestTask.MathLibrary.dll /y /q