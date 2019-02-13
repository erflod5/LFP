Imports System.Drawing
Public Class Clase
    Private Nombre, color As String
    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub
    Public Sub New(nombre As String, color As String)
        Me.Nombre = nombre
        Me.color = color
    End Sub
    Public Property DameColor
        Get
            Return color
        End Get
        Set(value)
            color = value
        End Set
    End Property
    Public Property DameNombre
        Get
            Return Nombre
        End Get
        Set(value)
            Nombre = value
        End Set
    End Property
End Class
Class Atributos
    Dim Clase As String
    Private visibilidad As String
    Dim variable As String
    Dim tipo As String
    Dim fila As Integer

    Public Sub New(Clase As String, visibilidad As String, variable As String, tipo As String, fila As Integer)
        Me.visibilidad = visibilidad
        Me.variable = variable
        Me.tipo = tipo
        Me.Clase = Clase
        Me.Fila1 = fila
    End Sub

    Public Sub New(Clase As String, visibilidad As String, variable As String, tipo As String)
        Me.visibilidad = visibilidad
        Me.variable = variable
        Me.tipo = tipo
        Me.Clase = Clase
    End Sub
    Public Sub New(visibilidad As String, variable As String, tipo As String, fila As Integer)
        Me.visibilidad = visibilidad
        Me.variable = variable
        Me.tipo = tipo
        Me.fila = fila
    End Sub
    Public Property dameClase
        Get
            Return Clase
        End Get
        Set(value)

        End Set
    End Property

    Public Property dameVisibilidad
        Get
            Return visibilidad
        End Get
        Set(value)
            visibilidad = value
        End Set
    End Property

    Public Property dameVariable
        Get
            Return variable
        End Get
        Set(value)

        End Set
    End Property

    Public Property dameRetorno
        Get
            Return tipo
        End Get
        Set(value)

        End Set
    End Property

    Public Property Fila1 As Integer
        Get
            Return fila
        End Get
        Set(value As Integer)
            fila = value
        End Set
    End Property
End Class
Class Metodos
    Dim Clase As String
    Dim visibilidad As String
    Dim Variable As String
    Dim retorno As String
    Dim fila As Integer

    Public Sub New(Clase As String, visibilidad As String, variable As String, retorno As String, fila As Integer)
        Me.visibilidad = visibilidad
        Me.Variable = variable
        Me.retorno = retorno
        Me.Clase = Clase
        Me.fila = fila
    End Sub
    Public Sub New(Clase As String, visibilidad As String, variable As String, retorno As String)
        Me.visibilidad = visibilidad
        Me.Variable = variable
        Me.retorno = retorno
        Me.Clase = Clase
    End Sub
    Public Sub New(visibilidad As String, variable As String, retorno As String, fila As Integer)
        Me.visibilidad = visibilidad
        Me.Variable = variable
        Me.retorno = retorno
        Me.fila = fila
    End Sub
    Public Property dameFile
        Get
            Return fila
        End Get
        Set(value)

        End Set
    End Property

    Public Property dameClase
        Get
            Return Clase
        End Get
        Set(value)

        End Set
    End Property
    Public Property dameVisibilidad
        Get
            Return visibilidad
        End Get
        Set(value)
            visibilidad = value
        End Set
    End Property

    Public Property dameVariable
        Get
            Return Variable
        End Get
        Set(value)

        End Set
    End Property

    Public Property dameRetorno
        Get
            Return retorno
        End Get
        Set(value)

        End Set
    End Property
End Class
