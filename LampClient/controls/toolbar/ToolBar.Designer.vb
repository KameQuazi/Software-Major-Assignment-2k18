<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ToolBar
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolBar))
        Me.Tooltip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnNewTemplate = New System.Windows.Forms.Button()
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnNewOrder = New System.Windows.Forms.Button()
        Me.Username = New System.Windows.Forms.Label()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.btnDesigns = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnSettings = New System.Windows.Forms.Button()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNewTemplate
        '
        Me.btnNewTemplate.BackColor = System.Drawing.Color.White
        Me.btnNewTemplate.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewTemplate.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnNewTemplate.Location = New System.Drawing.Point(195, 3)
        Me.btnNewTemplate.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNewTemplate.Name = "btnNewTemplate"
        Me.btnNewTemplate.Size = New System.Drawing.Size(90, 50)
        Me.btnNewTemplate.TabIndex = 67
        Me.btnNewTemplate.Text = "New Template"
        Me.btnNewTemplate.UseVisualStyleBackColor = False
        '
        'Logo
        '
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(3, 3)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(92, 102)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 56
        Me.Logo.TabStop = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.White
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQuit.Location = New System.Drawing.Point(1138, 54)
        Me.btnQuit.Margin = New System.Windows.Forms.Padding(5)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(90, 50)
        Me.btnQuit.TabIndex = 57
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.White
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHome.Location = New System.Drawing.Point(103, 3)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(5)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(90, 50)
        Me.btnHome.TabIndex = 59
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnNewOrder
        '
        Me.btnNewOrder.BackColor = System.Drawing.Color.White
        Me.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewOrder.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnNewOrder.Location = New System.Drawing.Point(287, 3)
        Me.btnNewOrder.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNewOrder.Name = "btnNewOrder"
        Me.btnNewOrder.Size = New System.Drawing.Size(90, 50)
        Me.btnNewOrder.TabIndex = 65
        Me.btnNewOrder.Text = "New Order"
        Me.btnNewOrder.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.BackColor = System.Drawing.Color.Transparent
        Me.Username.Font = New System.Drawing.Font("Arial", 16.25!)
        Me.Username.ForeColor = System.Drawing.Color.White
        Me.Username.Location = New System.Drawing.Point(698, 3)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(195, 50)
        Me.Username.TabIndex = 61
        Me.Username.Text = "Hello Username!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Welcome to LAMP"
        Me.Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOrders
        '
        Me.btnOrders.BackColor = System.Drawing.Color.White
        Me.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrders.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnOrders.Location = New System.Drawing.Point(287, 54)
        Me.btnOrders.Margin = New System.Windows.Forms.Padding(5)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(90, 50)
        Me.btnOrders.TabIndex = 63
        Me.btnOrders.Text = "View Orders"
        Me.btnOrders.UseVisualStyleBackColor = False
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.White
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnLogOut.Location = New System.Drawing.Point(1138, 3)
        Me.btnLogOut.Margin = New System.Windows.Forms.Padding(5)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(90, 50)
        Me.btnLogOut.TabIndex = 60
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'btnDesigns
        '
        Me.btnDesigns.BackColor = System.Drawing.Color.White
        Me.btnDesigns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesigns.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnDesigns.Location = New System.Drawing.Point(195, 54)
        Me.btnDesigns.Margin = New System.Windows.Forms.Padding(5)
        Me.btnDesigns.Name = "btnDesigns"
        Me.btnDesigns.Size = New System.Drawing.Size(90, 50)
        Me.btnDesigns.TabIndex = 62
        Me.btnDesigns.Text = "View Template"
        Me.btnDesigns.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.White
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnAbout.Location = New System.Drawing.Point(1046, 3)
        Me.btnAbout.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(90, 50)
        Me.btnAbout.TabIndex = 58
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.White
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnBack.Location = New System.Drawing.Point(103, 54)
        Me.btnBack.Margin = New System.Windows.Forms.Padding(5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(90, 50)
        Me.btnBack.TabIndex = 66
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.White
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHelp.Location = New System.Drawing.Point(1046, 54)
        Me.btnHelp.Margin = New System.Windows.Forms.Padding(5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(90, 50)
        Me.btnHelp.TabIndex = 64
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnSettings
        '
        Me.btnSettings.BackColor = System.Drawing.Color.White
        Me.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSettings.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnSettings.Location = New System.Drawing.Point(954, 3)
        Me.btnSettings.Margin = New System.Windows.Forms.Padding(5)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(90, 50)
        Me.btnSettings.TabIndex = 68
        Me.btnSettings.Text = "Settings"
        Me.btnSettings.UseVisualStyleBackColor = False
        '
        'ToolBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.Controls.Add(Me.btnSettings)
        Me.Controls.Add(Me.btnNewTemplate)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnNewOrder)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.btnOrders)
        Me.Controls.Add(Me.btnLogOut)
        Me.Controls.Add(Me.btnDesigns)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnHelp)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ToolBar"
        Me.Size = New System.Drawing.Size(1231, 108)
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Tooltip1 As ToolTip
    Friend WithEvents btnNewTemplate As Button
    Friend WithEvents Logo As PictureBox
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnNewOrder As Button
    Friend WithEvents Username As Label
    Friend WithEvents btnOrders As Button
    Friend WithEvents btnLogOut As Button
    Friend WithEvents btnDesigns As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnSettings As Button
End Class
