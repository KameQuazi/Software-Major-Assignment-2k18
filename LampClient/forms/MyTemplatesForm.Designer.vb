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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.MultiTemplateViewer1 = New LampClient.MultiTemplateViewer()
        Me.SuspendLayout()
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.White
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = True
        Me.ToolBar1.Location = New System.Drawing.Point(-1, 1)
        Me.ToolBar1.MyOrdersEnabled = True
        Me.ToolBar1.MyTrophyEnabled = False
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = True
        Me.ToolBar1.Size = New System.Drawing.Size(1231, 108)
        Me.ToolBar1.TabIndex = 0
        '
        'MultiTemplateViewer1
        '
        Me.MultiTemplateViewer1.Location = New System.Drawing.Point(-1, 115)
        Me.MultiTemplateViewer1.Name = "MultiTemplateViewer1"
        Me.MultiTemplateViewer1.Size = New System.Drawing.Size(1231, 590)
        Me.MultiTemplateViewer1.TabIndex = 1
        '
        'MyTemplatesForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.MultiTemplateViewer1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Name = "MyTemplatesForm"
        Me.Text = "MyTemplatesForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents MultiTemplateViewer1 As MultiTemplateViewer
End Class
