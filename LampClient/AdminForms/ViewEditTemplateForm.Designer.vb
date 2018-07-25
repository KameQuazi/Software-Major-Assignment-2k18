<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewEditTemplateForm
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
        Me.AdminToolbar1 = New LampClient.AdminToolbar()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.ServiceSortableTemplateViewer1 = New LampClient.ServiceSortableTemplateViewer()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'AdminToolbar1
        '
        Me.AdminToolbar1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.AdminToolbar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdminToolbar1.Location = New System.Drawing.Point(3, 3)
        Me.AdminToolbar1.Name = "AdminToolbar1"
        Me.AdminToolbar1.Size = New System.Drawing.Size(1226, 99)
        Me.AdminToolbar1.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AdminToolbar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ServiceSortableTemplateViewer1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'ServiceSortableTemplateViewer1
        '
        Me.ServiceSortableTemplateViewer1.ApprovedType = LampCommon.LampApprove.All
        Me.ServiceSortableTemplateViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServiceSortableTemplateViewer1.JustMyTemplates = False
        Me.ServiceSortableTemplateViewer1.Location = New System.Drawing.Point(3, 108)
        Me.ServiceSortableTemplateViewer1.Name = "ServiceSortableTemplateViewer1"
        Me.ServiceSortableTemplateViewer1.SidebarHidden = False
        Me.ServiceSortableTemplateViewer1.Size = New System.Drawing.Size(1226, 592)
        Me.ServiceSortableTemplateViewer1.SortOrder = LampCommon.LampSort.NoSort
        Me.ServiceSortableTemplateViewer1.TabIndex = 1
        Me.ServiceSortableTemplateViewer1.TitleText = "Edit Template"
        '
        'ViewEditTemplateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ViewEditTemplateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ViewEditTemplateForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AdminToolbar1 As AdminToolbar
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents ServiceSortableTemplateViewer1 As ServiceSortableTemplateViewer
End Class
