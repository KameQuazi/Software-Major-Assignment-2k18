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
        Me.txtRecipient = New System.Windows.Forms.TextBox()
        Me.txtPrefix = New System.Windows.Forms.ComboBox()
        Me.grpParameters = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.chkYear = New System.Windows.Forms.CheckBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.grpParameters.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtRecipient
        '
        Me.txtRecipient.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtRecipient.Location = New System.Drawing.Point(190, 51)
        Me.txtRecipient.Name = "txtRecipient"
        Me.txtRecipient.Size = New System.Drawing.Size(224, 29)
        Me.txtRecipient.TabIndex = 33
        Me.txtRecipient.Text = "Insert Name Here"
        '
        'txtPrefix
        '
        Me.txtPrefix.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.txtPrefix.FormattingEnabled = True
        Me.txtPrefix.Items.AddRange(New Object() {"Awarded to:", "to:"})
        Me.txtPrefix.Location = New System.Drawing.Point(23, 51)
        Me.txtPrefix.Name = "txtPrefix"
        Me.txtPrefix.Size = New System.Drawing.Size(161, 32)
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
        Me.grpParameters.Location = New System.Drawing.Point(776, 139)
        Me.grpParameters.Name = "grpParameters"
        Me.grpParameters.Size = New System.Drawing.Size(420, 422)
        Me.grpParameters.TabIndex = 36
        Me.grpParameters.TabStop = False
        Me.grpParameters.Text = "Edit Text"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 129)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 20)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Year:"
        '
        'chkYear
        '
        Me.chkYear.AutoSize = True
        Me.chkYear.Location = New System.Drawing.Point(23, 96)
        Me.chkYear.Name = "chkYear"
        Me.chkYear.Size = New System.Drawing.Size(127, 24)
        Me.chkYear.TabIndex = 36
        Me.chkYear.Text = "Include Year?"
        Me.chkYear.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!)
        Me.TextBox1.Location = New System.Drawing.Point(83, 125)
        Me.TextBox1.MaxLength = 4
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(63, 29)
        Me.TextBox1.TabIndex = 35
        Me.TextBox1.Text = "2018"
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.Fuchsia
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
        'CreateJob
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.grpParameters)
        Me.Name = "CreateJob"
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
End Class
