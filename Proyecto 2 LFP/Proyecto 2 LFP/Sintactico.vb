Public Class Sintactico
    Dim numPreanalisis As Integer
    Dim preanalisis As Token
    Dim listaTokens As List(Of Token)
    Dim listaErrores = New List(Of Errores)
    Dim name, met, at, col As Boolean

    Public Sub New(listaTokens As List(Of Token), listaErrores As List(Of Errores))
        Me.listaTokens = listaTokens
        Me.listaErrores = listaErrores
    End Sub
    Public Sub Analizar()
        preanalisis = listaTokens.Item(0)
        numPreanalisis = 0
        S()
    End Sub
    Private Sub S()
        Select Case preanalisis.PToken
            Case 3
                Match(3)
                SP()
            Case 0
                MessageBox.Show("Analisis Completo")
            Case Else
                ErrorInicio()
        End Select
    End Sub
    Private Sub S1()
        Select Case preanalisis.PToken
            Case 3
                Match(3)
                SP1()
            Case 0
                MessageBox.Show("Analisis Completo")
            Case Else
                ErrorInicio1()
        End Select
    End Sub
    Private Sub SP()
        Select Case preanalisis.PToken
            Case 1000
                name = False
                met = False
                at = False
                col = False
                Match(1000)
                Match(4)
                Match(1)
                Clase()
                Match(2)
                S()
            Case 5000
                Match(5000)
                Match(4)
                Match(1)
                Asociacion()
                Match(2)
                S1()
            Case 11000
                Match(11000)
                Match(4)
                Match(1)
                Comentario()
                Match(2)
                S()
            Case Else
                listaErrores.Add(New Errores("Se esperaba Clase, Comentario o Asociacion", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorPalabraPrincipal() Then
                    S()
                End If
        End Select
    End Sub
    Private Sub SP1()
        Select Case preanalisis.PToken
            Case 1000
                name = False
                met = False
                at = False
                col = False
                Match(1000)
                Match(4)
                Match(1)
                Clase()
                Match(2)
                S1()
            Case 11000
                Match(11000)
                Match(4)
                Match(1)
                Comentario()
                Match(2)
                S1()
            Case 5000
                listaErrores.Add(New Errores("Metodo Asociacion ya definido", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorPalabraPrincipal() Then
                    S1()
                End If
            Case Else
                listaErrores.Add(New Errores("Se esperaba Clase o Comentario ", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorPalabraPrincipal() Then
                    S1()
                End If
        End Select
    End Sub
    Private Sub Clase()
        Select Case preanalisis.PToken
            Case 3
                Match(3)
                ClaseP()
            Case Else

        End Select
    End Sub
    Private Sub ClaseP()
        Select Case preanalisis.PToken
            Case 2000
                If name Then
                    listaErrores.Add(New Errores("Nombre ya definido 1 vez", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                End If
                name = True
                Match(2000)
                Match(4)
                Match(5)
                Match(200)
                Match(7)
                Clase()
            Case 10000
                If col Then
                    listaErrores.Add(New Errores("Color ya definido 1 vez", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                End If
                col = True
                Match(10000)
                Match(4)
                Match(5)
                Match(100)
                Match(6)
                Match(100)
                Match(6)
                Match(100)
                Match(7)
                Clase()
            Case 3000
                If met Then
                    listaErrores.Add(New Errores("Metodo ya definido 1 vez", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                End If
                Match(3000)
                Match(4)
                Match(1)
                Metodos()
                Match(2)
                Clase()
            Case 4000
                If at Then
                    listaErrores.Add(New Errores("Atributo ya definido 1 vez", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                End If
                at = True
                Match(4000)
                Match(4)
                Match(1)
                Atributos()
                Match(2)
                Clase()
        End Select
    End Sub
    Private Sub Atributos()
        Match(12)
        Visibilidad()
        Match(13)
        Match(200)
        MetodosP()
        Metodos1()
    End Sub
    Private Sub Metodos()
        Match(12)
        Visibilidad()
        Match(13)
        Match(200)
        MetodosP()
        Metodos1()
    End Sub
    Private Sub Metodos1()
        Select Case preanalisis.PToken
            Case 12
                Match(12)
                Visibilidad()
                Match(13)
                Match(200)
                MetodosP()
                Metodos1()
            Case Else

        End Select
    End Sub
    Private Sub MetodosP()
        Select Case preanalisis.PToken
            Case 7
                Match(7)
            Case 8
                Match(8)
                Match(200)
                Match(7)
        End Select
    End Sub
    Private Sub Visibilidad()
        Select Case preanalisis.PToken
            Case 9
                Match(9)
            Case 10
                Match(10)
            Case 11
                Match(11)
        End Select
    End Sub
    Private Sub Comentario()
        Select Case preanalisis.PToken
            Case 3
                Match(3)
                ComentarioP()
            Case Else
                listaErrores.Add(New Errores("Se esperaba [", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                ComentarioP()
        End Select
    End Sub
    Private Sub ComentarioP()
        Select Case preanalisis.PToken
            Case 2000
                Match(2000)
                Match(4)
                Match(5)
                Match(200)
                Match(7)
                ComentarioP1()
            Case 12000
                Match(12000)
                Match(4)
                Match(5)
                Match(14)
                Match(300)
                Match(14)
                Match(7)
                ComentarioP2()
            Case Else
                listaErrores.Add(New Errores("Se esperaba Nombre o Texto", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorComentario() Then
                    Match(3)
                    ComentarioP()
                End If
        End Select
    End Sub
    Private Sub ComentarioP1()
        Match(3)
        Select Case preanalisis.PToken
            Case 12000
                Match(12000)
                Match(4)
                Match(5)
                Match(14)
                Match(300)
                Match(14)
                Match(7)
            Case 2000
                listaErrores.Add(New Errores("Nombre ya definido una vez", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorComentario() Then
                    ComentarioP1()
                End If
        End Select
    End Sub
    Private Sub ComentarioP2()
        Match(3)
        Select Case preanalisis.PToken
            Case 2000
                Match(3)
                Match(2000)
                Match(4)
                Match(5)
                Match(200)
                Match(7)
            Case 12000
                listaErrores.Add(New Errores("Texto ya definido una vez", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorComentario() Then
                    ComentarioP2()
                End If
        End Select
    End Sub
    Private Sub Asociacion()
        Select Case preanalisis.PToken
            Case 200
                Match(200)
                Match(8)
                TipoAsociacion()
                Asociacion()
            Case 2
            Case Else
                listaErrores.Add(New Errores("Se esperaba identificador", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorAsociacion() Then
                    numPreanalisis += 1
                    preanalisis = listaTokens.Item(numPreanalisis)
                    Asociacion()
                End If
        End Select
    End Sub
    Private Sub TipoAsociacion()
        Select Case preanalisis.PToken
            Case 200
                Match(200)
                Match(7)
            Case 6000
                Match(6000)
                Match(8)
                Match(200)
                Match1(7)
            Case 7000
                Match(7000)
                Match(8)
                Match(200)
                Match1(7)
            Case 8000
                Match(8000)
                Match(8)
                Match(200)
                Match1(7)
            Case 9000
                Match(9000)
                Match(8)
                Match(200)
                Match1(7)
            Case Else
                listaErrores.Add(New Errores("Se esperaba identificador, Herencia, Agregacion, Composicion o AsSimple", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
                If ErrorAsociacion() Then
                    numPreanalisis += 1
                    preanalisis = listaTokens.Item(numPreanalisis)
                    Asociacion()
                End If
        End Select
    End Sub
    Private Sub Match(token As Integer)
        If Not token = preanalisis.PToken Then
            listaErrores.Add(New Errores("Se esperaba " + getError(token), preanalisis.Pcolumna, preanalisis.PFila, "Sintactico"))
        End If
        If Not preanalisis.PToken = 0 Then
            numPreanalisis += 1
            preanalisis = listaTokens.Item(numPreanalisis)
        End If
    End Sub
    Private Sub Match1(token As Integer)
        If token = preanalisis.PToken Then
            numPreanalisis += 1
            preanalisis = listaTokens.Item(numPreanalisis)
        Else
            listaErrores.Add(New Errores("Falta " + getError(token), preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
        End If
    End Sub
    Public Function getError(valor As Integer)
        If valor = 1000 Or valor = 5000 Or valor = 11000 Then
            Return "Clase, Asociacion o Comentario"
        ElseIf valor = 2000 Or valor = 3000 Or valor = 4000 Or valor = 10000 Then
            Return "Nombre, Atributos, Metodos o Color"
        ElseIf valor = 6000 Or valor = 7000 Or valor = 8000 Or valor = 9000 Then
            Return "Asocacion Simple, Agregacion, Composicion o Herencia"
        ElseIf valor = 12000 Then
            Return "Texto"
        ElseIf valor = 100 Then
            Return "Numero"
        ElseIf valor = 200 Then
            Return "Identificador"
        ElseIf valor = 300 Then
            Return "Comentario"
        ElseIf valor = 1 Then
            Return "{"
        ElseIf valor = 2 Then
            Return "}"
        ElseIf valor = 3 Then
            Return "["
        ElseIf valor = 4 Then
            Return "]"
        ElseIf valor = 5 Then
            Return "="
        ElseIf valor = 6 Then
            Return ","
        ElseIf valor = 7 Then
            Return ";"
        ElseIf valor = 8 Then
            Return ":"
        ElseIf valor = 12 Then
            Return "("
        ElseIf valor = 13 Then
            Return ")"
        Else
            Return "Desconocido"
        End If
    End Function
    Private Sub ErrorInicio()
        listaErrores.Add(New Errores("Se omitio [ ", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
        SP()
    End Sub
    Private Sub ErrorInicio1()
        listaErrores.Add(New Errores("Se omitio [ ", preanalisis.PFila, preanalisis.Pcolumna, "Sintactico"))
        SP1()
    End Sub
    Private Function ErrorPalabraPrincipal() As Boolean
        Dim ret As Boolean = False
        While preanalisis.PToken <> 3 And preanalisis.PToken <> 0
            numPreanalisis += 1
            preanalisis = listaTokens.Item(numPreanalisis)
            If preanalisis.PToken = 3 Then
                ret = True
            ElseIf preanalisis.PToken = 0 Then
                ret = False
            End If
        End While
        Return ret
    End Function
    Private Function ErrorComentario() As Boolean
        Dim ret As Boolean = False
        While preanalisis.PToken <> 3 And preanalisis.PToken <> 0 And preanalisis.PToken <> 2
            numPreanalisis += 1
            preanalisis = listaTokens.Item(numPreanalisis)
            If preanalisis.PToken = 3 Then
                ret = True
            ElseIf preanalisis.PToken = 0 Then
                ret = False
            End If
        End While
        Return ret
    End Function
    Private Function ErrorAsociacion() As Boolean
        Dim ret As Boolean = False
        While preanalisis.PToken <> 7 And preanalisis.PToken <> 0 And preanalisis.PToken <> 2
            numPreanalisis += 1
            preanalisis = listaTokens.Item(numPreanalisis)
            If preanalisis.PToken = 7 Then
                ret = True
            ElseIf preanalisis.PToken = 0 Or preanalisis.PToken = 2 Then
                ret = False
            End If
        End While
        Return ret
    End Function
    Public Property PListaErrores
        Set(value)

        End Set
        Get
            Return listaErrores
        End Get
    End Property
    Public Property PListaTokens
        Get
            Return listaTokens
        End Get
        Set(value)

        End Set
    End Property
End Class
