﻿Imports LampCommon

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class NewTemplateForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(NewTemplateForm))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.TemplateCreatorControl1 = New LampClient.TemplateCreatorControl()
        Me.ToolBar1 = New LampClient.ToolBar()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.TemplateCreatorControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.ToolBar1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1232, 703)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'TemplateCreatorControl1
        '
        Me.TemplateCreatorControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TemplateCreatorControl1.Location = New System.Drawing.Point(3, 108)
        Me.TemplateCreatorControl1.Name = "TemplateCreatorControl1"
        Me.TemplateCreatorControl1.OptionsControl = Nothing
        Me.TemplateCreatorControl1.ReadOnly = False
        Me.TemplateCreatorControl1.Size = New System.Drawing.Size(1226, 592)
        Me.TemplateCreatorControl1.TabIndex = 0
        '
        'ToolBar1
        '
        Me.ToolBar1.BackColor = System.Drawing.Color.MediumSlateBlue
        Me.ToolBar1.ConfirmationRequired = Nothing
        Me.ToolBar1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ToolBar1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolBar1.HomeEnabled = True
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Margin = New System.Windows.Forms.Padding(0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.NewOrderEnabled = True
        Me.ToolBar1.NewTemplateEnabled = False
        Me.ToolBar1.Size = New System.Drawing.Size(1232, 105)
        Me.ToolBar1.TabIndex = 1
        Me.ToolBar1.ViewOrderEnabled = True
        Me.ToolBar1.ViewTemplateEnabled = True
        '
        'NewTemplateForm
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.Silver
        Me.ClientSize = New System.Drawing.Size(1232, 703)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "NewTemplateForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LAMP - New Template"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TemplateCreatorControl1 As TemplateCreatorControl
    Friend WithEvents ToolBar1 As ToolBar


End Class
