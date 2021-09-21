@echo off
setlocal
SET UNITY_BLENDER_EXPORTER_OUTPUT_FILE=%~1.fbx
:: echo %UNITY_BLENDER_EXPORTER_OUTPUT_FILE%
:: copy NUL %UNITY_BLENDER_EXPORTER_OUTPUT_FILE%
echo Exporting .blend file using Unity's exporter %~1 (drag and drop it to this .bat)
"C:\Program Files\Blender Foundation\Blender\blender.exe" "-b" "%~1" "-P" "F:\E\Unity versions\2020.3.15f2\Editor\Data\Tools\Unity-BlenderToFBX.py"
endlocal
echo Export done
pause
