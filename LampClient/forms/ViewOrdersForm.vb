Imports LampCommon

Public Class ViewOrdersForm

    Private Sub ShowError(status As LampStatus)
        MessageBox.Show("Could not update: " + status.ToString)
    End Sub




End Class