<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SingleDynamicText
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
        Me.TablePanel = New System.Windows.Forms.TableLayoutPanel()
        Me.ParameterName = New System.Windows.Forms.Label()
        Me.DescriptionText = New System.Windows.Forms.Label()
        Me.TablePanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'TablePabel
        '
        Me.TablePanel.ColumnCount = 3
        Me.TablePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TablePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.0!))
        Me.TablePanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30.0!))
        Me.TablePanel.Controls.Add(Me.ParameterName, 0, 0)
        Me.TablePanel.Controls.Add(Me.DescriptionText, 1, 0)
        Me.TablePanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TablePanel.Location = New System.Drawing.Point(0, 0)
        Me.TablePanel.Name = "TablePabel"
        Me.TablePanel.RowCount = 1
        Me.TablePanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TablePanel.Size = New System.Drawing.Size(749, 110)
        Me.TablePanel.TabIndex = 0
        '
        'ParameterName
        '
        Me.ParameterName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ParameterName.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ParameterName.Location = New System.Drawing.Point(3, 0)
        Me.ParameterName.Name = "ParameterName"
        Me.ParameterName.Size = New System.Drawing.Size(218, 110)
        Me.ParameterName.TabIndex = 1
        Me.ParameterName.Text = "ParameterName"
        Me.ParameterName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'DescriptionText
        '
        Me.DescriptionText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DescriptionText.Location = New System.Drawing.Point(227, 0)
        Me.DescriptionText.Name = "DescriptionText"
        Me.DescriptionText.Size = New System.Drawing.Size(293, 110)
        Me.DescriptionText.TabIndex = 2
        Me.DescriptionText.Text = "Not Not a description"
        Me.DescriptionText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'SingleDynamicText
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TablePanel)
        Me.Name = "SingleDynamicText"
        Me.Size = New System.Drawing.Size(749, 110)
        Me.TablePanel.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TablePanel As TableLayoutPanel
    Friend WithEvents ParameterName As Label
    Friend WithEvents DescriptionText As Label
End Class
