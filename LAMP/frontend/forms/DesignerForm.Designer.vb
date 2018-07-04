<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DesignerForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DesignerForm))
        Me.OpenFileBtn = New System.Windows.Forms.Button()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SaveFileBtn = New System.Windows.Forms.Button()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
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
        Me.DesignerScreen1 = New LAMP.DxfViewerControl()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.ToolBar1 = New LAMP.ToolBar()
        Me.SuspendLayout()
        '
        'OpenFileBtn
        '
        Me.OpenFileBtn.BackColor = System.Drawing.Color.White
        Me.OpenFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenFileBtn.Location = New System.Drawing.Point(95, 147)
        Me.OpenFileBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OpenFileBtn.Name = "OpenFileBtn"
        Me.OpenFileBtn.Size = New System.Drawing.Size(100, 28)
        Me.OpenFileBtn.TabIndex = 0
        Me.OpenFileBtn.Text = "Open file"
        Me.OpenFileBtn.UseVisualStyleBackColor = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        Me.OpenFileDialog1.Filter = "dxf Files|*.dxf|All files|*.*"
        '
        'SaveFileBtn
        '
        Me.SaveFileBtn.BackColor = System.Drawing.Color.White
        Me.SaveFileBtn.Enabled = False
        Me.SaveFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.SaveFileBtn.Location = New System.Drawing.Point(95, 183)
        Me.SaveFileBtn.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.SaveFileBtn.Name = "SaveFileBtn"
        Me.SaveFileBtn.Size = New System.Drawing.Size(100, 28)
        Me.SaveFileBtn.TabIndex = 1
        Me.SaveFileBtn.Text = "Save file"
        Me.SaveFileBtn.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(105, 417)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 22)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(105, 458)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 22)
        Me.TextBox2.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(120, 514)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "New line"
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(63, 417)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(36, 17)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "start"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(63, 461)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 17)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "end"
        '
        'jsonOutput
        '
        Me.jsonOutput.Location = New System.Drawing.Point(943, 377)
        Me.jsonOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.jsonOutput.Name = "jsonOutput"
        Me.jsonOutput.Size = New System.Drawing.Size(204, 210)
        Me.jsonOutput.TabIndex = 11
        Me.jsonOutput.Text = "serialized her"
        '
        'rightButton
        '
        Me.rightButton.BackColor = System.Drawing.Color.White
        Me.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rightButton.Location = New System.Drawing.Point(1047, 266)
        Me.rightButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.rightButton.Name = "rightButton"
        Me.rightButton.Size = New System.Drawing.Size(100, 28)
        Me.rightButton.TabIndex = 12
        Me.rightButton.Text = "->"
        Me.rightButton.UseVisualStyleBackColor = False
        '
        'downButton
        '
        Me.downButton.BackColor = System.Drawing.Color.White
        Me.downButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.downButton.Location = New System.Drawing.Point(995, 302)
        Me.downButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(100, 28)
        Me.downButton.TabIndex = 13
        Me.downButton.Text = "v"
        Me.downButton.UseVisualStyleBackColor = False
        '
        'leftButton
        '
        Me.leftButton.BackColor = System.Drawing.Color.White
        Me.leftButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.leftButton.Location = New System.Drawing.Point(943, 266)
        Me.leftButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.leftButton.Name = "leftButton"
        Me.leftButton.Size = New System.Drawing.Size(100, 28)
        Me.leftButton.TabIndex = 14
        Me.leftButton.Text = "<-"
        Me.leftButton.UseVisualStyleBackColor = False
        '
        'upButton
        '
        Me.upButton.BackColor = System.Drawing.Color.White
        Me.upButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.upButton.Location = New System.Drawing.Point(995, 230)
        Me.upButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(100, 28)
        Me.upButton.TabIndex = 15
        Me.upButton.Text = "^"
        Me.upButton.UseVisualStyleBackColor = False
        '
        'FilenameTbox
        '
        Me.FilenameTbox.Location = New System.Drawing.Point(12, 253)
        Me.FilenameTbox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FilenameTbox.Name = "FilenameTbox"
        Me.FilenameTbox.Size = New System.Drawing.Size(259, 96)
        Me.FilenameTbox.TabIndex = 16
        Me.FilenameTbox.Text = ""
        '
        'DesignerScreen1
        '
        Me.DesignerScreen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DesignerScreen1.Center = CType(resources.GetObject("DesignerScreen1.Center"), System.Drawing.PointF)
        Me.DesignerScreen1.Location = New System.Drawing.Point(319, 158)
        Me.DesignerScreen1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.DesignerScreen1.Name = "DesignerScreen1"
        Me.DesignerScreen1.Size = New System.Drawing.Size(501, 500)
        Me.DesignerScreen1.Source = Nothing
        Me.DesignerScreen1.TabIndex = 17
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(95, 219)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Save As Dxf"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.Fuchsia
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(1231, 108)
        Me.ToolBar1.TabIndex = 19
        '
        'DesignerForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DesignerScreen1)
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
        Me.Name = "DesignerForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileBtn As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileBtn As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
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
    Friend WithEvents DesignerScreen1 As DxfViewerControl
    Friend WithEvents Button1 As Button
    Friend WithEvents SaveFileDialog2 As SaveFileDialog
    Friend WithEvents ToolBar1 As ToolBar
End Class
