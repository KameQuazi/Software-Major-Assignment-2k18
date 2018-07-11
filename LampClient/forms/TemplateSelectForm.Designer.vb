<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TemplateSelectForm
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
        Me.ServiceSortableTemplateViewer1 = New LampClient.ServiceSortableTemplateViewer()
        Me.SuspendLayout()
        '
        'ServiceSortableTemplateViewer1
        '
        Me.ServiceSortableTemplateViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ServiceSortableTemplateViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ServiceSortableTemplateViewer1.Name = "ServiceSortableTemplateViewer1"
        Me.ServiceSortableTemplateViewer1.SidebarHidden = False
        Me.ServiceSortableTemplateViewer1.Size = New System.Drawing.Size(1232, 703)
        Me.ServiceSortableTemplateViewer1.TabIndex = 0
        Me.ServiceSortableTemplateViewer1.TitleText = "Choose Template"
        '
        'TemplateSelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.ServiceSortableTemplateViewer1)
        Me.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TemplateSelectForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Viewer"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ServiceSortableTemplateViewer1 As ServiceSortableTemplateViewer
End Class
