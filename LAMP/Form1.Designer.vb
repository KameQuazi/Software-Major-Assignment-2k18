<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Me.OpenFileBtn = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileBtn = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.jsonOutput = New System.Windows.Forms.RichTextBox()
        Me.rightButton = New System.Windows.Forms.Button()
        Me.downButton = New System.Windows.Forms.Button()
        Me.leftButton = New System.Windows.Forms.Button()
        Me.upButton = New System.Windows.Forms.Button()
        Me.FilenameTbox = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'OpenFileBtn
        '
        Me.OpenFileBtn.Location = New System.Drawing.Point(60, 87)
        Me.OpenFileBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OpenFileBtn.Name = "OpenFileBtn"
        Me.OpenFileBtn.Size = New System.Drawing.Size(100, 28)
        Me.OpenFileBtn.TabIndex = 0
        Me.OpenFileBtn.Text = "Open file"
        Me.OpenFileBtn.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "dxf Files|*.dxf|All files|*.*"
        '
        'SaveFileBtn
        '
        Me.SaveFileBtn.Enabled = False
        Me.SaveFileBtn.Location = New System.Drawing.Point(59, 123)
        Me.SaveFileBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SaveFileBtn.Name = "SaveFileBtn"
        Me.SaveFileBtn.Size = New System.Drawing.Size(100, 28)
        Me.SaveFileBtn.TabIndex = 1
        Me.SaveFileBtn.Text = "Save file"
        Me.SaveFileBtn.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(69, 325)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(69, 366)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(84, 422)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "New line"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 325)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "start"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(27, 369)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "end"
        '
        'jsonOutput
        '
        Me.jsonOutput.Location = New System.Drawing.Point(692, 226)
        Me.jsonOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.jsonOutput.Name = "jsonOutput"
        Me.jsonOutput.Size = New System.Drawing.Size(279, 210)
        Me.jsonOutput.TabIndex = 11
        Me.jsonOutput.Text = "serialized her"
        '
        'rightButton
        '
        Me.rightButton.Location = New System.Drawing.Point(872, 103)
        Me.rightButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rightButton.Name = "rightButton"
        Me.rightButton.Size = New System.Drawing.Size(100, 28)
        Me.rightButton.TabIndex = 12
        Me.rightButton.Text = "->"
        Me.rightButton.UseVisualStyleBackColor = True
        '
        'downButton
        '
        Me.downButton.Location = New System.Drawing.Point(776, 162)
        Me.downButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(100, 28)
        Me.downButton.TabIndex = 13
        Me.downButton.Text = "V"
        Me.downButton.UseVisualStyleBackColor = True
        '
        'leftButton
        '
        Me.leftButton.Location = New System.Drawing.Point(692, 103)
        Me.leftButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.leftButton.Name = "leftButton"
        Me.leftButton.Size = New System.Drawing.Size(100, 28)
        Me.leftButton.TabIndex = 14
        Me.leftButton.Text = "<-"
        Me.leftButton.UseVisualStyleBackColor = True
        '
        'upButton
        '
        Me.upButton.Location = New System.Drawing.Point(792, 46)
        Me.upButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(100, 28)
        Me.upButton.TabIndex = 15
        Me.upButton.Text = "^"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'FilenameTbox
        '
        Me.FilenameTbox.Location = New System.Drawing.Point(12, 177)
        Me.FilenameTbox.Name = "FilenameTbox"
        Me.FilenameTbox.Size = New System.Drawing.Size(259, 96)
        Me.FilenameTbox.TabIndex = 16
        Me.FilenameTbox.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(983, 480)
        Me.Controls.Add(Me.FilenameTbox)
        Me.Controls.Add(Me.upButton)
        Me.Controls.Add(Me.leftButton)
        Me.Controls.Add(Me.downButton)
        Me.Controls.Add(Me.rightButton)
        Me.Controls.Add(Me.jsonOutput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.SaveFileBtn)
        Me.Controls.Add(Me.OpenFileBtn)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileBtn As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileBtn As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Button4 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents jsonOutput As RichTextBox
    Friend WithEvents rightButton As Button
    Friend WithEvents downButton As Button
    Friend WithEvents leftButton As Button
    Friend WithEvents upButton As Button
    Friend WithEvents FilenameTbox As RichTextBox
End Class
