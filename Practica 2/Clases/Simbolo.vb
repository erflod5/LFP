Public Class Simbolo
    Private Simbolo, Tipo, Uso As String

    Public Sub New(simbolo As String, tipo As String)
        Me.Simbolo = simbolo
        Me.Tipo = tipo
    End Sub

    Public Property DameSimbolo
        Get
            Return Simbolo
        End Get
        Set(value)
            Simbolo = value
        End Set
    End Property
    Public Property DameTipo
        Get
            Return Tipo
        End Get
        Set(value)
            Tipo = value
        End Set
    End Property
    Public Property DameUso
        Get
            Return Uso
        End Get
        Set(value)
            Uso = value
        End Set
    End Property
End Class
