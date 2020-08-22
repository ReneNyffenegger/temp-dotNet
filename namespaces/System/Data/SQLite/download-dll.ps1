[Net.ServicePointManager]::SecurityProtocol = [Net.SecurityProtocolType]::Tls12
invoke-webRequest https://system.data.sqlite.org/downloads/1.0.113.0/sqlite-netFx40-binary-bundle-Win32-2010-1.0.113.0.zip -outFile sqite-netFx40.dll
