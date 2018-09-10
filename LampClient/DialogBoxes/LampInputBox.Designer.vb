<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LampInputBox
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LampInputBox))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CancelExitButon = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(33, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Enter Data"
        '
        'CancelExitButon
        '
        Me.CancelExitButon.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CancelExitButon.Location = New System.Drawing.Point(108, 181)
        Me.CancelExitButon.Name = "CancelExitButon"
        Me.CancelExitButon.Size = New System.Drawing.Size(75, 23)
        Me.CancelExitButon.TabIndex = 2
        Me.CancelExitButon.Text = "Cancel"
        Me.CancelExitButon.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OkButton.Location = New System.Drawing.Point(202, 181)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 3
        Me.OkButton.Text = "Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(12, 66)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(218, 96)
        Me.RichTextBox1.TabIndex = 1
        Me.RichTextBox1.Text = ""
        '
        'LampInputBox
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(293, 216)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.CancelExitButon)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "LampInputBox"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents CancelExitButon As Button
    Friend WithEvents OkButton As Button
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
