<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FileViewer
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
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSort = New System.Windows.Forms.ComboBox()
        Me.lblSort = New System.Windows.Forms.Label()
        Me.FileDisplay5 = New LAMP.fileDisplay()
        Me.FileDisplay6 = New LAMP.fileDisplay()
        Me.FileDisplay7 = New LAMP.fileDisplay()
        Me.FileDisplay8 = New LAMP.fileDisplay()
        Me.FileDisplay4 = New LAMP.fileDisplay()
        Me.FileDisplay3 = New LAMP.fileDisplay()
        Me.FileDisplay2 = New LAMP.fileDisplay()
        Me.FileDisplay1 = New LAMP.fileDisplay()
        Me.ToolBar1 = New LAMP.ToolBar()
        Me.SuspendLayout()
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(867, 710)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(42, 25)
        Me.btnNext.TabIndex = 4
        Me.btnNext.Text = "->"
        Me.btnNext.UseVisualStyleBackColor = True
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(819, 710)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(42, 25)
        Me.btnPrev.TabIndex = 5
        Me.btnPrev.Text = "<-"
        Me.btnPrev.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(827, 735)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Prev"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(875, 735)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "next"
        '
        'cmbSort
        '
        Me.cmbSort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSort.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSort.FormattingEnabled = True
        Me.cmbSort.Items.AddRange(New Object() {"Creator (Alphabetical)", "Date Created", "Height (Ascending)", "Height (Descending)", "Material", "Name (Alphabetical)", "Width (Ascending)", "Width (Descending)"})
        Me.cmbSort.Location = New System.Drawing.Point(788, 96)
        Me.cmbSort.Name = "cmbSort"
        Me.cmbSort.Size = New System.Drawing.Size(188, 26)
        Me.cmbSort.Sorted = True
        Me.cmbSort.TabIndex = 17
        '
        'lblSort
        '
        Me.lblSort.AutoSize = True
        Me.lblSort.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSort.Location = New System.Drawing.Point(722, 99)
        Me.lblSort.Name = "lblSort"
        Me.lblSort.Size = New System.Drawing.Size(63, 18)
        Me.lblSort.TabIndex = 13
        Me.lblSort.Text = "Sort By:"
        '
        'FileDisplay5
        '
        Me.FileDisplay5.BackColor = System.Drawing.Color.White
        Me.FileDisplay5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay5.Location = New System.Drawing.Point(91, 426)
        Me.FileDisplay5.Name = "FileDisplay5"
        Me.FileDisplay5.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay5.TabIndex = 27
        '
        'FileDisplay6
        '
        Me.FileDisplay6.BackColor = System.Drawing.Color.White
        Me.FileDisplay6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay6.Location = New System.Drawing.Point(297, 426)
        Me.FileDisplay6.Name = "FileDisplay6"
        Me.FileDisplay6.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay6.TabIndex = 26
        '
        'FileDisplay7
        '
        Me.FileDisplay7.BackColor = System.Drawing.Color.White
        Me.FileDisplay7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay7.Location = New System.Drawing.Point(503, 426)
        Me.FileDisplay7.Name = "FileDisplay7"
        Me.FileDisplay7.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay7.TabIndex = 25
        '
        'FileDisplay8
        '
        Me.FileDisplay8.BackColor = System.Drawing.Color.White
        Me.FileDisplay8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay8.Location = New System.Drawing.Point(709, 426)
        Me.FileDisplay8.Name = "FileDisplay8"
        Me.FileDisplay8.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay8.TabIndex = 24
        '
        'FileDisplay4
        '
        Me.FileDisplay4.BackColor = System.Drawing.Color.White
        Me.FileDisplay4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay4.Location = New System.Drawing.Point(709, 150)
        Me.FileDisplay4.Name = "FileDisplay4"
        Me.FileDisplay4.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay4.TabIndex = 23
        '
        'FileDisplay3
        '
        Me.FileDisplay3.BackColor = System.Drawing.Color.White
        Me.FileDisplay3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay3.Location = New System.Drawing.Point(503, 150)
        Me.FileDisplay3.Name = "FileDisplay3"
        Me.FileDisplay3.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay3.TabIndex = 22
        '
        'FileDisplay2
        '
        Me.FileDisplay2.BackColor = System.Drawing.Color.White
        Me.FileDisplay2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay2.Location = New System.Drawing.Point(297, 150)
        Me.FileDisplay2.Name = "FileDisplay2"
        Me.FileDisplay2.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay2.TabIndex = 21
        '
        'FileDisplay1
        '
        Me.FileDisplay1.BackColor = System.Drawing.Color.White
        Me.FileDisplay1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay1.Location = New System.Drawing.Point(91, 150)
        Me.FileDisplay1.Name = "FileDisplay1"
        Me.FileDisplay1.Size = New System.Drawing.Size(200, 270)
        Me.FileDisplay1.TabIndex = 20
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.White
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(1000, 96)
        Me.ToolBar1.TabIndex = 18
        '
        'fileViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 750)
        Me.Controls.Add(Me.FileDisplay5)
        Me.Controls.Add(Me.FileDisplay6)
        Me.Controls.Add(Me.FileDisplay7)
        Me.Controls.Add(Me.FileDisplay8)
        Me.Controls.Add(Me.FileDisplay4)
        Me.Controls.Add(Me.FileDisplay3)
        Me.Controls.Add(Me.FileDisplay2)
        Me.Controls.Add(Me.FileDisplay1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.lblSort)
        Me.Controls.Add(Me.cmbSort)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnPrev)
        Me.Controls.Add(Me.btnNext)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "fileViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Viewer"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrev As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents cmbSort As ComboBox
    Friend WithEvents lblSort As Label
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents FileDisplay1 As fileDisplay
    Friend WithEvents FileDisplay2 As fileDisplay
    Friend WithEvents FileDisplay3 As fileDisplay
    Friend WithEvents FileDisplay4 As fileDisplay
    Friend WithEvents FileDisplay5 As fileDisplay
    Friend WithEvents FileDisplay6 As fileDisplay
    Friend WithEvents FileDisplay7 As fileDisplay
    Friend WithEvents FileDisplay8 As fileDisplay
End Class
