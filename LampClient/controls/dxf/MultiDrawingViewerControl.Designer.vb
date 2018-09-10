<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiDrawingViewerControl
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiDrawingViewerControl))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.DxfViewerControl1 = New LampClient.DxfViewerControl()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.DxfViewerControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(515, 401)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DxfViewerControl1.Location = New System.Drawing.Point(12, 12)
        Me.DxfViewerControl1.Margin = New System.Windows.Forms.Padding(12)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Size = New System.Drawing.Size(491, 336)
        Me.DxfViewerControl1.TabIndex = 0
        Me.DxfViewerControl1.ZoomX = 1.0R
        Me.DxfViewerControl1.ZoomY = 1.0R
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.Location = New System.Drawing.Point(3, 0)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(104, 35)
        Me.lblPage.TabIndex = 58
        Me.lblPage.Text = "Page: 1/1"
        Me.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 3
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle())
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.lblPage, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 2, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 363)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(509, 35)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Panel1.Controls.Add(Me.btnNextPage)
        Me.Panel1.Controls.Add(Me.btnPreviousPage)
        Me.Panel1.Location = New System.Drawing.Point(328, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(181, 35)
        Me.Panel1.TabIndex = 59
        '
        'btnNextPage
        '
        Me.btnNextPage.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNextPage.Enabled = False
        Me.btnNextPage.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNextPage.Image = Global.LampClient.My.Resources.Resources.arrowRight
        Me.btnNextPage.Location = New System.Drawing.Point(103, 3)
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
        Me.btnPreviousPage.Location = New System.Drawing.Point(1, 3)
        Me.btnPreviousPage.Name = "btnPreviousPage"
        Me.btnPreviousPage.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPreviousPage.Size = New System.Drawing.Size(75, 29)
        Me.btnPreviousPage.TabIndex = 10
        Me.btnPreviousPage.UseVisualStyleBackColor = True
        '
        'MultiDrawingViewerControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "MultiDrawingViewerControl"
        Me.Size = New System.Drawing.Size(515, 401)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents lblPage As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnNextPage As Button
    Friend WithEvents btnPreviousPage As Button
End Class
