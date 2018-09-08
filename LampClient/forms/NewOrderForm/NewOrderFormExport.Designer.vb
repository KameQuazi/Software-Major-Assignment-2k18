<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewOrderFormExport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.gboxSummary = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.rtboxSummary = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gboxExport = New System.Windows.Forms.GroupBox()
        Me.btnExportDxf = New System.Windows.Forms.Button()
        Me.btnExportJob = New System.Windows.Forms.Button()
        Me.btnSubmitJob = New System.Windows.Forms.Button()
        Me.gboxGenerated = New System.Windows.Forms.GroupBox()
        Me.MultiDrawingViewerControl1 = New LampClient.MultiDrawingViewerControl()
        Me.DxfListSaveFileDialog = New System.Windows.Forms.FolderBrowserDialog()
        Me.JobSaveFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.gboxSummary.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.gboxExport.SuspendLayout()
        Me.gboxGenerated.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ToolBar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 38
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ToolBar1.ConfirmationRequired = Nothing
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = True
        Me.ToolBar1.Location = New System.Drawing.Point(3, 3)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = False
        Me.ToolBar1.NewTemplateEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1226, 99)
        Me.ToolBar1.TabIndex = 37
        Me.ToolBar1.ViewOrderEnabled = True
        Me.ToolBar1.ViewTemplateEnabled = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gboxGenerated, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1226, 592)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.gboxSummary, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.gboxExport, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(738, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(239, 586)
        Me.TableLayoutPanel3.TabIndex = 41
        '
        'gboxSummary
        '
        Me.gboxSummary.Controls.Add(Me.TableLayoutPanel4)
        Me.gboxSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxSummary.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.gboxSummary.Location = New System.Drawing.Point(3, 3)
        Me.gboxSummary.Name = "gboxSummary"
        Me.gboxSummary.Size = New System.Drawing.Size(233, 228)
        Me.gboxSummary.TabIndex = 0
        Me.gboxSummary.TabStop = False
        Me.gboxSummary.Text = "Summary"
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.rtboxSummary, 0, 1)
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 27)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(227, 198)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'rtboxSummary
        '
        Me.rtboxSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.rtboxSummary.Location = New System.Drawing.Point(15, 31)
        Me.rtboxSummary.Margin = New System.Windows.Forms.Padding(15)
        Me.rtboxSummary.Name = "rtboxSummary"
        Me.rtboxSummary.Size = New System.Drawing.Size(197, 152)
        Me.rtboxSummary.TabIndex = 2
        Me.rtboxSummary.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(161, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Summary (optional):"
        '
        'gboxExport
        '
        Me.gboxExport.Controls.Add(Me.btnExportDxf)
        Me.gboxExport.Controls.Add(Me.btnExportJob)
        Me.gboxExport.Controls.Add(Me.btnSubmitJob)
        Me.gboxExport.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxExport.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.gboxExport.Location = New System.Drawing.Point(3, 237)
        Me.gboxExport.Name = "gboxExport"
        Me.gboxExport.Size = New System.Drawing.Size(233, 346)
        Me.gboxExport.TabIndex = 1
        Me.gboxExport.TabStop = False
        Me.gboxExport.Text = "Export Options"
        '
        'btnExportDxf
        '
        Me.btnExportDxf.BackColor = System.Drawing.Color.White
        Me.btnExportDxf.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnExportDxf.Location = New System.Drawing.Point(9, 140)
        Me.btnExportDxf.Name = "btnExportDxf"
        Me.btnExportDxf.Size = New System.Drawing.Size(138, 49)
        Me.btnExportDxf.TabIndex = 16
        Me.btnExportDxf.Text = "Export as DXF"
        Me.btnExportDxf.UseVisualStyleBackColor = False
        '
        'btnExportJob
        '
        Me.btnExportJob.BackColor = System.Drawing.Color.White
        Me.btnExportJob.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnExportJob.Location = New System.Drawing.Point(6, 85)
        Me.btnExportJob.Name = "btnExportJob"
        Me.btnExportJob.Size = New System.Drawing.Size(138, 49)
        Me.btnExportJob.TabIndex = 15
        Me.btnExportJob.Text = "Save as JOB"
        Me.btnExportJob.UseVisualStyleBackColor = False
        '
        'btnSubmitJob
        '
        Me.btnSubmitJob.BackColor = System.Drawing.Color.White
        Me.btnSubmitJob.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnSubmitJob.Location = New System.Drawing.Point(6, 30)
        Me.btnSubmitJob.Name = "btnSubmitJob"
        Me.btnSubmitJob.Size = New System.Drawing.Size(138, 49)
        Me.btnSubmitJob.TabIndex = 14
        Me.btnSubmitJob.Text = "Submit Job"
        Me.btnSubmitJob.UseVisualStyleBackColor = False
        '
        'gboxGenerated
        '
        Me.gboxGenerated.Controls.Add(Me.MultiDrawingViewerControl1)
        Me.gboxGenerated.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxGenerated.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.gboxGenerated.Location = New System.Drawing.Point(3, 3)
        Me.gboxGenerated.Name = "gboxGenerated"
        Me.gboxGenerated.Size = New System.Drawing.Size(729, 586)
        Me.gboxGenerated.TabIndex = 42
        Me.gboxGenerated.TabStop = False
        Me.gboxGenerated.Text = "Generated Drawings"
        '
        'MultiDrawingViewerControl1
        '
        Me.MultiDrawingViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MultiDrawingViewerControl1.Location = New System.Drawing.Point(3, 27)
        Me.MultiDrawingViewerControl1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.MultiDrawingViewerControl1.Name = "MultiDrawingViewerControl1"
        Me.MultiDrawingViewerControl1.Size = New System.Drawing.Size(723, 556)
        Me.MultiDrawingViewerControl1.TabIndex = 0
        Me.MultiDrawingViewerControl1.ZoomFactor = 1.0R
        Me.MultiDrawingViewerControl1.ZoomxX = 1.0R
        Me.MultiDrawingViewerControl1.ZoomxY = 1.0R
        '
        'JobSaveFileDialog
        '
        Me.JobSaveFileDialog.Filter = "Job file|*.job|All files|*.*"
        '
        'NewOrderFormExport
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "NewOrderFormExport"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAMP - Create New Job"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.gboxSummary.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.gboxExport.ResumeLayout(False)
        Me.gboxGenerated.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents gboxGenerated As GroupBox
    Friend WithEvents MultiDrawingViewerControl1 As MultiDrawingViewerControl
    Friend WithEvents gboxSummary As GroupBox
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents rtboxSummary As RichTextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gboxExport As GroupBox
    Friend WithEvents btnExportDxf As Button
    Friend WithEvents btnExportJob As Button
    Friend WithEvents btnSubmitJob As Button
    Friend WithEvents DxfListSaveFileDialog As FolderBrowserDialog
    Friend WithEvents JobSaveFileDialog As SaveFileDialog
End Class
