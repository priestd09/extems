@echo off
bundler\MixERP.Net.Utility.SqlBundler.exe ..\..\..\ "db/academic/1.x/1.0" false false

copy extems.sql extems-blank.sql
copy extems-blank.sql ..\..\..\extems-blank.sql
del extems.sql

pause