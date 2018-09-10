Public Class TagEditorControl

    Private Function NormalizeTags(text As String) As String
        Return New String(text.Where(Function(x) Not Char.IsWhiteSpace(x)).ToArray()).ToLower
    End Function


    Private Sub AddTag_Click(sender As Object, e As EventArgs) Handles AddTag.Click
        Dim dialog As New LampInputBox("New tag", "Enter new tag")
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim newTag = NormalizeTags(dialog.InputText)

            If Me.Template.Tags.Contains(newTag) Then
                ' dont allow duplicates
                MessageBox.Show("tags must be unique ")
            ElseIf newTag.Length > 16 Then
                MessageBox.Show("tag must be shorter or equal to 16 characters")
            ElseIf newTag.Length = 0 Then
                MessageBox.Show("tag not be empty")
            Else
                ' add them to the tags in the template
                Me.Template.Tags.Add(newTag)
                Me.Template.SortTags()
            End If
        End If
    End Sub

    Private Sub RemoveTagTags_Click(sender As Object, e As EventArgs) Handles RemoveTag.Click
        Dim selectedPosition = TagsBox.SelectedIndex
        If selectedPosition <> -1 Then
            ' an item is selected
            Dim selectedTag = NormalizeTags(TagsBox.SelectedItem.ToString)
            Me.Template.Tags.Remove(selectedTag)

        End If
    End Sub
End Class
