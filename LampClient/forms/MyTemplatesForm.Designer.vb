<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyTemplatesForm
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
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.MultiTemplateViewer1 = New LampClient.MultiTemplateViewer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnNextPage
        '
        Me.btnNextPage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnNextPage.Enabled = False
        Me.btnNextPage.Location = New System.Drawing.Point(84, 3)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNextPage.Size = New System.Drawing.Size(75, 23)
        Me.btnNextPage.TabIndex = 4
        Me.btnNextPage.Text = "->"
        Me.btnNextPage.UseVisualStyleBackColor = True
        '
        'MultiTemplateViewer1
        '
        Me.MultiTemplateViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MultiTemplateViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MultiTemplateViewer1.Location = New System.Drawing.Point(3, 3)
        Me.MultiTemplateViewer1.Name = "MultiTemplateViewer1"
        Me.MultiTemplateViewer1.Size = New System.Drawing.Size(1220, 538)
        Me.MultiTemplateViewer1.TabIndex = 1
        Me.MultiTemplateViewer1.AutoScroll = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.ToolBar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 6
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = True
        Me.ToolBar1.Location = New System.Drawing.Point(3, 3)
        Me.ToolBar1.MyOrdersEnabled = True
        Me.ToolBar1.MyTrophyEnabled = False
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1226, 99)
        Me.ToolBar1.TabIndex = 8
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.MultiTemplateViewer1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1226, 592)
        Me.TableLayoutPanel2.TabIndex = 7
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPreviousPage)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnNextPage)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(1023, 547)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(200, 42)
        Me.FlowLayoutPanel1.TabIndex = 6
        '
        'btnPreviousPage
        '
        Me.btnPreviousPage.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnPreviousPage.Enabled = False
        Me.btnPreviousPage.Location = New System.Drawing.Point(3, 3)
        Me.btnPreviousPage.Name = "btnPreviousPage"
        Me.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPreviousPage.Size = New System.Drawing.Size(75, 23)
        Me.btnPreviousPage.TabIndex = 6
        Me.btnPreviousPage.Text = "<-"
        Me.btnPreviousPage.UseVisualStyleBackColor = True
        '
        'MyTemplatesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MyTemplatesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "MyTemplatesForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MultiTemplateViewer1 As MultiTemplateViewer
    Friend WithEvents btnNextPage As Button
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnPreviousPage As Button
End Class
