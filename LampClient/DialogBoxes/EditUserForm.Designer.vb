<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EditUserForm
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ManageUserControl1 = New LampClient.ManageUserControl()
        Me.SuspendLayout()
        '
        'ManageUserControl1
        '
        Me.ManageUserControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ManageUserControl1.Location = New System.Drawing.Point(0, 0)
        Me.ManageUserControl1.Name = "ManageUserControl1"
        Me.ManageUserControl1.Size = New System.Drawing.Size(447, 435)
        Me.ManageUserControl1.TabIndex = 0
        '
        'EditUserForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(447, 435)
        Me.Controls.Add(Me.ManageUserControl1)
        Me.Name = "EditUserForm"
        Me.Text = "EditUserForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ManageUserControl1 As ManageUserControl
End Class
