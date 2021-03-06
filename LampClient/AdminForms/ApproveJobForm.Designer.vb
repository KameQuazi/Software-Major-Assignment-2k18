﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ApproveJobForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ApproveJobForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.AdminToolbar1 = New LampClient.AdminToolbar()
        Me.ServiceSortableJobViewer1 = New LampClient.ServiceSortableJobViewer()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.AdminToolbar1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.ServiceSortableJobViewer1, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'AdminToolbar1
        '
        Me.AdminToolbar1.ApproveJobEnabled = True
        Me.AdminToolbar1.ApproveTemplateEnabled = True
        Me.AdminToolbar1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.AdminToolbar1.ConfirmationRequired = Nothing
        Me.AdminToolbar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.AdminToolbar1.HomeEnabled = True
        Me.AdminToolbar1.Location = New System.Drawing.Point(0, 0)
        Me.AdminToolbar1.ManageUsersEnabled = True
        Me.AdminToolbar1.Margin = New System.Windows.Forms.Padding(0)
        Me.AdminToolbar1.Name = "AdminToolbar1"
        Me.AdminToolbar1.Size = New System.Drawing.Size(1232, 105)
        Me.AdminToolbar1.TabIndex = 0
        '
        'ServiceSortableJobViewer1
        '
        Me.ServiceSortableJobViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServiceSortableJobViewer1.JustMyJobs = False
        Me.ServiceSortableJobViewer1.Location = New System.Drawing.Point(3, 108)
        Me.ServiceSortableJobViewer1.Name = "ServiceSortableJobViewer1"
        Me.ServiceSortableJobViewer1.SidebarHidden = False
        Me.ServiceSortableJobViewer1.Size = New System.Drawing.Size(1226, 592)
        Me.ServiceSortableJobViewer1.SortOrder = LampCommon.LampJobSort.NoSort
        Me.ServiceSortableJobViewer1.SplitterDistance = 981
        Me.ServiceSortableJobViewer1.TabIndex = 1
        Me.ServiceSortableJobViewer1.TitleText = "Approve Job"
        '
        'ApproveJobForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ApproveJobForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "View/Edit Jobs"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents AdminToolbar1 As AdminToolbar
    Friend WithEvents ServiceSortableJobViewer1 As ServiceSortableJobViewer
End Class
