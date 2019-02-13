Public Class Relacion
    Dim clase1 As String
    Dim clase2 As String
    Dim relacion As String

    Public Sub New(clase1 As String, clase2 As String, relacion As String)
        Me.clase1 = clase1
        Me.clase2 = clase2
        Me.relacion = relacion
    End Sub
    Public Sub New(clase1 As String, clase2 As String)
        Me.clase1 = clase1
        Me.clase2 = clase2
    End Sub
    Public Property dameClase1
        Get
            Return clase1
        End Get
        Set(value)

        End Set
    End Property

    Public Property dameClase2
        Get
            Return clase2
        End Get
        Set(value)

        End Set
    End Property

    Public Property dameRelacion
        Get
            Return relacion
        End Get
        Set(value)

        End Set
    End Property
End Class