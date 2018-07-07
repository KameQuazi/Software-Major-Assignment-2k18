<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyTemplatesForm
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.MultiTemplateViewer2 = New LampClient.MultiTemplateViewer()
        Me.MultiTemplateViewer1 = New LampClient.MultiTemplateViewer()
        Me.SuspendLayout()
        '
        'MultiTemplateViewer2
        '
        Me.MultiTemplateViewer2.Location = New System.Drawing.Point(0, 859)
        Me.MultiTemplateViewer2.Margin = New System.Windows.Forms.Padding(5)
        Me.MultiTemplateViewer2.Name = "MultiTemplateViewer2"
        Me.MultiTemplateViewer2.Size = New System.Drawing.Size(1643, 738)
        Me.MultiTemplateViewer2.TabIndex = 3
        '
        'MultiTemplateViewer1
        '
        Me.MultiTemplateViewer1.Location = New System.Drawing.Point(0, 133)
        Me.MultiTemplateViewer1.Margin = New System.Windows.Forms.Padding(5)
        Me.MultiTemplateViewer1.Name = "MultiTemplateViewer1"
        Me.MultiTemplateViewer1.Size = New System.Drawing.Size(1643, 726)
        Me.MultiTemplateViewer1.TabIndex = 1
        '
        'MyTemplatesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 953)
        Me.Controls.Add(Me.MultiTemplateViewer2)
        Me.Controls.Add(Me.MultiTemplateViewer1)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "MyTemplatesForm"
        Me.Text = "MyTemplatesForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents MultiTemplateViewer2 As MultiTemplateViewer
    Friend WithEvents MultiTemplateViewer1 As MultiTemplateViewer
End Class
