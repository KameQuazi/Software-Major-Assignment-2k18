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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gboxData = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.gbox1 = New System.Windows.Forms.GroupBox()
        Me.TemplateDisplay1 = New LampClient.TemplateDisplay()
        Me.MultipleTemplateDynamicTextDictionaryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.gboxHelp.SuspendLayout()
        Me.gboxData.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbox1.SuspendLayout()
        CType(Me.MultipleTemplateDynamicTextDictionaryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.ToolBar1.Location = New System.Drawing.Point(3, 3)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = False
        Me.ToolBar1.NewTemplateEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1226, 99)
        Me.ToolBar1.TabIndex = 37
        Me.ToolBar1.ViewOrderEnabled = True
        Me.ToolBar1.ViewTemplateEnabled = True
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182!))
        Me.TableLayoutPanel2.Controls.Add(Me.gboxHelp, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gboxData, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gbox1, 0, 0)
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
        Me.gboxHelp.Controls.Add(Me.Label2)
        Me.gboxHelp.Controls.Add(Me.Label1)
        Me.gboxHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxHelp.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxHelp.Location = New System.Drawing.Point(1005, 3)
        Me.gboxHelp.Name = "gboxHelp"
        Me.gboxHelp.Size = New System.Drawing.Size(218, 586)
        Me.gboxHelp.TabIndex = 40
        Me.gboxHelp.TabStop = False
        Me.gboxHelp.Text = "Help"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(-1, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(210, 60)
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
        Me.gboxData.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxData.Location = New System.Drawing.Point(337, 3)
        Me.gboxData.Name = "gboxData"
        Me.gboxData.Size = New System.Drawing.Size(662, 586)
        Me.gboxData.TabIndex = 0
        Me.gboxData.TabStop = False
        Me.gboxData.Text = "Template Text"
        '
        'DataGridView1
        '
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.DataSource = Me.MultipleTemplateDynamicTextDictionaryBindingSource
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(656, 555)
        Me.DataGridView1.TabIndex = 0
        '
        'gbox1
        '
        Me.gbox1.Controls.Add(Me.TemplateDisplay1)
        Me.gbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbox1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox1.Location = New System.Drawing.Point(3, 3)
        Me.gbox1.Name = "gbox1"
        Me.gbox1.Size = New System.Drawing.Size(328, 586)
        Me.gbox1.TabIndex = 39
        Me.gbox1.TabStop = False
        Me.gbox1.Text = "Selected Template"
        '
        'TemplateDisplay1
        '
        Me.TemplateDisplay1.BackColor = System.Drawing.Color.White
        Me.TemplateDisplay1.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.TemplateDisplay1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TemplateDisplay1.Location = New System.Drawing.Point(54, 51)
        Me.TemplateDisplay1.Name = "TemplateDisplay1"
        Me.TemplateDisplay1.Size = New System.Drawing.Size(200, 301)
        Me.TemplateDisplay1.TabIndex = 0
        '
        'MultipleTemplateDynamicTextDictionaryBindingSource
        '
        Me.MultipleTemplateDynamicTextDictionaryBindingSource.DataSource = GetType(LampClient.MultipleTemplateDynamicTextDictionary)
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
        Me.gbox1.ResumeLayout(False)
        CType(Me.MultipleTemplateDynamicTextDictionaryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents gboxData As GroupBox
    Friend WithEvents gbox1 As GroupBox
    Friend WithEvents TemplateDisplay1 As TemplateDisplay
    Friend WithEvents gboxHelp As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents MultipleTemplateDynamicTextDictionaryBindingSource As BindingSource
End Class
