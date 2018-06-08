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
        Me.DynamicFormCreation1 = New Global.LampClient.DynamicFormCreation()
        Me.ToolBar1 = New Global.LampClient.ToolBar()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'DynamicFormCreation1
        '
        Me.DynamicFormCreation1.AutoScroll = True
        Me.DynamicFormCreation1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.DynamicFormCreation1.Location = New System.Drawing.Point(0, 126)
        Me.DynamicFormCreation1.Name = "DynamicFormCreation1"
        Me.DynamicFormCreation1.Size = New System.Drawing.Size(984, 585)
        Me.DynamicFormCreation1.TabIndex = 0
        '
        'ToolBar1
        '
        Me.ToolBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ToolBar1.BackColor = System.Drawing.Color.White
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.Location = New System.Drawing.Point(-6, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ScreenName = "Attach/Edit Parameters"
        Me.ToolBar1.Size = New System.Drawing.Size(1000, 91)
        Me.ToolBar1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(909, 97)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Edit.."
        Me.Button1.UseVisualStyleBackColor = True
        '
        'DynamicTextCreationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(984, 711)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.DynamicFormCreation1)
        Me.Name = "DynamicTextCreationForm"
        Me.Text = "DynamicTextCreationForm"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DynamicFormCreation1 As DynamicFormCreation
    Friend WithEvents ToolBar1 As ToolBar
    Friend WithEvents Button1 As Button
End Class
