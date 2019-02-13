Imports System.Windows.Forms
Public Class Clase
    Private Nombre As String
    Public Sub New(nombre As String)
        Me.Nombre = nombre
    End Sub
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

    Public Sub New(Clase As String, visibilidad As String, variable As String, tipo As String)
        Me.visibilidad = visibilidad
        Me.variable = variable
        Me.tipo = tipo
        Me.Clase = Clase
    End Sub
    Public Sub New(visibilidad As String, variable As String, tipo As String)
        Me.visibilidad = visibilidad
        Me.variable = variable
        Me.tipo = tipo
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
End Class

Class Metodos
    Dim Clase As String
    Dim visibilidad As String
    Dim Variable As String
    Dim retorno As String

    Public Sub New(Clase As String, visibilidad As String, variable As String, retorno As String)
        Me.visibilidad = visibilidad
        Me.Variable = variable
        Me.retorno = retorno
        Me.Clase = Clase
    End Sub
    Public Sub New(visibilidad As String, variable As String, retorno As String)
        Me.visibilidad = visibilidad
        Me.Variable = variable
        Me.retorno = retorno
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