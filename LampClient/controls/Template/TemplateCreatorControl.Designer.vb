<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TemplateCreatorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateCreatorControl))
        Me.TboxApprove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Preview3 = New System.Windows.Forms.PictureBox()
        Me.Preview2 = New System.Windows.Forms.PictureBox()
        Me.Preview1 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LongDescription = New System.Windows.Forms.RichTextBox()
        Me.ShortDescription = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBoxMaterial = New System.Windows.Forms.ComboBox()
        Me.TboxThickness = New System.Windows.Forms.TextBox()
        Me.gboxPrimary = New System.Windows.Forms.GroupBox()
        Me.gboxSecondary = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel7 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnGeneratePreview = New System.Windows.Forms.Button()
        Me.gboxTags = New System.Windows.Forms.GroupBox()
        Me.btnSetDrawing = New System.Windows.Forms.Button()
        Me.ErrorProviderThickness = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProviderName = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel4 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel5 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gboxOptions = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel6 = New System.Windows.Forms.TableLayoutPanel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel9 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnEditDrawing = New System.Windows.Forms.Button()
        Me.btnAddDynamicText = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.DxfOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SpfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.DxfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.TagEditorControl1 = New LampClient.TagEditorControl()
        Me.DxfViewerControl1 = New LampClient.DxfViewerControl()
        Me.DynamicFormCreation1 = New LampClient.DynamicFormCreation()
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gboxPrimary.SuspendLayout()
        Me.gboxSecondary.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TableLayoutPanel7.SuspendLayout()
        Me.gboxTags.SuspendLayout()
        CType(Me.ErrorProviderThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel4.SuspendLayout()
        Me.TableLayoutPanel5.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gboxOptions.SuspendLayout()
        Me.TableLayoutPanel6.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        Me.TableLayoutPanel9.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'TboxApprove
        '
        Me.TboxApprove.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TboxApprove.Location = New System.Drawing.Point(115, 201)
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
        Me.Label6.Location = New System.Drawing.Point(28, 205)
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
        Me.Preview3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview3.Location = New System.Drawing.Point(498, 16)
        Me.Preview3.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview3.Name = "Preview3"
        Me.Preview3.Size = New System.Drawing.Size(209, 160)
        Me.Preview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview3.TabIndex = 33
        Me.Preview3.TabStop = False
        '
        'Preview2
        '
        Me.Preview2.BackColor = System.Drawing.Color.White
        Me.Preview2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview2.Location = New System.Drawing.Point(257, 16)
        Me.Preview2.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview2.Name = "Preview2"
        Me.Preview2.Size = New System.Drawing.Size(209, 160)
        Me.Preview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview2.TabIndex = 32
        Me.Preview2.TabStop = False
        '
        'Preview1
        '
        Me.Preview1.BackColor = System.Drawing.Color.White
        Me.Preview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview1.Location = New System.Drawing.Point(16, 16)
        Me.Preview1.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview1.Name = "Preview1"
        Me.Preview1.Size = New System.Drawing.Size(209, 160)
        Me.Preview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview1.TabIndex = 30
        Me.Preview1.TabStop = False
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(75, 75)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 34
        Me.Label1.Text = "Name:"
        '
        'NameBox
        '
        Me.NameBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.NameBox.Location = New System.Drawing.Point(115, 71)
        Me.NameBox.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.NameBox.MaxLength = 38
        Me.NameBox.Name = "NameBox"
        Me.NameBox.Size = New System.Drawing.Size(203, 20)
        Me.NameBox.TabIndex = 35
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(32, 135)
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
        Me.LongDescription.Location = New System.Drawing.Point(115, 37)
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
        Me.ShortDescription.Location = New System.Drawing.Point(115, 129)
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
        Me.Label2.Location = New System.Drawing.Point(23, 45)
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
        Me.Label4.Location = New System.Drawing.Point(66, 103)
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
        Me.Label5.Location = New System.Drawing.Point(54, 180)
        Me.Label5.Margin = New System.Windows.Forms.Padding(8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 50
        Me.Label5.Text = "Thickness:"
        '
        'ComboBoxMaterial
        '
        Me.ComboBoxMaterial.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.ComboBoxMaterial.FormattingEnabled = True
        Me.ComboBoxMaterial.Location = New System.Drawing.Point(115, 100)
        Me.ComboBoxMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.ComboBoxMaterial.Name = "ComboBoxMaterial"
        Me.ComboBoxMaterial.Size = New System.Drawing.Size(203, 21)
        Me.ComboBoxMaterial.TabIndex = 49
        '
        'TboxThickness
        '
        Me.TboxThickness.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.TboxThickness.Location = New System.Drawing.Point(115, 178)
        Me.TboxThickness.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.TboxThickness.MaxLength = 38
        Me.TboxThickness.Name = "TboxThickness"
        Me.TboxThickness.Size = New System.Drawing.Size(203, 20)
        Me.TboxThickness.TabIndex = 51
        '
        'gboxPrimary
        '
        Me.gboxPrimary.Controls.Add(Me.ShortDescription)
        Me.gboxPrimary.Controls.Add(Me.ComboBoxMaterial)
        Me.gboxPrimary.Controls.Add(Me.Label4)
        Me.gboxPrimary.Controls.Add(Me.Label3)
        Me.gboxPrimary.Controls.Add(Me.NameBox)
        Me.gboxPrimary.Controls.Add(Me.Label1)
        Me.gboxPrimary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxPrimary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gboxPrimary.Location = New System.Drawing.Point(3, 3)
        Me.gboxPrimary.Name = "gboxPrimary"
        Me.gboxPrimary.Size = New System.Drawing.Size(355, 247)
        Me.gboxPrimary.TabIndex = 57
        Me.gboxPrimary.TabStop = False
        Me.gboxPrimary.Text = "Primary Info"
        '
        'gboxSecondary
        '
        Me.gboxSecondary.Controls.Add(Me.LongDescription)
        Me.gboxSecondary.Controls.Add(Me.TboxThickness)
        Me.gboxSecondary.Controls.Add(Me.Label5)
        Me.gboxSecondary.Controls.Add(Me.Label2)
        Me.gboxSecondary.Controls.Add(Me.TboxApprove)
        Me.gboxSecondary.Controls.Add(Me.Label6)
        Me.gboxSecondary.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxSecondary.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gboxSecondary.Location = New System.Drawing.Point(3, 256)
        Me.gboxSecondary.Name = "gboxSecondary"
        Me.gboxSecondary.Size = New System.Drawing.Size(355, 248)
        Me.gboxSecondary.TabIndex = 58
        Me.gboxSecondary.TabStop = False
        Me.gboxSecondary.Text = "Secondary Info"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TableLayoutPanel7)
        Me.GroupBox3.Controls.Add(Me.btnGeneratePreview)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(729, 211)
        Me.GroupBox3.TabIndex = 59
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Image Preview"
        '
        'TableLayoutPanel7
        '
        Me.TableLayoutPanel7.ColumnCount = 3
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel7.Controls.Add(Me.Preview1, 0, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Preview2, 1, 0)
        Me.TableLayoutPanel7.Controls.Add(Me.Preview3, 2, 0)
        Me.TableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel7.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel7.Name = "TableLayoutPanel7"
        Me.TableLayoutPanel7.RowCount = 1
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel7.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 192.0!))
        Me.TableLayoutPanel7.Size = New System.Drawing.Size(723, 192)
        Me.TableLayoutPanel7.TabIndex = 62
        '
        'btnGeneratePreview
        '
        Me.btnGeneratePreview.BackColor = System.Drawing.Color.White
        Me.btnGeneratePreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGeneratePreview.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.btnGeneratePreview.Location = New System.Drawing.Point(563, 272)
        Me.btnGeneratePreview.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGeneratePreview.Name = "btnGeneratePreview"
        Me.btnGeneratePreview.Size = New System.Drawing.Size(198, 39)
        Me.btnGeneratePreview.TabIndex = 61
        Me.btnGeneratePreview.Text = "Generate Preview"
        Me.btnGeneratePreview.UseVisualStyleBackColor = False
        '
        'gboxTags
        '
        Me.gboxTags.Controls.Add(Me.TagEditorControl1)
        Me.gboxTags.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxTags.Location = New System.Drawing.Point(3, 155)
        Me.gboxTags.Name = "gboxTags"
        Me.gboxTags.Size = New System.Drawing.Size(355, 349)
        Me.gboxTags.TabIndex = 60
        Me.gboxTags.TabStop = False
        Me.gboxTags.Text = "Trophy Tags"
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
        'ErrorProviderThickness
        '
        Me.ErrorProviderThickness.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProviderThickness.ContainerControl = Me
        '
        'ImageFileDialog
        '
        Me.ImageFileDialog.FileName = "OpenFileDialog2"
        Me.ImageFileDialog.Filter = "image Files|*.png;*jpg;*jpeg|All files|*.*"
        '
        'ErrorProviderName
        '
        Me.ErrorProviderName.ContainerControl = Me
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1231, 742)
        Me.TableLayoutPanel1.TabIndex = 61
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel4, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel5, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel6, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1225, 513)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'TableLayoutPanel4
        '
        Me.TableLayoutPanel4.ColumnCount = 1
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel4.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel4.Controls.Add(Me.gboxPrimary, 0, 0)
        Me.TableLayoutPanel4.Controls.Add(Me.gboxSecondary, 0, 1)
        Me.TableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel4.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel4.Name = "TableLayoutPanel4"
        Me.TableLayoutPanel4.RowCount = 2
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel4.Size = New System.Drawing.Size(361, 507)
        Me.TableLayoutPanel4.TabIndex = 0
        '
        'TableLayoutPanel5
        '
        Me.TableLayoutPanel5.ColumnCount = 1
        Me.TableLayoutPanel5.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel5.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel5.Controls.Add(Me.gboxTags, 0, 1)
        Me.TableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel5.Location = New System.Drawing.Point(370, 3)
        Me.TableLayoutPanel5.Name = "TableLayoutPanel5"
        Me.TableLayoutPanel5.RowCount = 2
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel5.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel5.Size = New System.Drawing.Size(361, 507)
        Me.TableLayoutPanel5.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.gboxOptions)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(355, 146)
        Me.Panel1.TabIndex = 0
        '
        'gboxOptions
        '
        Me.gboxOptions.Controls.Add(Me.Label7)
        Me.gboxOptions.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxOptions.Location = New System.Drawing.Point(0, 0)
        Me.gboxOptions.Name = "gboxOptions"
        Me.gboxOptions.Size = New System.Drawing.Size(355, 146)
        Me.gboxOptions.TabIndex = 0
        Me.gboxOptions.TabStop = False
        Me.gboxOptions.Text = "Options"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(48, 27)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(255, 104)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = resources.GetString("Label7.Text")
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'TableLayoutPanel6
        '
        Me.TableLayoutPanel6.ColumnCount = 1
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel6.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel6.Location = New System.Drawing.Point(737, 3)
        Me.TableLayoutPanel6.Name = "TableLayoutPanel6"
        Me.TableLayoutPanel6.RowCount = 1
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel6.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 507.0!))
        Me.TableLayoutPanel6.Size = New System.Drawing.Size(485, 507)
        Me.TableLayoutPanel6.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableLayoutPanel8)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(479, 501)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Template Preview"
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.ColumnCount = 1
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Controls.Add(Me.DxfViewerControl1, 0, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.TableLayoutPanel9, 0, 1)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 16)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 2
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(473, 482)
        Me.TableLayoutPanel8.TabIndex = 0
        '
        'TableLayoutPanel9
        '
        Me.TableLayoutPanel9.ColumnCount = 2
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel9.Controls.Add(Me.btnEditDrawing, 1, 0)
        Me.TableLayoutPanel9.Controls.Add(Me.btnAddDynamicText, 0, 0)
        Me.TableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel9.Location = New System.Drawing.Point(3, 419)
        Me.TableLayoutPanel9.Name = "TableLayoutPanel9"
        Me.TableLayoutPanel9.RowCount = 1
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel9.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel9.Size = New System.Drawing.Size(467, 60)
        Me.TableLayoutPanel9.TabIndex = 33
        '
        'btnEditDrawing
        '
        Me.btnEditDrawing.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnEditDrawing.AutoSize = True
        Me.btnEditDrawing.BackColor = System.Drawing.Color.White
        Me.btnEditDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnEditDrawing.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.btnEditDrawing.Location = New System.Drawing.Point(237, 15)
        Me.btnEditDrawing.Margin = New System.Windows.Forms.Padding(4)
        Me.btnEditDrawing.Name = "btnEditDrawing"
        Me.btnEditDrawing.Size = New System.Drawing.Size(99, 29)
        Me.btnEditDrawing.TabIndex = 47
        Me.btnEditDrawing.Text = "Edit Drawing"
        Me.btnEditDrawing.UseVisualStyleBackColor = False
        '
        'btnAddDynamicText
        '
        Me.btnAddDynamicText.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnAddDynamicText.AutoSize = True
        Me.btnAddDynamicText.BackColor = System.Drawing.Color.White
        Me.btnAddDynamicText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddDynamicText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.btnAddDynamicText.Location = New System.Drawing.Point(95, 15)
        Me.btnAddDynamicText.Margin = New System.Windows.Forms.Padding(4)
        Me.btnAddDynamicText.Name = "btnAddDynamicText"
        Me.btnAddDynamicText.Size = New System.Drawing.Size(134, 29)
        Me.btnAddDynamicText.TabIndex = 46
        Me.btnAddDynamicText.Text = "Add Dynamic Text"
        Me.btnAddDynamicText.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox3, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.DynamicFormCreation1, 1, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(3, 522)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 1
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1225, 217)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'DxfOpenDialog
        '
        Me.DxfOpenDialog.Filter = "dxf Files|*.dxf|All files|*.*"
        '
        'SpfSaveDialog
        '
        Me.SpfSaveDialog.Filter = "spf file|*.spf|All files|*.*"
        '
        'SpfOpenDialog
        '
        Me.SpfOpenDialog.FileName = "SpfFileDialog"
        '
        'DxfSaveDialog
        '
        Me.DxfSaveDialog.Filter = "dxf file|*.dxf"
        '
        'SaveFileDialog2
        '
        Me.SaveFileDialog2.Filter = "dxf file|*.dxf|All files|*.*"
        '
        'TagEditorControl1
        '
        Me.TagEditorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagEditorControl1.Location = New System.Drawing.Point(3, 16)
        Me.TagEditorControl1.Name = "TagEditorControl1"
        Me.TagEditorControl1.Readonly = False
        Me.TagEditorControl1.Size = New System.Drawing.Size(349, 330)
        Me.TagEditorControl1.TabIndex = 2
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DxfViewerControl1.Location = New System.Drawing.Point(16, 16)
        Me.DxfViewerControl1.Margin = New System.Windows.Forms.Padding(16)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Readonly = False
        Me.DxfViewerControl1.Size = New System.Drawing.Size(441, 384)
        Me.DxfViewerControl1.TabIndex = 32
        Me.DxfViewerControl1.ZoomX = 1.0R
        Me.DxfViewerControl1.ZoomY = 1.0R
        '
        'DynamicFormCreation1
        '
        Me.DynamicFormCreation1.AutoScroll = True
        Me.DynamicFormCreation1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DynamicFormCreation1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DynamicFormCreation1.Location = New System.Drawing.Point(738, 3)
        Me.DynamicFormCreation1.Name = "DynamicFormCreation1"
        Me.DynamicFormCreation1.Padding = New System.Windows.Forms.Padding(20)
        Me.DynamicFormCreation1.Size = New System.Drawing.Size(484, 211)
        Me.DynamicFormCreation1.TabIndex = 55
        '
        'TemplateCreatorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "TemplateCreatorControl"
        Me.Size = New System.Drawing.Size(1231, 742)
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gboxPrimary.ResumeLayout(False)
        Me.gboxPrimary.PerformLayout()
        Me.gboxSecondary.ResumeLayout(False)
        Me.gboxSecondary.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.TableLayoutPanel7.ResumeLayout(False)
        Me.gboxTags.ResumeLayout(False)
        CType(Me.ErrorProviderThickness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel4.ResumeLayout(False)
        Me.TableLayoutPanel5.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gboxOptions.ResumeLayout(False)
        Me.gboxOptions.PerformLayout()
        Me.TableLayoutPanel6.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        Me.TableLayoutPanel9.ResumeLayout(False)
        Me.TableLayoutPanel9.PerformLayout()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TboxApprove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Preview3 As PictureBox
    Friend WithEvents Preview2 As PictureBox
    Friend WithEvents Preview1 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents DynamicFormCreation1 As DynamicFormCreation
    Friend WithEvents NameBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LongDescription As RichTextBox
    Friend WithEvents ShortDescription As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents ComboBoxMaterial As ComboBox
    Friend WithEvents TboxThickness As TextBox
    Friend WithEvents ErrorProviderThickness As ErrorProvider
    Friend WithEvents ImageFileDialog As OpenFileDialog
    Friend WithEvents ErrorProviderName As ErrorProvider
    Friend WithEvents btnSetDrawing As Button
    Friend WithEvents TagEditorControl1 As TagEditorControl
    Friend WithEvents gboxPrimary As GroupBox
    Friend WithEvents gboxSecondary As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents gboxTags As GroupBox
    Friend WithEvents btnGeneratePreview As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel4 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel5 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel6 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel7 As TableLayoutPanel
    Friend WithEvents gboxOptions As GroupBox
    Friend WithEvents Label7 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents DxfOpenDialog As OpenFileDialog
    Friend WithEvents SpfSaveDialog As SaveFileDialog
    Friend WithEvents SpfOpenDialog As OpenFileDialog
    Friend WithEvents DxfSaveDialog As SaveFileDialog
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents TableLayoutPanel9 As TableLayoutPanel
    Friend WithEvents btnEditDrawing As Button
    Friend WithEvents btnAddDynamicText As Button
End Class
