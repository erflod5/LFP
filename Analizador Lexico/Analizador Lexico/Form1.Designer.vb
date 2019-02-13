<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class framePrincipal
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.menuP = New System.Windows.Forms.MenuStrip()
        Me.menuArchivo = New System.Windows.Forms.ToolStripMenuItem()
        Me.funcionAbrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.funcionGuardar = New System.Windows.Forms.ToolStripMenuItem()
        Me.funcionGuardarComo = New System.Windows.Forms.ToolStripMenuItem()
        Me.funcionSalir = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuAbrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.funcionAnalizarLexico = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuReportes = New System.Windows.Forms.ToolStripMenuItem()
        Me.funcionReporte = New System.Windows.Forms.ToolStripMenuItem()
        Me.DiagramarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualDeUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ManualTecnicoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaveFile = New System.Windows.Forms.SaveFileDialog()
        Me.OpenFile = New System.Windows.Forms.OpenFileDialog()
        Me.consolaAnalizador = New System.Windows.Forms.TextBox()
        Me.panelAnalizador = New System.Windows.Forms.Panel()
        Me.menuP.SuspendLayout()
        Me.panelAnalizador.SuspendLayout()
        Me.SuspendLayout()
        '
        'menuP
        '
        Me.menuP.BackColor = System.Drawing.SystemColors.Highlight
        Me.menuP.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuP.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuArchivo, Me.menuAbrir, Me.menuReportes, Me.AyudaToolStripMenuItem})
        Me.menuP.Location = New System.Drawing.Point(0, 0)
        Me.menuP.Name = "menuP"
        Me.menuP.Padding = New System.Windows.Forms.Padding(5, 2, 0, 2)
        Me.menuP.Size = New System.Drawing.Size(838, 28)
        Me.menuP.TabIndex = 0
        Me.menuP.Text = "MenuStrip1"
        '
        'menuArchivo
        '
        Me.menuArchivo.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.funcionAbrir, Me.funcionGuardar, Me.funcionGuardarComo, Me.funcionSalir})
        Me.menuArchivo.Name = "menuArchivo"
        Me.menuArchivo.Size = New System.Drawing.Size(71, 24)
        Me.menuArchivo.Text = "Archivo"
        '
        'funcionAbrir
        '
        Me.funcionAbrir.Name = "funcionAbrir"
        Me.funcionAbrir.Size = New System.Drawing.Size(181, 26)
        Me.funcionAbrir.Text = "Abrir"
        '
        'funcionGuardar
        '
        Me.funcionGuardar.Name = "funcionGuardar"
        Me.funcionGuardar.Size = New System.Drawing.Size(181, 26)
        Me.funcionGuardar.Text = "Guardar"
        '
        'funcionGuardarComo
        '
        Me.funcionGuardarComo.Name = "funcionGuardarComo"
        Me.funcionGuardarComo.Size = New System.Drawing.Size(181, 26)
        Me.funcionGuardarComo.Text = "Guardar Como"
        '
        'funcionSalir
        '
        Me.funcionSalir.Name = "funcionSalir"
        Me.funcionSalir.Size = New System.Drawing.Size(181, 26)
        Me.funcionSalir.Text = "Salir"
        '
        'menuAbrir
        '
        Me.menuAbrir.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.funcionAnalizarLexico})
        Me.menuAbrir.Name = "menuAbrir"
        Me.menuAbrir.Size = New System.Drawing.Size(75, 24)
        Me.menuAbrir.Text = "Analizar"
        '
        'funcionAnalizarLexico
        '
        Me.funcionAnalizarLexico.Name = "funcionAnalizarLexico"
        Me.funcionAnalizarLexico.Size = New System.Drawing.Size(184, 26)
        Me.funcionAnalizarLexico.Text = "Analizar Léxico"
        '
        'menuReportes
        '
        Me.menuReportes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.funcionReporte, Me.DiagramarToolStripMenuItem})
        Me.menuReportes.Name = "menuReportes"
        Me.menuReportes.Size = New System.Drawing.Size(80, 24)
        Me.menuReportes.Text = "Reportes"
        '
        'funcionReporte
        '
        Me.funcionReporte.Name = "funcionReporte"
        Me.funcionReporte.Size = New System.Drawing.Size(216, 26)
        Me.funcionReporte.Text = "Reporte de Tokens"
        '
        'DiagramarToolStripMenuItem
        '
        Me.DiagramarToolStripMenuItem.Name = "DiagramarToolStripMenuItem"
        Me.DiagramarToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.DiagramarToolStripMenuItem.Text = "Diagramar"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ManualDeUsuarioToolStripMenuItem, Me.ManualTecnicoToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
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
        'ManualTecnicoToolStripMenuItem
        '
        Me.ManualTecnicoToolStripMenuItem.Name = "ManualTecnicoToolStripMenuItem"
        Me.ManualTecnicoToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.ManualTecnicoToolStripMenuItem.Text = "Manual Tecnico"
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(216, 26)
        Me.AcercaDeToolStripMenuItem.Text = "Acerca De"
        '
        'OpenFile
        '
        Me.OpenFile.FileName = "OpenFileDialog1"
        '
        'consolaAnalizador
        '
        Me.consolaAnalizador.AcceptsReturn = True
        Me.consolaAnalizador.AcceptsTab = True
        Me.consolaAnalizador.BackColor = System.Drawing.Color.Black
        Me.consolaAnalizador.Font = New System.Drawing.Font("Comic Sans MS", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.consolaAnalizador.ForeColor = System.Drawing.Color.White
        Me.consolaAnalizador.Location = New System.Drawing.Point(32, 22)
        Me.consolaAnalizador.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.consolaAnalizador.Multiline = True
        Me.consolaAnalizador.Name = "consolaAnalizador"
        Me.consolaAnalizador.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.consolaAnalizador.Size = New System.Drawing.Size(764, 526)
        Me.consolaAnalizador.TabIndex = 0
        '
        'panelAnalizador
        '
        Me.panelAnalizador.BackColor = System.Drawing.SystemColors.HighlightText
        Me.panelAnalizador.Controls.Add(Me.consolaAnalizador)
        Me.panelAnalizador.Location = New System.Drawing.Point(0, 29)
        Me.panelAnalizador.Name = "panelAnalizador"
        Me.panelAnalizador.Size = New System.Drawing.Size(828, 574)
        Me.panelAnalizador.TabIndex = 1
        '
        'framePrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(838, 614)
        Me.Controls.Add(Me.panelAnalizador)
        Me.Controls.Add(Me.menuP)
        Me.Font = New System.Drawing.Font("Monotype Corsiva", 7.8!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MainMenuStrip = Me.menuP
        Me.MaximizeBox = False
        Me.MinimumSize = New System.Drawing.Size(738, 591)
        Me.Name = "framePrincipal"
        Me.Text = "Analizador Léxico"
        Me.menuP.ResumeLayout(False)
        Me.menuP.PerformLayout()
        Me.panelAnalizador.ResumeLayout(False)
        Me.panelAnalizador.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents menuP As MenuStrip
    Friend WithEvents menuArchivo As ToolStripMenuItem
    Friend WithEvents funcionAbrir As ToolStripMenuItem
    Friend WithEvents funcionGuardar As ToolStripMenuItem
    Friend WithEvents funcionGuardarComo As ToolStripMenuItem
    Friend WithEvents funcionSalir As ToolStripMenuItem
    Friend WithEvents menuAbrir As ToolStripMenuItem
    Friend WithEvents funcionAnalizarLexico As ToolStripMenuItem
    Friend WithEvents menuReportes As ToolStripMenuItem
    Friend WithEvents funcionReporte As ToolStripMenuItem
    Friend WithEvents SaveFile As SaveFileDialog
    Friend WithEvents OpenFile As OpenFileDialog
    Friend WithEvents consolaAnalizador As TextBox
    Friend WithEvents panelAnalizador As Panel
    Friend WithEvents DiagramarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualDeUsuarioToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ManualTecnicoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As ToolStripMenuItem
End Class
