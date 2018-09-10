<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TemplateCreatorControl
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateCreatorControl))
        Me.btnViewDrawing = New System.Windows.Forms.Button()
        Me.TboxApprove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Preview3 = New System.Windows.Forms.PictureBox()
        Me.Preview2 = New System.Windows.Forms.PictureBox()
        Me.Preview1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameBox = New System.Windows.Forms.TextBox()
        Me.btnSubmitTemplate = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LongDescription = New System.Windows.Forms.RichTextBox()
        Me.ShortDescription = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.RemoveTag = New System.Windows.Forms.Button()
        Me.ComboBoxMaterial = New System.Windows.Forms.ComboBox()
        Me.TboxThickness = New System.Windows.Forms.TextBox()
        Me.TagsBox = New System.Windows.Forms.ListBox()
        Me.btnNewJob = New System.Windows.Forms.Button()
        Me.AddTag = New System.Windows.Forms.Button()
        Me.ImportSpf = New System.Windows.Forms.Button()
        Me.ExportDxf = New System.Windows.Forms.Button()
        Me.ExportSpf = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnSetDrawing = New System.Windows.Forms.Button()
        Me.DrawingDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.ErrorProviderThickness = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DxfFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.DxfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProviderName = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DynamicFormCreation1 = New LampClient.DynamicFormCreation()
        Me.DxfViewerControl1 = New LampClient.DxfViewerControl()
        Me.TagEditorControl1 = New LampClient.TagEditorControl()
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ErrorProviderThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnViewDrawing
        '
        Me.btnViewDrawing.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnViewDrawing.BackColor = System.Drawing.Color.White
        Me.btnViewDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDrawing.Location = New System.Drawing.Point(215, 16)
        Me.btnViewDrawing.Margin = New System.Windows.Forms.Padding(16)
        Me.btnViewDrawing.Name = "btnViewDrawing"
        Me.btnViewDrawing.Size = New System.Drawing.Size(100, 24)
        Me.btnViewDrawing.TabIndex = 17
        Me.btnViewDrawing.Text = "View Drawing"
        Me.btnViewDrawing.UseVisualStyleBackColor = False
        '
        'TboxApprove
        '
        Me.TboxApprove.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TboxApprove.Location = New System.Drawing.Point(121, 184)
        Me.TboxApprove.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.TboxApprove.MaxLength = 38
        Me.TboxApprove.Name = "TboxApprove"
        Me.TboxApprove.Size = New System.Drawing.Size(203, 20)
        Me.TboxApprove.TabIndex = 53
        '
        'Label6
        '
        Me.Label6.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(34, 188)
        Me.Label6.Margin = New System.Windows.Forms.Padding(8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "Approval Status:"
        '
        'Preview3
        '
        Me.Preview3.BackColor = System.Drawing.Color.White
        Me.Preview3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview3.Location = New System.Drawing.Point(509, 19)
        Me.Preview3.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview3.Name = "Preview3"
        Me.Preview3.Size = New System.Drawing.Size(253, 254)
        Me.Preview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview3.TabIndex = 33
        Me.Preview3.TabStop = False
        '
        'Preview2
        '
        Me.Preview2.BackColor = System.Drawing.Color.White
        Me.Preview2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview2.Location = New System.Drawing.Point(258, 19)
        Me.Preview2.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview2.Name = "Preview2"
        Me.Preview2.Size = New System.Drawing.Size(253, 254)
        Me.Preview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview2.TabIndex = 32
        Me.Preview2.TabStop = False
        '
        'Preview1
        '
        Me.Preview1.BackColor = System.Drawing.Color.White
        Me.Preview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview1.Location = New System.Drawing.Point(6, 19)
        Me.Preview1.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview1.Name = "Preview1"
        Me.Preview1.Size = New System.Drawing.Size(253, 254)
        Me.Preview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview1.TabIndex = 30
        Me.Preview1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 16)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Name:"
        '
        'NameBox
        '
        Me.NameBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.NameBox.Location = New System.Drawing.Point(121, 13)
        Me.NameBox.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.NameBox.MaxLength = 38
        Me.NameBox.Name = "NameBox"
        Me.NameBox.Size = New System.Drawing.Size(203, 20)
        Me.NameBox.TabIndex = 35
        '
        'btnSubmitTemplate
        '
        Me.btnSubmitTemplate.BackColor = System.Drawing.Color.White
        Me.btnSubmitTemplate.Enabled = False
        Me.btnSubmitTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitTemplate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.btnSubmitTemplate.Location = New System.Drawing.Point(593, 31)
        Me.btnSubmitTemplate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubmitTemplate.Name = "btnSubmitTemplate"
        Me.btnSubmitTemplate.Size = New System.Drawing.Size(120, 56)
        Me.btnSubmitTemplate.TabIndex = 40
        Me.btnSubmitTemplate.Text = "Submit To Database"
        Me.btnSubmitTemplate.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(38, 77)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 46
        Me.Label3.Text = "Short Summary:"
        '
        'LongDescription
        '
        Me.LongDescription.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.LongDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.LongDescription.Location = New System.Drawing.Point(121, 20)
        Me.LongDescription.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.LongDescription.Name = "LongDescription"
        Me.LongDescription.Size = New System.Drawing.Size(203, 137)
        Me.LongDescription.TabIndex = 47
        Me.LongDescription.Text = ""
        '
        'ShortDescription
        '
        Me.ShortDescription.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ShortDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ShortDescription.Location = New System.Drawing.Point(121, 71)
        Me.ShortDescription.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.ShortDescription.MaxLength = 190
        Me.ShortDescription.Name = "ShortDescription"
        Me.ShortDescription.Size = New System.Drawing.Size(203, 56)
        Me.ShortDescription.TabIndex = 44
        Me.ShortDescription.Text = ""
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(29, 28)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 45
        Me.Label2.Text = "Long Description:"
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(72, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 48
        Me.Label4.Text = "Material:"
        '
        'Label5
        '
        Me.Label5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(60, 163)
        Me.Label5.Margin = New System.Windows.Forms.Padding(8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Thickness:"
        '
        'RemoveTag
        '
        Me.RemoveTag.BackColor = System.Drawing.Color.White
        Me.RemoveTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RemoveTag.Location = New System.Drawing.Point(187, 162)
        Me.RemoveTag.Margin = New System.Windows.Forms.Padding(16)
        Me.RemoveTag.Name = "RemoveTag"
        Me.RemoveTag.Size = New System.Drawing.Size(100, 24)
        Me.RemoveTag.TabIndex = 42
        Me.RemoveTag.Text = "Remove Tag"
        Me.RemoveTag.UseVisualStyleBackColor = False
        '
        'ComboBoxMaterial
        '
        Me.ComboBoxMaterial.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBoxMaterial.FormattingEnabled = True
        Me.ComboBoxMaterial.Location = New System.Drawing.Point(121, 42)
        Me.ComboBoxMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.ComboBoxMaterial.Name = "ComboBoxMaterial"
        Me.ComboBoxMaterial.Size = New System.Drawing.Size(203, 21)
        Me.ComboBoxMaterial.TabIndex = 49
        '
        'TboxThickness
        '
        Me.TboxThickness.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TboxThickness.Location = New System.Drawing.Point(121, 161)
        Me.TboxThickness.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.TboxThickness.MaxLength = 38
        Me.TboxThickness.Name = "TboxThickness"
        Me.TboxThickness.Size = New System.Drawing.Size(203, 20)
        Me.TboxThickness.TabIndex = 51
        '
        'TagsBox
        '
        Me.TagsBox.FormattingEnabled = True
        Me.TagsBox.Items.AddRange(New Object() {""})
        Me.TagsBox.Location = New System.Drawing.Point(8, 15)
        Me.TagsBox.Margin = New System.Windows.Forms.Padding(16)
        Me.TagsBox.Name = "TagsBox"
        Me.TagsBox.Size = New System.Drawing.Size(279, 147)
        Me.TagsBox.TabIndex = 54
        '
        'btnNewJob
        '
        Me.btnNewJob.BackColor = System.Drawing.Color.White
        Me.btnNewJob.Enabled = False
        Me.btnNewJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewJob.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.btnNewJob.Location = New System.Drawing.Point(593, 85)
        Me.btnNewJob.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewJob.Name = "btnNewJob"
        Me.btnNewJob.Size = New System.Drawing.Size(120, 54)
        Me.btnNewJob.TabIndex = 41
        Me.btnNewJob.Text = "Create Job With Template"
        Me.btnNewJob.UseVisualStyleBackColor = False
        '
        'AddTag
        '
        Me.AddTag.BackColor = System.Drawing.Color.White
        Me.AddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddTag.Location = New System.Drawing.Point(88, 162)
        Me.AddTag.Margin = New System.Windows.Forms.Padding(16)
        Me.AddTag.Name = "AddTag"
        Me.AddTag.Size = New System.Drawing.Size(100, 24)
        Me.AddTag.TabIndex = 39
        Me.AddTag.Text = "Add Tag"
        Me.AddTag.UseVisualStyleBackColor = False
        '
        'ImportSpf
        '
        Me.ImportSpf.BackColor = System.Drawing.Color.White
        Me.ImportSpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportSpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ImportSpf.Location = New System.Drawing.Point(422, 31)
        Me.ImportSpf.Margin = New System.Windows.Forms.Padding(4)
        Me.ImportSpf.Name = "ImportSpf"
        Me.ImportSpf.Size = New System.Drawing.Size(79, 108)
        Me.ImportSpf.TabIndex = 38
        Me.ImportSpf.Text = "Load Spf"
        Me.ImportSpf.UseVisualStyleBackColor = False
        '
        'ExportDxf
        '
        Me.ExportDxf.BackColor = System.Drawing.Color.White
        Me.ExportDxf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportDxf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ExportDxf.Location = New System.Drawing.Point(501, 31)
        Me.ExportDxf.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportDxf.Name = "ExportDxf"
        Me.ExportDxf.Size = New System.Drawing.Size(93, 56)
        Me.ExportDxf.TabIndex = 37
        Me.ExportDxf.Text = "Export To DXF"
        Me.ExportDxf.UseVisualStyleBackColor = False
        '
        'ExportSpf
        '
        Me.ExportSpf.BackColor = System.Drawing.Color.White
        Me.ExportSpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportSpf.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.ExportSpf.Location = New System.Drawing.Point(501, 85)
        Me.ExportSpf.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportSpf.Name = "ExportSpf"
        Me.ExportSpf.Size = New System.Drawing.Size(93, 54)
        Me.ExportSpf.TabIndex = 36
        Me.ExportSpf.Text = "Export To SPF"
        Me.ExportSpf.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ShortDescription)
        Me.GroupBox1.Controls.Add(Me.ComboBoxMaterial)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.NameBox)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(13, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(367, 132)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Primary Info"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.LongDescription)
        Me.GroupBox2.Controls.Add(Me.TboxThickness)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.TboxApprove)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox2.Location = New System.Drawing.Point(13, 169)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(367, 213)
        Me.GroupBox2.TabIndex = 58
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Secondary Info"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Preview3)
        Me.GroupBox3.Controls.Add(Me.Preview2)
        Me.GroupBox3.Controls.Add(Me.Preview1)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(13, 420)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(768, 273)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Preview"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TagsBox)
        Me.GroupBox4.Controls.Add(Me.AddTag)
        Me.GroupBox4.Controls.Add(Me.RemoveTag)
        Me.GroupBox4.Location = New System.Drawing.Point(414, 175)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(296, 223)
        Me.GroupBox4.TabIndex = 60
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Trophy Tags"

        '
        'btnSetDrawing
        '
        Me.btnSetDrawing.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnSetDrawing.BackColor = System.Drawing.Color.White
        Me.btnSetDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSetDrawing.Location = New System.Drawing.Point(38, 16)
        Me.btnSetDrawing.Margin = New System.Windows.Forms.Padding(16)
        Me.btnSetDrawing.Name = "btnSetDrawing"
        Me.btnSetDrawing.Size = New System.Drawing.Size(100, 24)
        Me.btnSetDrawing.TabIndex = 18
        Me.btnSetDrawing.Text = "Load Drawing"
        Me.btnSetDrawing.UseVisualStyleBackColor = False

        '
        'DrawingDivider
        '
        Me.DrawingDivider.Location = New System.Drawing.Point(3, 370)
        Me.DrawingDivider.Name = "DrawingDivider"
        Me.DrawingDivider.Size = New System.Drawing.Size(200, 100)
        Me.DrawingDivider.TabIndex = 0
        '
        'ErrorProviderThickness
        '
        Me.ErrorProviderThickness.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderThickness.ContainerControl = Me
        '
        'DxfFileDialog
        '
        Me.DxfFileDialog.Filter = "dxf Files|*.dxf|All files|*.*"
        '
        'ImageFileDialog
        '
        Me.ImageFileDialog.FileName = "OpenFileDialog2"
        Me.ImageFileDialog.Filter = "image Files|*.png;*jpg;*jpeg|All files|*.*"
        '
        'DxfSaveDialog
        '
        Me.DxfSaveDialog.Filter = "dxf file|*.dxf"
        '
        'SpfSaveDialog
        '
        Me.SpfSaveDialog.Filter = "spf file|*.spf"
        '
        'SpfOpenDialog
        '
        Me.SpfOpenDialog.FileName = "SpfFileDialog"
        '
        'ErrorProviderName
        '
        Me.ErrorProviderName.ContainerControl = Me
        '
        'DynamicFormCreation1
        '
        Me.DynamicFormCreation1.AutoScroll = True
        Me.DynamicFormCreation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DynamicFormCreation1.Location = New System.Drawing.Point(794, 427)
        Me.DynamicFormCreation1.Name = "DynamicFormCreation1"
        Me.DynamicFormCreation1.Padding = New System.Windows.Forms.Padding(20)
        Me.DynamicFormCreation1.Size = New System.Drawing.Size(393, 266)
        Me.DynamicFormCreation1.TabIndex = 55
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Location = New System.Drawing.Point(831, 16)
        Me.DxfViewerControl1.Margin = New System.Windows.Forms.Padding(16)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Size = New System.Drawing.Size(311, 360)
        Me.DxfViewerControl1.TabIndex = 31
        Me.DxfViewerControl1.ZoomX = 1.0R
        Me.DxfViewerControl1.ZoomY = 1.0R
        '
        'TagEditorControl1
        '
        Me.TagEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagEditorControl1.Location = New System.Drawing.Point(3, 3)
        Me.TagEditorControl1.Name = "TagEditorControl1"
        Me.TagEditorControl1.Readonly = False
        Me.TagEditorControl1.Size = New System.Drawing.Size(362, 361)
        Me.TagEditorControl1.TabIndex = 2
        '
        'TemplateCreatorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnViewDrawing)
        Me.Controls.Add(Me.DynamicFormCreation1)
        Me.Controls.Add(Me.btnSubmitTemplate)
        Me.Controls.Add(Me.DxfViewerControl1)
        Me.Controls.Add(Me.btnNewJob)
        Me.Controls.Add(Me.ImportSpf)
        Me.Controls.Add(Me.ExportDxf)
        Me.Controls.Add(Me.ExportSpf)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "TemplateCreatorControl"
        Me.Size = New System.Drawing.Size(1231, 742)
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.ErrorProviderThickness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnViewDrawing As Button
    Friend WithEvents TboxApprove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Preview3 As PictureBox
    Friend WithEvents Preview2 As PictureBox
    Friend WithEvents Preview1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DynamicFormCreation1 As DynamicFormCreation
    Friend WithEvents NameBox As TextBox
    Friend WithEvents btnSubmitTemplate As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents LongDescription As RichTextBox
    Friend WithEvents ShortDescription As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents RemoveTag As Button
    Friend WithEvents ComboBoxMaterial As ComboBox
    Friend WithEvents TboxThickness As TextBox
    Friend WithEvents TagsBox As ListBox
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents btnNewJob As Button
    Friend WithEvents AddTag As Button
    Friend WithEvents ImportSpf As Button
    Friend WithEvents ExportDxf As Button
    Friend WithEvents ExportSpf As Button
    Friend WithEvents DrawingDivider As TableLayoutPanel
    Friend WithEvents ErrorProviderThickness As ErrorProvider
    Friend WithEvents DxfFileDialog As OpenFileDialog
    Friend WithEvents ImageFileDialog As OpenFileDialog
    Friend WithEvents DxfSaveDialog As SaveFileDialog
    Friend WithEvents SpfSaveDialog As SaveFileDialog
    Friend WithEvents SpfOpenDialog As OpenFileDialog
    Friend WithEvents ErrorProviderName As ErrorProvider
    Friend WithEvents btnSetDrawing As Button
    Friend WithEvents TagEditorControl1 As TagEditorControl
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
End Class
