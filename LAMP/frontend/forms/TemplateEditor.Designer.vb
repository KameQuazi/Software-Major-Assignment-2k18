<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TemplateEditor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateEditor))
        Me.Preview1 = New System.Windows.Forms.PictureBox()
        Me.Preview2 = New System.Windows.Forms.PictureBox()
        Me.Preview3 = New System.Windows.Forms.PictureBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NameBox = New System.Windows.Forms.TextBox()
        Me.SelectDxf = New System.Windows.Forms.Button()
        Me.DxfFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImageFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.AddToDb = New System.Windows.Forms.Button()
        Me.DxfIndicator = New System.Windows.Forms.Label()
        Me.ExportSpf = New System.Windows.Forms.Button()
        Me.ExportDxf = New System.Windows.Forms.Button()
        Me.DxfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SpfSaveDialog = New System.Windows.Forms.SaveFileDialog()
        Me.TagsBox = New System.Windows.Forms.ListBox()
        Me.SpfOpenDialog = New System.Windows.Forms.OpenFileDialog()
        Me.ImportSpf = New System.Windows.Forms.Button()
        Me.AddTag = New System.Windows.Forms.Button()
        Me.RemoveTag = New System.Windows.Forms.Button()
        Me.ShortDescription = New System.Windows.Forms.RichTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.LongDescription = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DxfViewerControl1 = New LAMP.DxfViewerControl()
        Me.GuidBox = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.NewGuidButton = New System.Windows.Forms.Button()
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Preview1
        '
        Me.Preview1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview1.Location = New System.Drawing.Point(30, 267)
        Me.Preview1.Name = "Preview1"
        Me.Preview1.Size = New System.Drawing.Size(141, 120)
        Me.Preview1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview1.TabIndex = 0
        Me.Preview1.TabStop = False
        '
        'Preview2
        '
        Me.Preview2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview2.Location = New System.Drawing.Point(206, 267)
        Me.Preview2.Name = "Preview2"
        Me.Preview2.Size = New System.Drawing.Size(141, 120)
        Me.Preview2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview2.TabIndex = 1
        Me.Preview2.TabStop = False
        '
        'Preview3
        '
        Me.Preview3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Preview3.Location = New System.Drawing.Point(380, 267)
        Me.Preview3.Name = "Preview3"
        Me.Preview3.Size = New System.Drawing.Size(141, 120)
        Me.Preview3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Preview3.TabIndex = 2
        Me.Preview3.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(30, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Name:"
        '
        'NameBox
        '
        Me.NameBox.Location = New System.Drawing.Point(96, 20)
        Me.NameBox.Name = "NameBox"
        Me.NameBox.Size = New System.Drawing.Size(261, 20)
        Me.NameBox.TabIndex = 4
        '
        'SelectDxf
        '
        Me.SelectDxf.Location = New System.Drawing.Point(224, 446)
        Me.SelectDxf.Name = "SelectDxf"
        Me.SelectDxf.Size = New System.Drawing.Size(75, 23)
        Me.SelectDxf.TabIndex = 6
        Me.SelectDxf.Text = "Attach Dxf"
        Me.SelectDxf.UseVisualStyleBackColor = True
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
        'AddToDb
        '
        Me.AddToDb.Location = New System.Drawing.Point(432, 446)
        Me.AddToDb.Name = "AddToDb"
        Me.AddToDb.Size = New System.Drawing.Size(75, 23)
        Me.AddToDb.TabIndex = 7
        Me.AddToDb.Text = "add to db"
        Me.AddToDb.UseVisualStyleBackColor = True
        '
        'DxfIndicator
        '
        Me.DxfIndicator.AutoSize = True
        Me.DxfIndicator.Location = New System.Drawing.Point(247, 197)
        Me.DxfIndicator.Name = "DxfIndicator"
        Me.DxfIndicator.Size = New System.Drawing.Size(0, 13)
        Me.DxfIndicator.TabIndex = 9
        '
        'ExportSpf
        '
        Me.ExportSpf.Location = New System.Drawing.Point(93, 446)
        Me.ExportSpf.Name = "ExportSpf"
        Me.ExportSpf.Size = New System.Drawing.Size(118, 23)
        Me.ExportSpf.TabIndex = 10
        Me.ExportSpf.Text = "Export To SPF"
        Me.ExportSpf.UseVisualStyleBackColor = True
        '
        'ExportDxf
        '
        Me.ExportDxf.Location = New System.Drawing.Point(305, 446)
        Me.ExportDxf.Name = "ExportDxf"
        Me.ExportDxf.Size = New System.Drawing.Size(101, 23)
        Me.ExportDxf.TabIndex = 11
        Me.ExportDxf.Text = "Export To DXF"
        Me.ExportDxf.UseVisualStyleBackColor = True
        '
        'DxfSaveDialog
        '
        Me.DxfSaveDialog.Filter = "dxf file|*.dxf"
        '
        'SpfSaveDialog
        '
        Me.SpfSaveDialog.Filter = "spf file|*.spf"
        '
        'TagsBox
        '
        Me.TagsBox.FormattingEnabled = True
        Me.TagsBox.Items.AddRange(New Object() {""})
        Me.TagsBox.Location = New System.Drawing.Point(576, 12)
        Me.TagsBox.Name = "TagsBox"
        Me.TagsBox.Size = New System.Drawing.Size(322, 134)
        Me.TagsBox.TabIndex = 13
        '
        'SpfOpenDialog
        '
        Me.SpfOpenDialog.FileName = "SpfFileDialog"
        '
        'ImportSpf
        '
        Me.ImportSpf.Location = New System.Drawing.Point(12, 446)
        Me.ImportSpf.Name = "ImportSpf"
        Me.ImportSpf.Size = New System.Drawing.Size(75, 23)
        Me.ImportSpf.TabIndex = 14
        Me.ImportSpf.Text = "Load Spf"
        Me.ImportSpf.UseVisualStyleBackColor = True
        '
        'AddTag
        '
        Me.AddTag.Location = New System.Drawing.Point(670, 164)
        Me.AddTag.Name = "AddTag"
        Me.AddTag.Size = New System.Drawing.Size(75, 23)
        Me.AddTag.TabIndex = 15
        Me.AddTag.Text = "Add Tag"
        Me.AddTag.UseVisualStyleBackColor = True
        '
        'RemoveTag
        '
        Me.RemoveTag.Location = New System.Drawing.Point(751, 164)
        Me.RemoveTag.Name = "RemoveTag"
        Me.RemoveTag.Size = New System.Drawing.Size(113, 23)
        Me.RemoveTag.TabIndex = 16
        Me.RemoveTag.Text = "Remove Tag"
        Me.RemoveTag.UseVisualStyleBackColor = True
        '
        'ShortDescription
        '
        Me.ShortDescription.Location = New System.Drawing.Point(93, 58)
        Me.ShortDescription.Name = "ShortDescription"
        Me.ShortDescription.Size = New System.Drawing.Size(264, 36)
        Me.ShortDescription.TabIndex = 17
        Me.ShortDescription.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 121)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(30, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(50, 13)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Summary"
        '
        'LongDescription
        '
        Me.LongDescription.Location = New System.Drawing.Point(93, 118)
        Me.LongDescription.Name = "LongDescription"
        Me.LongDescription.Size = New System.Drawing.Size(264, 122)
        Me.LongDescription.TabIndex = 20
        Me.LongDescription.Text = ""
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(432, 417)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 21
        Me.Button1.Text = "Save"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Location = New System.Drawing.Point(566, 197)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Size = New System.Drawing.Size(342, 311)
        Me.DxfViewerControl1.Source = Nothing
        Me.DxfViewerControl1.TabIndex = 12
        '
        'GuidBox
        '
        Me.GuidBox.Enabled = False
        Me.GuidBox.Location = New System.Drawing.Point(398, 20)
        Me.GuidBox.Name = "GuidBox"
        Me.GuidBox.Size = New System.Drawing.Size(172, 20)
        Me.GuidBox.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(363, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Guid"
        '
        'NewGuidButton
        '
        Me.NewGuidButton.Location = New System.Drawing.Point(457, 51)
        Me.NewGuidButton.Name = "NewGuidButton"
        Me.NewGuidButton.Size = New System.Drawing.Size(75, 23)
        Me.NewGuidButton.TabIndex = 24
        Me.NewGuidButton.Text = "New guid"
        Me.NewGuidButton.UseVisualStyleBackColor = True
        '
        'TemplateEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(920, 520)
        Me.Controls.Add(Me.NewGuidButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.GuidBox)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.LongDescription)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ShortDescription)
        Me.Controls.Add(Me.RemoveTag)
        Me.Controls.Add(Me.AddTag)
        Me.Controls.Add(Me.ImportSpf)
        Me.Controls.Add(Me.TagsBox)
        Me.Controls.Add(Me.DxfViewerControl1)
        Me.Controls.Add(Me.ExportDxf)
        Me.Controls.Add(Me.ExportSpf)
        Me.Controls.Add(Me.DxfIndicator)
        Me.Controls.Add(Me.AddToDb)
        Me.Controls.Add(Me.SelectDxf)
        Me.Controls.Add(Me.NameBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Preview3)
        Me.Controls.Add(Me.Preview2)
        Me.Controls.Add(Me.Preview1)
        Me.Name = "TemplateEditor"
        Me.Text = "AddTemplate"
        CType(Me.Preview1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Preview3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Preview1 As PictureBox
    Friend WithEvents Preview2 As PictureBox
    Friend WithEvents Preview3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents NameBox As TextBox
    Friend WithEvents SelectDxf As Button
    Friend WithEvents DxfFileDialog As OpenFileDialog
    Friend WithEvents ImageFileDialog As OpenFileDialog
    Friend WithEvents AddToDb As Button
    Friend WithEvents DxfIndicator As Label
    Friend WithEvents ExportSpf As Button
    Friend WithEvents ExportDxf As Button
    Friend WithEvents DxfSaveDialog As SaveFileDialog
    Friend WithEvents SpfSaveDialog As SaveFileDialog
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents TagsBox As ListBox
    Friend WithEvents SpfOpenDialog As OpenFileDialog
    Friend WithEvents ImportSpf As Button
    Friend WithEvents AddTag As Button
    Friend WithEvents RemoveTag As Button
    Friend WithEvents ShortDescription As RichTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LongDescription As RichTextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GuidBox As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents NewGuidButton As Button
End Class
