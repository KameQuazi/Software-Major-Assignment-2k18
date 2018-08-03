<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageUserControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TboxEmail = New System.Windows.Forms.TextBox()
        Me.lblUsername = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TboxUsername = New System.Windows.Forms.TextBox()
        Me.TboxName = New System.Windows.Forms.TextBox()
        Me.DropDownPermission = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TboxPassword = New System.Windows.Forms.TextBox()
        Me.btnResetPassword = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(476, 429)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.[Single]
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Label4, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.Label2, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.TboxEmail, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblUsername, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Label1, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Label3, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.TboxUsername, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TboxName, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.DropDownPermission, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 1, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 3)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 5
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(470, 423)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(87, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 20)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Name"
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(56, 116)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Password:"
        '
        'TboxEmail
        '
        Me.TboxEmail.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TboxEmail.Location = New System.Drawing.Point(158, 369)
        Me.TboxEmail.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.TboxEmail.Name = "TboxEmail"
        Me.TboxEmail.Size = New System.Drawing.Size(185, 20)
        Me.TboxEmail.TabIndex = 9
        '
        'lblUsername
        '
        Me.lblUsername.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.lblUsername.AutoSize = True
        Me.lblUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsername.Location = New System.Drawing.Point(51, 32)
        Me.lblUsername.Name = "lblUsername"
        Me.lblUsername.Size = New System.Drawing.Size(87, 20)
        Me.lblUsername.TabIndex = 0
        Me.lblUsername.Text = "Username:"
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 284)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 20)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Permission Level"
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(90, 369)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 20)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Email"
        '
        'TboxUsername
        '
        Me.TboxUsername.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TboxUsername.Location = New System.Drawing.Point(158, 32)
        Me.TboxUsername.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.TboxUsername.Name = "TboxUsername"
        Me.TboxUsername.ReadOnly = True
        Me.TboxUsername.Size = New System.Drawing.Size(185, 20)
        Me.TboxUsername.TabIndex = 5
        '
        'TboxName
        '
        Me.TboxName.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TboxName.Location = New System.Drawing.Point(158, 200)
        Me.TboxName.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.TboxName.Name = "TboxName"
        Me.TboxName.Size = New System.Drawing.Size(185, 20)
        Me.TboxName.TabIndex = 8
        '
        'DropDownPermission
        '
        Me.DropDownPermission.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.DropDownPermission.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DropDownPermission.FormattingEnabled = True
        Me.DropDownPermission.Items.AddRange(New Object() {"Standard", "Elevated", "Admin"})
        Me.DropDownPermission.Location = New System.Drawing.Point(158, 284)
        Me.DropDownPermission.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.DropDownPermission.MaxDropDownItems = 3
        Me.DropDownPermission.Name = "DropDownPermission"
        Me.DropDownPermission.Size = New System.Drawing.Size(185, 21)
        Me.DropDownPermission.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TboxPassword)
        Me.Panel1.Controls.Add(Me.btnResetPassword)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(145, 88)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(321, 77)
        Me.Panel1.TabIndex = 11
        '
        'TboxPassword
        '
        Me.TboxPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.TboxPassword.Location = New System.Drawing.Point(13, 28)
        Me.TboxPassword.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.TboxPassword.Name = "TboxPassword"
        Me.TboxPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TboxPassword.ReadOnly = True
        Me.TboxPassword.Size = New System.Drawing.Size(185, 20)
        Me.TboxPassword.TabIndex = 8
        '
        'btnResetPassword
        '
        Me.btnResetPassword.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnResetPassword.Location = New System.Drawing.Point(217, 26)
        Me.btnResetPassword.Margin = New System.Windows.Forms.Padding(16, 3, 3, 3)
        Me.btnResetPassword.Name = "btnResetPassword"
        Me.btnResetPassword.Size = New System.Drawing.Size(75, 23)
        Me.btnResetPassword.TabIndex = 7
        Me.btnResetPassword.Text = "Reset Password"
        Me.btnResetPassword.UseVisualStyleBackColor = True
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ManageUserControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ManageUserControl"
        Me.Size = New System.Drawing.Size(476, 429)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblUsername As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents TboxUsername As TextBox
    Friend WithEvents TboxEmail As TextBox
    Friend WithEvents TboxName As TextBox
    Friend WithEvents DropDownPermission As ComboBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TboxPassword As TextBox
    Friend WithEvents btnResetPassword As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
