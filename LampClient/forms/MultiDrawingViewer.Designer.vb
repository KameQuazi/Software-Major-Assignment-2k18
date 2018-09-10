<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MultiDrawingViewer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MultiDrawingViewer))
        Me.MultiDrawingViewerControl1 = New LampClient.MultiDrawingViewerControl()
        Me.SuspendLayout()
        '
        'MultiDrawingViewerControl1
        '
        Me.MultiDrawingViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.MultiDrawingViewerControl1.Location = New System.Drawing.Point(0, 0)
        Me.MultiDrawingViewerControl1.Name = "MultiDrawingViewerControl1"
        Me.MultiDrawingViewerControl1.Size = New System.Drawing.Size(590, 542)
        Me.MultiDrawingViewerControl1.TabIndex = 0
        Me.MultiDrawingViewerControl1.ZoomFactor = 1.0R
        Me.MultiDrawingViewerControl1.ZoomxX = 1.0R
        Me.MultiDrawingViewerControl1.ZoomxY = 1.0R
        '
        'MultiDrawingViewer
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(590, 542)
        Me.Controls.Add(Me.MultiDrawingViewerControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MultiDrawingViewer"
        Me.Text = "MultiDrawingViewer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiDrawingViewerControl1 As MultiDrawingViewerControl
End Class
