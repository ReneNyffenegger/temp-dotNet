$conn                                           = new-object System.Net.Sockets.TcpClient('renenyffenegger.ch', 443)
[System.Net.Sockets.NetworkStream] $connStream  = $conn.GetStream()

$reader = new-object System.IO.StreamReader($connStream)
$writer = new-object System.IO.StreamWriter($connStream)

$writer.AutoFlush = $true

while ($conn.Connected) {

# write-host "Peek: $($reader.Peek())"
# return

  while ($connStream.DataAvailable
  #  -or $reader.Peek() -ne -1
  ) {
#     write-host "server> $($reader.ReadLine())"
      write-host "server> $($reader.ReadToEnd())"
  }

  return

}
