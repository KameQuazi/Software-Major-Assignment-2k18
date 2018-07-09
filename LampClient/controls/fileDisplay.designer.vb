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
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblCreator = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.lblCutTime = New System.Windows.Forms.Label()
        Me.editname = New System.Windows.Forms.Label()
        Me.editcreator = New System.Windows.Forms.Label()
        Me.editheight = New System.Windows.Forms.Label()
        Me.editwidth = New System.Windows.Forms.Label()
        Me.editmaterial = New System.Windows.Forms.Label()
        Me.editapprover = New System.Windows.Forms.Label()
        Me.DisplayBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        CType(Me.DisplayBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(19, 15)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(46, 16)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name:"
        '
        'lblCreator
        '
        Me.lblCreator.AutoSize = True
        Me.lblCreator.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreator.Location = New System.Drawing.Point(11, 79)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(54, 16)
        Me.lblCreator.TabIndex = 2
        Me.lblCreator.Text = "Creator:"
        '
        'lblHeight
        '
        Me.lblHeight.AutoSize = True
        Me.lblHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(16, 47)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(49, 16)
        Me.lblHeight.TabIndex = 3
        Me.lblHeight.Text = "Height:"
        '
        'lblWidth
        '
        Me.lblWidth.AutoSize = True
        Me.lblWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(19, 31)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(46, 16)
        Me.lblWidth.TabIndex = 4
        Me.lblWidth.Text = "Width:"
        '
        'lblMaterial
        '
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterial.Location = New System.Drawing.Point(7, 63)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(58, 16)
        Me.lblMaterial.TabIndex = 5
        Me.lblMaterial.Text = "Material:"
        '
        'lblCutTime
        '
        Me.lblCutTime.AutoSize = True
        Me.lblCutTime.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCutTime.Location = New System.Drawing.Point(3, 95)
        Me.lblCutTime.Name = "lblCutTime"
        Me.lblCutTime.Size = New System.Drawing.Size(62, 16)
        Me.lblCutTime.TabIndex = 6
        Me.lblCutTime.Text = "Approver:"
        '
        'editname
        '
        Me.editname.AutoSize = True
        Me.editname.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editname.Location = New System.Drawing.Point(71, 15)
        Me.editname.Name = "editname"
        Me.editname.Size = New System.Drawing.Size(30, 16)
        Me.editname.TabIndex = 7
        Me.editname.Text = "text"
        '
        'editcreator
        '
        Me.editcreator.AutoSize = True
        Me.editcreator.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editcreator.Location = New System.Drawing.Point(71, 79)
        Me.editcreator.Name = "editcreator"
        Me.editcreator.Size = New System.Drawing.Size(30, 16)
        Me.editcreator.TabIndex = 8
        Me.editcreator.Text = "text"
        '
        'editheight
        '
        Me.editheight.AutoSize = True
        Me.editheight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editheight.Location = New System.Drawing.Point(71, 47)
        Me.editheight.Name = "editheight"
        Me.editheight.Size = New System.Drawing.Size(30, 16)
        Me.editheight.TabIndex = 9
        Me.editheight.Text = "text"
        '
        'editwidth
        '
        Me.editwidth.AutoSize = True
        Me.editwidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editwidth.Location = New System.Drawing.Point(71, 31)
        Me.editwidth.Name = "editwidth"
        Me.editwidth.Size = New System.Drawing.Size(30, 16)
        Me.editwidth.TabIndex = 10
        Me.editwidth.Text = "text"
        '
        'editmaterial
        '
        Me.editmaterial.AutoSize = True
        Me.editmaterial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editmaterial.Location = New System.Drawing.Point(71, 63)
        Me.editmaterial.Name = "editmaterial"
        Me.editmaterial.Size = New System.Drawing.Size(30, 16)
        Me.editmaterial.TabIndex = 11
        Me.editmaterial.Text = "text"
        '
        'editapprover
        '
        Me.editapprover.AutoSize = True
        Me.editapprover.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editapprover.Location = New System.Drawing.Point(71, 95)
        Me.editapprover.Name = "editapprover"
        Me.editapprover.Size = New System.Drawing.Size(30, 16)
        Me.editapprover.TabIndex = 12
        Me.editapprover.Text = "text"
        '
        'DisplayBox
        '
        Me.DisplayBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DisplayBox.Image = CType(resources.GetObject("DisplayBox.Image"), System.Drawing.Image)
        Me.DisplayBox.Location = New System.Drawing.Point(3, 3)
        Me.DisplayBox.Name = "DisplayBox"
        Me.DisplayBox.Size = New System.Drawing.Size(194, 144)
        Me.DisplayBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.DisplayBox.TabIndex = 0
        Me.DisplayBox.TabStop = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DisplayBox, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 301)
        Me.TableLayoutPanel1.TabIndex = 13
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblName)
        Me.Panel1.Controls.Add(Me.lblCreator)
        Me.Panel1.Controls.Add(Me.lblHeight)
        Me.Panel1.Controls.Add(Me.lblWidth)
        Me.Panel1.Controls.Add(Me.lblMaterial)
        Me.Panel1.Controls.Add(Me.lblCutTime)
        Me.Panel1.Controls.Add(Me.editname)
        Me.Panel1.Controls.Add(Me.editcreator)
        Me.Panel1.Controls.Add(Me.editheight)
        Me.Panel1.Controls.Add(Me.editwidth)
        Me.Panel1.Controls.Add(Me.editmaterial)
        Me.Panel1.Controls.Add(Me.editapprover)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 145)
        Me.Panel1.TabIndex = 1
        '
        'FileDisplay
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FileDisplay"
        Me.Size = New System.Drawing.Size(200, 301)
        CType(Me.DisplayBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DisplayBox As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblCreator As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblMaterial As Label
    Friend WithEvents lblCutTime As Label
    Friend WithEvents editname As Label
    Friend WithEvents editcreator As Label
    Friend WithEvents editheight As Label
    Friend WithEvents editwidth As Label
    Friend WithEvents editmaterial As Label
    Friend WithEvents editapprover As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
End Class
