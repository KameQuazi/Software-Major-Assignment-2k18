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
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.ZoomLevelBox = New System.Windows.Forms.TextBox()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileBtn
        '
        Me.OpenFileBtn.Location = New System.Drawing.Point(44, 45)
        Me.OpenFileBtn.Name = "OpenFileBtn"
        Me.OpenFileBtn.Size = New System.Drawing.Size(75, 23)
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
        Me.SaveFileBtn.Location = New System.Drawing.Point(44, 74)
        Me.SaveFileBtn.Name = "SaveFileBtn"
        Me.SaveFileBtn.Size = New System.Drawing.Size(75, 23)
        Me.SaveFileBtn.TabIndex = 1
        Me.SaveFileBtn.Text = "Save file"
        Me.SaveFileBtn.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(52, 264)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(76, 20)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(52, 297)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(76, 20)
        Me.TextBox2.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(63, 343)
        Me.Button4.Margin = New System.Windows.Forms.Padding(2)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(56, 19)
        Me.Button4.TabIndex = 7
        Me.Button4.Text = "New line"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 264)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "start"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 300)
        Me.Label2.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "end"
        '
        'jsonOutput
        '
        Me.jsonOutput.Location = New System.Drawing.Point(615, 208)
        Me.jsonOutput.Margin = New System.Windows.Forms.Padding(2)
        Me.jsonOutput.Name = "jsonOutput"
        Me.jsonOutput.Size = New System.Drawing.Size(154, 171)
        Me.jsonOutput.TabIndex = 11
        Me.jsonOutput.Text = "serialized her"
        '
        'rightButton
        '
        Me.rightButton.Location = New System.Drawing.Point(753, 122)
        Me.rightButton.Name = "rightButton"
        Me.rightButton.Size = New System.Drawing.Size(75, 23)
        Me.rightButton.TabIndex = 12
        Me.rightButton.Text = "->"
        Me.rightButton.UseVisualStyleBackColor = True
        '
        'downButton
        '
        Me.downButton.Location = New System.Drawing.Point(668, 163)
        Me.downButton.Name = "downButton"
        Me.downButton.Size = New System.Drawing.Size(75, 23)
        Me.downButton.TabIndex = 13
        Me.downButton.Text = "v"
        Me.downButton.UseVisualStyleBackColor = True
        '
        'leftButton
        '
        Me.leftButton.Location = New System.Drawing.Point(594, 122)
        Me.leftButton.Name = "leftButton"
        Me.leftButton.Size = New System.Drawing.Size(75, 23)
        Me.leftButton.TabIndex = 14
        Me.leftButton.Text = "<-"
        Me.leftButton.UseVisualStyleBackColor = True
        '
        'upButton
        '
        Me.upButton.Location = New System.Drawing.Point(668, 71)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(75, 23)
        Me.upButton.TabIndex = 15
        Me.upButton.Text = "^"
        Me.upButton.UseVisualStyleBackColor = True
        '
        'FilenameTbox
        '
        Me.FilenameTbox.Location = New System.Drawing.Point(9, 144)
        Me.FilenameTbox.Margin = New System.Windows.Forms.Padding(2)
        Me.FilenameTbox.Name = "FilenameTbox"
        Me.FilenameTbox.Size = New System.Drawing.Size(195, 79)
        Me.FilenameTbox.TabIndex = 16
        Me.FilenameTbox.Text = ""
        '
        'DesignerScreen1
        '
        Me.DesignerScreen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DesignerScreen1.Center = CType(resources.GetObject("DesignerScreen1.Center"), System.Drawing.PointF)
        Me.DesignerScreen1.Location = New System.Drawing.Point(212, 54)
        Me.DesignerScreen1.Margin = New System.Windows.Forms.Padding(4)
        Me.DesignerScreen1.Name = "DesignerScreen1"
        Me.DesignerScreen1.Size = New System.Drawing.Size(376, 407)
        Me.DesignerScreen1.Source = Nothing
        Me.DesignerScreen1.TabIndex = 17
        Me.DesignerScreen1.ZoomX = 1.0R
        Me.DesignerScreen1.ZoomY = 1.0R
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(44, 103)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Save As Dxf"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TrackBar1
        '
        Me.TrackBar1.Location = New System.Drawing.Point(627, 395)
        Me.TrackBar1.Maximum = 30
        Me.TrackBar1.Minimum = 1
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(201, 45)
        Me.TrackBar1.TabIndex = 19
        Me.TrackBar1.Value = 10
        '
        'ZoomLevelBox
        '
        Me.ZoomLevelBox.Enabled = False
        Me.ZoomLevelBox.Location = New System.Drawing.Point(668, 439)
        Me.ZoomLevelBox.Name = "ZoomLevelBox"
        Me.ZoomLevelBox.Size = New System.Drawing.Size(100, 20)
        Me.ZoomLevelBox.TabIndex = 20
        Me.ZoomLevelBox.Text = "1"
        '
        'DesignerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(864, 471)
        Me.Controls.Add(Me.ZoomLevelBox)
        Me.Controls.Add(Me.TrackBar1)
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
        Me.Name = "DesignerForm"
        Me.Text = "Form1"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TrackBar1 As TrackBar
    Friend WithEvents ZoomLevelBox As TextBox
End Class
