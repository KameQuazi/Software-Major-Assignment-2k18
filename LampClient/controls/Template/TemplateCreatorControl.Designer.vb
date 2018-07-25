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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateCreatorControl))
        Me.RootColumn = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Dynbox = New System.Windows.Forms.ListBox()
        Me.LeftDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel8 = New System.Windows.Forms.TableLayoutPanel()
        Me.Preview3 = New System.Windows.Forms.PictureBox()
        Me.Preview2 = New System.Windows.Forms.PictureBox()
        Me.Preview1 = New System.Windows.Forms.PictureBox()
        Me.EmptySpaceDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.DescriptionDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.TboxApprove = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LongDescription = New System.Windows.Forms.RichTextBox()
        Me.ShortDescription = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboBoxMaterial = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TboxThickness = New System.Windows.Forms.TextBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNewJob = New System.Windows.Forms.Button()
        Me.btnSubmitTemplate = New System.Windows.Forms.Button()
        Me.ImportSpf = New System.Windows.Forms.Button()
        Me.ExportDxf = New System.Windows.Forms.Button()
        Me.ExportSpf = New System.Windows.Forms.Button()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.DrawingDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.DxfViewerControl1 = New LampClient.DxfViewerControl()
        Me.btnViewDrawing = New System.Windows.Forms.Button()
        Me.TagDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.TagsBox = New System.Windows.Forms.ListBox()
        Me.RemoveTag = New System.Windows.Forms.Button()
        Me.AddTag = New System.Windows.Forms.Button()
        Me.ErrorProviderThickness = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.DxfFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.DxfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ErrorProviderName = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.RootColumn.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.LeftDivider.SuspendLayout()
        Me.TableLayoutPanel8.SuspendLayout()
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.EmptySpaceDivider.SuspendLayout()
        Me.DescriptionDivider.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.DrawingDivider.SuspendLayout()
        Me.TagDivider.SuspendLayout()
        CType(Me.ErrorProviderThickness, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProviderName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RootColumn
        '
        Me.RootColumn.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.RootColumn.ColumnCount = 2
        Me.RootColumn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.RootColumn.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.RootColumn.Controls.Add(Me.Panel1, 0, 0)
        Me.RootColumn.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.RootColumn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.RootColumn.Location = New System.Drawing.Point(0, 0)
        Me.RootColumn.Name = "RootColumn"
        Me.RootColumn.RowCount = 1
        Me.RootColumn.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.RootColumn.Size = New System.Drawing.Size(1248, 742)
        Me.RootColumn.TabIndex = 29
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Dynbox)
        Me.Panel1.Controls.Add(Me.LeftDivider)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(4, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(865, 734)
        Me.Panel1.TabIndex = 0
        '
        'Dynbox
        '
        Me.Dynbox.FormattingEnabled = True
        Me.Dynbox.Items.AddRange(New Object() {""})
        Me.Dynbox.Location = New System.Drawing.Point(1009, 153)
        Me.Dynbox.Name = "Dynbox"
        Me.Dynbox.Size = New System.Drawing.Size(372, 134)
        Me.Dynbox.TabIndex = 25
        '
        'LeftDivider
        '
        Me.LeftDivider.ColumnCount = 1
        Me.LeftDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.LeftDivider.Controls.Add(Me.TableLayoutPanel8, 0, 1)
        Me.LeftDivider.Controls.Add(Me.EmptySpaceDivider, 0, 0)
        Me.LeftDivider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LeftDivider.Location = New System.Drawing.Point(0, 0)
        Me.LeftDivider.Name = "LeftDivider"
        Me.LeftDivider.RowCount = 2
        Me.LeftDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.LeftDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.LeftDivider.Size = New System.Drawing.Size(865, 734)
        Me.LeftDivider.TabIndex = 28
        '
        'TableLayoutPanel8
        '
        Me.TableLayoutPanel8.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel8.ColumnCount = 3
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel8.Controls.Add(Me.Preview3, 2, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Preview2, 1, 0)
        Me.TableLayoutPanel8.Controls.Add(Me.Preview1, 0, 0)
        Me.TableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel8.Location = New System.Drawing.Point(3, 443)
        Me.TableLayoutPanel8.Name = "TableLayoutPanel8"
        Me.TableLayoutPanel8.RowCount = 1
        Me.TableLayoutPanel8.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel8.Size = New System.Drawing.Size(859, 288)
        Me.TableLayoutPanel8.TabIndex = 27
        '
        'Preview3
        '
        Me.Preview3.BackColor = System.Drawing.Color.White
        Me.Preview3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview3.Location = New System.Drawing.Point(589, 17)
        Me.Preview3.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview3.Name = "Preview3"
        Me.Preview3.Size = New System.Drawing.Size(253, 254)
        Me.Preview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview3.TabIndex = 3
        Me.Preview3.TabStop = False
        '
        'Preview2
        '
        Me.Preview2.BackColor = System.Drawing.Color.White
        Me.Preview2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview2.Location = New System.Drawing.Point(303, 17)
        Me.Preview2.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview2.Name = "Preview2"
        Me.Preview2.Size = New System.Drawing.Size(253, 254)
        Me.Preview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview2.TabIndex = 1
        Me.Preview2.TabStop = False
        '
        'Preview1
        '
        Me.Preview1.BackColor = System.Drawing.Color.White
        Me.Preview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Preview1.Location = New System.Drawing.Point(17, 17)
        Me.Preview1.Margin = New System.Windows.Forms.Padding(16)
        Me.Preview1.Name = "Preview1"
        Me.Preview1.Size = New System.Drawing.Size(253, 254)
        Me.Preview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview1.TabIndex = 0
        Me.Preview1.TabStop = False
        '
        'EmptySpaceDivider
        '
        Me.EmptySpaceDivider.ColumnCount = 3
        Me.EmptySpaceDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.EmptySpaceDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.EmptySpaceDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.EmptySpaceDivider.Controls.Add(Me.DescriptionDivider, 0, 0)
        Me.EmptySpaceDivider.Controls.Add(Me.TableLayoutPanel1, 2, 0)
        Me.EmptySpaceDivider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.EmptySpaceDivider.Location = New System.Drawing.Point(3, 3)
        Me.EmptySpaceDivider.Name = "EmptySpaceDivider"
        Me.EmptySpaceDivider.RowCount = 1
        Me.EmptySpaceDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.EmptySpaceDivider.Size = New System.Drawing.Size(859, 434)
        Me.EmptySpaceDivider.TabIndex = 28
        '
        'DescriptionDivider
        '
        Me.DescriptionDivider.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.DescriptionDivider.ColumnCount = 2
        Me.DescriptionDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.DescriptionDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.DescriptionDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.DescriptionDivider.Controls.Add(Me.TboxApprove, 1, 5)
        Me.DescriptionDivider.Controls.Add(Me.Label6, 0, 5)
        Me.DescriptionDivider.Controls.Add(Me.Label1, 0, 0)
        Me.DescriptionDivider.Controls.Add(Me.NameBox, 1, 0)
        Me.DescriptionDivider.Controls.Add(Me.Label3, 0, 1)
        Me.DescriptionDivider.Controls.Add(Me.LongDescription, 1, 2)
        Me.DescriptionDivider.Controls.Add(Me.ShortDescription, 1, 1)
        Me.DescriptionDivider.Controls.Add(Me.Label2, 0, 2)
        Me.DescriptionDivider.Controls.Add(Me.Label4, 0, 3)
        Me.DescriptionDivider.Controls.Add(Me.ComboBoxMaterial, 1, 3)
        Me.DescriptionDivider.Controls.Add(Me.Label5, 0, 4)
        Me.DescriptionDivider.Controls.Add(Me.TboxThickness, 1, 4)
        Me.DescriptionDivider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DescriptionDivider.Location = New System.Drawing.Point(4, 4)
        Me.DescriptionDivider.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.DescriptionDivider.Name = "DescriptionDivider"
        Me.DescriptionDivider.RowCount = 6
        Me.DescriptionDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.DescriptionDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.DescriptionDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.DescriptionDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.DescriptionDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.DescriptionDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.DescriptionDivider.Size = New System.Drawing.Size(409, 426)
        Me.DescriptionDivider.TabIndex = 27
        '
        'TboxApprove
        '
        Me.TboxApprove.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TboxApprove.Location = New System.Drawing.Point(168, 383)
        Me.TboxApprove.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.TboxApprove.MaxLength = 38
        Me.TboxApprove.Name = "TboxApprove"
        Me.TboxApprove.Size = New System.Drawing.Size(224, 20)
        Me.TboxApprove.TabIndex = 26
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(70, 387)
        Me.Label6.Margin = New System.Windows.Forms.Padding(8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 13)
        Me.Label6.TabIndex = 25
        Me.Label6.Text = "Approval Status:"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(117, 9)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Name:"
        '
        'NameBox
        '
        Me.NameBox.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.NameBox.Location = New System.Drawing.Point(168, 5)
        Me.NameBox.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.NameBox.MaxLength = 38
        Me.NameBox.Name = "NameBox"
        Me.NameBox.Size = New System.Drawing.Size(224, 20)
        Me.NameBox.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(74, 51)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Short Summary:"
        '
        'LongDescription
        '
        Me.LongDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LongDescription.Location = New System.Drawing.Point(168, 131)
        Me.LongDescription.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.LongDescription.Name = "LongDescription"
        Me.LongDescription.Size = New System.Drawing.Size(224, 159)
        Me.LongDescription.TabIndex = 20
        Me.LongDescription.Text = ""
        '
        'ShortDescription
        '
        Me.ShortDescription.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ShortDescription.Location = New System.Drawing.Point(168, 47)
        Me.ShortDescription.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.ShortDescription.MaxLength = 190
        Me.ShortDescription.Name = "ShortDescription"
        Me.ShortDescription.Size = New System.Drawing.Size(224, 75)
        Me.ShortDescription.TabIndex = 17
        Me.ShortDescription.Text = ""
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(65, 135)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Long Description:"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(108, 303)
        Me.Label4.Margin = New System.Windows.Forms.Padding(8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 13)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "Material:"
        '
        'ComboBoxMaterial
        '
        Me.ComboBoxMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ComboBoxMaterial.FormattingEnabled = True
        Me.ComboBoxMaterial.Location = New System.Drawing.Point(168, 299)
        Me.ComboBoxMaterial.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.ComboBoxMaterial.Name = "ComboBoxMaterial"
        Me.ComboBoxMaterial.Size = New System.Drawing.Size(224, 21)
        Me.ComboBoxMaterial.TabIndex = 22
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(96, 345)
        Me.Label5.Margin = New System.Windows.Forms.Padding(8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Thickness:"
        '
        'TboxThickness
        '
        Me.TboxThickness.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TboxThickness.Location = New System.Drawing.Point(168, 341)
        Me.TboxThickness.Margin = New System.Windows.Forms.Padding(4, 4, 16, 4)
        Me.TboxThickness.MaxLength = 38
        Me.TboxThickness.Name = "TboxThickness"
        Me.TboxThickness.Size = New System.Drawing.Size(224, 20)
        Me.TboxThickness.TabIndex = 24
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnNewJob, 0, 4)
        Me.TableLayoutPanel1.Controls.Add(Me.btnSubmitTemplate, 0, 3)
        Me.TableLayoutPanel1.Controls.Add(Me.ImportSpf, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ExportDxf, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ExportSpf, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(775, 3)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 5
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(81, 428)
        Me.TableLayoutPanel1.TabIndex = 28
        '
        'btnNewJob
        '
        Me.btnNewJob.BackColor = System.Drawing.Color.White
        Me.btnNewJob.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNewJob.Enabled = False
        Me.btnNewJob.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewJob.Location = New System.Drawing.Point(5, 345)
        Me.btnNewJob.Margin = New System.Windows.Forms.Padding(4)
        Me.btnNewJob.Name = "btnNewJob"
        Me.btnNewJob.Size = New System.Drawing.Size(71, 78)
        Me.btnNewJob.TabIndex = 16
        Me.btnNewJob.Text = "Create Job With Template"
        Me.btnNewJob.UseVisualStyleBackColor = False
        '
        'btnSubmitTemplate
        '
        Me.btnSubmitTemplate.BackColor = System.Drawing.Color.White
        Me.btnSubmitTemplate.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnSubmitTemplate.Enabled = False
        Me.btnSubmitTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubmitTemplate.Location = New System.Drawing.Point(5, 260)
        Me.btnSubmitTemplate.Margin = New System.Windows.Forms.Padding(4)
        Me.btnSubmitTemplate.Name = "btnSubmitTemplate"
        Me.btnSubmitTemplate.Size = New System.Drawing.Size(71, 76)
        Me.btnSubmitTemplate.TabIndex = 15
        Me.btnSubmitTemplate.Text = "Submit To Database"
        Me.btnSubmitTemplate.UseVisualStyleBackColor = False
        '
        'ImportSpf
        '
        Me.ImportSpf.BackColor = System.Drawing.Color.White
        Me.ImportSpf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ImportSpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ImportSpf.Location = New System.Drawing.Point(5, 5)
        Me.ImportSpf.Margin = New System.Windows.Forms.Padding(4)
        Me.ImportSpf.Name = "ImportSpf"
        Me.ImportSpf.Size = New System.Drawing.Size(71, 76)
        Me.ImportSpf.TabIndex = 14
        Me.ImportSpf.Text = "Load Spf"
        Me.ImportSpf.UseVisualStyleBackColor = False
        '
        'ExportDxf
        '
        Me.ExportDxf.BackColor = System.Drawing.Color.White
        Me.ExportDxf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExportDxf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportDxf.Location = New System.Drawing.Point(5, 90)
        Me.ExportDxf.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportDxf.Name = "ExportDxf"
        Me.ExportDxf.Size = New System.Drawing.Size(71, 76)
        Me.ExportDxf.TabIndex = 11
        Me.ExportDxf.Text = "Export To DXF"
        Me.ExportDxf.UseVisualStyleBackColor = False
        '
        'ExportSpf
        '
        Me.ExportSpf.BackColor = System.Drawing.Color.White
        Me.ExportSpf.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ExportSpf.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.ExportSpf.Location = New System.Drawing.Point(5, 175)
        Me.ExportSpf.Margin = New System.Windows.Forms.Padding(4)
        Me.ExportSpf.Name = "ExportSpf"
        Me.ExportSpf.Size = New System.Drawing.Size(71, 76)
        Me.ExportSpf.TabIndex = 10
        Me.ExportSpf.Text = "Export To SPF"
        Me.ExportSpf.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.DrawingDivider, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.TagDivider, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(876, 4)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(368, 734)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'DrawingDivider
        '
        Me.DrawingDivider.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.DrawingDivider.ColumnCount = 1
        Me.DrawingDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.DrawingDivider.Controls.Add(Me.DxfViewerControl1, 0, 0)
        Me.DrawingDivider.Controls.Add(Me.btnViewDrawing, 0, 1)
        Me.DrawingDivider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DrawingDivider.Location = New System.Drawing.Point(3, 370)
        Me.DrawingDivider.Name = "DrawingDivider"
        Me.DrawingDivider.RowCount = 2
        Me.DrawingDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.DrawingDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.DrawingDivider.Size = New System.Drawing.Size(362, 361)
        Me.DrawingDivider.TabIndex = 1
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DxfViewerControl1.Drawing = Nothing
        Me.DxfViewerControl1.Location = New System.Drawing.Point(17, 17)
        Me.DxfViewerControl1.Margin = New System.Windows.Forms.Padding(16)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Size = New System.Drawing.Size(328, 254)
        Me.DxfViewerControl1.TabIndex = 0
        Me.DxfViewerControl1.ZoomX = 1.0R
        Me.DxfViewerControl1.ZoomY = 1.0R
        '
        'btnViewDrawing
        '
        Me.btnViewDrawing.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnViewDrawing.BackColor = System.Drawing.Color.White
        Me.btnViewDrawing.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewDrawing.Location = New System.Drawing.Point(131, 304)
        Me.btnViewDrawing.Margin = New System.Windows.Forms.Padding(16)
        Me.btnViewDrawing.Name = "btnViewDrawing"
        Me.btnViewDrawing.Size = New System.Drawing.Size(100, 24)
        Me.btnViewDrawing.TabIndex = 16
        Me.btnViewDrawing.Text = "View Drawing"
        Me.btnViewDrawing.UseVisualStyleBackColor = False
        '
        'TagDivider
        '
        Me.TagDivider.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TagDivider.ColumnCount = 2
        Me.TagDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TagDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TagDivider.Controls.Add(Me.TagsBox, 0, 0)
        Me.TagDivider.Controls.Add(Me.RemoveTag, 1, 1)
        Me.TagDivider.Controls.Add(Me.AddTag, 0, 1)
        Me.TagDivider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagDivider.Location = New System.Drawing.Point(3, 3)
        Me.TagDivider.Name = "TagDivider"
        Me.TagDivider.RowCount = 2
        Me.TagDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TagDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TagDivider.Size = New System.Drawing.Size(362, 361)
        Me.TagDivider.TabIndex = 0
        '
        'TagsBox
        '
        Me.TagDivider.SetColumnSpan(Me.TagsBox, 2)
        Me.TagsBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagsBox.FormattingEnabled = True
        Me.TagsBox.Items.AddRange(New Object() {""})
        Me.TagsBox.Location = New System.Drawing.Point(17, 17)
        Me.TagsBox.Margin = New System.Windows.Forms.Padding(16)
        Me.TagsBox.Name = "TagsBox"
        Me.TagsBox.Size = New System.Drawing.Size(328, 254)
        Me.TagsBox.TabIndex = 29
        '
        'RemoveTag
        '
        Me.RemoveTag.BackColor = System.Drawing.Color.White
        Me.RemoveTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RemoveTag.Location = New System.Drawing.Point(197, 304)
        Me.RemoveTag.Margin = New System.Windows.Forms.Padding(16)
        Me.RemoveTag.Name = "RemoveTag"
        Me.RemoveTag.Size = New System.Drawing.Size(100, 24)
        Me.RemoveTag.TabIndex = 16
        Me.RemoveTag.Text = "Remove Tag"
        Me.RemoveTag.UseVisualStyleBackColor = False
        '
        'AddTag
        '
        Me.AddTag.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AddTag.BackColor = System.Drawing.Color.White
        Me.AddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddTag.Location = New System.Drawing.Point(64, 304)
        Me.AddTag.Margin = New System.Windows.Forms.Padding(16)
        Me.AddTag.Name = "AddTag"
        Me.AddTag.Size = New System.Drawing.Size(100, 24)
        Me.AddTag.TabIndex = 15
        Me.AddTag.Text = "Add Tag"
        Me.AddTag.UseVisualStyleBackColor = False
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
        'TemplateCreatorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RootColumn)
        Me.Name = "TemplateCreatorControl"
        Me.Size = New System.Drawing.Size(1248, 742)
        Me.RootColumn.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.LeftDivider.ResumeLayout(False)
        Me.TableLayoutPanel8.ResumeLayout(False)
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.EmptySpaceDivider.ResumeLayout(False)
        Me.DescriptionDivider.ResumeLayout(False)
        Me.DescriptionDivider.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.DrawingDivider.ResumeLayout(False)
        Me.TagDivider.ResumeLayout(False)
        CType(Me.ErrorProviderThickness, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProviderName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RootColumn As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Dynbox As ListBox
    Friend WithEvents LeftDivider As TableLayoutPanel
    Friend WithEvents TableLayoutPanel8 As TableLayoutPanel
    Friend WithEvents Preview3 As PictureBox
    Friend WithEvents Preview2 As PictureBox
    Friend WithEvents Preview1 As PictureBox
    Friend WithEvents EmptySpaceDivider As TableLayoutPanel
    Friend WithEvents DescriptionDivider As TableLayoutPanel
    Friend WithEvents Label1 As Label
    Friend WithEvents NameBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents LongDescription As RichTextBox
    Friend WithEvents ShortDescription As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ComboBoxMaterial As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TboxThickness As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ImportSpf As Button
    Friend WithEvents ExportDxf As Button
    Friend WithEvents ExportSpf As Button
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents DrawingDivider As TableLayoutPanel
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents btnViewDrawing As Button
    Friend WithEvents TagDivider As TableLayoutPanel
    Friend WithEvents TagsBox As ListBox
    Friend WithEvents RemoveTag As Button
    Friend WithEvents AddTag As Button
    Friend WithEvents ErrorProviderThickness As ErrorProvider
    Friend WithEvents DxfFileDialog As OpenFileDialog
    Friend WithEvents ImageFileDialog As OpenFileDialog
    Friend WithEvents DxfSaveDialog As SaveFileDialog
    Friend WithEvents SpfSaveDialog As SaveFileDialog
    Friend WithEvents SpfOpenDialog As OpenFileDialog
    Friend WithEvents btnSubmitTemplate As Button
    Friend WithEvents ErrorProviderName As ErrorProvider
    Friend WithEvents TboxApprove As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnNewJob As Button
End Class
