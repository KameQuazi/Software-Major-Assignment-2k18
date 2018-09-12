<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LampPasswordBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LampPasswordBox))
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tboxPassword = New System.Windows.Forms.TextBox()
        Me.tboxConfirm = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblNoUser = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(260, 235)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(157, 235)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 47)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Enter New Password"
        '
        'tboxPassword
        '
        Me.tboxPassword.Location = New System.Drawing.Point(12, 63)
        Me.tboxPassword.Name = "tboxPassword"
        Me.tboxPassword.Size = New System.Drawing.Size(250, 20)
        Me.tboxPassword.TabIndex = 4
        Me.tboxPassword.UseSystemPasswordChar = True
        '
        'tboxConfirm
        '
        Me.tboxConfirm.Location = New System.Drawing.Point(12, 134)
        Me.tboxConfirm.Name = "tboxConfirm"
        Me.tboxConfirm.Size = New System.Drawing.Size(250, 20)
        Me.tboxConfirm.TabIndex = 5
        Me.tboxConfirm.UseSystemPasswordChar = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Enter password again:"
        '
        'lblNoUser
        '
        Me.lblNoUser.AutoSize = True
        Me.lblNoUser.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblNoUser.ForeColor = System.Drawing.Color.Red
        Me.lblNoUser.Location = New System.Drawing.Point(118, 86)
        Me.lblNoUser.Name = "lblNoUser"
        Me.lblNoUser.Size = New System.Drawing.Size(144, 15)
        Me.lblNoUser.TabIndex = 28
        Me.lblNoUser.Text = "Passwords do not match"
        Me.lblNoUser.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(118, 157)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Passwords do not match"
        Me.Label3.Visible = False
        '
        'LampPasswordBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(358, 270)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lblNoUser)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tboxConfirm)
        Me.Controls.Add(Me.tboxPassword)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LampPasswordBox"
        Me.Text = "Enter Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents tboxPassword As TextBox
    Friend WithEvents tboxConfirm As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents lblNoUser As Label
    Friend WithEvents Label3 As Label
End Class
