Imports System.ComponentModel
Imports LampCommon

Public Class MultiDrawingViewer
    <Browsable(False), EditorBrowsable(EditorBrowsableState.Never), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property Drawings As List(Of LampDxfDocument)
        Get
            Return MultiDrawingViewerControl1.Drawings
        End Get
        Set(value As List(Of LampDxfDocument))
            MultiDrawingViewerControl1.Drawings = value
        End Set
    End Property

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        If Settings.DesignerProgram.Internal Then
            MessageBox.Show("Please specify an external dxf viewer in settings tag")
            SettingsForm.ShowDialog()
        Else
            Dim process As New Process
            process.StartInfo.FileName = Settings.DesignerProgram.ProgramPath
            ' prompt use for file name and create empty dxf file
            ' save it into a temp file
            Dim currentfilename = "temp.dxf"
            Dim current = MultiDrawingViewerControl1.CurrentDrawing
            If current Is Nothing Then
                MessageBox.Show("No drawing found!")
            Else
                Try
                    current.Save(currentfilename)
                    process.StartInfo.Arguments = currentfilename
                    'process.StartInfo.Verb = "print"
                Catch ex As Exception
                    MessageBox.Show("temp.dxf is open in another program. Please close that program")
                    Return
                End Try

                    Try
                    process.Start()
                Catch ex As Exception
                    MessageBox.Show(String.Format("Cannot open using program: {0}. Please specify another program in Settings.", DesignerProgram.ProgramPath))
                End Try
            End If
        End If





    End Sub
End Class