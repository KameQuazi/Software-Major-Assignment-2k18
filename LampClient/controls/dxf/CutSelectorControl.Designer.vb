<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CutSelectorControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.radioBlack = New System.Windows.Forms.RadioButton()
        Me.radioBlue = New System.Windows.Forms.RadioButton()
        Me.radioRed = New System.Windows.Forms.RadioButton()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.radioBlack, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.radioBlue, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.radioRed, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(150, 150)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'radioBlack
        '
        Me.radioBlack.AutoSize = True
        Me.radioBlack.Location = New System.Drawing.Point(3, 103)
        Me.radioBlack.Name = "radioBlack"
        Me.radioBlack.Size = New System.Drawing.Size(135, 17)
        Me.radioBlack.TabIndex = 3
        Me.radioBlack.TabStop = True
        Me.radioBlack.Text = "Black (Raster Engrave)" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.radioBlack.UseVisualStyleBackColor = True
        '
        'radioBlue
        '
        Me.radioBlue.AutoSize = True
        Me.radioBlue.Location = New System.Drawing.Point(3, 53)
        Me.radioBlue.Name = "radioBlue"
        Me.radioBlue.Size = New System.Drawing.Size(105, 17)
        Me.radioBlue.TabIndex = 2
        Me.radioBlue.TabStop = True
        Me.radioBlue.Text = "Blue (Raster Cut)"
        Me.radioBlue.UseVisualStyleBackColor = True
        '
        'radioRed
        '
        Me.radioRed.AutoSize = True
        Me.radioRed.Checked = True
        Me.radioRed.Location = New System.Drawing.Point(3, 3)
        Me.radioRed.Name = "radioRed"
        Me.radioRed.Size = New System.Drawing.Size(104, 17)
        Me.radioRed.TabIndex = 1
        Me.radioRed.TabStop = True
        Me.radioRed.Text = "Red (Vector Cut)"
        Me.radioRed.UseVisualStyleBackColor = True
        '
        'CutSelectorControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "CutSelectorControl"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents radioRed As RadioButton
    Friend WithEvents radioBlue As RadioButton
    Friend WithEvents radioBlack As RadioButton
End Class
