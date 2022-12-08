path %SystemRoot%\System32
taskkill /f /im CypWeld.exe
if exist .\ECatFirmUpdate.exe start /WAIT .\ECatFirmUpdate.exe
start .\CypWeld.exe