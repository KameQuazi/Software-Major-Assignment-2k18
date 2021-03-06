﻿Imports LampCommon

Public Class EditUserForm
    Public Property User As LampUser
        Get
            Return ManageUserControl1.User
        End Get
        Set(value As LampUser)
            ManageUserControl1.User = value
        End Set
    End Property



    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.DialogResult = DialogResult.Cancel
        Me.Readonly = False
    End Sub



    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        If MessageBox.Show("This will permanently remove this user", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) Then
            Dim response = CurrentSender.RemoveUser(CurrentUser.ToCredentials, User.UserId)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Sucessfully deleted user!")
                Case Else
                    ShowError(response)
            End Select
        End If
    End Sub



    Private Sub ManageUserControl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ManageUserControl1.Readonly = True
        editPressed = False
    End Sub


    Private Sub btnRevert_Click(sender As Object, e As EventArgs) Handles btnRevert.Click
        btnRevert.Enabled = False
        User = previousUser
        previousUser = Nothing
        btnEdit.Enabled = True
        btnEdit.Text = "Edit User"
        editPressed = False

    End Sub
    Private _editPressed As Boolean = False
    Private Property editPressed As Boolean
        Get
            Return _editPressed
        End Get
        Set(value As Boolean)
            _editPressed = value
            If editPressed Then
                btnEdit.Text = "Confirm Edit"
                btnRevert.Enabled = True
                previousUser = User.Clone()
                ManageUserControl1.Readonly = False
            Else
                ' reset the edit button
                btnEdit.Text = "Edit User"
                btnRevert.Enabled = False
                ManageUserControl1.Readonly = True
                previousUser = Nothing
            End If

        End Set
    End Property

    Private _readonly As Boolean = False
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            ManageUserControl1.Readonly = value
            If [Readonly] Then
                btnDelete.Enabled = False
                btnEdit.Enabled = False
                btnRevert.Enabled = False
            Else
                btnDelete.Enabled = True
                btnEdit.Enabled = True
            End If
        End Set
    End Property

    Private previousUser As LampUser
    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        If editPressed Then
            If Not validateUser() Then
                Return
            End If
            Dim response = CurrentSender.EditUser(CurrentUser.ToCredentials, User)
            Select Case response
                Case LampStatus.OK
                    MessageBox.Show("Successfully edited user!")
                Case Else
                    ShowError(response)
            End Select
        End If

        editPressed = Not editPressed
    End Sub

    Private Function validateUser() As Boolean
        Dim warnings As Boolean = False
        Dim warningTEext As String = "Warnings detected: \n"
        If User.Username = String.Empty Then
            MessageBox.Show("Username must be specified")
            Return False
        End If
        If User.Email = String.Empty Then
            MessageBox.Show("Email must be specified")
            Return False
        End If

        If Not ValidateEmail(User.Email) Then
            MessageBox.Show("Email is invalid")
            Return False
        End If

        If User.Password = String.Empty Then
            MessageBox.Show("Password is empty")
            Return False
        End If

        If User.Password.Length < MIN_PASSWORD_LENGTH Then
            MessageBox.Show(String.Format("Password must be {0} or more characters long", MIN_PASSWORD_LENGTH))
            Return False
        End If
        Return True

    End Function

    Private Sub btnDelete_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click

    End Sub
End Class
