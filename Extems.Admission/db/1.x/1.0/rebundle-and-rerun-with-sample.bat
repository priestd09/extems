@echo off

cmd.exe /c chcp 1252

call rebundle-db-with-sample.bat


"C:\Progra~1\PostgreSQL\9.4\bin\psql.exe" -U postgres --single-transaction -t -v ON_ERROR_STOP=1 -d mixerp < "%~dp0"\mixerp-incremental-sample.sql

echo Task completed successfully.
pause