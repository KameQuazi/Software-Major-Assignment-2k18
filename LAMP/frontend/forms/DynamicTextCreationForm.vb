Public Class DynamicTextCreationForm
    Private Sub DynamicTextCreationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DynamicFormCreation1.Source.Add(New DynamicTemplateInput("name", "nae of the studnet", Nothing))
        DynamicFormCreation1.Source.Add(New DynamicTemplateInput("f_irl", "subreedit", Nothing))
        DynamicFormCreation1.Source.Add(New DynamicTemplateInput("monosodium glumate", "is bad fur you", Nothing))
    End Sub

    Private Sub DynamicFormCreation1_Load(sender As Object, e As EventArgs) Handles DynamicFormCreation1.Load

    End Sub
End Class