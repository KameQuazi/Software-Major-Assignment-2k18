<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.MultiJobViewer1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
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
        Me.MultiJobViewer1.Size = New System.Drawing.Size(790, 550)
        Me.MultiJobViewer1.TabIndex = 7
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Panel1.Controls.Add(Me.btnNextPage)
        Me.Panel1.Controls.Add(Me.btnPreviousPage)
        Me.Panel1.Location = New System.Drawing.Point(612, 563)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(183, 32)
        Me.Panel1.TabIndex = 8
        '
        'btnNextPage
        '
        Me.btnNextPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextPage.Enabled = False
        Me.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextPage.Image = Global.LampClient.My.Resources.Resources.arrowRight
        Me.btnNextPage.Location = New System.Drawing.Point(105, 0)
        Me.btnNextPage.Name = "btnNextPage"
        Me.btnNextPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnNextPage.Size = New System.Drawing.Size(75, 29)
        Me.btnNextPage.TabIndex = 9
        Me.btnNextPage.UseVisualStyleBackColor = True
        '
        'btnPreviousPage
        '
        Me.btnPreviousPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPreviousPage.Enabled = False
        Me.btnPreviousPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreviousPage.Image = Global.LampClient.My.Resources.Resources.arrowLeft
        Me.btnPreviousPage.Location = New System.Drawing.Point(3, 0)
        Me.btnPreviousPage.Name = "btnPreviousPage"
        Me.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPreviousPage.Size = New System.Drawing.Size(75, 29)
        Me.btnPreviousPage.TabIndex = 10
        Me.btnPreviousPage.UseVisualStyleBackColor = True
        '
        'ServiceJobViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "ServiceJobViewer"
        Me.Size = New System.Drawing.Size(800, 600)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents MultiJobViewer1 As MultiJobViewer
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnNextPage As Button
    Friend WithEvents btnPreviousPage As Button
End Class
