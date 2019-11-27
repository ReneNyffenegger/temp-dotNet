#
#  This is on very shaky ground.
#


add-type -assemblyName 'System.IO.Compression.FileSystem'

$zipFile = [System.IO.Path]::GetFullPath("$env:temp") + '\createdWithPowerShell.zip'

if (test-path $zipFile) {
   write-output "$zipFile exists, deleting it"
   remove-item   $zipFile
}


$srcDir = resolve-path .

echo "srcDir = $srcDir"

write-output "Trying to create $zipFile in directory $srcDir"
  [System.IO.Compression.ZipFile]::CreateFromDirectory($srcDir, $zipFile)
# [System.IO.Compression.ZipFile]::CreateFromDirectory('./'   , $zipFile)


if (test-path "$srcDir\new-directory") {
  remove-item "$srcDir\new-directory" -recurse
}

# mkdir "$srcDir\new-directory"
write-output "Trying to extract $zipFile to $srcDir\new-directory"
[System.IO.Compression.ZipFile]::ExtractToDirectory($zipFile, "$srcDir\new-directory")
