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
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.lblPage = New System.Windows.Forms.Label()
        Me.DxfViewerControl1 = New LampClient.DxfViewerControl()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
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
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(515, 401)
        Me.TableLayoutPanel1.TabIndex = 1
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 4
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.btnNext, 3, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.btnPrevious, 2, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.lblPage, 0, 0)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(3, 363)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 1
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(509, 35)
        Me.TableLayoutPanel2.TabIndex = 1
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.White
        Me.btnNext.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnNext.Location = New System.Drawing.Point(436, 5)
        Me.btnNext.Margin = New System.Windows.Forms.Padding(5)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(68, 25)
        Me.btnNext.TabIndex = 57
        Me.btnNext.Text = "->"
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.White
        Me.btnPrevious.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Font = New System.Drawing.Font("Arial", 12.25!)
        Me.btnPrevious.Location = New System.Drawing.Point(360, 5)
        Me.btnPrevious.Margin = New System.Windows.Forms.Padding(5)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(66, 25)
        Me.btnPrevious.TabIndex = 56
        Me.btnPrevious.Text = "<-"
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'lblPage
        '
        Me.lblPage.AutoSize = True
        Me.lblPage.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblPage.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPage.Location = New System.Drawing.Point(3, 0)
        Me.lblPage.Name = "lblPage"
        Me.lblPage.Size = New System.Drawing.Size(248, 35)
        Me.lblPage.TabIndex = 58
        Me.lblPage.Text = "Page: 1/1"
        Me.lblPage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DxfViewerControl1
        '
        Me.DxfViewerControl1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DxfViewerControl1.Center = CType(resources.GetObject("DxfViewerControl1.Center"), System.Drawing.PointF)
        Me.DxfViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DxfViewerControl1.Drawing = Nothing
        Me.DxfViewerControl1.Location = New System.Drawing.Point(12, 12)
        Me.DxfViewerControl1.Margin = New System.Windows.Forms.Padding(12)
        Me.DxfViewerControl1.Name = "DxfViewerControl1"
        Me.DxfViewerControl1.Size = New System.Drawing.Size(491, 336)
        Me.DxfViewerControl1.TabIndex = 0
        Me.DxfViewerControl1.ZoomX = 1.0R
        Me.DxfViewerControl1.ZoomY = 1.0R
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
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents DxfViewerControl1 As DxfViewerControl
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents btnNext As Button
    Friend WithEvents btnPrevious As Button
    Friend WithEvents lblPage As Label
End Class
