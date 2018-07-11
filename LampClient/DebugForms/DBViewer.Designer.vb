<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DBViewer
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
        Dim LampTemplate1 As LampCommon.LampTemplate = New LampCommon.LampTemplate()
        Dim LampDxfDocument1 As LampCommon.LampDxfDocument = New LampCommon.LampDxfDocument()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DBViewer))
        Me.DBGrid = New System.Windows.Forms.DataGridView()
        Me.btnUpdate = New System.Windows.Forms.Button()
        CType(Me.DBGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DBGrid
        '
        Me.DBGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DBGrid.Location = New System.Drawing.Point(34, 44)
        Me.DBGrid.Name = "DBGrid"
        Me.DBGrid.Size = New System.Drawing.Size(751, 315)
        Me.DBGrid.TabIndex = 0
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(466, 382)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 1
        Me.btnUpdate.Text = "Button1"
        Me.btnUpdate.UseVisualStyleBackColor = True
        '
        'DBViewer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(814, 440)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.DBGrid)
        Me.Name = "DBViewer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DBViewer"
        CType(Me.DBGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents DBGrid As DataGridView
    Friend WithEvents btnUpdate As Button
End Class
