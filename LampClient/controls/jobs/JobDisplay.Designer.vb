<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobDisplay
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
        Dim LampTemplate1 As LampCommon.LampTemplate = New LampCommon.LampTemplate()
        Dim LampDxfDocument1 As LampCommon.LampDxfDocument = New LampCommon.LampDxfDocument()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.FileDisplay1 = New LampClient.TemplateDisplay()
        Me.SimpleProfileDisplay2 = New LampClient.SimpleProfileDisplay()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.SimpleProfileDisplay1 = New LampClient.SimpleProfileDisplay()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tboxSummary = New System.Windows.Forms.RichTextBox()
        Me.btnAdvanced = New System.Windows.Forms.Button()
        Me.btnViewDrawing = New System.Windows.Forms.Button()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FileDisplay1, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(961, 304)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Controls.Add(Me.SimpleProfileDisplay2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(474, 298)
        Me.Panel1.TabIndex = 1
        '
        'FileDisplay1
        '
        Me.FileDisplay1.BackColor = System.Drawing.Color.White
        Me.FileDisplay1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.FileDisplay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FileDisplay1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay1.HighLightColor = System.Drawing.Color.AliceBlue
        Me.FileDisplay1.Location = New System.Drawing.Point(483, 3)
        Me.FileDisplay1.MouseOverHighlight = False
        Me.FileDisplay1.Name = "FileDisplay1"
        Me.FileDisplay1.Size = New System.Drawing.Size(475, 298)
        Me.FileDisplay1.TabIndex = 3
        LampTemplate1.ApproverProfile = Nothing
        LampTemplate1.BaseDrawing = LampDxfDocument1
        LampTemplate1.CreatorProfile = Nothing
        LampTemplate1.GUID = "cef4512c-eb16-4eb4-ac49-71de15c81646"
        LampTemplate1.Height = 0R
        LampTemplate1.IsComplete = False
        LampTemplate1.Length = 0R
        LampTemplate1.LongDescription = ""
        LampTemplate1.Material = "Unspecified"
        LampTemplate1.MaterialThickness = 0R
        LampTemplate1.Name = ""
        LampTemplate1.ShortDescription = ""
        LampTemplate1.SubmitDate = Nothing
        Me.FileDisplay1.Template = LampTemplate1
        '
        'SimpleProfileDisplay2
        '
        Me.SimpleProfileDisplay2.DetailedEnabled = True
        Me.SimpleProfileDisplay2.Location = New System.Drawing.Point(111, 94)
        Me.SimpleProfileDisplay2.Name = "SimpleProfileDisplay2"
        Me.SimpleProfileDisplay2.Profile = Nothing
        Me.SimpleProfileDisplay2.Readonly = True
        Me.SimpleProfileDisplay2.Size = New System.Drawing.Size(8, 8)
        Me.SimpleProfileDisplay2.TabIndex = 1
        Me.SimpleProfileDisplay2.TitleText = "Title"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.SimpleProfileDisplay1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(474, 298)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'SimpleProfileDisplay1
        '
        Me.SimpleProfileDisplay1.DetailedEnabled = True
        Me.SimpleProfileDisplay1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SimpleProfileDisplay1.Location = New System.Drawing.Point(4, 4)
        Me.SimpleProfileDisplay1.Name = "SimpleProfileDisplay1"
        Me.SimpleProfileDisplay1.Profile = Nothing
        Me.SimpleProfileDisplay1.Readonly = True
        Me.SimpleProfileDisplay1.Size = New System.Drawing.Size(466, 82)
        Me.SimpleProfileDisplay1.TabIndex = 1
        Me.SimpleProfileDisplay1.TitleText = "Title"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 3
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel3.Controls.Add(Me.btnApprove, 2, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnViewDrawing, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.btnAdvanced, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(4, 241)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(466, 53)
        Me.TableLayoutPanel3.TabIndex = 2
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.Label1, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.tboxSummary, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(4, 93)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(466, 141)
        Me.TableLayoutPanel4.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(178, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Summary"
        '
        'tboxSummary
        '
        Me.tboxSummary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tboxSummary.Location = New System.Drawing.Point(6, 31)
        Me.tboxSummary.Margin = New System.Windows.Forms.Padding(6)
        Me.tboxSummary.Name = "tboxSummary"
        Me.tboxSummary.Size = New System.Drawing.Size(454, 104)
        Me.tboxSummary.TabIndex = 1
        Me.tboxSummary.Text = ""
        '
        'btnAdvanced
        '
        Me.btnAdvanced.BackColor = System.Drawing.Color.White
        Me.btnAdvanced.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAdvanced.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAdvanced.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdvanced.Location = New System.Drawing.Point(5, 5)
        Me.btnAdvanced.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAdvanced.Name = "btnAdvanced"
        Me.btnAdvanced.Size = New System.Drawing.Size(145, 43)
        Me.btnAdvanced.TabIndex = 45
        Me.btnAdvanced.Text = "Advanced Options"
        Me.btnAdvanced.UseVisualStyleBackColor = False
        '
        'btnViewDrawing
        '
        Me.btnViewDrawing.BackColor = System.Drawing.Color.White
        Me.btnViewDrawing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnViewDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDrawing.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewDrawing.Location = New System.Drawing.Point(160, 5)
        Me.btnViewDrawing.Margin = New System.Windows.Forms.Padding(5)
        Me.btnViewDrawing.Name = "btnViewDrawing"
        Me.btnViewDrawing.Size = New System.Drawing.Size(145, 43)
        Me.btnViewDrawing.TabIndex = 46
        Me.btnViewDrawing.Text = "View Drawing(s)"
        Me.btnViewDrawing.UseVisualStyleBackColor = False
        '
        'btnApprove
        '
        Me.btnApprove.BackColor = System.Drawing.Color.White
        Me.btnApprove.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnApprove.Location = New System.Drawing.Point(315, 5)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(5)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(146, 43)
        Me.btnApprove.TabIndex = 47
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'JobDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "JobDisplay"
        Me.Size = New System.Drawing.Size(961, 304)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents FileDisplay1 As TemplateDisplay
    Friend WithEvents SimpleProfileDisplay2 As SimpleProfileDisplay
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents SimpleProfileDisplay1 As SimpleProfileDisplay
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents tboxSummary As RichTextBox
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnViewDrawing As Button
    Friend WithEvents btnAdvanced As Button
End Class
