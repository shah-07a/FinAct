Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Public Class EnCryp_DeCryp_String
    Private key() As Byte = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24}
    Private iv() As Byte = {254, 110, 68, 26, 69, 178, 200, 219}
    Public Function Encrypt(ByVal plainText As String) As Byte()
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
        Dim inputInBytes() As Byte = utf8encoder.GetBytes(plainText)
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateEncryptor(Me.key, Me.iv)
        Dim encryptedStream As MemoryStream = New MemoryStream()
        Dim cryptStream As CryptoStream = New CryptoStream(encryptedStream, cryptoTransform, CryptoStreamMode.Write)
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        encryptedStream.Position = 0
        Dim result(encryptedStream.Length - 1) As Byte
        encryptedStream.Read(result, 0, encryptedStream.Length)
        cryptStream.Close()
        Return result
    End Function

    Public Function Decrypt(ByVal inputInBytes() As Byte) As String
        Dim utf8encoder As UTF8Encoding = New UTF8Encoding()
        Dim tdesProvider As TripleDESCryptoServiceProvider = New TripleDESCryptoServiceProvider()
        Dim cryptoTransform As ICryptoTransform = tdesProvider.CreateDecryptor(Me.key, Me.iv)
        Dim decryptedStream As MemoryStream = New MemoryStream()
        Dim cryptStream As CryptoStream = New CryptoStream(decryptedStream, cryptoTransform, CryptoStreamMode.Write)
        cryptStream.Write(inputInBytes, 0, inputInBytes.Length)
        cryptStream.FlushFinalBlock()
        decryptedStream.Position = 0
        Dim result(decryptedStream.Length - 1) As Byte
        decryptedStream.Read(result, 0, decryptedStream.Length)
        cryptStream.Close()
        Dim myutf As UTF8Encoding = New UTF8Encoding()
        Return myutf.GetString(result)
    End Function

End Class
