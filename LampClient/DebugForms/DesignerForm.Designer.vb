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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.ZoomLevelBox = New System.Windows.Forms.TextBox()
        Me.DuplicateButton = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboxStaticText = New System.Windows.Forms.CheckBox()
        Me.cboxDynamicText = New System.Windows.Forms.CheckBox()
        Me.cboxLine = New System.Windows.Forms.CheckBox()
        Me.cboxCircle = New System.Windows.Forms.CheckBox()
        Me.cboxArc = New System.Windows.Forms.CheckBox()
        Me.cboxMeasure = New System.Windows.Forms.CheckBox()
        Me.rtboxPrevious = New System.Windows.Forms.RichTextBox()
        Me.rtboxCurrent = New System.Windows.Forms.RichTextBox()
        Me.DesignerScreen1 = New LampClient.DxfViewerControl()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileBtn
        '
        Me.OpenFileBtn.BackColor = System.Drawing.Color.White
        Me.OpenFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenFileBtn.Location = New System.Drawing.Point(73, 163)
        Me.OpenFileBtn.Margin = New System.Windows.Forms.Padding(4)
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
        Me.SaveFileBtn.Location = New System.Drawing.Point(73, 199)
        Me.SaveFileBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveFileBtn.Name = "SaveFileBtn"
        Me.SaveFileBtn.Size = New System.Drawing.Size(100, 28)
        Me.SaveFileBtn.TabIndex = 1
        Me.SaveFileBtn.Text = "Save file"
        Me.SaveFileBtn.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(125, 433)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 5
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(125, 474)
        Me.TextBox2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 6
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.White
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(140, 530)
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
        Me.Label1.Location = New System.Drawing.Point(83, 433)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(27, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "start"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(83, 477)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "end"
        '
        'jsonOutput
        '
        Me.jsonOutput.Location = New System.Drawing.Point(913, 343)
        Me.jsonOutput.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.jsonOutput.Name = "jsonOutput"
        Me.jsonOutput.Size = New System.Drawing.Size(204, 210)
        Me.jsonOutput.TabIndex = 11
        Me.jsonOutput.Text = "serialized here"
        '
        'rightButton
        '
        Me.rightButton.BackColor = System.Drawing.Color.White
        Me.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rightButton.Location = New System.Drawing.Point(1018, 258)
        Me.rightButton.Margin = New System.Windows.Forms.Padding(4)
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
        Me.downButton.Location = New System.Drawing.Point(966, 294)
        Me.downButton.Margin = New System.Windows.Forms.Padding(4)
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
        Me.leftButton.Location = New System.Drawing.Point(910, 258)
        Me.leftButton.Margin = New System.Windows.Forms.Padding(4)
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
        Me.upButton.Location = New System.Drawing.Point(966, 222)
        Me.upButton.Margin = New System.Windows.Forms.Padding(4)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(100, 28)
        Me.upButton.TabIndex = 15
        Me.upButton.Text = "^"
        Me.upButton.UseVisualStyleBackColor = False
        '
        'FilenameTbox
        '
        Me.FilenameTbox.Location = New System.Drawing.Point(12, 280)
        Me.FilenameTbox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FilenameTbox.Name = "FilenameTbox"
        Me.FilenameTbox.Size = New System.Drawing.Size(170, 96)
        Me.FilenameTbox.TabIndex = 16
        Me.FilenameTbox.Text = ""
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(73, 235)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Save As spf"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'TrackBar1
        '
        Me.TrackBar1.BackColor = System.Drawing.Color.White
        Me.TrackBar1.LargeChange = 100
        Me.TrackBar1.Location = New System.Drawing.Point(892, 594)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.TrackBar1.Maximum = 1000
        Me.TrackBar1.Minimum = 10
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(268, 45)
        Me.TrackBar1.SmallChange = 10
        Me.TrackBar1.TabIndex = 19
        Me.TrackBar1.TickFrequency = 10
        Me.TrackBar1.Value = 10
        '
        'ZoomLevelBox
        '
        Me.ZoomLevelBox.Enabled = False
        Me.ZoomLevelBox.Location = New System.Drawing.Point(934, 654)
        Me.ZoomLevelBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ZoomLevelBox.Name = "ZoomLevelBox"
        Me.ZoomLevelBox.Size = New System.Drawing.Size(132, 20)
        Me.ZoomLevelBox.TabIndex = 20
        Me.ZoomLevelBox.Text = "100"
        '
        'DuplicateButton
        '
        Me.DuplicateButton.BackColor = System.Drawing.Color.White
        Me.DuplicateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.DuplicateButton.Location = New System.Drawing.Point(140, 577)
        Me.DuplicateButton.Margin = New System.Windows.Forms.Padding(4)
        Me.DuplicateButton.Name = "DuplicateButton"
        Me.DuplicateButton.Size = New System.Drawing.Size(100, 28)
        Me.DuplicateButton.TabIndex = 21
        Me.DuplicateButton.Text = "duplicate"
        Me.DuplicateButton.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(39, 646)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 28)
        Me.Button2.TabIndex = 22
        Me.Button2.Text = "OK"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'cboxStaticText
        '
        Me.cboxStaticText.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxStaticText.AutoSize = True
        Me.cboxStaticText.Location = New System.Drawing.Point(236, 382)
        Me.cboxStaticText.Name = "cboxStaticText"
        Me.cboxStaticText.Size = New System.Drawing.Size(68, 23)
        Me.cboxStaticText.TabIndex = 27
        Me.cboxStaticText.Text = "Static Text"
        Me.cboxStaticText.UseVisualStyleBackColor = True
        '
        'cboxDynamicText
        '
        Me.cboxDynamicText.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxDynamicText.AutoSize = True
        Me.cboxDynamicText.Location = New System.Drawing.Point(231, 423)
        Me.cboxDynamicText.Name = "cboxDynamicText"
        Me.cboxDynamicText.Size = New System.Drawing.Size(79, 23)
        Me.cboxDynamicText.TabIndex = 28
        Me.cboxDynamicText.Text = "DynamicText"
        Me.cboxDynamicText.UseVisualStyleBackColor = True
        '
        'cboxLine
        '
        Me.cboxLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxLine.AutoSize = True
        Me.cboxLine.Location = New System.Drawing.Point(261, 187)
        Me.cboxLine.Name = "cboxLine"
        Me.cboxLine.Size = New System.Drawing.Size(37, 23)
        Me.cboxLine.TabIndex = 29
        Me.cboxLine.Text = "Line"
        Me.cboxLine.UseVisualStyleBackColor = True
        '
        'cboxCircle
        '
        Me.cboxCircle.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxCircle.AutoSize = True
        Me.cboxCircle.Location = New System.Drawing.Point(257, 227)
        Me.cboxCircle.Name = "cboxCircle"
        Me.cboxCircle.Size = New System.Drawing.Size(43, 23)
        Me.cboxCircle.TabIndex = 30
        Me.cboxCircle.Text = "Cirlce"
        Me.cboxCircle.UseVisualStyleBackColor = True
        '
        'cboxArc
        '
        Me.cboxArc.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxArc.AutoSize = True
        Me.cboxArc.Location = New System.Drawing.Point(261, 294)
        Me.cboxArc.Name = "cboxArc"
        Me.cboxArc.Size = New System.Drawing.Size(33, 23)
        Me.cboxArc.TabIndex = 31
        Me.cboxArc.Text = "Arc"
        Me.cboxArc.UseVisualStyleBackColor = True
        '
        'cboxMeasure
        '
        Me.cboxMeasure.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxMeasure.AutoSize = True
        Me.cboxMeasure.Location = New System.Drawing.Point(257, 343)
        Me.cboxMeasure.Name = "cboxMeasure"
        Me.cboxMeasure.Size = New System.Drawing.Size(58, 23)
        Me.cboxMeasure.TabIndex = 32
        Me.cboxMeasure.Text = "Meausre"
        Me.cboxMeasure.UseVisualStyleBackColor = True
        '
        'rtboxPrevious
        '
        Me.rtboxPrevious.Location = New System.Drawing.Point(303, 548)
        Me.rtboxPrevious.Name = "rtboxPrevious"
        Me.rtboxPrevious.Size = New System.Drawing.Size(546, 96)
        Me.rtboxPrevious.TabIndex = 33
        Me.rtboxPrevious.Text = ""
        '
        'rtboxCurrent
        '
        Me.rtboxCurrent.Location = New System.Drawing.Point(303, 651)
        Me.rtboxCurrent.Name = "rtboxCurrent"
        Me.rtboxCurrent.Size = New System.Drawing.Size(546, 37)
        Me.rtboxCurrent.TabIndex = 34
        Me.rtboxCurrent.Text = ""
        '
        'DesignerScreen1
        '
        Me.DesignerScreen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DesignerScreen1.Center = CType(resources.GetObject("DesignerScreen1.Center"), System.Drawing.PointF)
        Me.DesignerScreen1.Drawing = Nothing
        Me.DesignerScreen1.Location = New System.Drawing.Point(339, 174)
        Me.DesignerScreen1.Margin = New System.Windows.Forms.Padding(5)
        Me.DesignerScreen1.Name = "DesignerScreen1"
        Me.DesignerScreen1.Size = New System.Drawing.Size(501, 366)
        Me.DesignerScreen1.TabIndex = 17
        Me.DesignerScreen1.ZoomX = 1.0R
        Me.DesignerScreen1.ZoomY = 1.0R
        '
        'DesignerForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.rtboxCurrent)
        Me.Controls.Add(Me.rtboxPrevious)
        Me.Controls.Add(Me.cboxMeasure)
        Me.Controls.Add(Me.cboxArc)
        Me.Controls.Add(Me.cboxCircle)
        Me.Controls.Add(Me.cboxLine)
        Me.Controls.Add(Me.cboxDynamicText)
        Me.Controls.Add(Me.cboxStaticText)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DuplicateButton)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DesignerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAMP - Designer"
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
    Friend WithEvents DuplicateButton As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents cboxStaticText As CheckBox
    Friend WithEvents cboxDynamicText As CheckBox
    Friend WithEvents cboxLine As CheckBox
    Friend WithEvents cboxCircle As CheckBox
    Friend WithEvents cboxArc As CheckBox
    Friend WithEvents cboxMeasure As CheckBox
    Friend WithEvents rtboxPrevious As RichTextBox
    Friend WithEvents rtboxCurrent As RichTextBox
End Class
