Imports System.IO

Public Class Reportes
    Dim listaToken As List(Of Token)
    Dim listaErrores As List(Of Errores)
    Public Sub New(listaToken As List(Of Token), listaErrores As List(Of Errores))
        Me.listaToken = listaToken
        Me.listaErrores = listaErrores
    End Sub
    Public Function TablaToken() As String
        Dim reporte As String
        Dim numero As Integer = 1
        reporte = ""
        If (listaToken IsNot Nothing) Then
            For Each Token As Token In listaToken
                reporte += "<tr> <td>" & numero & "</td> <td> " & Token.Plexema & "</td> <td> " & Token.Pnombre & "</td> <td> " & Token.Pcolumna & "</td> <td> " & Token.PFila & "</td> <td> " & Token.PToken & "</td> </tr>"
                numero += 1
            Next
        End If
        Return reporte
    End Function
    Public Function TablaErrores() As String
        Dim reporte As String
        Dim numero As Integer = 1
        reporte = ""
        If (listaErrores IsNot Nothing) Then
            For Each Errores As Errores In listaErrores
                reporte += "<tr> <td>" & numero & "</td> <td> " & Errores.Perr & "</td> <td> " & Errores.PColumna & "</td> <td> " & Errores.PFila & "</td> <td>" & Errores.Ptipo & "</td>  </tr>"
                numero += 1
            Next
        End If
        Return reporte
    End Function
    Public Sub CrearReporteTokens()
        Try
            Dim ruta As String = "ReporteTokens.html"
            Dim sw As StreamWriter = New StreamWriter(ruta)
            sw.Write("<HTML> <head> <title> Reporte de Tokens </title> </head> <body> <table border = 1> <tr> <th>No</th> <th>Lexema</th> <th>Tipo</th> <th>Columna</th> <th>Fila</th> <th>Token</th> </tr>")
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
            sw.Write("<HTML> <head> <title> Reporte de Errores </title> </head> <body> <table border = 1> <tr> <th>No</th> <th>Error</th> <th>Columna</th> <th>Fila</th> <th>Tipo</th> </tr>")
            sw.Write(TablaErrores)
            sw.Write("</table> </body> </HTML>")
            sw.Flush()
            sw.Close()
        Catch ex As Exception
            MessageBox.Show("No creado")
        End Try
    End Sub
    Public Sub Imprimir()
        If listaErrores.Count = 0 Then
            CrearReporteTokens()
            Try
                System.Diagnostics.Process.Start("ReporteTokens.html")
            Catch ex As Exception
                MessageBox.Show("No se ha encontrado la ruta del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Else
            crearReporteErrores()
            Try
                System.Diagnostics.Process.Start("ReporteErrores.html")
            Catch ex As Exception
                MessageBox.Show("No se ha encontrado la ruta del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class
