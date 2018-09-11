Imports LampCommon

Public Class frmCreateAcc
    Private Async Sub btnCreate_Click(sender As Object, e As EventArgs) Handles btnCreate.Click
        Dim noErrors = True

        If txtPass.Text <> txtPass2.Text Then
            lblNoMatch.Show()
            noErrors = False
        Else
            lblNoMatch.Hide()
        End If
        If txtName.Text = "" Then
            lblFillRequired.Show()
            required2.Show()
            noErrors = False
        End If
        If txtName2.Text = "" Then
            lblFillRequired.Show()
            required3.Show()
            noErrors = False
        End If
        If txtUser.Text = "" Then
            lblFillRequired.Show()
            required1.Show()
            noErrors = False
        End If
        If txtPass.Text = "" Then
            lblFillRequired.Show()
            required4.Show()
            noErrors = False
        End If
        If txtPass2.Text = "" Then
            lblFillRequired.Show()
            required5.Show()
            noErrors = False
        End If

        If noErrors Then
            ' help me please
            Dim past = Me.Enabled
            Me.Enabled = False

            Try
                ShowWaitForm()

                Dim user As New LampUser(GetNewGuid, UserPermission.Standard, txtEmail.Text, txtUser.Text, txtPass.Text, txtName.Text + " " + txtName2.Text)
                Dim response = Await CurrentSender.AddUserAsync(Nothing, user)

                Select Case response
                    Case LampStatus.OK
                        MessageBox.Show("User signup successful!")
                        Me.Close()
                    Case Else
                        ShowError(response)
                End Select

            Catch ex As Exception
                MessageBox.Show("An error occured while connecting to server")
#If DEBUG Then
                Throw ex
#End If
            Finally
                Me.Enabled = past
                HideWaitForm()

            End Try




        End If
    End Sub

    Private Sub btncancel_Click(sender As Object, e As EventArgs) Handles btncancel.Click
        Me.Close()
    End Sub

    Private Sub frmCreateAcc_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtPass.Text = txtPass2.Text Then
            lblNoMatch.Hide()
        End If
        lblNoEmail.Hide()
        lblNoUser.Hide()
    End Sub
End Class