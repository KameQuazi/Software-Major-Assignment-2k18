<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TemplateDisplay
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateDisplay))
        Me.lblName = New System.Windows.Forms.Label()
        Me.lblHeight = New System.Windows.Forms.Label()
        Me.lblWidth = New System.Windows.Forms.Label()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.editname = New System.Windows.Forms.Label()
        Me.editwidth = New System.Windows.Forms.Label()
        Me.editmaterial = New System.Windows.Forms.Label()
        Me.DisplayBox = New System.Windows.Forms.PictureBox()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.lblApprover = New System.Windows.Forms.Label()
        Me.editheight = New System.Windows.Forms.Label()
        Me.lblCreator = New System.Windows.Forms.Label()
        Me.editapprover = New System.Windows.Forms.Label()
        Me.editcreator = New System.Windows.Forms.Label()
        CType(Me.DisplayBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblName
        '
        Me.lblName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblName.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(3, 0)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(91, 24)
        Me.lblName.TabIndex = 1
        Me.lblName.Text = "Name:"
        Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHeight
        '
        Me.lblHeight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblHeight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHeight.Location = New System.Drawing.Point(3, 72)
        Me.lblHeight.Name = "lblHeight"
        Me.lblHeight.Size = New System.Drawing.Size(91, 24)
        Me.lblHeight.TabIndex = 3
        Me.lblHeight.Text = "Height:"
        Me.lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblWidth
        '
        Me.lblWidth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblWidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWidth.Location = New System.Drawing.Point(3, 48)
        Me.lblWidth.Name = "lblWidth"
        Me.lblWidth.Size = New System.Drawing.Size(91, 24)
        Me.lblWidth.TabIndex = 4
        Me.lblWidth.Text = "Width:"
        Me.lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMaterial
        '
        Me.lblMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblMaterial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMaterial.Location = New System.Drawing.Point(3, 24)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(91, 24)
        Me.lblMaterial.TabIndex = 5
        Me.lblMaterial.Text = "Material:"
        Me.lblMaterial.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'editname
        '
        Me.editname.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editname.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editname.Location = New System.Drawing.Point(100, 0)
        Me.editname.Name = "editname"
        Me.editname.Size = New System.Drawing.Size(91, 24)
        Me.editname.TabIndex = 7
        Me.editname.Text = "text"
        Me.editname.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'editwidth
        '
        Me.editwidth.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editwidth.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editwidth.Location = New System.Drawing.Point(100, 48)
        Me.editwidth.Name = "editwidth"
        Me.editwidth.Size = New System.Drawing.Size(91, 24)
        Me.editwidth.TabIndex = 10
        Me.editwidth.Text = "text"
        Me.editwidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'editmaterial
        '
        Me.editmaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editmaterial.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editmaterial.Location = New System.Drawing.Point(100, 24)
        Me.editmaterial.Name = "editmaterial"
        Me.editmaterial.Size = New System.Drawing.Size(91, 24)
        Me.editmaterial.TabIndex = 11
        Me.editmaterial.Text = "text"
        Me.editmaterial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.Panel1.Controls.Add(Me.TableLayoutPanel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 153)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(194, 145)
        Me.Panel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblName, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.editname, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblMaterial, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.editmaterial, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.editwidth, 1, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.lblHeight, 0, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblWidth, 0, 2)
        Me.TableLayoutPanel2.Controls.Add(Me.editheight, 1, 3)
        Me.TableLayoutPanel2.Controls.Add(Me.lblCreator, 0, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.editcreator, 1, 4)
        Me.TableLayoutPanel2.Controls.Add(Me.lblApprover, 0, 5)
        Me.TableLayoutPanel2.Controls.Add(Me.editapprover, 1, 5)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 6
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(194, 145)
        Me.TableLayoutPanel2.TabIndex = 13
        '
        'lblApprover
        '
        Me.lblApprover.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblApprover.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApprover.Location = New System.Drawing.Point(3, 120)
        Me.lblApprover.Name = "lblApprover"
        Me.lblApprover.Size = New System.Drawing.Size(91, 25)
        Me.lblApprover.TabIndex = 6
        Me.lblApprover.Text = "Approver:"
        Me.lblApprover.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'editheight
        '
        Me.editheight.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editheight.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editheight.Location = New System.Drawing.Point(100, 72)
        Me.editheight.Name = "editheight"
        Me.editheight.Size = New System.Drawing.Size(91, 24)
        Me.editheight.TabIndex = 9
        Me.editheight.Text = "text"
        Me.editheight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCreator
        '
        Me.lblCreator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblCreator.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCreator.Location = New System.Drawing.Point(3, 96)
        Me.lblCreator.Name = "lblCreator"
        Me.lblCreator.Size = New System.Drawing.Size(91, 24)
        Me.lblCreator.TabIndex = 2
        Me.lblCreator.Text = "Creator:"
        Me.lblCreator.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'editapprover
        '
        Me.editapprover.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editapprover.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editapprover.Location = New System.Drawing.Point(100, 120)
        Me.editapprover.Name = "editapprover"
        Me.editapprover.Size = New System.Drawing.Size(91, 25)
        Me.editapprover.TabIndex = 12
        Me.editapprover.Text = "text"
        Me.editapprover.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'editcreator
        '
        Me.editcreator.Dock = System.Windows.Forms.DockStyle.Fill
        Me.editcreator.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.editcreator.Location = New System.Drawing.Point(100, 96)
        Me.editcreator.Name = "editcreator"
        Me.editcreator.Size = New System.Drawing.Size(91, 24)
        Me.editcreator.TabIndex = 8
        Me.editcreator.Text = "text"
        Me.editcreator.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FileDisplay
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "FileDisplay"
        Me.Size = New System.Drawing.Size(200, 301)
        CType(Me.DisplayBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DisplayBox As PictureBox
    Friend WithEvents lblName As Label
    Friend WithEvents lblHeight As Label
    Friend WithEvents lblWidth As Label
    Friend WithEvents lblMaterial As Label
    Friend WithEvents editname As Label
    Friend WithEvents editwidth As Label
    Friend WithEvents editmaterial As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents editheight As Label
    Friend WithEvents lblCreator As Label
    Friend WithEvents editcreator As Label
    Friend WithEvents lblApprover As Label
    Friend WithEvents editapprover As Label
End Class
