Public Class Comentario
    Private nombre, texto As String

    Public Sub New()

    End Sub
    Public Sub New(nombre As String, texto As String)
        Me.nombre = nombre
        Me.texto = texto
    End Sub
    Public Property dameNombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
        End Set
    End Property

    Public Property dameTexto As String
        Get
            Return texto
        End Get
        Set(value As String)
            texto = value
        End Set
    End Property
End Class
