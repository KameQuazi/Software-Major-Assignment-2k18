Imports System.Drawing.Imaging
Imports Newtonsoft.Json
Imports Point = netDxf.Vector3
Imports LAMP.LampMath



Public Class DesignerForm
    Private dxf As LampDxfDocument
    Private template As LampTemplate
    Private database As TemplateDatabase


    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles OpenFileBtn.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf = LampDxfDocument.LoadFromFile(OpenFileDialog1.FileName)
            SaveFileBtn.Enabled = True

            FilenameTbox.Text = OpenFileDialog1.FileName
            DesignerScreen1.Source = dxf
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles SaveFileBtn.Click
        If SaveFileDialog1.ShowDialog() = DialogResult.OK Then
            dxf.Save(SaveFileDialog1.FileName)
        End If
    End Sub


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' NOTE!!
        ' Exceptions in event handlers (form.load) suppress exceptions implicitly
        ' That means if any function raises an exception (e.g. inserting a duplicate item,
        ' since the GUID is a unique constraint, it will simply exit the function
        ' as if a return was placed there
        ' I've moved the stuff to the sub new underneath


    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dxf = New LampDxfDocument()

        dxf.AddLine(0, 0, -100, -100)
        dxf.AddCircle(0, 0, 10)



        template = New LampTemplate(dxf)
        DesignerScreen1.Source = dxf

        jsonOutput.Text = template.Serialize(Formatting.Indented)
        template.Save("out.spf", Formatting.Indented)
        LampTemplate.LoadFromFile("out.spf")

    End Sub


    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            Dim z = TextBox1.Text.Split(" "c)
            Dim y = TextBox2.Text.Split(" "c)
            dxf.AddLine(Double.Parse(z(0)), Double.Parse(z(1)), Double.Parse(y(0)), Double.Parse(y(1)))
            DesignerScreen1.Refresh()
            jsonOutput.Text = template.Serialize(Formatting.Indented)
            template.Save("out.spf", Formatting.Indented)
        Catch ex As FormatException
            MessageBox.Show("The format is incorrect!")
        End Try
    End Sub



    Private Sub rightButton_Click(sender As Object, e As EventArgs) Handles rightButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 10, 0)
    End Sub

    Private Sub downButton_Click(sender As Object, e As EventArgs) Handles downButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, -10)
    End Sub

    Private Sub leftButton_Click(sender As Object, e As EventArgs) Handles leftButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, -10, 0)
    End Sub

    Private Sub upButton_Click(sender As Object, e As EventArgs) Handles upButton.Click
        DesignerScreen1.Center = Transform(DesignerScreen1.Center, 0, 10)
    End Sub

    Private Sub DesignerScreen1_Load(sender As Object, e As EventArgs) Handles DesignerScreen1.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        If SaveFileDialog2.ShowDialog = DialogResult.OK Then
            template.template.Save(SaveFileDialog2.FileName)
        End If
    End Sub


End Class

