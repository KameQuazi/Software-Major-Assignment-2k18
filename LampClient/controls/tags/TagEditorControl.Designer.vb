<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TagEditorControl
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
        Me.TagDivider = New System.Windows.Forms.TableLayoutPanel()
        Me.TagsBox = New System.Windows.Forms.ListBox()
        Me.RemoveTag = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AddTag = New System.Windows.Forms.Button()
        Me.TagDivider.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TagDivider
        '
        Me.TagDivider.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TagDivider.ColumnCount = 1
        Me.TagDivider.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TagDivider.Controls.Add(Me.TagsBox, 0, 0)
        Me.TagDivider.Controls.Add(Me.TableLayoutPanel1, 0, 1)
        Me.TagDivider.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagDivider.Location = New System.Drawing.Point(0, 0)
        Me.TagDivider.Name = "TagDivider"
        Me.TagDivider.RowCount = 2
        Me.TagDivider.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TagDivider.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TagDivider.Size = New System.Drawing.Size(517, 373)
        Me.TagDivider.TabIndex = 1
        '
        'TagsBox
        '
        Me.TagsBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagsBox.FormattingEnabled = True
        Me.TagsBox.Items.AddRange(New Object() {""})
        Me.TagsBox.Location = New System.Drawing.Point(17, 17)
        Me.TagsBox.Margin = New System.Windows.Forms.Padding(16)
        Me.TagsBox.Name = "TagsBox"
        Me.TagsBox.Size = New System.Drawing.Size(483, 282)
        Me.TagsBox.TabIndex = 29
        '
        'RemoveTag
        '
        Me.RemoveTag.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.RemoveTag.BackColor = System.Drawing.Color.White
        Me.RemoveTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RemoveTag.Location = New System.Drawing.Point(257, 6)
        Me.RemoveTag.Margin = New System.Windows.Forms.Padding(3, 0, 0, 0)
        Me.RemoveTag.Name = "RemoveTag"
        Me.RemoveTag.Size = New System.Drawing.Size(100, 38)
        Me.RemoveTag.TabIndex = 16
        Me.RemoveTag.Text = "Remove Tag"
        Me.RemoveTag.UseVisualStyleBackColor = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AddTag, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.RemoveTag, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(4, 319)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(509, 50)
        Me.TableLayoutPanel1.TabIndex = 30
        '
        'AddTag
        '
        Me.AddTag.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.AddTag.BackColor = System.Drawing.Color.White
        Me.AddTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.AddTag.Location = New System.Drawing.Point(151, 6)
        Me.AddTag.Margin = New System.Windows.Forms.Padding(0, 0, 3, 0)
        Me.AddTag.Name = "AddTag"
        Me.AddTag.Size = New System.Drawing.Size(100, 37)
        Me.AddTag.TabIndex = 17
        Me.AddTag.Text = "Add Tag"
        Me.AddTag.UseVisualStyleBackColor = False
        '
        'TagEditorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TagDivider)
        Me.Name = "TagEditorControl"
        Me.Size = New System.Drawing.Size(517, 373)
        Me.TagDivider.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TagDivider As TableLayoutPanel
    Friend WithEvents TagsBox As ListBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents AddTag As Button
    Friend WithEvents RemoveTag As Button
End Class
