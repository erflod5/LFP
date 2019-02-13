Imports System.IO
Public Class Graficadora
    Public Sub CrearDot(clases As String)
        Try
            Dim ruta As String = "UML.dot"
            Dim sw As StreamWriter = New StreamWriter(ruta)
            sw.Write("digraph uml{ node[shape=record,style=filled,fillcolor=gray95]  edge[dir=back,arrowtail=empty] ")
            sw.Write(clases)
            sw.Write("}")
            sw.Flush()
            sw.Close()
        Catch ex As Exception
        End Try
    End Sub
    Public Sub GenerarImagen()
        Dim doPath As String = "D:\Program Files\Graphviz\bin\dot.exe"
        Dim cmd As String = doPath & " -Tjpg " & "UML.dot" & " -o " & "diagrama.jpg"
        Dim prog As VariantType
        prog = Shell(cmd, 1)
    End Sub
End Class
