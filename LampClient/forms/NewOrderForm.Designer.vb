<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewOrderForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewOrderForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.gboxHelp = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbox1 = New System.Windows.Forms.GroupBox()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.ServiceSortableTemplateViewer1 = New LampClient.ServiceSortableTemplateViewer()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.gboxHelp.SuspendLayout()
        Me.gbox1.SuspendLayout()
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
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.gbox1, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1226, 592)
        Me.TableLayoutPanel2.TabIndex = 38
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.gboxHelp, 0, 0)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(983, 3)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(240, 586)
        Me.TableLayoutPanel3.TabIndex = 38
        '
        'gboxHelp
        '
        Me.gboxHelp.Controls.Add(Me.Label2)
        Me.gboxHelp.Controls.Add(Me.Label1)
        Me.gboxHelp.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gboxHelp.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gboxHelp.Location = New System.Drawing.Point(3, 3)
        Me.gboxHelp.Name = "gboxHelp"
        Me.gboxHelp.Size = New System.Drawing.Size(234, 287)
        Me.gboxHelp.TabIndex = 0
        Me.gboxHelp.TabStop = False
        Me.gboxHelp.Text = "Help"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(228, 72)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Choose a template to create a " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "job. This template will be placed" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "one or more ti" &
    "mes in the final " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "output to laser cut"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gbox1
        '
        Me.gbox1.Controls.Add(Me.ServiceSortableTemplateViewer1)
        Me.gbox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbox1.Font = New System.Drawing.Font("Arial Narrow", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbox1.Location = New System.Drawing.Point(3, 3)
        Me.gbox1.Name = "gbox1"
        Me.gbox1.Size = New System.Drawing.Size(974, 586)
        Me.gbox1.TabIndex = 39
        Me.gbox1.TabStop = False
        Me.gbox1.Text = "Choose Template"
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.MediumSlateBlue
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
        'ServiceSortableTemplateViewer1
        '
        Me.ServiceSortableTemplateViewer1.ApprovedType = LampCommon.LampApprove.All
        Me.ServiceSortableTemplateViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServiceSortableTemplateViewer1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ServiceSortableTemplateViewer1.JustMyTemplates = False
        Me.ServiceSortableTemplateViewer1.Location = New System.Drawing.Point(3, 28)
        Me.ServiceSortableTemplateViewer1.Margin = New System.Windows.Forms.Padding(5, 6, 5, 6)
        Me.ServiceSortableTemplateViewer1.Name = "ServiceSortableTemplateViewer1"
        Me.ServiceSortableTemplateViewer1.SidebarHidden = False
        Me.ServiceSortableTemplateViewer1.Size = New System.Drawing.Size(968, 555)
        Me.ServiceSortableTemplateViewer1.SortOrder = LampCommon.LampTemplateSort.NoSort
        Me.ServiceSortableTemplateViewer1.SplitterDistance = 750
        Me.ServiceSortableTemplateViewer1.TabIndex = 0
        Me.ServiceSortableTemplateViewer1.TitleText = "Choose Template"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 115)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(206, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Click on a template in the list to" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "select"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'NewOrderForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewOrderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAMP - Create New Job"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.gboxHelp.ResumeLayout(False)
        Me.gboxHelp.PerformLayout()
        Me.gbox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents gboxHelp As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents gbox1 As GroupBox
    Friend WithEvents ServiceSortableTemplateViewer1 As ServiceSortableTemplateViewer
    Friend WithEvents Label2 As Label
End Class
