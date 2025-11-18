$domain = 'renenyffenegger.ch'
$conn  = new-object System.Net.Sockets.TcpClient($domain, 443)

[System.Net.Sockets.NetworkStream] $connStream  = $conn.GetStream()


$sslStream = New-Object System.Net.Security.SslStream($connStream,$false)
$sslStream.AuthenticateAsClient($domain)

# $reader = new-object System.IO.StreamReader($connStream)
# $writer = new-object System.IO.StreamWriter($connStream)
$reader = new-object System.IO.StreamReader($sslStream)
$writer = new-object System.IO.StreamWriter($sslStream)

$writer.AutoFlush = $true

$writer.WriteLine('GET / HTTP/1.1')
$writer.WriteLine("Host: $domain")
$writer.WriteLine('')

while ($reader.Peek() -ne -1) {
   write-host ($reader.ReadLine())
}

return

# while ($conn.Connected) {

# write-host "Peek: $($reader.Peek())"
# return

# while ($connStream.DataAvailable
  while ($reader.DataAvailable
  #  -or $reader.Peek() -ne -1
  ) {
#     write-host "server> $($reader.ReadLine())"
      write-host "server> $($reader.ReadToEnd())"
  }


# }
