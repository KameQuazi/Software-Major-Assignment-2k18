<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LoginForm
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoginForm))
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.PasswordCheckbox = New System.Windows.Forms.CheckBox()
        Me.cboxInternal = New System.Windows.Forms.CheckBox()
        Me.tboxServerUrl = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.btnTryConnection = New System.Windows.Forms.Button()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtUser.Location = New System.Drawing.Point(407, 486)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(193, 31)
        Me.txtUser.TabIndex = 0
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtPass.Location = New System.Drawing.Point(407, 529)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(193, 31)
        Me.txtPass.TabIndex = 1
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.lblUser.Location = New System.Drawing.Point(294, 493)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(88, 19)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Username:"
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.lblPass.Location = New System.Drawing.Point(296, 536)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(85, 19)
        Me.lblPass.TabIndex = 3
        Me.lblPass.Text = "Password:"
        '
        'pbLogo
        '
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), System.Drawing.Image)
        Me.pbLogo.Location = New System.Drawing.Point(275, 12)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(450, 450)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 4
        Me.pbLogo.TabStop = False
        '
        'btnLogin
        '
        Me.btnLogin.BackColor = System.Drawing.Color.White
        Me.btnLogin.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnLogin.Location = New System.Drawing.Point(509, 572)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(91, 53)
        Me.btnLogin.TabIndex = 5
        Me.btnLogin.Text = "Log In"
        Me.btnLogin.UseVisualStyleBackColor = False
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.Color.White
        Me.btnCreate.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnCreate.Location = New System.Drawing.Point(407, 572)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(91, 53)
        Me.btnCreate.TabIndex = 6
        Me.btnCreate.Text = "Sign Up"
        Me.btnCreate.UseVisualStyleBackColor = False
        '
        'PasswordCheckbox
        '
        Me.PasswordCheckbox.AutoSize = True
        Me.PasswordCheckbox.Location = New System.Drawing.Point(616, 539)
        Me.PasswordCheckbox.Name = "PasswordCheckbox"
        Me.PasswordCheckbox.Size = New System.Drawing.Size(104, 18)
        Me.PasswordCheckbox.TabIndex = 7
        Me.PasswordCheckbox.Text = "Save Password"
        Me.PasswordCheckbox.UseVisualStyleBackColor = True
        '
        'cboxInternal
        '
        Me.cboxInternal.AutoSize = True
        Me.cboxInternal.Location = New System.Drawing.Point(710, 682)
        Me.cboxInternal.Name = "cboxInternal"
        Me.cboxInternal.Size = New System.Drawing.Size(123, 18)
        Me.cboxInternal.TabIndex = 8
        Me.cboxInternal.Text = "Use Local Database"
        Me.cboxInternal.UseVisualStyleBackColor = True
        '
        'tboxServerUrl
        '
        Me.tboxServerUrl.Location = New System.Drawing.Point(710, 720)
        Me.tboxServerUrl.Name = "tboxServerUrl"
        Me.tboxServerUrl.Size = New System.Drawing.Size(160, 20)
        Me.tboxServerUrl.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(707, 703)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Server URL:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'btnTryConnection
        '
        Me.btnTryConnection.BackColor = System.Drawing.Color.White
        Me.btnTryConnection.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTryConnection.Location = New System.Drawing.Point(899, 719)
        Me.btnTryConnection.Name = "btnTryConnection"
        Me.btnTryConnection.Size = New System.Drawing.Size(101, 23)
        Me.btnTryConnection.TabIndex = 11
        Me.btnTryConnection.Text = "Retry Connection"
        Me.btnTryConnection.UseVisualStyleBackColor = False
        '
        'LoginForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(1000, 750)
        Me.Controls.Add(Me.btnTryConnection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tboxServerUrl)
        Me.Controls.Add(Me.cboxInternal)
        Me.Controls.Add(Me.PasswordCheckbox)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.btnLogin)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.txtUser)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LoginForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Log In"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtUser As TextBox
    Friend WithEvents txtPass As TextBox
    Friend WithEvents lblUser As Label
    Friend WithEvents lblPass As Label
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents PasswordCheckbox As CheckBox
    Friend WithEvents cboxInternal As CheckBox
    Friend WithEvents tboxServerUrl As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents btnTryConnection As Button
End Class
