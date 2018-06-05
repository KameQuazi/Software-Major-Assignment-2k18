<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FileDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FileDisplay))
        Me.DisplayBox = New System.Windows.Forms.PictureBox()
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblCreator = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.lblCutTime = New System.Windows.Forms.Label()
        CType(Me.DisplayBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DisplayBox
        '
        Me.DisplayBox.Image = CType(resources.GetObject("DisplayBox.Image"), System.Drawing.Image)
        Me.DisplayBox.Location = New System.Drawing.Point(0, 0)
        Me.DisplayBox.Name = "DisplayBox"
        Me.DisplayBox.Size = New System.Drawing.Size(200, 150)
        Me.DisplayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DisplayBox.TabIndex = 0
        Me.DisplayBox.TabStop = False
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(3, 153)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(46, 16)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name:"
        '
        'lblCreator
        '
        Me.lblCreator.AutoSize = True
        Me.lblCreator.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreator.Location = New System.Drawing.Point(3, 169)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(54, 16)
        Me.lblCreator.TabIndex = 2
        Me.lblCreator.Text = "Creator:"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(3, 185)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(49, 16)
        Me.lblHeight.TabIndex = 3
        Me.lblHeight.Text = "Height:"
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(3, 201)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(46, 16)
        Me.lblWidth.TabIndex = 4
        Me.lblWidth.Text = "Width:"
        '
        'lblMaterial
        '
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterial.Location = New System.Drawing.Point(3, 217)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(58, 16)
        Me.lblMaterial.TabIndex = 5
        Me.lblMaterial.Text = "Material:"
        '
        'lblCutTime
        '
        Me.lblCutTime.AutoSize = True
        Me.lblCutTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCutTime.Location = New System.Drawing.Point(3, 233)
        Me.lblCutTime.Name = "lblCutTime"
        Me.lblCutTime.Size = New System.Drawing.Size(79, 16)
        Me.lblCutTime.TabIndex = 6
        Me.lblCutTime.Text = "Time to Cut:"
        '
        'FileDisplay
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.lblCutTime)
        Me.Controls.Add(Me.lblMaterial)
        Me.Controls.Add(Me.lblWidth)
        Me.Controls.Add(Me.lblHeight)
        Me.Controls.Add(Me.lblCreator)
        Me.Controls.Add(Me.lblName)
        Me.Controls.Add(Me.DisplayBox)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FileDisplay"
        Me.Size = New System.Drawing.Size(200, 270)
        CType(Me.DisplayBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DisplayBox As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblCreator As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblMaterial As Label
    Friend WithEvents lblCutTime As Label
End Class
