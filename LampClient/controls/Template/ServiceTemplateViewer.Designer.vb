<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ServiceTemplateViewer
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
        Me.MultiTemplateViewer1 = New LampClient.MultiTemplateViewer()
        Me.btnPreviousPage = New System.Windows.Forms.Button()
        Me.btnNextPage = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.MultiTemplateViewer1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Panel1, 0, 1)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(857, 565)
        Me.TableLayoutPanel2.TabIndex = 8
        '
        'MultiTemplateViewer1
        '
        Me.MultiTemplateViewer1.AutoScroll = True
        Me.MultiTemplateViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.MultiTemplateViewer1.Columns = 4
        Me.MultiTemplateViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MultiTemplateViewer1.Location = New System.Drawing.Point(3, 3)
        Me.MultiTemplateViewer1.MouseOverHighlight = False
        Me.MultiTemplateViewer1.Name = "MultiTemplateViewer1"
        Me.MultiTemplateViewer1.Padding = New System.Windows.Forms.Padding(0, 0, 0, 35)
        Me.MultiTemplateViewer1.Rows = 2
        Me.MultiTemplateViewer1.Size = New System.Drawing.Size(851, 521)
        Me.MultiTemplateViewer1.TabIndex = 1
        Me.MultiTemplateViewer1.TemplateCursor = System.Windows.Forms.Cursors.Hand
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
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Panel1.Controls.Add(Me.btnNextPage)
        Me.Panel1.Controls.Add(Me.btnPreviousPage)
        Me.Panel1.Location = New System.Drawing.Point(671, 530)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(183, 32)
        Me.Panel1.TabIndex = 2
        '
        'ServiceTemplateViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel2)
        Me.Name = "ServiceTemplateViewer"
        Me.Size = New System.Drawing.Size(857, 565)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents MultiTemplateViewer1 As MultiTemplateViewer
    Friend WithEvents btnPreviousPage As Button
    Friend WithEvents btnNextPage As Button
    Friend WithEvents Panel1 As Panel
End Class
