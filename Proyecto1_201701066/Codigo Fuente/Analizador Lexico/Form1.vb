Imports Clases
Imports System.IO
Public Class framePrincipal
    Dim ubicacion As String
    Dim abierto As Boolean = False
    Dim rutaArchivo As String
    Dim Analizador As New Analizador()
    Dim analizar As Boolean = False
    Private Sub funcionAbrir_Click(sender As Object, e As EventArgs) Handles funcionAbrir.Click
        Dim myStream As Stream = Nothing
        OpenFile.Filter = "Archivo lfp |*.lfp"
        OpenFile.FilterIndex = 3
        OpenFile.RestoreDirectory = True
        If OpenFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Try
                myStream = OpenFile.OpenFile()
                If (myStream IsNot Nothing) Then
                    ubicacion = OpenFile.FileName
                    Dim fic As String = ubicacion
                    Dim texto As String
                    Dim sr As New System.IO.StreamReader(fic)
                    texto = sr.ReadToEnd()
                    consolaAnalizador.Text = texto
                    sr.Close()
                    abierto = True
                End If
            Catch ex As Exception
                MessageBox.Show("Error en la lectura de archivo" & ex.Message)
            Finally
                If (myStream IsNot Nothing) Then
                    myStream.Close()
                End If
            End Try
        End If
    End Sub
    Private Sub funcionSalir_Click(sender As Object, e As EventArgs) Handles funcionSalir.Click
        Me.Close()
    End Sub
    Private Sub funcionGuardarComo_Click(sender As Object, e As EventArgs) Handles funcionGuardarComo.Click
        guardar()
    End Sub
    Private Sub guardar()
        SaveFile.Filter = "Archivos lfp (*.lfp)|*.lfp"
        SaveFile.FilterIndex = 2
        SaveFile.RestoreDirectory = True
        If SaveFile.ShowDialog() = DialogResult.OK Then
            Dim sw As StreamWriter = New StreamWriter(SaveFile.OpenFile())
            If (sw IsNot Nothing) Then
                sw.WriteLine(consolaAnalizador.Text)
                sw.Close()
            End If
        End If
    End Sub
    Private Sub funcionGuardar_Click(sender As Object, e As EventArgs) Handles funcionGuardar.Click
        If (abierto) Then
            Dim file As StreamWriter = New StreamWriter(ubicacion)
            file.Write(consolaAnalizador.Text)
            file.Flush()
            file.Close()
        Else
            guardar()
        End If
    End Sub
    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        MessageBox.Show("Erik Gerardo Flores Diaz" & vbNewLine & "201701066" & vbNewLine & "Version 1.0" & vbNewLine & "CopyRight", "Analizador Léxico", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub funcionAnalizarLexico_Click(sender As Object, e As EventArgs) Handles funcionAnalizarLexico.Click
        Analizador.LimpiarLista()
        Analizador.Analizar(consolaAnalizador)
        analizar = True
    End Sub
    Private Sub funcionReporte_Click(sender As Object, e As EventArgs) Handles funcionReporte.Click
        If Analizador.DameEstado = False And analizar = True Then
            Analizador.ImprimirToken()
            Try
                System.Diagnostics.Process.Start("ReporteTokens.html")
            Catch ex As Exception
                MessageBox.Show("No se ha encontrado la ruta del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf Analizador.DameEstado = True Then
            Analizador.ImprimirError()
            Try
                System.Diagnostics.Process.Start("ReporteErrores.html")
            Catch ex As Exception
                MessageBox.Show("No se ha encontrado la ruta del archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf analizar = False Then
            MessageBox.Show("Analice el archivo antes de Reportar Tokens")
        End If
    End Sub
    Private Sub DiagramarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiagramarToolStripMenuItem.Click
        If Analizador.DameEstado = True Then
            MessageBox.Show("No se puede generar la imagen " & vbNewLine & "Revice que el lenguaje no tenga errores", "Error de Sintaxis", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ElseIf Analizador.DameEstado = False And analizar = True Then
            Analizador.CrearClases()
            Analizador.imprimirClases()
            If Analizador.dameClase = True Then
                Try
                    System.Diagnostics.Process.Start("diagrama.jpg")
                Catch ex As Exception
                    MessageBox.Show("No se ha encontrado la ruta, intente nuevamente")
                End Try
            End If
        ElseIf analizar = False Then
            MessageBox.Show("Analice el archivo antes de Generar el Diagrama")
        End If
    End Sub

    Private Sub ManualDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualDeUsuarioToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Manual de Usuario.pdf")
        Catch ex As Exception
            MessageBox.Show("No se encuentra el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ManualTecnicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualTecnicoToolStripMenuItem.Click
        Try
            System.Diagnostics.Process.Start("Manual Tecnico.pdf")
        Catch ex As Exception
            MessageBox.Show("No se encuentra el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class