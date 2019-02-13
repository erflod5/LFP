Imports System
Imports System.Collections.Generic
Imports System.Windows.Forms
Imports System.IO
Public Class Analizador
    Private Token As String
    Dim ListaToken = New List(Of Token)
    Dim ListaErrores = New List(Of Errores)
    Dim ListaClases = New List(Of Clase)
    Dim ListaAtributos = New List(Of Atributos)
    Dim ListaMetodos = New List(Of Metodos)
    Dim Relacion = New List(Of Relacion)
    Dim Siguiente As Integer
    Dim c As Integer
    Private EstadoError As Boolean
    Public Const PR1 As String = "clase"
    Public Const PR2 As String = "nombre"
    Public Const PR3 As String = "Metodos"
    Public Const PR4 As String = "Atributos"
    Public Const PR5 As String = "Asociacion"
    Public Const PR6 As String = "Herencia"
    Public Const PR7 As String = "Agregacion"
    Public Const PR8 As String = "Composicion"
    Public Const PR9 As String = "AsociacionSimple"
    Dim visibilidad As String
    Dim Graficador As Graficadora
    Public Sub New()
        EstadoError = False
        Graficador = New Graficadora()
    End Sub
    Public Property DameEstado
        Get
            Return EstadoError
        End Get
        Set(value)
            EstadoError = value
        End Set
    End Property
    Public Sub Analizar(Consola As TextBox)
        c = 0
        EstadoError = False
        Token = ""
        Dim Estado As Integer = 0
        Dim Texto() As String = Consola.Text.Split(ChrW(10))
        Dim x, y As Integer
        For x = 0 To Texto.Length - 1 'Recorre cada linea
            c = 0
            For y = 0 To Len(Texto(x)) - 1 'Recorre hasta que termina la palabra
                Dim a, b As Integer
                a = Asc(Texto(x).Chars(y)) 'Almacenaje de codigo ASCII
                If (Estado = 0) Then
                    Estado = Reconocedor(a)
                End If
                Try
                    b = Asc(Texto(x).Chars(y + 1))
                Catch ex As Exception
                    b = -4
                End Try
                Siguiente = b
                If a = 9 Then
                    c += 8
                End If
                Select Case Estado
                    Case 1
                        If (a = 91) Then
                            ListaToken.add(New Token("Corchete", "[", x + 1, y))
                            Estado = 0
                        ElseIf a = 93 Then
                            ListaToken.add(New Token("Corchete", "]", x + 1, y))
                            Estado = 0
                        ElseIf a = 123 Then
                            ListaToken.Add(New Token("Delimitador", "{", x + 1, c))
                            Estado = 0
                        ElseIf a = 125 Then
                            ListaToken.Add(New Token("Delimitador", "}", x + 1, c))
                            Estado = 0
                        ElseIf a = 58 Then
                            ListaToken.Add(New Token("Delimitador", ":", x + 1, c))
                            Estado = 0
                        ElseIf a = 59 Then
                            ListaToken.Add(New Token("Delimitador", ";", x + 1, c))
                            Estado = 0
                        ElseIf a = 61 Then
                            ListaToken.Add(New Token("Asignacion", "=", x + 1, c))
                            Estado = 0
                        ElseIf a = 40 Then
                            ListaToken.Add(New Token("Parentesis Abierto", "(", x + 1, c))
                            Estado = 0
                        ElseIf a = 41 Then
                            ListaToken.add(New Token("Parentesis Cierre", ")", x + 1, c))
                            Estado = 0
                        End If
                    Case 2
                        Token = Token + Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            If Token.ToLower = PR1.ToLower Or Token.ToLower = PR2.ToLower Or Token.ToLower = PR3.ToLower Or Token.ToLower = PR4.ToLower Or Token.ToLower = PR5.ToLower Then
                                ListaErrores.Add(New Errores("PR", x + 1, y))
                                Estado = 0
                                Token = ""
                                EstadoError = True
                            Else
                                ListaToken.Add(New Token("Identificador", Token, x + 1, y + 1 - Token.Length))
                                Token = ""
                                Estado = 0
                            End If
                        End If
                    Case 3
                        If a = 43 Then
                            Token += Texto(x).Chars(y)
                            visibilidad = "Publico"
                            ListaToken.add(New Token(visibilidad, Token, x + 1, y + 1 - Token.Length))
                            Token = ""
                            Estado = 0
                        ElseIf a = 45 Then
                            Token += Texto(x).Chars(y)
                            visibilidad = "privado"
                            ListaToken.add(New Token(visibilidad, Token, x + 1, y + 1 - Token.Length))
                            Token = ""
                            Estado = 0
                        ElseIf a = 35 Then
                            Token += Texto(x).Chars(y)
                            visibilidad = "protegido"
                            ListaToken.add(New Token(visibilidad, Token, x + 1, y + 1 - Token.Length))
                            Token = ""
                            Estado = 0
                        End If
                    Case 666
                        If Siguiente = 99 Or Siguiente = 67 Then
                            Estado = 1000
                        ElseIf Siguiente = 78 Or Siguiente = 110 Then
                            Estado = 2000
                        ElseIf Siguiente = 77 Or Siguiente = 109 Then
                            Estado = 3000
                        ElseIf Siguiente = 65 Or Siguiente = 97 Then
                            Estado = 4000
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 666
                        ElseIf a = 13 Or a = 9 Or a = 10 Or a = 32 Then
                            Estado = 666
                        Else
                            ListaErrores.Add(New Errores(Token, x + 1, y))
                            Estado = 0
                            EstadoError = True
                        End If
                    Case 1000
                        If a <> 32 And a <> 9 And a <> 10 And a <> 13 Then
                            Token += Texto(x).Chars(y)
                        End If
                        If Siguiente = 108 Or Siguiente = 76 Then 'L l
                            Estado = 1001
                        ElseIf Siguiente = 79 Or Siguiente = 111 Then 'Oo
                            Estado = 7002
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 1000
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 1001
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If Siguiente = 97 Or Siguiente = 65 Then
                            Estado = 1002
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 1001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 1002
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 115 Or Siguiente = 83) Then
                            Estado = 1003
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 1002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 1003
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 101 Or Siguiente = 69) Then
                            Estado = 1004
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 1003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 1004
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 2000
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 2001
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 2000
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 2001
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 109 Or Siguiente = 77) Then
                            Estado = 2002
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 2001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 2002
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 98 Or Siguiente = 66) Then
                            Estado = 2003
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 2002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 2003
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 114 Or Siguiente = 82) Then
                            Estado = 2004
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 2003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 2004
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 101 Or Siguiente = 69) Then
                            Estado = 2005
                        ElseIf Siguiente = 32 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 13 Then
                            Estado = 2004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 2005
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 3000
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 101 Or Siguiente = 69) Then
                            Estado = 3001
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 3000
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 3001
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 116 Or Siguiente = 84) Then
                            Estado = 3002
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 3001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 3002
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 3003
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 3002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 3003
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 100 Or Siguiente = 68) Then
                            Estado = 3004
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 3003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 3004
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 3005
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 3004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 3005
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 115 Or Siguiente = 83) Then
                            Estado = 3006
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 3005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 3006
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 4000
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 116 Or Siguiente = 84) Then
                            Estado = 4001
                        ElseIf Siguiente = 115 Or Siguiente = 83 Then
                            Estado = 5001
                        ElseIf Siguiente = 71 Or Siguiente = 103 Then
                            Estado = 6002
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4000
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4001
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 114 Or Siguiente = 82) Then
                            Estado = 4002
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4002
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 105 Or Siguiente = 73) Then
                            Estado = 4003
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4003
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 98 Or Siguiente = 66) Then
                            Estado = 4004
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4004
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 117 Or Siguiente = 85) Then
                            Estado = 4005
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4005
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 116 Or Siguiente = 84) Then
                            Estado = 4006
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4006
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 4007
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4006
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4007
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 115 Or Siguiente = 83) Then
                            Estado = 4008
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 4007
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 4008
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 5001
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 5002
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5002
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 99 Or Siguiente = 67) Then
                            Estado = 5003
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5003
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 105 Or Siguiente = 73) Then
                            Estado = 5004
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5004
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 97 Or Siguiente = 65) Then
                            Estado = 5005
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5005
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 99 Or Siguiente = 67) Then
                            Estado = 5006
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5006
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 105 Or Siguiente = 73) Then
                            Estado = 5007
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5006
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5007
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 5008
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5007
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5008
                        If (a <> 32 And a <> 9 And a <> 10 And a <> 13) Then
                            Token += Texto(x).Chars(y)
                        End If
                        If (Siguiente = 110 Or Siguiente = 78) Then
                            Estado = 5009
                        ElseIf Siguiente = 13 Or Siguiente = 9 Or Siguiente = 10 Or Siguiente = 32 Then
                            Estado = 5008
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 5009
                        Token += Texto(x).Chars(y)
                        If Siguiente = 83 Or Siguiente = 115 Then
                            Estado = 9001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 6002
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 82 Or Siguiente = 114) Then
                            Estado = 6003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6003
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 69 Or Siguiente = 101) Then
                            Estado = 6004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6004
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 71 Or Siguiente = 103) Then
                            Estado = 6005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6005
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 65 Or Siguiente = 97) Then
                            Estado = 6006
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6006
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 67 Or Siguiente = 99) Then
                            Estado = 6007
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6007
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 73 Or Siguiente = 105) Then
                            Estado = 6008
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6008
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 79 Or Siguiente = 111) Then
                            Estado = 6009
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6009
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 78 Or Siguiente = 110) Then
                            Estado = 6010
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 6010
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 7002
                        Token += Texto(x).Chars(y) 'Mm
                        If (Siguiente = 77 Or Siguiente = 109) Then
                            Estado = 7003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7003
                        Token += Texto(x).Chars(y) 'Pp
                        If (Siguiente = 80 Or Siguiente = 112) Then
                            Estado = 7004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7004
                        Token += Texto(x).Chars(y) 'Oo
                        If (Siguiente = 79 Or Siguiente = 111) Then
                            Estado = 7005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7005
                        Token += Texto(x).Chars(y) 'Ss
                        If (Siguiente = 115 Or Siguiente = 83) Then
                            Estado = 7006
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7006
                        Token += Texto(x).Chars(y) 'Ii
                        If (Siguiente = 73 Or Siguiente = 105) Then
                            Estado = 7007
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7007
                        Token += Texto(x).Chars(y) 'cC
                        If (Siguiente = 99 Or Siguiente = 67) Then
                            Estado = 7008
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7008
                        Token += Texto(x).Chars(y) 'Ii
                        If (Siguiente = 73 Or Siguiente = 105) Then
                            Estado = 7009
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7009
                        Token += Texto(x).Chars(y) 'oO
                        If (Siguiente = 111 Or Siguiente = 79) Then
                            Estado = 7010
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7010
                        Token += Texto(x).Chars(y) 'Nn
                        If (Siguiente = 78 Or Siguiente = 110) Then
                            Estado = 7011
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 7011
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 8000
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 101 Or Siguiente = 69) Then
                            Estado = 8001
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8001
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 82 Or Siguiente = 114) Then
                            Estado = 8002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8002
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 101 Or Siguiente = 69) Then
                            Estado = 8003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8003
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 78 Or Siguiente = 110) Then
                            Estado = 8004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8004
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 67 Or Siguiente = 99) Then
                            Estado = 8005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8005
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 73 Or Siguiente = 105) Then
                            Estado = 8006
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8006
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 65 Or Siguiente = 97) Then
                            Estado = 8007
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 8007
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case 9001
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 73 Or Siguiente = 105) Then
                            Estado = 9002
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 9002
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 77 Or Siguiente = 109) Then
                            Estado = 9003
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 9003
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 82 Or Siguiente = 112) Then
                            Estado = 9004
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 9004
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 76 Or Siguiente = 108) Then
                            Estado = 9005
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 9005
                        Token += Texto(x).Chars(y)
                        If (Siguiente = 69 Or Siguiente = 101) Then
                            Estado = 9006
                        ElseIf (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.Add(New Token("Variable", Token, x + 1, y))
                            Token = ""
                            Estado = 0
                        End If
                    Case 9006
                        Token += Texto(x).Chars(y)
                        If (Siguiente >= 65 And Siguiente <= 90) Or (Siguiente >= 48 And Siguiente <= 57) Or (Siguiente >= 97 And Siguiente <= 122) Or Siguiente = 95 Then
                            Estado = 2
                        Else
                            ListaToken.add(New Token("Palabra Reservada", Token, x + 1, y - Token.Length + 1))
                            Estado = 0
                            Token = ""
                        End If
                    Case -1
                        Token = Texto(x).Chars(y)
                        ListaErrores.Add(New Errores(Token, x + 1, y))
                        Estado = 0
                        EstadoError = True
                End Select
                c += 1
            Next
        Next
    End Sub
    Private Function Reconocedor(ByVal n As Integer) As Integer
        If (n = 91 Or n = 93 Or n = 123 Or n = 125 Or n = 58 Or n = 59 Or n = 61 Or n = 40 Or n = 41) Then '[]{}:;=  []
            Return 1 'Llaves, corchetes, punto y coma, etc n=43 n = 45 n = 35
            'ElseIf n = 40 Then '(
            '   Return 3
            'ElseIf n = 41 Then
            '   Return 5
        ElseIf n = 43 Or n = 45 Or n = 35 Then
            Return 3
        ElseIf n = 67 Or n = 99 Then
            Return 1000
        ElseIf n = 78 Or n = 110 Then
            Return 2000
        ElseIf n = 77 Or n = 109 Then
            Return 3000
        ElseIf n = 65 Or n = 97 Then
            Return 4000
        ElseIf n = 72 Or n = 104 Then
            Return 8000
        ElseIf (n >= 65 And n <= 90 Or n >= 97 And n <= 122) Then
            Return 2 'Letras mayusculas y minusculas
        ElseIf n = 32 Or n = 13 Or n = 9 Then
            Return 0
        Else
            Return -1
        End If
    End Function
    Public Sub ImprimirToken()
        Dim lexema, Tipo As String
        Dim fila, columna As Integer
        If (ListaToken IsNot Nothing) Then
            For Each token As Token In ListaToken
                lexema = token.Plexema
                Tipo = token.Pnombre
                fila = token.PFila
                columna = token.Pcolumna
            Next
        End If
        CrearReporteTokens()
    End Sub
    Public Sub ImprimirError()
        Dim NombreError As String
        Dim fila, columna As Integer
        If (ListaErrores IsNot Nothing) Then
            For Each Err As Errores In ListaErrores
                NombreError = Err.Perr
                fila = Err.PFila
                columna = Err.PColumna
            Next
        End If
        crearReporteErrores()
    End Sub
    Public Sub LimpiarLista()
        ListaToken.Clear()
        ListaErrores.Clear()
        ListaClases.Clear()
        ListaAtributos.Clear()
        ListaMetodos.Clear()
    End Sub
    Public Function TablaToken() As String
        Dim reporte As String
        Dim numero As Integer = 1
        reporte = ""
        If (ListaToken IsNot Nothing) Then
            For Each Token As Token In ListaToken
                reporte += "<tr> <td>" & numero & "</td> <td> " & Token.Plexema & "</td> <td> " & Token.Pnombre & "</td> <td> " & Token.Pcolumna & "</td> <td> " & Token.PFila & "</td> </tr>"
                numero += 1
            Next
        End If
        Return reporte
    End Function
    Public Function TablaErrores() As String
        Dim reporte As String
        Dim numero As Integer = 1
        reporte = ""
        If (ListaErrores IsNot Nothing) Then
            For Each Errores As Errores In ListaErrores
                reporte += "<tr> <td>" & numero & "</td> <td> " & Errores.Perr & "</td> <td> " & Errores.PColumna & "</td> <td> " & Errores.PFila & "</td>  </tr>"
                numero += 1
            Next
        End If
        Return reporte
    End Function
    Public Sub CrearReporteTokens()
        Try
            Dim ruta As String = "ReporteTokens.html"
            Dim sw As StreamWriter = New StreamWriter(ruta)
            sw.Write("<HTML> <head> <title> Reporte de Tokens </title> </head> <body> <table border = 1> <tr> <th>No</th> <th>Lexema</th> <th>Tipo</th> <th>Columna</th> <th>Fila</th> </tr>")
            sw.Write(TablaToken)
            sw.Write("</table> </body> </HTML>")
            sw.Flush()
            sw.Close()
        Catch ex As Exception
            MessageBox.Show("no creado")
        End Try
    End Sub
    Public Sub crearReporteErrores()
        Try
            Dim ruta As String = "ReporteErrores.html"
            Dim sw As StreamWriter = New StreamWriter(ruta)
            sw.Write("<HTML> <head> <title> Reporte de Errores </title> </head> <body> <table border = 1> <tr> <th>No</th> <th>Error</th> <th>Columna</th> <th>Fila</th> </tr>")
            sw.Write(TablaErrores)
            sw.Write("</table> </body> </HTML>")
            sw.Flush()
            sw.Close()
        Catch ex As Exception
            MessageBox.Show("No creado")
        End Try
    End Sub
    Public Sub CrearClases()
        Dim pr2 As String = "Asociacion"
        Dim pr3 As String = "Atributos"
        Dim pr4 As String = "Metodos"
        Dim Nombre As String = ""
        Dim p As Integer
        Dim visibilidad, variable, tipo As String
        Dim acceso As Boolean
        Dim listaTempAtributos As New List(Of Atributos)
        Dim listaTempMetodos As New List(Of Metodos)
        ListaClases.Clear()
        Relacion.Clear()
        ListaMetodos.Clear()
        ListaAtributos.Clear()
        Dim llaveCl As Integer
        If ListaToken IsNot Nothing Then
            Dim x As Integer = ListaToken.Count
            For i As Integer = 0 To x Step 1
                If i < x - 1 Then
                    Dim token1 As Token = ListaToken(i)
                    Dim token2 As Token = ListaToken(i + 1)
                    'SE VA A CLASE O SE VA A ASOCIACION
                    If PR1.ToLower = token1.Plexema.ToLower Then
                        acceso = True
                    ElseIf pr2.ToLower = token1.Plexema.ToLower Then
                        acceso = False
                    End If
                    'SE VA A ATRIBUTOS O SE VA A METODOS
                    If pr3.ToLower = token1.Plexema.ToLower Then
                        p = 1
                    ElseIf pr4.ToLower = token1.Plexema.ToLower Then
                        p = 2
                    End If
                    If acceso Then
                        If token1.Plexema = "=" Then
                            Nombre = token2.Plexema
                            ListaClases.add(New Clase(Nombre))
                        End If
                        If p = 1 Then
                            If token1.Plexema = "+" Or token1.Plexema = "-" Or token1.Plexema = "#" Then
                                Dim token3 As Token = ListaToken(i + 3)
                                Dim tokenV As Token = ListaToken(i + 2)
                                If token3.Plexema = ":" Then
                                    Dim token4 As Token = ListaToken(i + 4)
                                    tipo = token4.Plexema
                                Else
                                    tipo = ""
                                End If
                                visibilidad = token1.Plexema
                                variable = tokenV.Plexema
                                'ListaAtributos.Add(New Atributos(Nombre, visibilidad, variable, tipo))
                                listaTempAtributos.Add(New Atributos(visibilidad, variable, tipo))
                                visibilidad = ""
                                tipo = ""
                                variable = ""
                            End If
                        ElseIf p = 2 Then
                            If token1.Plexema = "+" Or token1.Plexema = "-" Or token1.Plexema = "#" Then
                                Dim token3 As Token = ListaToken(i + 3)
                                Dim tokenV As Token = ListaToken(i + 2)
                                If token3.Plexema = ":" Then
                                    Dim token4 As Token = ListaToken(i + 4)
                                    tipo = token4.Plexema
                                Else
                                    tipo = ""
                                End If
                                visibilidad = token1.Plexema
                                variable = tokenV.Plexema
                                'ListaMetodos.Add(New Metodos(Nombre, visibilidad, variable, tipo))
                                listaTempMetodos.Add(New Metodos(visibilidad, variable, tipo))
                                visibilidad = ""
                                variable = ""
                                tipo = ""
                            End If
                        End If
                        If token2.Plexema = "{" Then
                            llaveCl += 1
                        End If
                        If token2.Plexema = "}" Then
                            llaveCl -= 1
                        End If
                        If llaveCl = 0 Then
                            If listaTempMetodos IsNot Nothing Then
                                For Each m As Metodos In listaTempMetodos
                                    ListaMetodos.Add(New Metodos(Nombre, m.dameVisibilidad, m.dameVariable, m.dameRetorno))
                                Next
                                listaTempMetodos.Clear()
                            End If
                            If listaTempAtributos IsNot Nothing Then
                                For Each a As Atributos In listaTempAtributos
                                    ListaAtributos.Add(New Atributos(Nombre, a.dameVisibilidad, a.dameVariable, a.dameRetorno))
                                Next
                                listaTempAtributos.Clear()
                            End If
                        End If
                    End If
                    If acceso = False Then
                        If PR9.ToLower = token1.Plexema.ToLower Or PR6.ToLower = token1.Plexema.ToLower Or PR7.ToLower = token1.Plexema.ToLower Or PR8.ToLower = token1.Plexema.ToLower Then
                            Dim token3 As Token = ListaToken(i - 2)
                            Dim token4 As Token = ListaToken(i + 2)
                            Relacion.Add(New Relacion(token3.Plexema, token4.Plexema, token1.Plexema))
                        End If
                    End If
                End If
            Next
        End If
    End Sub
    Dim TextoRelacion As String
    Dim valClase As Boolean
    Public Sub imprimirClases()
        valClase = True
        Dim interfa As Boolean = True
        TextoRelacion = ""
        Dim tempClase As String = ""
        Dim tempAtributos As String = ""
        Dim tempMetodos As String = ""
        Dim tempAbstract As String = ""
        Dim claseCreada As Integer
        If ListaClases IsNot Nothing Then
            For Each Clase As Clase In ListaClases
                tempClase = Clase.DameNombre
                If ListaAtributos IsNot Nothing Then
                    For Each Atributos As Atributos In ListaAtributos
                        If Clase.DameNombre = Atributos.dameClase Then
                            interfa = False
                            tempAtributos += Atributos.dameVisibilidad & " " & Atributos.dameVariable & " " & Atributos.dameRetorno & "\n"
                        End If
                    Next
                End If
                If ListaMetodos IsNot Nothing Then
                    For Each Metodos As Metodos In ListaMetodos
                        If Clase.DameNombre = Metodos.dameClase Then
                            tempMetodos += Metodos.dameVisibilidad & " " & Metodos.dameVariable & "(" & Metodos.dameRetorno & ")" & "\n"
                        End If
                    Next
                End If
                If interfa Then
                    tempAbstract = "\<\<Interface\>\>"
                End If
                TextoRelacion += tempClase & "[label = ""{" & tempClase & "\n " & tempAbstract & "|" & tempAtributos & "|" & tempMetodos & "}""]"
                interfa = True
                tempClase = ""
                tempMetodos = ""
                tempAtributos = ""
                tempAbstract = ""
            Next
        End If
        If Relacion IsNot Nothing Then
            For Each rel As Relacion In Relacion
                claseCreada = 0
                If ListaClases IsNot Nothing Then
                    For Each Clase As Clase In ListaClases
                        If rel.dameClase1 = Clase.DameNombre Or rel.dameClase2 = Clase.DameNombre Then
                            claseCreada += 1
                            If rel.dameClase1 = rel.dameClase2 Then
                                claseCreada += 1
                            End If
                        End If
                    Next
                End If
                If rel.dameRelacion.ToString.ToLower = PR6.ToLower Then
                    TextoRelacion += rel.dameClase1 & "->" & rel.dameClase2 & "[arrowtail = o""normal""]"
                ElseIf rel.dameRelacion.ToString.ToLower = PR7.ToLower Then
                    TextoRelacion += rel.dameClase1 & "->" & rel.dameClase2 & "[arrowtail = odiamond]"
                ElseIf rel.dameRelacion.ToString.ToLower = PR9.ToLower Then
                    TextoRelacion += rel.dameClase1 & "->" & rel.dameClase2 & "[arrowtail = ""none""]"
                ElseIf rel.dameRelacion.ToString.ToLower = PR8.ToLower Then
                    TextoRelacion += rel.dameClase1 & "->" & rel.dameClase2 & "[arrowtail = ""diamond""]"
                End If
                If claseCreada = 2 Then

                Else
                    valClase = False
                End If
            Next
        End If
        If valClase = False Then
            MessageBox.Show("Se han asociado clases sin crear " & vbNewLine & "Creelas antes de asociarlas")
        Else
            Graficador.CrearDot(TextoRelacion)
            Graficador.GenerarImagen()
            TextoRelacion = ""
        End If
    End Sub
    Public Property dameClase
        Get
            Return valClase
        End Get
        Set(value)

        End Set
    End Property
End Class
