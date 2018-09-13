<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewOrderFormChooseParameter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.gboxHelp = New System.Windows.Forms.GroupBox()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gboxData = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.gbox1 = New System.Windows.Forms.GroupBox()
        Me.TemplateDisplay1 = New LampClient.TemplateDisplay()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnMinus = New System.Windows.Forms.Button()
        Me.tboxNumTemplates = New System.Windows.Forms.TextBox()
        Me.btnDeletedSelected = New System.Windows.Forms.Button()
        Me.btnCreate = New System.Windows.Forms.Button()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.gboxHelp.SuspendLayout()
        Me.gboxData.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.gbox1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ToolBar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 38
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ToolBar1.ConfirmationRequired = Nothing
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = False
        Me.ToolBar1.NewTemplateEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1232, 105)
        Me.ToolBar1.TabIndex = 37
        Me.ToolBar1.ViewOrderEnabled = True
        Me.ToolBar1.ViewTemplateEnabled = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.gboxHelp, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gboxData, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1226, 592)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'gboxHelp
        '
        Me.gboxHelp.Controls.Add(Me.btnNext)
        Me.gboxHelp.Controls.Add(Me.Label2)
        Me.gboxHelp.Controls.Add(Me.Label1)
        Me.gboxHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxHelp.Location = New System.Drawing.Point(983, 3)
        Me.gboxHelp.Name = "gboxHelp"
        Me.gboxHelp.Size = New System.Drawing.Size(240, 586)
        Me.gboxHelp.TabIndex = 40
        Me.gboxHelp.TabStop = False
        Me.gboxHelp.Text = "Help"
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.White
        Me.btnNext.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnNext.Location = New System.Drawing.Point(144, 547)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(90, 33)
        Me.btnNext.TabIndex = 18
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(271, 60)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Use the add/remove buttons and" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the grid to edit each template's" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "individual text" &
    ""
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(212, 72)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Each individual template can " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "have different text, which can " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "be specified usin" &
    "g the grid on" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "the left" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gboxData
        '
        Me.gboxData.Controls.Add(Me.DataGridView1)
        Me.gboxData.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxData.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxData.Location = New System.Drawing.Point(3, 3)
        Me.gboxData.Name = "gboxData"
        Me.gboxData.Size = New System.Drawing.Size(729, 586)
        Me.gboxData.TabIndex = 0
        Me.gboxData.TabStop = False
        Me.gboxData.Text = "Template Text"
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 27)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(723, 556)
        Me.DataGridView1.TabIndex = 0
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.gbox1, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.GroupBox1, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(738, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(239, 586)
        Me.TableLayoutPanel3.TabIndex = 41
        '
        'gbox1
        '
        Me.gbox1.Controls.Add(Me.TemplateDisplay1)
        Me.gbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox1.Location = New System.Drawing.Point(3, 237)
        Me.gbox1.Name = "gbox1"
        Me.gbox1.Size = New System.Drawing.Size(233, 346)
        Me.gbox1.TabIndex = 42
        Me.gbox1.TabStop = False
        Me.gbox1.Text = "Selected Template"
        '
        'TemplateDisplay1
        '
        Me.TemplateDisplay1.BackColor = System.Drawing.Color.White
        Me.TemplateDisplay1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.TemplateDisplay1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TemplateDisplay1.Location = New System.Drawing.Point(6, 31)
        Me.TemplateDisplay1.Name = "TemplateDisplay1"
        Me.TemplateDisplay1.Size = New System.Drawing.Size(218, 294)
        Me.TemplateDisplay1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnAdd)
        Me.GroupBox1.Controls.Add(Me.btnMinus)
        Me.GroupBox1.Controls.Add(Me.tboxNumTemplates)
        Me.GroupBox1.Controls.Add(Me.btnDeletedSelected)
        Me.GroupBox1.Controls.Add(Me.btnCreate)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!)
        Me.GroupBox1.Location = New System.Drawing.Point(3, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(233, 228)
        Me.GroupBox1.TabIndex = 43
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Options"
        '
        'btnAdd
        '
        Me.btnAdd.BackColor = System.Drawing.Color.White
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnAdd.Location = New System.Drawing.Point(108, 192)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(38, 30)
        Me.btnAdd.TabIndex = 17
        Me.btnAdd.Text = "+"
        Me.btnAdd.UseVisualStyleBackColor = False
        '
        'btnMinus
        '
        Me.btnMinus.BackColor = System.Drawing.Color.White
        Me.btnMinus.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnMinus.Location = New System.Drawing.Point(6, 192)
        Me.btnMinus.Name = "btnMinus"
        Me.btnMinus.Size = New System.Drawing.Size(38, 30)
        Me.btnMinus.TabIndex = 16
        Me.btnMinus.Text = "-"
        Me.btnMinus.UseVisualStyleBackColor = False
        '
        'tboxNumTemplates
        '
        Me.tboxNumTemplates.Enabled = False
        Me.tboxNumTemplates.Location = New System.Drawing.Point(50, 192)
        Me.tboxNumTemplates.Name = "tboxNumTemplates"
        Me.tboxNumTemplates.Size = New System.Drawing.Size(52, 31)
        Me.tboxNumTemplates.TabIndex = 15
        Me.tboxNumTemplates.Text = "0"
        Me.tboxNumTemplates.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnDeletedSelected
        '
        Me.btnDeletedSelected.BackColor = System.Drawing.Color.White
        Me.btnDeletedSelected.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnDeletedSelected.Location = New System.Drawing.Point(6, 86)
        Me.btnDeletedSelected.Name = "btnDeletedSelected"
        Me.btnDeletedSelected.Size = New System.Drawing.Size(138, 49)
        Me.btnDeletedSelected.TabIndex = 14
        Me.btnDeletedSelected.Text = "Remove Selected Template"
        Me.btnDeletedSelected.UseVisualStyleBackColor = False
        '
        'btnCreate
        '
        Me.btnCreate.BackColor = System.Drawing.Color.White
        Me.btnCreate.Font = New System.Drawing.Font("Arial", 10.25!)
        Me.btnCreate.Location = New System.Drawing.Point(6, 33)
        Me.btnCreate.Name = "btnCreate"
        Me.btnCreate.Size = New System.Drawing.Size(138, 49)
        Me.btnCreate.TabIndex = 13
        Me.btnCreate.Text = "Add New Template"
        Me.btnCreate.UseVisualStyleBackColor = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'NewOrderFormChooseParameter
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "NewOrderFormChooseParameter"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAMP - Create New Job"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.gboxHelp.ResumeLayout(False)
        Me.gboxHelp.PerformLayout()
        Me.gboxData.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.gbox1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents gboxData As GroupBox
    Friend WithEvents gboxHelp As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents gbox1 As GroupBox
    Friend WithEvents TemplateDisplay1 As TemplateDisplay
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnDeletedSelected As Button
    Friend WithEvents btnCreate As Button
    Friend WithEvents btnAdd As Button
    Friend WithEvents btnMinus As Button
    Friend WithEvents tboxNumTemplates As TextBox
    Friend WithEvents btnNext As Button
    Friend WithEvents ErrorProvider1 As ErrorProvider
End Class
