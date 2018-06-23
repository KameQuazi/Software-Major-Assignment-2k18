<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmStart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStart))
        Me.login = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnCreateAcc = New System.Windows.Forms.Button()
        Me.btnlogon = New System.Windows.Forms.Button()
        Me.lblLogin = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.WelcomePanel = New System.Windows.Forms.Panel()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.btnAccCreate = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnLogin = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.login.SuspendLayout()
        Me.WelcomePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'login
        '
        Me.login.Controls.Add(Me.Button1)
        Me.login.Controls.Add(Me.btnCreateAcc)
        Me.login.Controls.Add(Me.btnlogon)
        Me.login.Controls.Add(Me.lblLogin)
        Me.login.Controls.Add(Me.txtPass)
        Me.login.Controls.Add(Me.txtUser)
        Me.login.Controls.Add(Me.lblPass)
        Me.login.Controls.Add(Me.lblUser)
        Me.login.Location = New System.Drawing.Point(309, 378)
        Me.login.Name = "login"
        Me.login.Size = New System.Drawing.Size(382, 162)
        Me.login.TabIndex = 7
        Me.login.Visible = False
        '
        'Button1
        '
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(0, 126)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(59, 27)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Back"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnCreateAcc
        '
        Me.btnCreateAcc.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateAcc.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateAcc.Location = New System.Drawing.Point(65, 126)
        Me.btnCreateAcc.Name = "btnCreateAcc"
        Me.btnCreateAcc.Size = New System.Drawing.Size(123, 27)
        Me.btnCreateAcc.TabIndex = 6
        Me.btnCreateAcc.Text = "Create Account"
        Me.btnCreateAcc.UseVisualStyleBackColor = True
        '
        'btnlogon
        '
        Me.btnlogon.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnlogon.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlogon.Location = New System.Drawing.Point(194, 126)
        Me.btnlogon.Name = "btnlogon"
        Me.btnlogon.Size = New System.Drawing.Size(142, 27)
        Me.btnlogon.TabIndex = 7
        Me.btnlogon.Text = "Log In"
        Me.btnlogon.UseVisualStyleBackColor = True
        '
        'lblLogin
        '
        Me.lblLogin.AutoSize = True
        Me.lblLogin.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLogin.Location = New System.Drawing.Point(47, 29)
        Me.lblLogin.Name = "lblLogin"
        Me.lblLogin.Size = New System.Drawing.Size(307, 18)
        Me.lblLogin.TabIndex = 4
        Me.lblLogin.Text = "Login with your SBHS Email and Password"
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPass.Location = New System.Drawing.Point(151, 91)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(186, 29)
        Me.txtPass.TabIndex = 1
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUser.Location = New System.Drawing.Point(151, 56)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(186, 29)
        Me.txtUser.TabIndex = 0
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblPass.Location = New System.Drawing.Point(53, 94)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(99, 22)
        Me.lblPass.TabIndex = 3
        Me.lblPass.Text = "Password:"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Arial", 14.25!)
        Me.lblUser.Location = New System.Drawing.Point(51, 60)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(102, 22)
        Me.lblUser.TabIndex = 2
        Me.lblUser.Text = "Username:"
        '
        'WelcomePanel
        '
        Me.WelcomePanel.Controls.Add(Me.ToolBar1)
        Me.WelcomePanel.Controls.Add(Me.login)
        Me.WelcomePanel.Controls.Add(Me.btnAccCreate)
        Me.WelcomePanel.Controls.Add(Me.Label1)
        Me.WelcomePanel.Controls.Add(Me.btnLogin)
        Me.WelcomePanel.Controls.Add(Me.Label2)
        Me.WelcomePanel.Location = New System.Drawing.Point(0, 0)
        Me.WelcomePanel.Name = "WelcomePanel"
        Me.WelcomePanel.Size = New System.Drawing.Size(1000, 750)
        Me.WelcomePanel.TabIndex = 12
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.White
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ScreenName = "SCREEN NAME HERE"
        Me.ToolBar1.Size = New System.Drawing.Size(1000, 91)
        Me.ToolBar1.TabIndex = 13
        '
        'btnAccCreate
        '
        Me.btnAccCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAccCreate.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAccCreate.Location = New System.Drawing.Point(503, 446)
        Me.btnAccCreate.Name = "btnAccCreate"
        Me.btnAccCreate.Size = New System.Drawing.Size(166, 85)
        Me.btnAccCreate.TabIndex = 12
        Me.btnAccCreate.Text = "Create Account"
        Me.btnAccCreate.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(356, 425)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(289, 18)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Laser Cutter File Designer and Assistant"
        '
        'btnLogin
        '
        Me.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogin.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogin.Location = New System.Drawing.Point(331, 446)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(166, 85)
        Me.btnLogin.TabIndex = 7
        Me.btnLogin.Text = "Login"
        Me.btnLogin.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(353, 378)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(294, 36)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Welcome To LAMP!"
        '
        'frmStart
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1000, 750)
        Me.Controls.Add(Me.WelcomePanel)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStart"
        Me.login.ResumeLayout(False)
        Me.login.PerformLayout()
        Me.WelcomePanel.ResumeLayout(False)
        Me.WelcomePanel.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents login As Panel
    Friend WithEvents lblUser As Label
    Friend WithEvents txtPass As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents WelcomePanel As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnLogin As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents lblPass As Label
    Friend WithEvents btnAccCreate As Button
    Friend WithEvents lblLogin As Label
    Friend WithEvents btnlogon As Button
    Friend WithEvents btnCreateAcc As Button
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents Button1 As Button
End Class
