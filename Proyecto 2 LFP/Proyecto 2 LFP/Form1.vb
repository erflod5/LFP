Imports System.IO
Imports System.Text.RegularExpressions
Imports Proyecto_2_LFP
Public Class Form1
    Dim Analizador As New Analizar()
    Dim graficadora As New Graficadora()
    Dim abierto As Boolean
    Dim ubicacion As String
    Dim rutaArchivo As String
    Dim analizar As Boolean = False
    Dim listaToken As List(Of Token)
    Dim listaErrores As List(Of Errores)
    Dim start As Integer = 0
    Dim indexOfSearchText As Integer = 0

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
                    Consola.SelectAll()
                    Consola.SelectionColor = Color.FloralWhite
                    Consola.DeselectAll()
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

    Private Sub Guardar()
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
            Guardar()
        End If
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        MessageBox.Show("Erik Gerardo Flores Diaz" & vbNewLine & "201701066" & vbNewLine & "Version 1.0" & vbNewLine & "CopyRight", "Analizador Léxico", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub GuardarComoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles GuardarComoToolStripMenuItem.Click
        Guardar()
    End Sub

    Private Sub AnalizarLexicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AnalizarLexicoToolStripMenuItem.Click
        'inicio colorear
        start = 0
        indexOfSearchText = 0

        'analizador lexico
        listaToken = Analizador.Analizar(Consola)
        listaErrores = Analizador.PListaErrores
        Colorear()

        'analizador sintactico
        listaToken.Add(New Token("Fin", "Fin", 0, 0, 0))
        Dim sintaxis As New Sintactico(listaToken, listaErrores)
        sintaxis.Analizar()
        analizar = True

        'errores sintacticos
        listaErrores = sintaxis.PListaErrores

        'graficador
        graficadora.Crearclase(listaToken)
        listaErrores = graficadora.comprobarRepetidos(listaErrores)

        ColorearSintaxis()

    End Sub

    Private Sub ReporteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReporteToolStripMenuItem.Click
        If analizar = True Then
            Dim reporte As New Reportes(listaToken, listaErrores)
            reporte.Imprimir()
        Else
            MessageBox.Show("Analice el archivo antes de Reportar Tokens")
        End If
    End Sub

    Private Sub Buscar_Coincidencia(
            ByVal pattern As String,
            ByVal RichTextBox As RichTextBox,
            ByVal cColor As Color,
            ByVal BackColor As Color)

        Dim Resultados As MatchCollection
        Dim Palabra As Match
        Try
            ' PAsar el pattern e indicar que ignore las mayúsculas y minúsculas al mosmento de buscar  
            Dim obj_Expresion As New Regex(pattern.ToString, RegexOptions.IgnoreCase)

            ' Ejecutar el método Matches para buscar la cadena en el texto del control  
            ' y retornar un MatchCollection con los resultados  
            Resultados = obj_Expresion.Matches(RichTextBox.Text)

            ' quitar el coloreado anterior  
            With RichTextBox
                .SelectAll()
                .SelectionColor = Color.Black
            End With

            ' Si se encontraron coincidencias recorre las colección    
            For Each Palabra In Resultados
                With RichTextBox
                    .SelectionStart = Palabra.Index ' comienzo de la selección  
                    .SelectionLength = Palabra.Length ' longitud de la cadena a seleccionar  
                    .SelectionColor = cColor ' color de la selección  
                    .SelectionBackColor = BackColor
                    Debug.Print(Palabra.Value)
                End With
            Next Palabra

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

    End Sub

    Private Sub DiagramaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DiagramaToolStripMenuItem.Click
        If analizar Then
            graficadora.imprimirClases()
            Try
                System.Diagnostics.Process.Start("diagrama.jpg")
            Catch ex As Exception
                MessageBox.Show("No se ha encontrado la ruta, intente nuevamente")
            End Try
        Else
            MessageBox.Show("Analice antes de graficar")
        End If
    End Sub

    Private Sub ManuaTecnicoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManuaTecnicoToolStripMenuItem.Click

    End Sub

    Private Sub Prueba(ByVal texto As String, color As Color)
        Dim startindex As Integer = 0
        startindex = FindMyText(texto, start, Consola.Text.Length)
        If startindex >= 0 Then
            Consola.SelectionColor = color
            Dim endindex As Integer = texto.Length
            Consola.Select(startindex, endindex)
            start = startindex + endindex
            Consola.DeselectAll()
        End If
    End Sub

    Public Function FindMyText(ByVal txtToSearch As String, ByVal searchStart As Integer, ByVal searchEnd As Integer) As Integer
        Dim retVal As Integer = -1
        If searchStart >= 0 AndAlso indexOfSearchText >= 0 Then
            If searchEnd > searchStart OrElse searchEnd = -1 Then
                indexOfSearchText = Consola.Find(txtToSearch, searchStart, searchEnd, RichTextBoxFinds.None)
                If indexOfSearchText <> -1 Then
                    retVal = indexOfSearchText
                End If
            End If
        End If
        Return retVal
    End Function

    Public Sub CheckKeyWord(word As String, color As Color, starIndex As Integer)
        If Me.Consola.Text.Contains(word) Then
            Dim index As Integer = -1
            Dim selectStart As Integer = Consola.SelectionStart
            index = Consola.Text.IndexOf(word, index + 1)
            While index <> -1
                Consola.Select(index + starIndex, word.Length)
                Consola.SelectionColor = color
                Consola.Select(selectStart, 0)
                Consola.SelectionColor = Color.Black
                index = Consola.Text.IndexOf(word, index + 1)
            End While
        End If
    End Sub

    Private Sub Colorear()
        If listaErrores IsNot Nothing Then
            For Each Errores As Errores In listaErrores
                CheckKeyWord(Errores.Perr, Color.Blue, 0)
            Next
        End If
        If listaToken IsNot Nothing Then
            For Each token As Token In listaToken
                If token.PToken >= 1000 And token.PToken <= 12000 Then
                    Prueba(token.Plexema, Color.Yellow)
                ElseIf token.PToken = 9 Or token.PToken = 10 Or token.PToken = 11 Then
                    Prueba(token.Plexema, Color.Lime)
                ElseIf token.PToken = 6 Or token.PToken = 7 Or token.PToken = 8 Or token.PToken = 5 Then
                    Prueba(token.Plexema, Color.Black)
                ElseIf token.PToken = 1 Or token.PToken = 2 Or token.PToken = 3 Or token.PToken = 4 Or token.PToken = 12 Or token.PToken = 13 Then
                    Prueba(token.Plexema, Color.Crimson)
                ElseIf token.PToken = 14 Or token.PToken = 300 Then
                    Prueba(token.Plexema, Color.Purple)
                ElseIf token.PToken = 200 Then
                    Prueba(token.Plexema, Color.LightSkyBlue)
                ElseIf token.PToken = 100 Then
                    Prueba(token.Plexema, Color.Magenta)
                End If
            Next
        End If
    End Sub

    Private Sub ColorearSintaxis()
        If listaErrores IsNot Nothing Then
            For Each Errores As Errores In listaErrores
                If Errores.Ptipo = "Sintactico" Then
                    Dim linea = Errores.PFila - 1
                    Consola.Select(Consola.GetFirstCharIndexFromLine(linea), Consola.Lines(linea).Length)
                    Consola.SelectionColor = Color.Blue
                    Consola.DeselectAll()
                End If
            Next
        End If
    End Sub
End Class
