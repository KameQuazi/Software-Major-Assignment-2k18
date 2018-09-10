Imports System.Collections.ObjectModel
Imports System.ComponentModel
Imports LampCommon

Public Class NewOrderFormExport
    Public Property Job As LampJob
    Public ReadOnly Property CompletedJobs As List(Of LampDxfDocument)
        Get
            Return Job?.CompleteDrawings
        End Get
    End Property

    Public Sub New(Optional newJob As LampJob = Nothing)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Job = newJob
        newJob.RefreshCompleteDrawing()
        UpdateContents()

    End Sub

    Private Sub UpdateContents()
        Job.RefreshCompleteDrawing()
        MultiDrawingViewerControl1.Drawings = Job.CompleteDrawings
        Job.SubmitId = CurrentUser.UserId

    End Sub

    Private Sub MultiDrawingViewerControl1_Load(sender As Object, e As EventArgs) Handles MultiDrawingViewerControl1.Load

    End Sub

    Private Sub btnSubmitJob_Click(sender As Object, e As EventArgs) Handles btnSubmitJob.Click
        If Not CheckPossibleErrors() Then
            Return
        End If

        Dim response = CurrentSender.AddJob(CurrentUser.ToCredentials, Job)
        If response = LampStatus.OK Then
            MessageBox.Show("Adding job successful")


        Else
            ShowError(response)

        End If
    End Sub

    Private Sub btnExportJob_Click(sender As Object, e As EventArgs) Handles btnExportJob.Click
        If Not CheckPossibleErrors() Then
            Return
        End If
        If JobSaveFileDialog.ShowDialog = DialogResult.OK Then
            Job.Save(JobSaveFileDialog.FileName)
        End If
    End Sub

    Private Sub btnExportDxf_Click(sender As Object, e As EventArgs) Handles btnExportDxf.Click
        If DxfListSaveFileDialog.ShowDialog() = DialogResult.OK Then
            Dim path = DxfListSaveFileDialog.SelectedPath
            For i = 1 To CompletedJobs.Count - 1
                CompletedJobs(i).Save(Job.Template.Name + i.ToString + ".dxf")
            Next
        End If
    End Sub

    Private Function CheckPossibleErrors() As Boolean
        Dim showWarning = False
        Dim warningText = "Possible Problems: "
        If rtboxSummary.Text = String.Empty Then
            showWarning = True
            warningText += "\n- Description Empty"
        End If

        If showWarning Then
            warningText += "\nDo you want to continue?"
            warningText = warningText.Replace("\n", Environment.NewLine)
            Dim result = MessageBox.Show(warningText, "Warning", MessageBoxButtons.YesNo)
            If result = DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    Private Sub rtboxSummary_TextChanged(sender As Object, e As EventArgs) Handles rtboxSummary.TextChanged
        Job.Summary = rtboxSummary.Text
    End Sub
End Class

