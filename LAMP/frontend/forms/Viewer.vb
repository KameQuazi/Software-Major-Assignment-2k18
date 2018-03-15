Public Class fileViewer
    Public Displays(7) As fileDisplay
    Private Sub pbLogo_Click(sender As Object, e As EventArgs)
        frmStart.Show()
        Me.Hide()
        frmStart.lastform = frmStart.curForm
        frmStart.curForm = "view"
    End Sub
    Private Sub fileViewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ToolBar1.lblCurScr.Text = "File Viewer"
        Displays(0) = FileDisplay1
        Displays(1) = FileDisplay2
        Displays(2) = FileDisplay3
        Displays(3) = FileDisplay4
        Displays(4) = FileDisplay5
        Displays(5) = FileDisplay6
        Displays(6) = FileDisplay7
        Displays(7) = FileDisplay8
        load_Files()
    End Sub
    Public Sub load_Files() ' Load Files into the viewing screen
        For i = 0 To 7
            Displays(i).lblName.Text = "Name: Standard trophy"
            Displays(i).lblCreator.Text = "Creator: Steve By Birth"
            Displays(i).lblHeight.Text = "Height: 140mm"
            Displays(i).lblWidth.Text = "Width: 70mm"
            Displays(i).lblMaterial.Text = "Material: 3mm Acrylic"
            Displays(i).lblCutTime.Text = "Time to Cut: 12 Min"
        Next
    End Sub

    Private Sub FileDisplay4_Load(sender As Object, e As EventArgs) Handles FileDisplay4.Load

    End Sub
End Class