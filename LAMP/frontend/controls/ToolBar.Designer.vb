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
        Me.Logo = New System.Windows.Forms.PictureBox()
        Me.btnQuit = New System.Windows.Forms.Button()
        Me.btnAbout = New System.Windows.Forms.Button()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnLogOut = New System.Windows.Forms.Button()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblCurScr = New System.Windows.Forms.Label()
        Me.btnQN = New System.Windows.Forms.Button()
        Me.btnQY = New System.Windows.Forms.Button()
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Logo
        '
        Me.Logo.Image = CType(resources.GetObject("Logo.Image"), System.Drawing.Image)
        Me.Logo.Location = New System.Drawing.Point(0, 0)
        Me.Logo.Name = "Logo"
        Me.Logo.Size = New System.Drawing.Size(90, 90)
        Me.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Logo.TabIndex = 0
        Me.Logo.TabStop = False
        '
        'btnQuit
        '
        Me.btnQuit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQuit.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQuit.Location = New System.Drawing.Point(920, 0)
        Me.btnQuit.Name = "btnQuit"
        Me.btnQuit.Size = New System.Drawing.Size(80, 89)
        Me.btnQuit.TabIndex = 11
        Me.btnQuit.Text = "Quit"
        Me.btnQuit.UseVisualStyleBackColor = True
        '
        'btnAbout
        '
        Me.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAbout.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnAbout.Location = New System.Drawing.Point(841, 0)
        Me.btnAbout.Name = "btnAbout"
        Me.btnAbout.Size = New System.Drawing.Size(80, 45)
        Me.btnAbout.TabIndex = 12
        Me.btnAbout.Text = "About"
        Me.btnAbout.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnHome.Location = New System.Drawing.Point(762, 0)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(80, 45)
        Me.btnHome.TabIndex = 13
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnLogOut
        '
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnLogOut.Location = New System.Drawing.Point(762, 44)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(80, 45)
        Me.btnLogOut.TabIndex = 14
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = True
        '
        'btnBack
        '
        Me.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBack.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnBack.Location = New System.Drawing.Point(841, 44)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(80, 45)
        Me.btnBack.TabIndex = 15
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblCurScr
        '
        Me.lblCurScr.AutoSize = True
        Me.lblCurScr.Font = New System.Drawing.Font("Arial", 39.25!)
        Me.lblCurScr.Location = New System.Drawing.Point(96, 24)
        Me.lblCurScr.Name = "lblCurScr"
        Me.lblCurScr.Size = New System.Drawing.Size(571, 60)
        Me.lblCurScr.TabIndex = 17
        Me.lblCurScr.Text = "SCREEN NAME HERE"
        '
        'btnQN
        '
        Me.btnQN.BackColor = System.Drawing.Color.White
        Me.btnQN.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQN.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQN.Location = New System.Drawing.Point(920, 44)
        Me.btnQN.Name = "btnQN"
        Me.btnQN.Size = New System.Drawing.Size(80, 45)
        Me.btnQN.TabIndex = 19
        Me.btnQN.Text = "No"
        Me.btnQN.UseVisualStyleBackColor = False
        Me.btnQN.Visible = False
        '
        'btnQY
        '
        Me.btnQY.BackColor = System.Drawing.Color.White
        Me.btnQY.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnQY.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnQY.Location = New System.Drawing.Point(920, 0)
        Me.btnQY.Name = "btnQY"
        Me.btnQY.Size = New System.Drawing.Size(80, 45)
        Me.btnQY.TabIndex = 18
        Me.btnQY.Text = "Yes"
        Me.btnQY.UseVisualStyleBackColor = False
        Me.btnQY.Visible = False
        '
        'ToolBar
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.btnQN)
        Me.Controls.Add(Me.btnQY)
        Me.Controls.Add(Me.lblCurScr)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.btnLogOut)
        Me.Controls.Add(Me.btnHome)
        Me.Controls.Add(Me.btnAbout)
        Me.Controls.Add(Me.btnQuit)
        Me.Controls.Add(Me.Logo)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ToolBar"
        Me.Size = New System.Drawing.Size(1000, 91)
        CType(Me.Logo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Logo As PictureBox
    Friend WithEvents btnQuit As Button
    Friend WithEvents btnAbout As Button
    Friend WithEvents btnHome As Button
    Friend WithEvents btnLogOut As Button
    Friend WithEvents btnBack As Button
    Friend WithEvents lblCurScr As Label
    Friend WithEvents btnQN As Button
    Friend WithEvents btnQY As Button
End Class
