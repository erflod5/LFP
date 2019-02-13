Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO

Public Class Analizador
    Private Siguiente, c As Integer
    Private EstadoError As Boolean
    Private Simbolo As String
    Public Sub Analizar(Consola As RichTextBox)
        EstadoError = False
        Simbolo = ""
        Dim Estado As Integer = 0
        Dim Texto() As String = Consola.Text.Split(ChrW(10))
        Dim x, y As Integer
        For x = 0 To Texto.Length - 1
            For y = 0 To Texto.Length - 1
                Dim a, b As Integer
                a = Asc(Texto(x).Chars(y))
                Try
                    b = Asc(Texto(x).Chars(y + 1))
                Catch ex As Exception
                    b = -4
                End Try


            Next
        Next
    End Sub
End Class
