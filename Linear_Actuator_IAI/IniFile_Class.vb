Imports System.Runtime.InteropServices

Namespace Cls_Ini

    Public Class IniFile

        Public path As String

        <DllImport("kernel32")>
        Private Shared Function WritePrivateProfileString(section As String, key As String, val As String, filePath As String) As Long
        End Function
        <DllImport("kernel32")>
        Private Shared Function GetPrivateProfileString(section As String, key As String, def As String, retVal As System.Text.StringBuilder, size As Integer, filePath As String) As Integer
        End Function

        <DllImport("kernel32")>
        Private Shared Function GetPrivateProfileString(Section As Integer, Key As String, Value As String, <MarshalAs(UnmanagedType.LPArray)> Result As Byte(), Size As Integer, FileName As String) As Integer
        End Function

        <DllImport("kernel32")>
        Private Shared Function GetPrivateProfileString(Section As String, Key As Integer, Value As String, <MarshalAs(UnmanagedType.LPArray)> Result As Byte(), Size As Integer, FileName As String) As Integer
        End Function

        Public Sub New(INIPath As String)

            path = INIPath

        End Sub

        Public Sub IniWriteValue(Section As String, Key As String, Value As String)

            WritePrivateProfileString(Section, Key, Value, path)

        End Sub

        Public Function IniGetValue(Section As String, Key As String) As String

            Dim temp As New System.Text.StringBuilder(255)
            Dim i As Integer = 0
            i = GetPrivateProfileString(Section, Key, "", temp, 255, path)
            Return temp.ToString()

        End Function


        Public Function IniGetSection() As String()

            Dim maxsize As Integer = 500
            While True
                Dim bytes As Byte() = New Byte(maxsize - 1) {}
                Dim size As Integer = GetPrivateProfileString(0, "", "", bytes, maxsize, path)
                If size < maxsize - 2 Then
                    Dim Selected As String = System.Text.Encoding.ASCII.GetString(bytes, 0, size - (If(size > 0, 1, 0)))
                    Return Selected.Split(New Char() {ControlChars.NullChar})
                    Exit Function
                End If
                maxsize *= 2
            End While

            Return {Nothing}
        End Function

        Public Function IniGetKey(Section As String) As String()

            Dim maxsize As Integer = 500
            While True

                Dim bytes As Byte() = New Byte(maxsize - 1) {}
                Dim size As Integer = GetPrivateProfileString(Section, 0, "", bytes, maxsize, path)
                If size < maxsize - 2 Then

                    Dim entries As String = System.Text.Encoding.ASCII.GetString(bytes, 0, size - (If(size > 0, 1, 0)))
                    Return entries.Split(New Char() {ControlChars.NullChar})
                    Exit Function

                End If

                maxsize *= 2

            End While

            Return {Nothing}
        End Function

    End Class


End Namespace