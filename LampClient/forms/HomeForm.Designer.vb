<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class HomeForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(HomeForm))
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.pnlStart = New System.Windows.Forms.Panel()
        Me.lblHelp1 = New System.Windows.Forms.Label()
        Me.ToolBar1 = New LampClient.ToolBar()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlStart.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbLogo
        '
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), System.Drawing.Image)
        Me.pbLogo.Location = New System.Drawing.Point(466, 38)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(300, 300)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 32
        Me.pbLogo.TabStop = False
        '
        'pnlStart
        '
        Me.pnlStart.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.pnlStart.Controls.Add(Me.lblHelp1)
        Me.pnlStart.Controls.Add(Me.pbLogo)
        Me.pnlStart.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlStart.Location = New System.Drawing.Point(0, 108)
        Me.pnlStart.Name = "pnlStart"
        Me.pnlStart.Size = New System.Drawing.Size(1232, 596)
        Me.pnlStart.TabIndex = 33
        '
        'lblHelp1
        '
        Me.lblHelp1.AutoSize = True
        Me.lblHelp1.Font = New System.Drawing.Font("Arial", 18.8!)
        Me.lblHelp1.Location = New System.Drawing.Point(364, 360)
        Me.lblHelp1.Name = "lblHelp1"
        Me.lblHelp1.Size = New System.Drawing.Size(414, 31)
        Me.lblHelp1.TabIndex = 33
        Me.lblHelp1.Text = "select a tool from the toolbar above"
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.Fuchsia
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = False
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.MyOrdersEnabled = True
        Me.ToolBar1.MyTrophyEnabled = True
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1232, 108)
        Me.ToolBar1.TabIndex = 34
        '
        'HomeForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.pnlStart)
        Me.Controls.Add(Me.ToolBar1)
        Me.Font = New System.Drawing.Font("Arial", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "HomeForm"
        Me.Text = "Main"
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlStart.ResumeLayout(False)
        Me.pnlStart.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pbLogo As PictureBox
    Friend WithEvents pnlStart As Panel
    Friend WithEvents lblHelp1 As Label
    Friend WithEvents ToolBar1 As ToolBar
End Class
