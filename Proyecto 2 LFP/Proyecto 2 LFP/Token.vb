Public Class Token
    Private nombre, lexema As String
    Private fila, columna As Integer
    Private token As Integer
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

    Public Sub New(nombre As String, lexema As String, fila As Integer, columna As Integer, token As Integer)
        Me.nombre = nombre
        Me.lexema = lexema
        Me.fila = fila
        Me.columna = columna
        Me.token = token
    End Sub

    Public Sub New(nombre As String, lexema As String, fila As Integer, columna As Integer)
        Me.nombre = nombre
        Me.lexema = lexema
        Me.fila = fila
        Me.columna = columna
        AsignarToken(nombre)
    End Sub

    Public Property Pnombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property PToken As String
        Get
            Return token
        End Get
        Set(value As String)
            token = value
        End Set
    End Property

    Public Property Plexema As String
        Get
            Return lexema
        End Get
        Set(value As String)
            lexema = value
        End Set
    End Property

    Public Property Pcolumna As Integer
        Get
            Return columna
        End Get
        Set(value As Integer)
            columna = value
        End Set
    End Property
    Public Property PFila As Integer
        Get
            Return fila
        End Get
        Set(value As Integer)
            fila = value
        End Set
    End Property

    Public Sub AsignarToken(ByVal nombre As String)
        If PR1.ToLower = nombre.ToLower Then
            token = 1000
        ElseIf PR2.ToLower = nombre.ToLower Then
            token = 2000
        ElseIf PR3.ToLower = nombre.ToLower Then
            token = 3000
        ElseIf PR4.ToLower = nombre.ToLower Then
            token = 4000
        ElseIf PR5.ToLower = nombre.ToLower Then
            token = 5000
        ElseIf PR6.ToLower = nombre.ToLower Then
            token = 6000
        ElseIf PR7.ToLower = nombre.ToLower Then
            token = 7000
        ElseIf PR8.ToLower = nombre.ToLower Then
            token = 8000
        ElseIf PR9.ToLower = nombre.ToLower Then
            token = 9000
        ElseIf PR10.ToLower = nombre.ToLower Then
            token = 10000
        ElseIf PR11.ToLower = nombre.ToLower Then
            token = 11000
        ElseIf PR12.ToLower = nombre.ToLower Then
            token = 12000
        ElseIf nombre = "{" Then
            token = 1
        ElseIf nombre = "}" Then
            token = 2
        ElseIf nombre = "[" Then
            token = 3
        ElseIf nombre = "]" Then
            token = 4
        ElseIf nombre = "=" Then
            token = 5
        ElseIf nombre = "," Then
            token = 6
        ElseIf nombre = ";" Then
            token = 7
        ElseIf nombre = ":" Then
            token = 8
        ElseIf nombre = "+" Then
            token = 9
        ElseIf nombre = "-" Then
            token = 10
        ElseIf nombre = "#" Then
            token = 11
        ElseIf nombre = "(" Then
            token = 12
        ElseIf nombre = ")" Then
            token = 13
        ElseIf nombre = """" Then
            token = 14
        ElseIf nombre = "Identificador" Then
            token = 200
        ElseIf nombre = "Numero" Then
            token = 100
        ElseIf nombre = "String" Then
            token = 300
        End If
    End Sub
End Class
