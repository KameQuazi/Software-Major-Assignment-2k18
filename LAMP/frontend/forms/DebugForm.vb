Public Class DebugForm
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim db As New TemplateDatabase()
        TemplateDatabase.FillDebugDatabase()
        db.GetAllTemplate()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim screen As New Form()
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
        x.DeleteTables()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim x = New TemplateSelect()
        x.ShowDialog()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Test()
    End Sub

    Private Sub Test()
        MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("one"))
        MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("two"))
        MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("three"))
        MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("four"))
        MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("five"))
        MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("six"))
        'MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("seven"))
        'MultipleTemplateViewer1.Items.Add(TemplateDatabase.GetExampleTemplate("eight"))
        'Dim x As New Button()
        'x.Text = "asdf"
        'MultipleTemplateViewer1.TableLayoutPanel1.Controls.Add(x)
    End Sub

    Private Sub Swap()
        Dim c1 As Control = MultipleTemplateViewer1.TableLayoutPanel1.GetControlFromPosition(0, 0)
        Dim c2 As Control = MultipleTemplateViewer1.TableLayoutPanel1.GetControlFromPosition(1, 0)

        If c1 IsNot Nothing And c2 IsNot Nothing Then

            MultipleTemplateViewer1.TableLayoutPanel1.SetColumn(c1, 1)
            MultipleTemplateViewer1.TableLayoutPanel1.SetColumn(c2, 0)

        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim x As New SingleTemplateViewer
        x.ShowDialog()
    End Sub

    Private Sub MultipleTemplateViewer1_Load(sender As Object, e As EventArgs) Handles MultipleTemplateViewer1.Load

    End Sub
End Class