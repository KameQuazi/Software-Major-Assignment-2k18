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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ToolBar))
        Me.btnNewOrder = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.btnDesigns = New System.Windows.Forms.Button()
        Me.Username = New System.Windows.Forms.Label()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnNewOrder
        '
        Me.btnNewOrder.BackColor = System.Drawing.Color.White
        Me.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewOrder.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnNewOrder.Location = New System.Drawing.Point(202, 6)
        Me.btnNewOrder.Name = "btnNewOrder"
        Me.btnNewOrder.Size = New System.Drawing.Size(97, 97)
        Me.btnNewOrder.TabIndex = 51
        Me.btnNewOrder.Text = "New Order"
        Me.btnNewOrder.UseVisualStyleBackColor = False
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.White
        Me.btnHelp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHelp.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHelp.Location = New System.Drawing.Point(958, 5)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(80, 95)
        Me.btnHelp.TabIndex = 50
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'btnOrders
        '
        Me.btnOrders.BackColor = System.Drawing.Color.White
        Me.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrders.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnOrders.Location = New System.Drawing.Point(408, 6)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(97, 97)
        Me.btnOrders.TabIndex = 49
        Me.btnOrders.Text = "My Orders"
        Me.btnOrders.UseVisualStyleBackColor = False
        '
        'btnDesigns
        '
        Me.btnDesigns.BackColor = System.Drawing.Color.White
        Me.btnDesigns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesigns.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnDesigns.Location = New System.Drawing.Point(305, 6)
        Me.btnDesigns.Name = "btnDesigns"
        Me.btnDesigns.Size = New System.Drawing.Size(97, 97)
        Me.btnDesigns.TabIndex = 48
        Me.btnDesigns.Text = "My Template Designs"
        Me.btnDesigns.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.BackColor = System.Drawing.Color.Transparent
        Me.Username.Font = New System.Drawing.Font("Arial", 18.25!)
        Me.Username.ForeColor = System.Drawing.Color.White
        Me.Username.Location = New System.Drawing.Point(646, 16)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(225, 56)
        Me.Username.TabIndex = 47
        Me.Username.Text = "Hello Username!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Welcome to LAMP"
        Me.Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.White
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnLogOut.Location = New System.Drawing.Point(511, 6)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(97, 97)
        Me.btnLogOut.TabIndex = 45
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'Logo
        '
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(3, 9)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(90, 90)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 41
        Me.Logo.TabStop = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.White
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQuit.Location = New System.Drawing.Point(1125, 5)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(97, 97)
        Me.btnQuit.TabIndex = 42
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.White
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnAbout.Location = New System.Drawing.Point(1044, 6)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(75, 96)
        Me.btnAbout.TabIndex = 43
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.White
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHome.Location = New System.Drawing.Point(99, 6)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(97, 97)
        Me.btnHome.TabIndex = 44
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.White
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnBack.Location = New System.Drawing.Point(872, 5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(80, 95)
        Me.btnBack.TabIndex = 52
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'ToolBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Fuchsia
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnNewOrder)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.btnOrders)
        Me.Controls.Add(Me.btnDesigns)
        Me.Controls.Add(Me.Username)
        Me.Controls.Add(Me.btnLogOut)
        Me.Controls.Add(Me.Logo)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnHome)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ToolBar"
        Me.Size = New System.Drawing.Size(1231, 108)
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnNewOrder As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents btnOrders As Button
    Friend WithEvents btnDesigns As Button
    Friend WithEvents Username As Label
    Friend WithEvents btnLogOut As Button
    Friend WithEvents Logo As PictureBox
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnBack As Button
End Class
