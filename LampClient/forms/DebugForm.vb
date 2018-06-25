Imports LampCommon
Imports LampService

Public Class DebugForm
    Dim db As New TemplateDatabase()
    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Await TemplateDatabase.FillDebugDatabaseAsync
        db.GetAllTemplate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim screen As New DBViewer(New TemplateDatabase())
        screen.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim screen As New DesignerForm()
        screen.ShowDialog()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim screen As New frmStart()
        screen.ShowDialog()
    End Sub

    Private Sub DebugForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim x = New TemplateDatabase()
        x.RemoveTables()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim x = New TemplateSelect()
        x.ShowDialog()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Test()

    End Sub

    Private Sub Test()
        'TableLayoutPanel1.Controls.Add(New FileDisplay() With {.Text = "hello!"})
        'TableLayoutPanel1.Padding = New Padding(0, 0, SystemInformation.VerticalScrollBarWidth, 0)
        MultiTemplateViewer1.Templates.Clear()
    End Sub

    Private Async Sub Test2()
        'TableLayoutPanel1.RowCount += 1
        'TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.AutoSize))
        ' Dim temps = New TemplateDatabase().GetAllTemplate.
        Dim temps = Await CurrentSender.GetAllTemplateAsync(CurrentUser.ToCredentials)


        MultiTemplateViewer1.Suspend()

        For Each temp In temps
            MultiTemplateViewer1.Templates.Add(temp)
        Next

        MultiTemplateViewer1.EndSuspend()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim x As New TemplateEditor
        x.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Test2()
    End Sub

    Private Sub MultiTemplateViewer_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frm As New DynamicTextCreationForm

        frm.ShowDialog()
    End Sub

    Private Sub DynamicFormCreation1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim x As New LampService.LampHost
        x.StartListenerFromConfig()
    End Sub

    Private Sub TestUserButton_Click(sender As Object, e As EventArgs) Handles TestUserButton.Click
        Dim user = UserTbox.Text
        Dim pass = PasswordTbox.Text
        Dim newuser = CurrentSender.Authenticate(New LampCredentials(user, pass))
        MessageBox.Show(newuser.Status.ToString)
        CurrentUserTbox.Text = If(newuser.user, "").ToString
    End Sub
End Class