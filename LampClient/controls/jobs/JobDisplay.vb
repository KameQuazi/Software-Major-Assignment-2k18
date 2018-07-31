Imports System.ComponentModel
Imports LampCommon

Public Class JobDisplay

    Private dynamicTextViewer As New DynamicTextCreationForm

    Private _job As LampJob

    ''' <summary>
    ''' Change template to change the text on the display
    ''' </summary>
    ''' <returns></returns>
    Public Property Job As LampJob
        Get
            Return _job
        End Get
        Set(value As LampJob)
            _job = value
            DisplayJob()
        End Set
    End Property

    <DefaultValue("True")>
    Private _readonly As Boolean
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value
            tboxSummary.ReadOnly = True
        End Set
    End Property

    Private Sub DisplayJob()
        If Job IsNot Nothing Then
            'SubmitProfileDisplay.Profile = Job.Submitter
            ' ApproveProfileDisplay.Profile = Job.Approver
            dynamicTextViewer.Source = Job.Template
            FileDisplay1.Template = Job.Template
            tboxSummary.Text = Job.Summary
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        dynamicTextViewer.ShowDialog()
    End Sub

    Private Sub btnApprove_Click(sender As Object, e As EventArgs) Handles btnApprove.Click
        RaiseEvent ApproveClick(Me, New LampJobEventArgs(Job))
    End Sub

    Private Sub btnViewDrawing_Click(sender As Object, e As EventArgs) Handles btnViewDrawing.Click
        RaiseEvent ViewDrawingClicks(Me, New LampJobEventArgs(Job))
    End Sub

    Private Sub btnAdvanced_Click(sender As Object, e As EventArgs) Handles btnAdvanced.Click
        RaiseEvent AdvancedClick(Me, New LampJobEventArgs(Job))
    End Sub

    Public Event ApproveClick(sender As Object, job As LampJobEventArgs)
    Public Event ViewDrawingClicks(sender As Object, job As LampJobEventArgs)
    Public Event AdvancedClick(sender As Object, job As LampJobEventArgs)
End Class


Public Class LampJobEventArgs
    Inherits EventArgs
    Public Property Job As LampJob
    Public Sub New(job As LampJob)
        Me.Job = job
    End Sub
End Class