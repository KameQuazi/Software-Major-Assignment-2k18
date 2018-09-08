<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class JobDisplay
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
        Dim LampTemplate1 As LampCommon.LampTemplate = New LampCommon.LampTemplate()
        Dim LampDxfDocument1 As LampCommon.LampDxfDocument = New LampCommon.LampDxfDocument()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(JobDisplay))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SubmitProfileDisplay = New LampClient.ProfileDisplay()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ApproveProfileDisplay = New LampClient.ProfileDisplay()
        Me.FileDisplay1 = New LampClient.FileDisplay()
        Me.btnDynamicText = New System.Windows.Forms.Button()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FileDisplay1, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel2, 1, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(961, 304)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.SubmitProfileDisplay)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(3, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(314, 298)
        Me.Panel1.TabIndex = 1
        '
        'SubmitProfileDisplay
        '
        Me.SubmitProfileDisplay.Location = New System.Drawing.Point(-3, 68)
        Me.SubmitProfileDisplay.Name = "SubmitProfileDisplay"
        Me.SubmitProfileDisplay.Profile = Nothing
        Me.SubmitProfileDisplay.Size = New System.Drawing.Size(337, 150)
        Me.SubmitProfileDisplay.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Submitter"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnDynamicText)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.ApproveProfileDisplay)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(323, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(314, 298)
        Me.Panel2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(37, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Approver"
        '
        'ApproveProfileDisplay
        '
        Me.ApproveProfileDisplay.Location = New System.Drawing.Point(0, 68)
        Me.ApproveProfileDisplay.Name = "ApproveProfileDisplay"
        Me.ApproveProfileDisplay.Profile = Nothing
        Me.ApproveProfileDisplay.Size = New System.Drawing.Size(337, 150)
        Me.ApproveProfileDisplay.TabIndex = 2
        '
        'FileDisplay1
        '
        Me.FileDisplay1.BackColor = System.Drawing.Color.White
        Me.FileDisplay1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FileDisplay1.Location = New System.Drawing.Point(643, 3)
        Me.FileDisplay1.Name = "FileDisplay1"
        Me.FileDisplay1.Size = New System.Drawing.Size(187, 270)
        Me.FileDisplay1.TabIndex = 3
        LampTemplate1.ApproverProfile = Nothing
        LampDxfDocument1.SerializedDrawing = resources.GetString("LampDxfDocument1.SerializedDrawing")
        LampTemplate1.BaseDrawing = LampDxfDocument1
        LampTemplate1.CreatorProfile = Nothing
        LampTemplate1.GUID = "cef4512c-eb16-4eb4-ac49-71de15c81646"
        LampTemplate1.Height = 0R
        LampTemplate1.IsComplete = False
        LampTemplate1.Length = 0R
        LampTemplate1.LongDescription = ""
        LampTemplate1.Material = "Unspecified"
        LampTemplate1.MaterialThickness = 0R
        LampTemplate1.Name = ""
        LampTemplate1.ShortDescription = ""
        LampTemplate1.SubmitDate = Nothing
        Me.FileDisplay1.Template = LampTemplate1
        '
        'Button1
        '
        Me.btnDynamicText.Location = New System.Drawing.Point(60, 246)
        Me.btnDynamicText.Name = "Button1"
        Me.btnDynamicText.Size = New System.Drawing.Size(171, 23)
        Me.btnDynamicText.TabIndex = 3
        Me.btnDynamicText.Text = "Show parameters"
        Me.btnDynamicText.UseVisualStyleBackColor = True
        '
        'JobDisplay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "JobDisplay"
        Me.Size = New System.Drawing.Size(961, 304)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents SubmitProfileDisplay As ProfileDisplay
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents ApproveProfileDisplay As ProfileDisplay
    Friend WithEvents FileDisplay1 As FileDisplay
    Friend WithEvents btnDynamicText As Button
End Class
