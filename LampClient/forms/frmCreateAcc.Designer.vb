<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCreateAcc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCreateAcc))
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.lblPass = New System.Windows.Forms.Label()
        Me.lblUser = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPass = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPass2 = New System.Windows.Forms.TextBox()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.txtName2 = New System.Windows.Forms.TextBox()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtUser = New System.Windows.Forms.TextBox()
        Me.btncancel = New System.Windows.Forms.Button()
        Me.lblNoMatch = New System.Windows.Forms.Label()
        Me.lblNoUser = New System.Windows.Forms.Label()
        Me.lblNoEmail = New System.Windows.Forms.Label()
        Me.lblFillRequired = New System.Windows.Forms.Label()
        Me.required1 = New System.Windows.Forms.Label()
        Me.required2 = New System.Windows.Forms.Label()
        Me.required3 = New System.Windows.Forms.Label()
        Me.required4 = New System.Windows.Forms.Label()
        Me.required5 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.Color.White
        Me.btnCreate.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnCreate.Location = New System.Drawing.Point(449, 283)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(123, 49)
        Me.btnCreate.TabIndex = 12
        Me.btnCreate.Text = "Create Account"
        Me.btnCreate.UseVisualStyleBackColor = False
        '
        'lblPass
        '
        Me.lblPass.AutoSize = True
        Me.lblPass.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.lblPass.Location = New System.Drawing.Point(52, 74)
        Me.lblPass.Name = "lblPass"
        Me.lblPass.Size = New System.Drawing.Size(102, 19)
        Me.lblPass.TabIndex = 10
        Me.lblPass.Text = "Given Name:"
        '
        'lblUser
        '
        Me.lblUser.AutoSize = True
        Me.lblUser.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.lblUser.Location = New System.Drawing.Point(66, 37)
        Me.lblUser.Name = "lblUser"
        Me.lblUser.Size = New System.Drawing.Size(88, 19)
        Me.lblUser.TabIndex = 9
        Me.lblUser.Text = "Username:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.Label1.Location = New System.Drawing.Point(74, 111)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 19)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Surname:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.Label2.Location = New System.Drawing.Point(69, 185)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 19)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Password:"
        '
        'txtPass
        '
        Me.txtPass.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtPass.Location = New System.Drawing.Point(160, 178)
        Me.txtPass.Name = "txtPass"
        Me.txtPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass.Size = New System.Drawing.Size(218, 31)
        Me.txtPass.TabIndex = 17
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.Label3.Location = New System.Drawing.Point(100, 148)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 19)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Email:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.Label4.Location = New System.Drawing.Point(6, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(148, 19)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Confirm Password:"
        '
        'txtPass2
        '
        Me.txtPass2.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtPass2.Location = New System.Drawing.Point(160, 215)
        Me.txtPass2.Name = "txtPass2"
        Me.txtPass2.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPass2.Size = New System.Drawing.Size(218, 31)
        Me.txtPass2.TabIndex = 19
        '
        'txtEmail
        '
        Me.txtEmail.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtEmail.Location = New System.Drawing.Point(160, 141)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(218, 31)
        Me.txtEmail.TabIndex = 21
        '
        'txtName2
        '
        Me.txtName2.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtName2.Location = New System.Drawing.Point(160, 104)
        Me.txtName2.Name = "txtName2"
        Me.txtName2.Size = New System.Drawing.Size(218, 31)
        Me.txtName2.TabIndex = 22
        '
        'txtName
        '
        Me.txtName.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtName.Location = New System.Drawing.Point(160, 67)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(218, 31)
        Me.txtName.TabIndex = 23
        '
        'txtUser
        '
        Me.txtUser.Font = New System.Drawing.Font("Arial", 15.25!)
        Me.txtUser.Location = New System.Drawing.Point(160, 30)
        Me.txtUser.Name = "txtUser"
        Me.txtUser.Size = New System.Drawing.Size(218, 31)
        Me.txtUser.TabIndex = 24
        '
        'btncancel
        '
        Me.btncancel.BackColor = System.Drawing.Color.White
        Me.btncancel.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btncancel.Location = New System.Drawing.Point(10, 283)
        Me.btncancel.Name = "btncancel"
        Me.btncancel.Size = New System.Drawing.Size(123, 49)
        Me.btncancel.TabIndex = 25
        Me.btncancel.Text = "Cancel"
        Me.btncancel.UseVisualStyleBackColor = False
        '
        'lblNoMatch
        '
        Me.lblNoMatch.AutoSize = True
        Me.lblNoMatch.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblNoMatch.ForeColor = System.Drawing.Color.Red
        Me.lblNoMatch.Location = New System.Drawing.Point(381, 181)
        Me.lblNoMatch.Name = "lblNoMatch"
        Me.lblNoMatch.Size = New System.Drawing.Size(159, 60)
        Me.lblNoMatch.TabIndex = 26
        Me.lblNoMatch.Text = "]" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    The passwords you have " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    enetered don't match." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "]"
        Me.lblNoMatch.Visible = False
        '
        'lblNoUser
        '
        Me.lblNoUser.AutoSize = True
        Me.lblNoUser.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblNoUser.ForeColor = System.Drawing.Color.Red
        Me.lblNoUser.Location = New System.Drawing.Point(384, 40)
        Me.lblNoUser.Name = "lblNoUser"
        Me.lblNoUser.Size = New System.Drawing.Size(144, 15)
        Me.lblNoUser.TabIndex = 27
        Me.lblNoUser.Text = "username already in use"
        Me.lblNoUser.Visible = False
        '
        'lblNoEmail
        '
        Me.lblNoEmail.AutoSize = True
        Me.lblNoEmail.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblNoEmail.ForeColor = System.Drawing.Color.Red
        Me.lblNoEmail.Location = New System.Drawing.Point(384, 151)
        Me.lblNoEmail.Name = "lblNoEmail"
        Me.lblNoEmail.Size = New System.Drawing.Size(160, 15)
        Me.lblNoEmail.TabIndex = 28
        Me.lblNoEmail.Text = "email adress already in use"
        Me.lblNoEmail.Visible = False
        '
        'lblFillRequired
        '
        Me.lblFillRequired.AutoSize = True
        Me.lblFillRequired.Font = New System.Drawing.Font("Arial", 11.0!)
        Me.lblFillRequired.ForeColor = System.Drawing.Color.Red
        Me.lblFillRequired.Location = New System.Drawing.Point(376, 335)
        Me.lblFillRequired.Name = "lblFillRequired"
        Me.lblFillRequired.Size = New System.Drawing.Size(196, 17)
        Me.lblFillRequired.TabIndex = 29
        Me.lblFillRequired.Text = "please fill in all required fields"
        Me.lblFillRequired.Visible = False
        '
        'required1
        '
        Me.required1.AutoSize = True
        Me.required1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.required1.ForeColor = System.Drawing.Color.Red
        Me.required1.Location = New System.Drawing.Point(101, 56)
        Me.required1.Name = "required1"
        Me.required1.Size = New System.Drawing.Size(53, 15)
        Me.required1.TabIndex = 30
        Me.required1.Text = "required"
        Me.required1.Visible = False
        '
        'required2
        '
        Me.required2.AutoSize = True
        Me.required2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.required2.ForeColor = System.Drawing.Color.Red
        Me.required2.Location = New System.Drawing.Point(101, 93)
        Me.required2.Name = "required2"
        Me.required2.Size = New System.Drawing.Size(53, 15)
        Me.required2.TabIndex = 31
        Me.required2.Text = "required"
        Me.required2.Visible = False
        '
        'required3
        '
        Me.required3.AutoSize = True
        Me.required3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.required3.ForeColor = System.Drawing.Color.Red
        Me.required3.Location = New System.Drawing.Point(101, 130)
        Me.required3.Name = "required3"
        Me.required3.Size = New System.Drawing.Size(53, 15)
        Me.required3.TabIndex = 32
        Me.required3.Text = "required"
        Me.required3.Visible = False
        '
        'required4
        '
        Me.required4.AutoSize = True
        Me.required4.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.required4.ForeColor = System.Drawing.Color.Red
        Me.required4.Location = New System.Drawing.Point(101, 204)
        Me.required4.Name = "required4"
        Me.required4.Size = New System.Drawing.Size(53, 15)
        Me.required4.TabIndex = 33
        Me.required4.Text = "required"
        Me.required4.Visible = False
        '
        'required5
        '
        Me.required5.AutoSize = True
        Me.required5.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.required5.ForeColor = System.Drawing.Color.Red
        Me.required5.Location = New System.Drawing.Point(101, 241)
        Me.required5.Name = "required5"
        Me.required5.Size = New System.Drawing.Size(53, 15)
        Me.required5.TabIndex = 34
        Me.required5.Text = "required"
        Me.required5.Visible = False
        '
        'frmCreateAcc
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(584, 361)
        Me.Controls.Add(Me.required5)
        Me.Controls.Add(Me.required4)
        Me.Controls.Add(Me.required3)
        Me.Controls.Add(Me.required2)
        Me.Controls.Add(Me.required1)
        Me.Controls.Add(Me.lblFillRequired)
        Me.Controls.Add(Me.lblNoEmail)
        Me.Controls.Add(Me.lblNoUser)
        Me.Controls.Add(Me.lblNoMatch)
        Me.Controls.Add(Me.btncancel)
        Me.Controls.Add(Me.txtUser)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.txtName2)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtPass2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPass)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCreate)
        Me.Controls.Add(Me.lblPass)
        Me.Controls.Add(Me.lblUser)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCreateAcc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Create Account"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCreate As Button
    Friend WithEvents lblPass As Label
    Friend WithEvents lblUser As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPass As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPass2 As TextBox
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents txtName2 As TextBox
    Friend WithEvents txtName As TextBox
    Friend WithEvents txtUser As TextBox
    Friend WithEvents btncancel As Button
    Friend WithEvents lblNoMatch As Label
    Friend WithEvents lblNoUser As Label
    Friend WithEvents lblNoEmail As Label
    Friend WithEvents lblFillRequired As Label
    Friend WithEvents required1 As Label
    Friend WithEvents required2 As Label
    Friend WithEvents required3 As Label
    Friend WithEvents required4 As Label
    Friend WithEvents required5 As Label
End Class
