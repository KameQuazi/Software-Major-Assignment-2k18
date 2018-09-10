Imports LampCommon

Public Class SettingsForm
    Private Loaded As Boolean = False
    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles radioLampViewer.CheckedChanged, radioExternal.CheckedChanged
        If radioLampViewer.Checked Then
            tboxExternalPath.Enabled = False
        Else
            tboxExternalPath.Enabled = True
        End If
    End Sub


    Private Sub SettingsForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Dim program = Settings.DesignerProgram
        If program.Internal Then
            radioLampViewer.Enabled = True
        Else
            radioLampViewer.Enabled = False
            tboxExternalPath.Text = program.ProgramPath
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If radioLampViewer.Checked Then
            ' use lamp viewer
            Settings.DesignerProgram = New OpenType(True, "")
        Else
            ' validate file path
            If Not ValidateFilePath() Then
                If MessageBox.Show("The program path specified does not appear to be valid. Are you sure you want to continue?", "Error Detected", MessageBoxButtons.OKCancel,
                                   MessageBoxIcon.Error, MessageBoxDefaultButton.Button1) <> DialogResult.OK Then
                    Return
                End If

            End If
            ' or actually save it
            Settings.DesignerProgram = New OpenType(False, tboxExternalPath.Text)
        End If
        Settings.PasswordSaved = chkSavePassword.Checked
        Me.Close()
    End Sub

    Private Function ValidateFilePath() As Boolean
        Return System.IO.File.Exists(tboxExternalPath.Text)
    End Function

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class