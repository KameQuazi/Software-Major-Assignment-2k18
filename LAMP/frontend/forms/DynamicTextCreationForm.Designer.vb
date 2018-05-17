<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DynamicTextCreationForm
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
        Me.DynamicFormCreation1 = New LAMP.DynamicFormCreation()
        Me.SuspendLayout()
        '
        'DynamicFormCreation1
        '
        Me.DynamicFormCreation1.AutoScroll = True
        Me.DynamicFormCreation1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DynamicFormCreation1.Location = New System.Drawing.Point(0, 0)
        Me.DynamicFormCreation1.Name = "DynamicFormCreation1"
        Me.DynamicFormCreation1.Size = New System.Drawing.Size(835, 526)
        Me.DynamicFormCreation1.TabIndex = 0
        '
        'DynamicTextCreationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 526)
        Me.Controls.Add(Me.DynamicFormCreation1)
        Me.Name = "DynamicTextCreationForm"
        Me.Text = "DynamicTextCreationForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DynamicFormCreation1 As DynamicFormCreation
End Class
