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
        Dim screen As New LoginForm()
        screen.ShowDialog()
    End Sub

    Private Sub DebugForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim x = New TemplateDatabase()
        x.RemoveTables()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim x = New TemplateSelectBox()
        x.Show()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Test()

    End Sub

    Private Sub Test()
        Dim x As New LampTemplate
        x.DynamicTextList.Add(New DynamicTextKey("asdf", "asdf", New netDxf.Vector3(), 4, 4))

        ' JobDisplay1.Job = New LampJob(x, New LampProfile("asdf", "b", "{}{}{}", UserPermission.Admin), "some summary")

    End Sub

    Private Sub Test2()


    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim x As New NewTemplateForm
        x.ShowDialog()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Test2()
    End Sub

    Private Sub MultiTemplateViewer_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim frm As New DynamicTextCreationForm(LampTemplate.FromFile("../../../templates/ten.spf"))

        frm.ShowDialog()
    End Sub

    Private Sub DynamicFormCreation1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim x As New LampService.LampHost
        x.StartListenerFromConfig()
    End Sub


    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim ref As New DebugRefpoints
        ref.ShowDialog()
    End Sub
End Class