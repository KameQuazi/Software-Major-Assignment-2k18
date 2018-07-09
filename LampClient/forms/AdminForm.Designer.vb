<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminForm
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
        Me.AdminToolbar1 = New LampClient.AdminToolbar()
        Me.SuspendLayout()
        '
        'AdminToolbar1
        '
        Me.AdminToolbar1.BackColor = System.Drawing.Color.LightSeaGreen
        Me.AdminToolbar1.Dock = System.Windows.Forms.DockStyle.Top
        Me.AdminToolbar1.Location = New System.Drawing.Point(0, 0)
        Me.AdminToolbar1.Name = "AdminToolbar1"
        Me.AdminToolbar1.Size = New System.Drawing.Size(1232, 108)
        Me.AdminToolbar1.TabIndex = 0
        '
        'AdminForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.AdminToolbar1)
        Me.Name = "AdminForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AdminForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents AdminToolbar1 As AdminToolbar
End Class
