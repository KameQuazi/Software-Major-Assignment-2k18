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
        Me.rightButton = New System.Windows.Forms.Button()
        Me.downButton = New System.Windows.Forms.Button()
        Me.leftButton = New System.Windows.Forms.Button()
        Me.upButton = New System.Windows.Forms.Button()
        Me.FilenameTbox = New System.Windows.Forms.RichTextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SaveFileDialog2 = New System.Windows.Forms.SaveFileDialog()
        Me.TrackBar1 = New System.Windows.Forms.TrackBar()
        Me.ZoomLevelBox = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cboxStaticText = New System.Windows.Forms.CheckBox()
        Me.cboxDynamicText = New System.Windows.Forms.CheckBox()
        Me.cboxLine = New System.Windows.Forms.CheckBox()
        Me.cboxCircle = New System.Windows.Forms.CheckBox()
        Me.cboxMeasure = New System.Windows.Forms.CheckBox()
        Me.rtboxPrevious = New System.Windows.Forms.RichTextBox()
        Me.rtboxCurrent = New System.Windows.Forms.RichTextBox()
        Me.DesignerScreen1 = New LampClient.DxfViewerControl()
        Me.btnUndo = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CutSelectorControl1 = New LampClient.CutSelectorControl()
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'OpenFileBtn
        '
        Me.OpenFileBtn.BackColor = System.Drawing.Color.White
        Me.OpenFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.OpenFileBtn.Location = New System.Drawing.Point(7, 20)
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
        Me.SaveFileBtn.Location = New System.Drawing.Point(7, 56)
        Me.SaveFileBtn.Margin = New System.Windows.Forms.Padding(4)
        Me.SaveFileBtn.Name = "SaveFileBtn"
        Me.SaveFileBtn.Size = New System.Drawing.Size(100, 28)
        Me.SaveFileBtn.TabIndex = 1
        Me.SaveFileBtn.Text = "Save file"
        Me.SaveFileBtn.UseVisualStyleBackColor = False
        '
        'rightButton
        '
        Me.rightButton.BackColor = System.Drawing.Color.White
        Me.rightButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.rightButton.Location = New System.Drawing.Point(765, 129)
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
        Me.downButton.Location = New System.Drawing.Point(713, 165)
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
        Me.leftButton.Location = New System.Drawing.Point(657, 129)
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
        Me.upButton.Location = New System.Drawing.Point(713, 93)
        Me.upButton.Margin = New System.Windows.Forms.Padding(4)
        Me.upButton.Name = "upButton"
        Me.upButton.Size = New System.Drawing.Size(100, 28)
        Me.upButton.TabIndex = 15
        Me.upButton.Text = "^"
        Me.upButton.UseVisualStyleBackColor = False
        '
        'FilenameTbox
        '
        Me.FilenameTbox.Location = New System.Drawing.Point(661, 493)
        Me.FilenameTbox.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.FilenameTbox.Name = "FilenameTbox"
        Me.FilenameTbox.Size = New System.Drawing.Size(208, 96)
        Me.FilenameTbox.TabIndex = 16
        Me.FilenameTbox.Text = ""
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(115, 56)
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
        Me.TrackBar1.Location = New System.Drawing.Point(661, 412)
        Me.TrackBar1.Margin = New System.Windows.Forms.Padding(4)
        Me.TrackBar1.Maximum = 1000
        Me.TrackBar1.Minimum = 10
        Me.TrackBar1.Name = "TrackBar1"
        Me.TrackBar1.Size = New System.Drawing.Size(208, 45)
        Me.TrackBar1.SmallChange = 10
        Me.TrackBar1.TabIndex = 19
        Me.TrackBar1.TickFrequency = 10
        Me.TrackBar1.Value = 10
        '
        'ZoomLevelBox
        '
        Me.ZoomLevelBox.Enabled = False
        Me.ZoomLevelBox.Location = New System.Drawing.Point(661, 465)
        Me.ZoomLevelBox.Margin = New System.Windows.Forms.Padding(4)
        Me.ZoomLevelBox.Name = "ZoomLevelBox"
        Me.ZoomLevelBox.Size = New System.Drawing.Size(208, 20)
        Me.ZoomLevelBox.TabIndex = 20
        Me.ZoomLevelBox.Text = "100"
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(769, 647)
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
        Me.cboxStaticText.BackColor = System.Drawing.Color.White
        Me.cboxStaticText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboxStaticText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.cboxStaticText.Location = New System.Drawing.Point(6, 19)
        Me.cboxStaticText.Name = "cboxStaticText"
        Me.cboxStaticText.Size = New System.Drawing.Size(84, 27)
        Me.cboxStaticText.TabIndex = 27
        Me.cboxStaticText.Text = "Static Text"
        Me.cboxStaticText.UseVisualStyleBackColor = False
        '
        'cboxDynamicText
        '
        Me.cboxDynamicText.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxDynamicText.AutoSize = True
        Me.cboxDynamicText.BackColor = System.Drawing.Color.White
        Me.cboxDynamicText.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboxDynamicText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.cboxDynamicText.Location = New System.Drawing.Point(6, 56)
        Me.cboxDynamicText.Name = "cboxDynamicText"
        Me.cboxDynamicText.Size = New System.Drawing.Size(99, 27)
        Me.cboxDynamicText.TabIndex = 28
        Me.cboxDynamicText.Text = "DynamicText"
        Me.cboxDynamicText.UseVisualStyleBackColor = False
        '
        'cboxLine
        '
        Me.cboxLine.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxLine.AutoSize = True
        Me.cboxLine.BackColor = System.Drawing.Color.White
        Me.cboxLine.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboxLine.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.cboxLine.Location = New System.Drawing.Point(0, 19)
        Me.cboxLine.Name = "cboxLine"
        Me.cboxLine.Size = New System.Drawing.Size(45, 27)
        Me.cboxLine.TabIndex = 29
        Me.cboxLine.Text = "Line"
        Me.cboxLine.UseVisualStyleBackColor = False
        '
        'cboxCircle
        '
        Me.cboxCircle.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxCircle.AutoSize = True
        Me.cboxCircle.BackColor = System.Drawing.Color.White
        Me.cboxCircle.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboxCircle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.cboxCircle.Location = New System.Drawing.Point(6, 57)
        Me.cboxCircle.Name = "cboxCircle"
        Me.cboxCircle.Size = New System.Drawing.Size(53, 27)
        Me.cboxCircle.TabIndex = 30
        Me.cboxCircle.Text = "Circle"
        Me.cboxCircle.UseVisualStyleBackColor = False
        '
        'cboxMeasure
        '
        Me.cboxMeasure.Appearance = System.Windows.Forms.Appearance.Button
        Me.cboxMeasure.AutoSize = True
        Me.cboxMeasure.BackColor = System.Drawing.Color.White
        Me.cboxMeasure.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboxMeasure.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.cboxMeasure.Location = New System.Drawing.Point(48, 19)
        Me.cboxMeasure.Name = "cboxMeasure"
        Me.cboxMeasure.Size = New System.Drawing.Size(116, 27)
        Me.cboxMeasure.TabIndex = 32
        Me.cboxMeasure.Text = "Measuring Tool"
        Me.cboxMeasure.UseVisualStyleBackColor = False
        '
        'rtboxPrevious
        '
        Me.rtboxPrevious.Location = New System.Drawing.Point(12, 493)
        Me.rtboxPrevious.Name = "rtboxPrevious"
        Me.rtboxPrevious.Size = New System.Drawing.Size(636, 96)
        Me.rtboxPrevious.TabIndex = 33
        Me.rtboxPrevious.Text = ""
        '
        'rtboxCurrent
        '
        Me.rtboxCurrent.Location = New System.Drawing.Point(12, 595)
        Me.rtboxCurrent.Name = "rtboxCurrent"
        Me.rtboxCurrent.Size = New System.Drawing.Size(636, 45)
        Me.rtboxCurrent.TabIndex = 34
        Me.rtboxCurrent.Text = ""
        '
        'DesignerScreen1
        '
        Me.DesignerScreen1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DesignerScreen1.Center = CType(resources.GetObject("DesignerScreen1.Center"), System.Drawing.PointF)
        Me.DesignerScreen1.Location = New System.Drawing.Point(12, 120)
        Me.DesignerScreen1.Margin = New System.Windows.Forms.Padding(5)
        Me.DesignerScreen1.Name = "DesignerScreen1"
        Me.DesignerScreen1.Readonly = False
        Me.DesignerScreen1.Size = New System.Drawing.Size(636, 366)
        Me.DesignerScreen1.TabIndex = 17
        Me.DesignerScreen1.ZoomX = 1.0R
        Me.DesignerScreen1.ZoomY = 1.0R
        '
        'btnUndo
        '
        Me.btnUndo.BackColor = System.Drawing.Color.White
        Me.btnUndo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUndo.Location = New System.Drawing.Point(115, 20)
        Me.btnUndo.Margin = New System.Windows.Forms.Padding(4)
        Me.btnUndo.Name = "btnUndo"
        Me.btnUndo.Size = New System.Drawing.Size(100, 28)
        Me.btnUndo.TabIndex = 35
        Me.btnUndo.Text = "Undo"
        Me.btnUndo.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(661, 594)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(208, 20)
        Me.TextBox1.TabIndex = 36
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(661, 620)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(208, 20)
        Me.TextBox2.TabIndex = 37
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUndo)
        Me.GroupBox1.Controls.Add(Me.OpenFileBtn)
        Me.GroupBox1.Controls.Add(Me.SaveFileBtn)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(222, 100)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "File"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cboxLine)
        Me.GroupBox2.Controls.Add(Me.cboxCircle)
        Me.GroupBox2.Controls.Add(Me.cboxMeasure)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox2.Location = New System.Drawing.Point(240, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(164, 100)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Add"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cboxStaticText)
        Me.GroupBox3.Controls.Add(Me.cboxDynamicText)
        Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox3.Location = New System.Drawing.Point(410, 12)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(117, 100)
        Me.GroupBox3.TabIndex = 40
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Text"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CutSelectorControl1)
        Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.GroupBox4.Location = New System.Drawing.Point(675, 200)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(190, 194)
        Me.GroupBox4.TabIndex = 41
        Me.GroupBox4.TabStop = False
        '
        'CutSelectorControl1
        '
        Me.CutSelectorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CutSelectorControl1.Location = New System.Drawing.Point(3, 19)
        Me.CutSelectorControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.CutSelectorControl1.Name = "CutSelectorControl1"
        Me.CutSelectorControl1.Size = New System.Drawing.Size(184, 172)
        Me.CutSelectorControl1.TabIndex = 0
        '
        'DesignerForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(882, 685)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.rtboxCurrent)
        Me.Controls.Add(Me.rtboxPrevious)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.ZoomLevelBox)
        Me.Controls.Add(Me.TrackBar1)
        Me.Controls.Add(Me.DesignerScreen1)
        Me.Controls.Add(Me.FilenameTbox)
        Me.Controls.Add(Me.upButton)
        Me.Controls.Add(Me.leftButton)
        Me.Controls.Add(Me.downButton)
        Me.Controls.Add(Me.rightButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "DesignerForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAMP - Designer"
        CType(Me.TrackBar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileBtn As Button
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents SaveFileBtn As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
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
    Friend WithEvents Button2 As Button
    Friend WithEvents cboxStaticText As CheckBox
    Friend WithEvents cboxDynamicText As CheckBox
    Friend WithEvents cboxLine As CheckBox
    Friend WithEvents cboxCircle As CheckBox
    Friend WithEvents cboxMeasure As CheckBox
    Friend WithEvents rtboxPrevious As RichTextBox
    Friend WithEvents rtboxCurrent As RichTextBox
    Friend WithEvents btnUndo As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CutSelectorControl1 As CutSelectorControl
End Class
