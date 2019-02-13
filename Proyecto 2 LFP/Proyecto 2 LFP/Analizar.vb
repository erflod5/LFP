Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO
Imports System.Text.RegularExpressions

Public Class Analizar
    Private Token As String
    Dim ListaToken = New List(Of Token)
    Dim ListaErrores = New List(Of Errores)
    Dim Siguiente As Integer
    Dim c As Integer
    Private EstadoError As Boolean
    Public Const PR1 As String = "Clase" 'ya
    Public Const PR2 As String = "Nombre" 'ya
    Public Const PR3 As String = "Metodos" 'ya
    Public Const PR4 As String = "Atributos" 'ya
    Public Const PR5 As String = "Asociacion"
    Public Const PR6 As String = "Herencia"
    Public Const PR7 As String = "Agregacion"
    Public Const PR8 As String = "Composicion"
    Public Const PR9 As String = "AsociacionSimple"
    Public Const PR10 As String = "Color"
    Public Const PR11 As String = "Comentario"
    Public Const PR12 As String = "Texto"

    Public Sub New()
        EstadoError = False
    End Sub
    Public Property DameEstado
        Get
            Return EstadoError
        End Get
        Set(value)
            EstadoError = value
        End Set
    End Property
    Public Function Analizar(Consola As RichTextBox)
        LimpiarLista()
        EstadoError = False
        Token = ""
        Dim Estado As Integer = 0
        Dim Texto() As String = Consola.Text.Split(ChrW(10))
        Dim x, y As Integer
        For x = 0 To Texto.Length - 1
            For y = 0 To Len(Texto(x)) - 1
                Dim a, b As Integer
                a = Asc(Texto(x).Chars(y))
                If (Estado = 0) Then
                    Estado = Reconocedor(a)
                End If
                Try
                    b = Asc(Texto(x).Chars(y + 1))
                Catch ex As Exception
                    b = -4
                End Try
                Siguiente = b
                Select Case Estado
                    Case 1
                        If (a = 91) Then
                            ListaToken.add(New Token("[", "[", x + 1, y))
                            Estado = 4
                        ElseIf a = 93 Then
                            ListaToken.add(New Token("]", "]", x + 1, y))
                            Estado = 0
                        ElseIf a = 123 Then
                            ListaToken.Add(New Token("{", "{", x + 1, y))
                            Estado = 0
                        ElseIf a = 125 Then
                            ListaToken.Add(New Token("}", "}", x + 1, y))
                            Estado = 0
                        ElseIf a = 58 Then
                            ListaToken.Add(New Token(":", ":", x + 1, y))
                            Estado = 0
                        ElseIf a = 59 Then
                            ListaToken.Add(New Token(";", ";", x + 1, y))
                            Estado = 0
                        ElseIf a = 61 Then
                            ListaToken.Add(New Token("=", "=", x + 1, y))
                            Estado = 0
                        ElseIf a = 40 Then
                            ListaToken.Add(New Token("(", "(", x + 1, y))
                            Estado = 0
                        ElseIf a = 41 Then
                            ListaToken.add(New Token(")", ")", x + 1, y))
                            Estado = 0
                        ElseIf a = 43 Then
                            ListaToken.add(New Token("+", "+", x + 1, y))
                            Estado = 0
                        ElseIf a = 45 Then
                            ListaToken.add(New Token("-", "-", x + 1, y))
                            Estado = 0
                        ElseIf a = 35 Then
                            ListaToken.add(New Token("#", "#", x + 1, y))
                            Estado = 0
                        ElseIf a = 44 Then
                            ListaToken.add(New Token(",", ",", x + 1, y))
                            Estado = 0
                        End If
                    Case 2
                        Token = Token + Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            If Token.ToLower = PR1.ToLower Or Token.ToLower = PR2.ToLower Or Token.ToLower = PR3.ToLower Or Token.ToLower = PR4.ToLower Or Token.ToLower = PR5.ToLower Or Token.ToLower = PR6.ToLower Or Token.ToLower = PR7.ToLower Or Token.ToLower = PR8.ToLower Or Token.ToLower = PR9.ToLower Or Token.ToLower = PR10.ToLower Or Token.ToLower = PR11.ToLower Or Token.ToLower = PR12.ToLower Then
                                ListaToken.Add(New Token(Token, Token, x + 1, y + 1 - Token.Length))
                                Token = ""
                                Estado = 0
                            Else
                                ListaToken.Add(New Token("Identificador", Token, x + 1, y + 1 - Token.Length))
                                Token = ""
                                Estado = 0
                            End If
                        End If
                    Case 3
                        Token = Token + Texto(x).Chars(y)
                        If Siguiente >= 48 And Siguiente <= 57 Then
                            Estado = 3
                        Else
                            ListaToken.add(New Token("Numero", Token, x + 1, y + 1 - Token.Length))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4
                        If a <> 32 And a <> 13 And a <> 9 Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 4
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 13 Or Siguiente = -4 Then
                            Estado = 4
                        Else
                            If Token.ToLower = PR1.ToLower Or Token.ToLower = PR2.ToLower Or Token.ToLower = PR3.ToLower Or Token.ToLower = PR4.ToLower Or Token.ToLower = PR5.ToLower Or Token.ToLower = PR6.ToLower Or Token.ToLower = PR7.ToLower Or Token.ToLower = PR8.ToLower Or Token.ToLower = PR9.ToLower Or Token.ToLower = PR10.ToLower Or Token.ToLower = PR11.ToLower Or Token.ToLower = PR12.ToLower Then
                                ListaToken.Add(New Token(Token, Token, x + 1, y + 1 - Token.Length))
                                Token = ""
                                Estado = 0
                            Else
                                ListaToken.Add(New Token("Identificador", Token, x + 1, y + 1 - Token.Length))
                                Token = ""
                                Estado = 0
                            End If
                        End If
                    Case 5
                        Token += Texto(x).Chars(y)
                        ListaToken.add(New Token(Token, Token, x + 1, y))
                        Token = ""
                        Estado = 6
                    Case 6
                        If a <> 34 Then
                            Estado = 6
                            Token += Texto(x).Chars(y)
                        End If
                        If a = 34 Then
                            ListaToken.add(New Token("String", Token, x + 1, y))
                            ListaToken.add(New Token("""", """", x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case -1
                        Token = Texto(x).Chars(y)
                        ListaErrores.Add(New Errores(Token, x + 1, y, "Lexico"))
                        Estado = 0
                        Token = ""
                        EstadoError = True
                End Select
            Next
        Next
        Return ListaToken
    End Function
    Private Function Reconocedor(ByVal n As Integer) As Integer
        If n = 91 Or n = 93 Or n = 123 Or n = 125 Or n = 58 Or n = 59 Or n = 61 Or n = 40 Or n = 41 Or n = 43 Or n = 45 Or n = 35 Or n = 44 Then '[]{}:;=  []
            Return 1
        ElseIf n >= 65 And n <= 90 Or n >= 97 And n <= 122 Then
            Return 2
        ElseIf n = 32 Or n = 13 Or n = 9 Then
            Return 0
        ElseIf n >= 48 And n <= 57 Then
            Return 3
        ElseIf n = 34 Then
            Return 5
        Else
            Return -1
        End If
    End Function
    Public Sub LimpiarLista()
        ListaToken.Clear()
        ListaErrores.Clear()
    End Sub
    Public Property PListaErrores
        Set(value)

        End Set
        Get
            Return ListaErrores
        End Get
    End Property
    Public Property PListaTokens
        Get
            Return ListaToken
        End Get
        Set(value)

        End Set
    End Property
End Class
