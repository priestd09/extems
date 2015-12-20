@echo off

bundler\MixERP.Net.Utility.SqlBundler.exe ..\..\..\ "db/1.x/1.0" false true

copy extems.sql extems-sample.sql
copy extems-sample.sql ..\..\..\extems-sample.sql
del extems.sql
pause