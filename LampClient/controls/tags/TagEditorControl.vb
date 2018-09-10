Imports System.Collections.ObjectModel
Imports System.Text

Public Class TagEditorControl

    Public Event TagContentsChanged(sender As Object, e As TagContentsChangedEvent)

    Public ReadOnly Property Tags As ObservableCollection(Of String)
        Get
            Return TagList
        End Get
    End Property

    Private WithEvents TagList As New ObservableCollection(Of String)

    Private Sub HandleTagUpdated(sender As Object, e As EventArgs) Handles TagList.CollectionChanged
        RaiseEvent TagContentsChanged(Me, New TagContentsChangedEvent())
        UpdateContents()
    End Sub

    Private _readonly As Boolean = False
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value
            AddTag.Enabled = Not value
            RemoveTag.Enabled = Not value
        End Set
    End Property

    Private Function NormalizeTags(text As String) As String
        text = text.Trim()

        Dim stringB As New StringBuilder
        For Each character As String In text

            If Char.IsWhiteSpace(character) OrElse character = "-" Then
                stringB.Append("-")
            ElseIf Char.IsLetter(character) Then
                stringB.Append(character.ToLower())
            End If

        Next

        Return stringB.ToString

    End Function


    Private Sub AddTag_Click(sender As Object, e As EventArgs) Handles AddTag.Click
        Dim dialog As New LampInputBox("New tag", "Enter new tag (lower case letters and space allowed):")
        If dialog.ShowDialog() = DialogResult.OK Then
            Dim newTag = NormalizeTags(dialog.InputText)
            If Tags.Contains(newTag) Then
                MessageBox.Show("Tag must be unique")
            ElseIf newTag.Length > 16 Then
                MessageBox.Show("tag must be shorter or equal to 16 characters")
            ElseIf newTag.Length = 0 Then
                MessageBox.Show("tag not be empty")
            Else
                ' add them to the tags in the template
                Tags.Add(newTag)
                End If
            End If
    End Sub

    Private Sub RemoveTagTags_Click(sender As Object, e As EventArgs) Handles RemoveTag.Click
        Dim selectedPosition = TagsBox.SelectedIndex
        If selectedPosition <> -1 Then
            ' an item is selected
            Dim selectedTag = TagsBox.SelectedItem.ToString
            Tags.Remove(selectedTag)
        End If
    End Sub

    Private Sub UpdateContents()
        TagsBox.Items.Clear()
        For Each tagItem In Tags
            TagsBox.Items.Add(tagItem)
        Next
    End Sub
End Class

Public Class TagContentsChangedEvent
    Inherits EventArgs

End Class
