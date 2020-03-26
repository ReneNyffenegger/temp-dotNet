#
#  https://social.technet.microsoft.com/Forums/en-US/bcb73aab-2175-4156-8f2d-2f4d2faaca01/ssl-handshake-parsing
# 

$targetHost = 'renenyffenegger.ch'

$client = New-Object System.Net.Sockets.TcpClient
$client.Connect($targetHost, 443)


$sslStream = New-Object System.Net.Security.SslStream($client.GetStream())

#
#  AuthenticateAsClient authenticates the server!
#
$sslStream.AuthenticateAsClient($targetHost)

$sslStream | Format-List CipherAlgorithm,CipherStrength,HashAlgorithm,HashStrength,KeyExchangeAlgorithm,KeyExchangeStrength

$enc = [system.Text.Encoding]::UTF8
$sslStream.Write($enc.GetBytes("GET / HTTP/1.0`n"))
$sslStream.Write($enc.GetBytes("Host: {0}`n`n" -f $targetHost))

$sslStream.ReadLine()
