Imports System.IO
Public Class Form1
    Dim abierto As Boolean
    Dim ubicacion As String
    Dim rutaArchivo As String
    Private Sub AbrirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AbrirToolStripMenuItem.Click
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
                    Consola.Text = texto
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

    Private Sub guardar()
        SaveFile.Filter = "Archivos lfp (*.lfp)|*.lfp"
        SaveFile.FilterIndex = 2
        SaveFile.RestoreDirectory = True
        If SaveFile.ShowDialog() = DialogResult.OK Then
            Dim sw As StreamWriter = New StreamWriter(SaveFile.OpenFile())
            If (sw IsNot Nothing) Then
                sw.WriteLine(Consola.Text)
                sw.Close()
            End If
        End If
    End Sub

    Private Sub GuardarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarToolStripMenuItem.Click
        If (abierto) Then
            Dim file As StreamWriter = New StreamWriter(ubicacion)
            file.Write(Consola.Text)
            file.Flush()
            file.Close()
        Else
            guardar()
        End If
    End Sub

    Private Sub GuardarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarComoToolStripMenuItem.Click
        guardar()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
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
            System.Diagnostics.Process.Start("Manual de Usuario.pdf")
        Catch ex As Exception
            MessageBox.Show("No se encuentra el archivo", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        MessageBox.Show("Erik Gerardo Flores Diaz" & vbNewLine & "201701066" & vbNewLine & "Version 1.0" & vbNewLine & "CopyRight", "Analizador Léxico", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Class
