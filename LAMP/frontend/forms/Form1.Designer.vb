<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Bar = New System.Windows.Forms.Panel()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.Username = New System.Windows.Forms.Label()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnDesigns = New System.Windows.Forms.Button()
        Me.btnOrders = New System.Windows.Forms.Button()
        Me.Bar.SuspendLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Bar
        '
        Me.Bar.BackColor = System.Drawing.Color.Red
        Me.Bar.Controls.Add(Me.btnOrders)
        Me.Bar.Controls.Add(Me.btnDesigns)
        Me.Bar.Controls.Add(Me.btnBack)
        Me.Bar.Controls.Add(Me.Username)
        Me.Bar.Controls.Add(Me.btnLogOut)
        Me.Bar.Controls.Add(Me.Logo)
        Me.Bar.Controls.Add(Me.btnQuit)
        Me.Bar.Controls.Add(Me.btnAbout)
        Me.Bar.Controls.Add(Me.btnHome)
        Me.Bar.Location = New System.Drawing.Point(1, 0)
        Me.Bar.Name = "Bar"
        Me.Bar.Size = New System.Drawing.Size(1231, 108)
        Me.Bar.TabIndex = 30
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.White
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnBack.Location = New System.Drawing.Point(755, 5)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(80, 95)
        Me.btnBack.TabIndex = 35
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'Username
        '
        Me.Username.AutoSize = True
        Me.Username.BackColor = System.Drawing.Color.White
        Me.Username.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.Username.Location = New System.Drawing.Point(1106, 5)
        Me.Username.Name = "Username"
        Me.Username.Size = New System.Drawing.Size(122, 96)
        Me.Username.TabIndex = 36
        Me.Username.Text = "Hello " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Username!" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Welcome to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "LAMP"
        Me.Username.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.White
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnLogOut.Location = New System.Drawing.Point(841, 5)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(75, 96)
        Me.btnLogOut.TabIndex = 34
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'Logo
        '
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(3, 8)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(90, 90)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 20
        Me.Logo.TabStop = False
        '
        'btnQuit
        '
        Me.btnQuit.BackColor = System.Drawing.Color.White
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQuit.Location = New System.Drawing.Point(1003, 4)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(97, 97)
        Me.btnQuit.TabIndex = 31
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = False
        '
        'btnAbout
        '
        Me.btnAbout.BackColor = System.Drawing.Color.White
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnAbout.Location = New System.Drawing.Point(922, 5)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(75, 96)
        Me.btnAbout.TabIndex = 32
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = False
        '
        'btnHome
        '
        Me.btnHome.BackColor = System.Drawing.Color.White
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHome.Location = New System.Drawing.Point(99, 5)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(97, 97)
        Me.btnHome.TabIndex = 33
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = False
        '
        'btnDesigns
        '
        Me.btnDesigns.BackColor = System.Drawing.Color.White
        Me.btnDesigns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnDesigns.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnDesigns.Location = New System.Drawing.Point(202, 6)
        Me.btnDesigns.Name = "btnDesigns"
        Me.btnDesigns.Size = New System.Drawing.Size(97, 97)
        Me.btnDesigns.TabIndex = 37
        Me.btnDesigns.Text = "My Trophy Designs"
        Me.btnDesigns.UseVisualStyleBackColor = False
        '
        'btnOrders
        '
        Me.btnOrders.BackColor = System.Drawing.Color.White
        Me.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnOrders.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnOrders.Location = New System.Drawing.Point(305, 6)
        Me.btnOrders.Name = "btnOrders"
        Me.btnOrders.Size = New System.Drawing.Size(97, 97)
        Me.btnOrders.TabIndex = 38
        Me.btnOrders.Text = "My Orders"
        Me.btnOrders.UseVisualStyleBackColor = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.Bar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Bar.ResumeLayout(False)
        Me.Bar.PerformLayout()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Bar As Panel
    Friend WithEvents btnBack As Button
    Friend WithEvents Username As Label
    Friend WithEvents btnLogOut As Button
    Friend WithEvents Logo As PictureBox
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnDesigns As Button
    Friend WithEvents btnOrders As Button
End Class
