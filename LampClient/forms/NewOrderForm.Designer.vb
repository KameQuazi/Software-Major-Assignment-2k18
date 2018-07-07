<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewOrderForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewOrderForm))
        Me.txtRecipient = New System.Windows.Forms.TextBox()
        Me.txtPrefix = New System.Windows.Forms.ComboBox()
        Me.grpParameters = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkYear = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.DxfViewerControl1 = New LampClient.DxfViewerControl()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.grpParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRecipient
        '
        Me.txtRecipient.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtRecipient.Location = New System.Drawing.Point(173, 29)
        Me.txtRecipient.Name = "txtRecipient"
        Me.txtRecipient.Size = New System.Drawing.Size(224, 34)
        Me.txtRecipient.TabIndex = 33
        Me.txtRecipient.Text = "Insert Name Here"
        '
        'txtPrefix
        '
        Me.txtPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtPrefix.FormattingEnabled = True
        Me.txtPrefix.Items.AddRange(New Object() {"Awarded to:", "to:"})
        Me.txtPrefix.Location = New System.Drawing.Point(6, 29)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(161, 37)
        Me.txtPrefix.TabIndex = 34
        '
        'grpParameters
        '
        Me.grpParameters.Controls.Add(Me.Label1)
        Me.grpParameters.Controls.Add(Me.chkYear)
        Me.grpParameters.Controls.Add(Me.TextBox1)
        Me.grpParameters.Controls.Add(Me.txtPrefix)
        Me.grpParameters.Controls.Add(Me.txtRecipient)
        Me.grpParameters.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.grpParameters.Location = New System.Drawing.Point(617, 114)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(427, 526)
        Me.grpParameters.TabIndex = 36
        Me.grpParameters.TabStop = False
        Me.grpParameters.Text = "Edit Text"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 384)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(59, 25)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Year:"
        '
        'chkYear
        '
        Me.chkYear.AutoSize = True
        Me.chkYear.Location = New System.Drawing.Point(23, 352)
        Me.chkYear.Name = "chkYear"
        Me.chkYear.Size = New System.Drawing.Size(154, 29)
        Me.chkYear.TabIndex = 36
        Me.chkYear.Text = "Include Year?"
        Me.chkYear.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.TextBox1.Location = New System.Drawing.Point(83, 380)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(63, 34)
        Me.TextBox1.TabIndex = 35
        Me.TextBox1.Text = "2018"
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = True
        Me.ToolBar1.Location = New System.Drawing.Point(1, 0)
        Me.ToolBar1.MyOrdersEnabled = True
        Me.ToolBar1.MyTrophyEnabled = True
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1231, 108)
        Me.ToolBar1.TabIndex = 37
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.8!)
        Me.Button1.Location = New System.Drawing.Point(1067, 647)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(129, 44)
        Me.Button1.TabIndex = 38
        Me.Button1.Text = "Next"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BackColor = System.Drawing.Color.White
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Drawing = Nothing
        Me.DxfViewerControl1.Location = New System.Drawing.Point(1, 108)
        Me.DxfViewerControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Size = New System.Drawing.Size(609, 532)
        Me.DxfViewerControl1.TabIndex = 39
        Me.DxfViewerControl1.ZoomX = 1.0R
        Me.DxfViewerControl1.ZoomY = 1.0R
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.White
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.8!)
        Me.Button2.Location = New System.Drawing.Point(481, 647)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(129, 52)
        Me.Button2.TabIndex = 40
        Me.Button2.Text = "choose new design"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'NewOrderForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.DxfViewerControl1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.grpParameters)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CreateJob"
        Me.grpParameters.ResumeLayout(False)
        Me.grpParameters.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtRecipient As TextBox
    Friend WithEvents txtPrefix As ComboBox
    Friend WithEvents grpParameters As GroupBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents chkYear As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents Button1 As Button
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents Button2 As Button
End Class
