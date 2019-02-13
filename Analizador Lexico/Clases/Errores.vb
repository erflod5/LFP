Public Class Errores
    Private Err As String
    Private Fila, Columna As Integer

    Public Sub New(err As String, fila As Integer, columna As Integer)
        Me.Err = err
        Me.Fila = fila
        Me.Columna = columna
    End Sub
    Public Property Perr As String
        Get
            Return Err
        End Get
        Set(value As String)
            Err = value
        End Set
    End Property
    Public Property PFila As Integer
        Get
            Return Fila
        End Get
        Set(value As Integer)
            Fila = value
        End Set
    End Property
    Public Property PColumna As Integer
        Get
            Return Columna
        End Get
        Set(value As Integer)
            Columna = value
        End Set
    End Property
End Class
