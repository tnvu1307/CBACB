Imports System.IO
Imports System.Security.Cryptography
Imports System.Security.Cryptography.Aes
Imports System.Text

Public Class AESCrypto
    Public Shared Function AESDecrypt(ByVal stringValue As String, ByVal key As String, ByVal iv As String) As String
        Using aesAlg As Aes = Aes.Create()
            aesAlg.Key = Encoding.UTF8.GetBytes(key)

            aesAlg.IV = Encoding.UTF8.GetBytes(iv)
            aesAlg.Mode = CipherMode.CBC

            Dim decryptor As ICryptoTransform = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV)

            Using msDecrypt As New MemoryStream(Convert.FromBase64String(stringValue))
                Using csDecrypt As New CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)
                    Using srDecrypt As New StreamReader(csDecrypt)
                        Return srDecrypt.ReadToEnd()
                    End Using
                End Using
            End Using
        End Using
    End Function
End Class
