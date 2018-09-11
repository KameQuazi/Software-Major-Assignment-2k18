<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditTemplateDialog
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EditTemplateDialog))
        Me.TemplateCreatorControl1 = New LampClient.TemplateCreatorControl()
        Me.SuspendLayout()
        '
        'TemplateCreatorControl1
        '
        Me.TemplateCreatorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TemplateCreatorControl1.Location = New System.Drawing.Point(0, 0)
        Me.TemplateCreatorControl1.Name = "TemplateCreatorControl1"
        Me.TemplateCreatorControl1.OptionsControl = Nothing
        Me.TemplateCreatorControl1.ReadOnly = False
        Me.TemplateCreatorControl1.Size = New System.Drawing.Size(1232, 703)
        Me.TemplateCreatorControl1.TabIndex = 2
        '
        'EditTemplateDialog
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TemplateCreatorControl1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "EditTemplateDialog"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Editing Template - LAMP"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TemplateCreatorControl1 As TemplateCreatorControl
End Class
