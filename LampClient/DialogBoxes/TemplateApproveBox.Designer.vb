<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TemplateApproveBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TemplateApproveBox))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TemplateCreatorControl1 = New LampClient.TemplateCreatorControl()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnApprove = New System.Windows.Forms.Button()
        Me.btnRevoke = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TemplateCreatorControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TemplateCreatorControl1
        '
        Me.TemplateCreatorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TemplateCreatorControl1.Location = New System.Drawing.Point(3, 73)
        Me.TemplateCreatorControl1.Name = "TemplateCreatorControl1"
        Me.TemplateCreatorControl1.ReadOnly = True
        Me.TemplateCreatorControl1.Size = New System.Drawing.Size(1226, 627)
        Me.TemplateCreatorControl1.TabIndex = 0
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Controls.Add(Me.btnApprove)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnRevoke)
        Me.FlowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.FlowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(3, 3)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(1226, 64)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'btnApprove
        '
        Me.btnApprove.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnApprove.BackColor = System.Drawing.Color.White
        Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnApprove.Location = New System.Drawing.Point(1161, 4)
        Me.btnApprove.Margin = New System.Windows.Forms.Padding(4)
        Me.btnApprove.Name = "btnApprove"
        Me.btnApprove.Size = New System.Drawing.Size(61, 59)
        Me.btnApprove.TabIndex = 12
        Me.btnApprove.Text = "Approve"
        Me.btnApprove.UseVisualStyleBackColor = False
        '
        'btnRevoke
        '
        Me.btnRevoke.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnRevoke.BackColor = System.Drawing.Color.White
        Me.btnRevoke.Enabled = False
        Me.btnRevoke.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnRevoke.Location = New System.Drawing.Point(1092, 4)
        Me.btnRevoke.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRevoke.Name = "btnRevoke"
        Me.btnRevoke.Size = New System.Drawing.Size(61, 59)
        Me.btnRevoke.TabIndex = 13
        Me.btnRevoke.Text = "Revoke"
        Me.btnRevoke.UseVisualStyleBackColor = False
        '
        'TemplateApproveBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TemplateApproveBox"
        Me.Text = "Approve Template"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TemplateCreatorControl1 As TemplateCreatorControl
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnApprove As Button
    Friend WithEvents btnRevoke As Button
End Class
