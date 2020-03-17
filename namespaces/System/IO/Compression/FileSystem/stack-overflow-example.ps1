#
#   https://stackoverflow.com/questions/14204230/how-to-list-the-files-in-a-zip-in-powershell
#


[Reflection.Assembly]::LoadWithPartialName('System.IO.Compression.FileSystem')
[IO.Compression.ZipFile]::OpenRead($sourceFile).Entries


*****

[Reflection.Assembly]::LoadWithPartialName('System.IO.Compression.FileSystem')

foreach($sourceFile in (Get-ChildItem -filter '*.zip'))
{
    [IO.Compression.ZipFile]::OpenRead($sourceFile.FullName).Entries.FullName |
        %{ "$sourcefile`:$_" }
}

******

$zip = [IO.Compression.ZipFile]::OpenRead($sourceFile); $entries = $zip.Entries; $zip.Dispose()
