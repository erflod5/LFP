<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.InicioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GuardarComoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalizarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AnalizarLexicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReporteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiagramaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualDeUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManuaTecnicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Consola = New System.Windows.Forms.RichTextBox()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.InicioToolStripMenuItem, Me.AnalizarToolStripMenuItem, Me.ReportesToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1028, 28)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'InicioToolStripMenuItem
        '
        Me.InicioToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AbrirToolStripMenuItem, Me.GuardarToolStripMenuItem, Me.GuardarComoToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.InicioToolStripMenuItem.Name = "InicioToolStripMenuItem"
        Me.InicioToolStripMenuItem.Size = New System.Drawing.Size(54, 24)
        Me.InicioToolStripMenuItem.Text = "Abrir"
        '
        'AbrirToolStripMenuItem
        '
        Me.AbrirToolStripMenuItem.Name = "AbrirToolStripMenuItem"
        Me.AbrirToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.AbrirToolStripMenuItem.Text = "Abrir"
        '
        'GuardarToolStripMenuItem
        '
        Me.GuardarToolStripMenuItem.Name = "GuardarToolStripMenuItem"
        Me.GuardarToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.GuardarToolStripMenuItem.Text = "Guardar"
        '
        'GuardarComoToolStripMenuItem
        '
        Me.GuardarComoToolStripMenuItem.Name = "GuardarComoToolStripMenuItem"
        Me.GuardarComoToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.GuardarComoToolStripMenuItem.Text = "Guardar Como"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(181, 26)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'AnalizarToolStripMenuItem
        '
        Me.AnalizarToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AnalizarLexicoToolStripMenuItem})
        Me.AnalizarToolStripMenuItem.Name = "AnalizarToolStripMenuItem"
        Me.AnalizarToolStripMenuItem.Size = New System.Drawing.Size(75, 24)
        Me.AnalizarToolStripMenuItem.Text = "Analizar"
        '
        'AnalizarLexicoToolStripMenuItem
        '
        Me.AnalizarLexicoToolStripMenuItem.Name = "AnalizarLexicoToolStripMenuItem"
        Me.AnalizarLexicoToolStripMenuItem.Size = New System.Drawing.Size(184, 26)
        Me.AnalizarLexicoToolStripMenuItem.Text = "Analizar Lexico"
        '
        'ReportesToolStripMenuItem
        '
        Me.ReportesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ReporteToolStripMenuItem, Me.DiagramaToolStripMenuItem})
        Me.ReportesToolStripMenuItem.Name = "ReportesToolStripMenuItem"
        Me.ReportesToolStripMenuItem.Size = New System.Drawing.Size(80, 24)
        Me.ReportesToolStripMenuItem.Text = "Reportes"
        '
        'ReporteToolStripMenuItem
        '
        Me.ReporteToolStripMenuItem.Name = "ReporteToolStripMenuItem"
        Me.ReporteToolStripMenuItem.Size = New System.Drawing.Size(150, 26)
        Me.ReporteToolStripMenuItem.Text = "Reporte"
        '
        'DiagramaToolStripMenuItem
        '
        Me.DiagramaToolStripMenuItem.Name = "DiagramaToolStripMenuItem"
        Me.DiagramaToolStripMenuItem.Size = New System.Drawing.Size(150, 26)
        Me.DiagramaToolStripMenuItem.Text = "Diagrama"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManualDeUsuarioToolStripMenuItem, Me.ManuaTecnicoToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(63, 24)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'ManualDeUsuarioToolStripMenuItem
        '
        Me.ManualDeUsuarioToolStripMenuItem.Name = "ManualDeUsuarioToolStripMenuItem"
        Me.ManualDeUsuarioToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ManualDeUsuarioToolStripMenuItem.Text = "Manual de Usuario"
        '
        'ManuaTecnicoToolStripMenuItem
        '
        Me.ManuaTecnicoToolStripMenuItem.Name = "ManuaTecnicoToolStripMenuItem"
        Me.ManuaTecnicoToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ManuaTecnicoToolStripMenuItem.Text = "Manua Tecnico"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca De"
        '
        'Consola
        '
        Me.Consola.AcceptsTab = True
        Me.Consola.BackColor = System.Drawing.SystemColors.WindowFrame
        Me.Consola.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Consola.ForeColor = System.Drawing.Color.FloralWhite
        Me.Consola.Location = New System.Drawing.Point(22, 47)
        Me.Consola.Margin = New System.Windows.Forms.Padding(5)
        Me.Consola.Name = "Consola"
        Me.Consola.Size = New System.Drawing.Size(975, 647)
        Me.Consola.TabIndex = 1
        Me.Consola.Text = ""
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1028, 718)
        Me.Controls.Add(Me.Consola)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "Analizador Lexico-Sintactico"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents InicioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AbrirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents GuardarComoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnalizarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AnalizarLexicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReportesToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReporteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DiagramaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualDeUsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManuaTecnicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Consola As RichTextBox
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents SaveFile As SaveFileDialog
End Class
