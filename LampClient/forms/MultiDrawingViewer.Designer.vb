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
        '
        'MultiDrawingViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(590, 542)
        Me.Controls.Add(Me.MultiDrawingViewerControl1)
        Me.Name = "MultiDrawingViewer"
        Me.Text = "MultiDrawingViewer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiDrawingViewerControl1 As MultiDrawingViewerControl
End Class
