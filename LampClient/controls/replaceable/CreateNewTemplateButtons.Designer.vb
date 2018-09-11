<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CreateNewTemplateButtons
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.RootTableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.ExportDxf = New System.Windows.Forms.Button()
        Me.ExportSpf = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnSubmitTemplate = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ImportSpf = New System.Windows.Forms.Button()
        Me.ImportDxf = New System.Windows.Forms.Button()
        Me.DxfFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.DxfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.RootTableLayoutPanel.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RootTableLayoutPanel
        '
        Me.RootTableLayoutPanel.ColumnCount = 3
        Me.RootTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.RootTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0!))
        Me.RootTableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.RootTableLayoutPanel.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.RootTableLayoutPanel.Controls.Add(Me.TableLayoutPanel3, 2, 0)
        Me.RootTableLayoutPanel.Controls.Add(Me.TableLayoutPanel1, 0, 0)
        Me.RootTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootTableLayoutPanel.Location = New System.Drawing.Point(0, 0)
        Me.RootTableLayoutPanel.Margin = New System.Windows.Forms.Padding(0)
        Me.RootTableLayoutPanel.Name = "RootTableLayoutPanel"
        Me.RootTableLayoutPanel.RowCount = 1
        Me.RootTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RootTableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.RootTableLayoutPanel.Size = New System.Drawing.Size(353, 155)
        Me.RootTableLayoutPanel.TabIndex = 0
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.ExportDxf, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.ExportSpf, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(88, 0)
        Me.TableLayoutPanel2.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(123, 155)
        Me.TableLayoutPanel2.TabIndex = 45
        '
        'ExportDxf
        '
        Me.ExportDxf.BackColor = System.Drawing.Color.White
        Me.ExportDxf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExportDxf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportDxf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ExportDxf.Location = New System.Drawing.Point(4, 4)
        Me.ExportDxf.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportDxf.Name = "ExportDxf"
        Me.ExportDxf.Size = New System.Drawing.Size(115, 69)
        Me.ExportDxf.TabIndex = 43
        Me.ExportDxf.Text = "Export To DXF"
        Me.ExportDxf.UseVisualStyleBackColor = False
        '
        'ExportSpf
        '
        Me.ExportSpf.BackColor = System.Drawing.Color.White
        Me.ExportSpf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExportSpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportSpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ExportSpf.Location = New System.Drawing.Point(4, 81)
        Me.ExportSpf.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportSpf.Name = "ExportSpf"
        Me.ExportSpf.Size = New System.Drawing.Size(115, 70)
        Me.ExportSpf.TabIndex = 42
        Me.ExportSpf.Text = "Export To SPF"
        Me.ExportSpf.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnSubmitTemplate, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(211, 0)
        Me.TableLayoutPanel3.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(142, 155)
        Me.TableLayoutPanel3.TabIndex = 46
        '
        'btnSubmitTemplate
        '
        Me.btnSubmitTemplate.BackColor = System.Drawing.Color.White
        Me.btnSubmitTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSubmitTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.btnSubmitTemplate.Location = New System.Drawing.Point(4, 4)
        Me.btnSubmitTemplate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubmitTemplate.Name = "btnSubmitTemplate"
        Me.btnSubmitTemplate.Size = New System.Drawing.Size(134, 69)
        Me.btnSubmitTemplate.TabIndex = 45
        Me.btnSubmitTemplate.Text = "Submit To Database"
        Me.btnSubmitTemplate.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ImportSpf, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ImportDxf, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(88, 155)
        Me.TableLayoutPanel1.TabIndex = 47
        '
        'ImportSpf
        '
        Me.ImportSpf.BackColor = System.Drawing.Color.White
        Me.ImportSpf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportSpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportSpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ImportSpf.Location = New System.Drawing.Point(4, 81)
        Me.ImportSpf.Margin = New System.Windows.Forms.Padding(4)
        Me.ImportSpf.Name = "ImportSpf"
        Me.ImportSpf.Size = New System.Drawing.Size(80, 70)
        Me.ImportSpf.TabIndex = 47
        Me.ImportSpf.Text = "Load Spf"
        Me.ImportSpf.UseVisualStyleBackColor = False
        '
        'ImportDxf
        '
        Me.ImportDxf.BackColor = System.Drawing.Color.White
        Me.ImportDxf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportDxf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportDxf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ImportDxf.Location = New System.Drawing.Point(4, 4)
        Me.ImportDxf.Margin = New System.Windows.Forms.Padding(4)
        Me.ImportDxf.Name = "ImportDxf"
        Me.ImportDxf.Size = New System.Drawing.Size(80, 69)
        Me.ImportDxf.TabIndex = 45
        Me.ImportDxf.Text = "Load DXF"
        Me.ImportDxf.UseVisualStyleBackColor = False
        '
        'DxfFileDialog
        '
        Me.DxfFileDialog.Filter = "dxf file|*.dxf|All files|*.*"
        '
        'DxfSaveDialog
        '
        Me.DxfSaveDialog.Filter = "dxf file|*.dxf|All files|*.*"
        '
        'SpfSaveDialog
        '
        Me.SpfSaveDialog.Filter = "spf file|*.spf|All files|*.*"
        '
        'SpfOpenDialog
        '
        Me.SpfOpenDialog.FileName = "SpfFileDialog"
        Me.SpfOpenDialog.Filter = "spf file|*.spf|All files|*.*"
        '
        'CreateNewTemplateButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RootTableLayoutPanel)
        Me.Name = "CreateNewTemplateButtons"
        Me.Size = New System.Drawing.Size(353, 155)
        Me.RootTableLayoutPanel.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RootTableLayoutPanel As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents ExportDxf As Button
    Friend WithEvents ExportSpf As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents btnSubmitTemplate As Button
    Friend WithEvents DxfFileDialog As OpenFileDialog
    Friend WithEvents DxfSaveDialog As SaveFileDialog
    Friend WithEvents SpfSaveDialog As SaveFileDialog
    Friend WithEvents SpfOpenDialog As OpenFileDialog
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ImportSpf As Button
    Friend WithEvents ImportDxf As Button
End Class
