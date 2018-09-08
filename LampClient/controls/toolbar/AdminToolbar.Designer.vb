<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminToolbar
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AdminToolbar))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnManageUsers = New System.Windows.Forms.Button()
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.Username = New System.Windows.Forms.Label()
        Me.btnApproveTemplates = New System.Windows.Forms.Button()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.btnViewEditJobs = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 11
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.333333!))
        Me.TableLayoutPanel1.Controls.Add(Me.btnManageUsers, 3, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Logo, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnQuit, 10, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHome, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Username, 6, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnApproveTemplates, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnLogOut, 5, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnViewEditJobs, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnAbout, 9, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnBack, 7, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.btnHelp, 8, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1231, 108)
        Me.TableLayoutPanel1.TabIndex = 54
        '
        'btnManageUsers
        '
        Me.btnManageUsers.BackColor = System.Drawing.Color.White
        Me.btnManageUsers.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageUsers.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnManageUsers.Location = New System.Drawing.Point(413, 5)
        Me.btnManageUsers.Margin = New System.Windows.Forms.Padding(5)
        Me.btnManageUsers.Name = "btnManageUsers"
        Me.btnManageUsers.Size = New System.Drawing.Size(92, 98)
        Me.btnManageUsers.TabIndex = 53
        Me.btnManageUsers.Text = "Manage Users"
        Me.btnManageUsers.UseVisualStyleBackColor = False
        '
        'Logo
        '
        Me.Logo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(3, 3)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(96, 102)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 41
        Me.Logo.TabStop = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.White
        Me.btnQuit.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQuit.Location = New System.Drawing.Point(1128, 5)
        Me.btnQuit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(98, 98)
        Me.btnQuit.TabIndex = 42
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.White
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHome.Location = New System.Drawing.Point(107, 5)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(5)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(92, 98)
        Me.btnHome.TabIndex = 44
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.BackColor = System.Drawing.Color.Transparent
        Me.Username.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Username.Font = New System.Drawing.Font("Arial", 16.25!)
        Me.Username.ForeColor = System.Drawing.Color.White
        Me.Username.Location = New System.Drawing.Point(615, 0)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(199, 108)
        Me.Username.TabIndex = 47
        Me.Username.Text = "Hello Username!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Welcome to LAMP"
        Me.Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnApproveTemplates
        '
        Me.btnApproveTemplates.BackColor = System.Drawing.Color.White
        Me.btnApproveTemplates.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnApproveTemplates.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApproveTemplates.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnApproveTemplates.Location = New System.Drawing.Point(209, 5)
        Me.btnApproveTemplates.Margin = New System.Windows.Forms.Padding(5)
        Me.btnApproveTemplates.Name = "btnApproveTemplates"
        Me.btnApproveTemplates.Size = New System.Drawing.Size(92, 98)
        Me.btnApproveTemplates.TabIndex = 49
        Me.btnApproveTemplates.Text = "Approve Templates"
        Me.btnApproveTemplates.UseVisualStyleBackColor = False
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.White
        Me.btnLogOut.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnLogOut.Location = New System.Drawing.Point(515, 5)
        Me.btnLogOut.Margin = New System.Windows.Forms.Padding(5)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(92, 98)
        Me.btnLogOut.TabIndex = 45
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'btnViewEditJobs
        '
        Me.btnViewEditJobs.BackColor = System.Drawing.Color.White
        Me.btnViewEditJobs.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnViewEditJobs.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewEditJobs.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnViewEditJobs.Location = New System.Drawing.Point(311, 5)
        Me.btnViewEditJobs.Margin = New System.Windows.Forms.Padding(5)
        Me.btnViewEditJobs.Name = "btnViewEditJobs"
        Me.btnViewEditJobs.Size = New System.Drawing.Size(92, 98)
        Me.btnViewEditJobs.TabIndex = 48
        Me.btnViewEditJobs.Text = "Approve Job"
        Me.btnViewEditJobs.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.White
        Me.btnAbout.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnAbout.Location = New System.Drawing.Point(1026, 5)
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(92, 98)
        Me.btnAbout.TabIndex = 43
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.White
        Me.btnBack.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnBack.Location = New System.Drawing.Point(822, 5)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(92, 98)
        Me.btnBack.TabIndex = 52
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.White
        Me.btnHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHelp.Location = New System.Drawing.Point(924, 5)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(92, 98)
        Me.btnHelp.TabIndex = 50
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'AdminToolbar
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSeaGreen
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "AdminToolbar"
        Me.Size = New System.Drawing.Size(1231, 108)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Logo As PictureBox
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents Username As Label
    Friend WithEvents btnApproveTemplates As Button
    Friend WithEvents btnLogOut As Button
    Friend WithEvents btnViewEditJobs As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnManageUsers As Button
End Class
