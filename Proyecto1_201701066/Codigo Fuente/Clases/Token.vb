Imports System
Imports System.Collections.ObjectModel
Imports System.Windows.Forms

Public Class Token
    Private nombre, lexema As String
    Private fila, columna As Integer

    Public Sub New(nombre As String, lexema As String, fila As Integer, columna As Integer)
        Me.nombre = nombre
        Me.lexema = lexema
        Me.fila = fila
        Me.columna = columna
    End Sub

    Public Property Pnombre As String
        Get
            Return nombre
        End Get
        Set(value As String)
            nombre = value
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

End Class
