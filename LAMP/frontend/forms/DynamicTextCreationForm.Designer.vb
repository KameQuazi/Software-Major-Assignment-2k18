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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ToolBar1 = New LAMP.ToolBar()
        Me.SuspendLayout()
        '
        'DynamicFormCreation1
        '
        Me.DynamicFormCreation1.AutoScroll = True
        Me.DynamicFormCreation1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DynamicFormCreation1.Location = New System.Drawing.Point(0, 198)
        Me.DynamicFormCreation1.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.DynamicFormCreation1.Name = "DynamicFormCreation1"
        Me.DynamicFormCreation1.Size = New System.Drawing.Size(1232, 505)
        Me.DynamicFormCreation1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1027, 132)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 28)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Edit.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.Fuchsia
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.Size = New System.Drawing.Size(1231, 108)
        Me.ToolBar1.TabIndex = 3
        '
        'DynamicTextCreationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DynamicFormCreation1)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "DynamicTextCreationForm"
        Me.Text = "DynamicTextCreationForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DynamicFormCreation1 As DynamicFormCreation
    Friend WithEvents Button1 As Button
    Friend WithEvents ToolBar1 As ToolBar
End Class
