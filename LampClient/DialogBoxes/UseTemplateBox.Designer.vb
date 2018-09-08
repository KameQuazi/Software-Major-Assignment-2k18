<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UseTemplateBox
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
        Dim LampTemplate1 As LampCommon.LampTemplate = New LampCommon.LampTemplate()
        Dim LampDxfDocument1 As LampCommon.LampDxfDocument = New LampCommon.LampDxfDocument()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UseTemplateBox))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TemplateCreatorControl1 = New LampClient.TemplateCreatorControl()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TemplateCreatorControl1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TemplateCreatorControl1
        '
        Me.TemplateCreatorControl1.Location = New System.Drawing.Point(3, 3)
        Me.TemplateCreatorControl1.Name = "TemplateCreatorControl1"
        Me.TemplateCreatorControl1.Size = New System.Drawing.Size(1226, 697)
        Me.TemplateCreatorControl1.SubmitType = LampClient.TemplateCreatorControl.SendType.None
        Me.TemplateCreatorControl1.TabIndex = 0
        LampTemplate1.ApproverProfile = Nothing
        LampDxfDocument1.SerializedDrawing = resources.GetString("LampDxfDocument1.SerializedDrawing")
        LampTemplate1.BaseDrawing = LampDxfDocument1
        LampTemplate1.CreatorProfile = Nothing
        LampTemplate1.GUID = "86a55c4b-2c35-447e-abc5-504823620f0c"
        LampTemplate1.Height = 0R
        LampTemplate1.IsComplete = False
        LampTemplate1.Length = 0R
        LampTemplate1.LongDescription = ""
        LampTemplate1.Material = "Unspecified"
        LampTemplate1.MaterialThickness = 0R
        LampTemplate1.Name = ""
        LampTemplate1.ShortDescription = ""
        LampTemplate1.SubmitDate = Nothing
        Me.TemplateCreatorControl1.Template = LampTemplate1
        '
        'UseTemplateBox
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "UseTemplateBox"
        Me.Text = "UseTemplateBox"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TemplateCreatorControl1 As TemplateCreatorControl
End Class
