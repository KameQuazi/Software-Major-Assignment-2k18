﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceJobViewer
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.MultiJobViewer1 = New LampClient.MultiJobViewer()
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.MultiJobViewer1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(800, 600)
        Me.TableLayoutPanel2.TabIndex = 9
        '
        'MultiJobViewer1
        '
        Me.MultiJobViewer1.Columns = 1
        Me.MultiJobViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MultiJobViewer1.JobCursor = System.Windows.Forms.Cursors.Hand
        Me.MultiJobViewer1.Location = New System.Drawing.Point(5, 5)
        Me.MultiJobViewer1.Name = "MultiJobViewer1"
        Me.MultiJobViewer1.Rows = 3
        Me.MultiJobViewer1.Size = New System.Drawing.Size(790, 540)
        Me.MultiJobViewer1.TabIndex = 7
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.FlowLayoutPanel1.Controls.Add(Me.btnPreviousPage)
        Me.FlowLayoutPanel1.Controls.Add(Me.btnNextPage)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(595, 554)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(200, 40)
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
        'ServiceJobViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "ServiceJobViewer"
        Me.Size = New System.Drawing.Size(800, 600)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents btnPreviousPage As Button
    Friend WithEvents btnNextPage As Button
    Friend WithEvents MultiJobViewer1 As MultiJobViewer
End Class