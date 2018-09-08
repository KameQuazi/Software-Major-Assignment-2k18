<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MultiTemplateViewer
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
        Me.GridPanel = New System.Windows.Forms.TableLayoutPanel()
        Me.LoadingPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.LoadingPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridPanel
        '
        Me.GridPanel.AutoScroll = True
        Me.GridPanel.ColumnCount = 4
        Me.GridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GridPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.0!))
        Me.GridPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridPanel.Location = New System.Drawing.Point(0, 0)
        Me.GridPanel.Name = "GridPanel"
        Me.GridPanel.RowCount = 1
        Me.GridPanel.RowStyles.Add(New System.Windows.Forms.RowStyle())
        Me.GridPanel.Size = New System.Drawing.Size(800, 600)
        Me.GridPanel.TabIndex = 0
        '
        'LoadingPictureBox
        '
        Me.LoadingPictureBox.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LoadingPictureBox.Image = Global.LampClient.My.Resources.Resources.loading
        Me.LoadingPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LoadingPictureBox.Name = "LoadingPictureBox"
        Me.LoadingPictureBox.Size = New System.Drawing.Size(800, 600)
        Me.LoadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LoadingPictureBox.TabIndex = 0
        Me.LoadingPictureBox.TabStop = False
        Me.LoadingPictureBox.Visible = False
        '
        'MultiTemplateViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.LoadingPictureBox)
        Me.Controls.Add(Me.GridPanel)
        Me.DoubleBuffered = True
        Me.Name = "MultiTemplateViewer"
        Me.Size = New System.Drawing.Size(800, 600)
        CType(Me.LoadingPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GridPanel As TableLayoutPanel
    Friend WithEvents LoadingPictureBox As PictureBox
End Class
