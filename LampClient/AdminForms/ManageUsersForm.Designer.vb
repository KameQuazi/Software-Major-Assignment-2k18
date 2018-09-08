<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ManageUsersForm
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AdminToolbar1 = New LampClient.AdminToolbar()
        Me.ServiceMultiUserViewer1 = New LampClient.ServiceUserViewer()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnAddUser = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AdminToolbar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ServiceMultiUserViewer1, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 0
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
        'ServiceMultiUserViewer1
        '
        Me.ServiceMultiUserViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServiceMultiUserViewer1.Location = New System.Drawing.Point(3, 178)
        Me.ServiceMultiUserViewer1.Name = "ServiceMultiUserViewer1"
        Me.ServiceMultiUserViewer1.Offset = 0
        Me.ServiceMultiUserViewer1.Size = New System.Drawing.Size(1226, 522)
        Me.ServiceMultiUserViewer1.SortOrder = LampCommon.LampUserSort.NameAsc
        Me.ServiceMultiUserViewer1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnAddUser, 1, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 108)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1226, 64)
        Me.TableLayoutPanel2.TabIndex = 2
        '
        'btnAddUser
        '
        Me.btnAddUser.BackColor = System.Drawing.Color.White
        Me.btnAddUser.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAddUser.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnAddUser.Location = New System.Drawing.Point(1108, 5)
        Me.btnAddUser.Margin = New System.Windows.Forms.Padding(5)
        Me.btnAddUser.Name = "btnAddUser"
        Me.btnAddUser.Size = New System.Drawing.Size(113, 54)
        Me.btnAddUser.TabIndex = 55
        Me.btnAddUser.Text = "Add User"
        Me.btnAddUser.UseVisualStyleBackColor = False
        '
        'ManageUsersForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "ManageUsersForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ManageUsersForm"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents AdminToolbar1 As AdminToolbar
    Friend WithEvents ServiceMultiUserViewer1 As ServiceUserViewer
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnAddUser As Button
End Class
