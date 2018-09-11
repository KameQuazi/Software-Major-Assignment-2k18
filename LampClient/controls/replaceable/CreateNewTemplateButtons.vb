Imports LampClient
Imports LampCommon

Public Class CreateNewTemplateButtons

    Public Event SubmitToDatabaseClicked(sender As Object, e As EventArgs)

    Public Event ImportSpfClicked(sender As Object, e As EventArgs)

    Public Event ImportDxfClicked(sender As Object, e As EventArgs)

    Public Event ExportSpfClicked(sender As Object, e As EventArgs)

    Public Event ExportDxfClicked(sender As Object, e As EventArgs)


    Private _readonly As Boolean = False
    Public Property [Readonly] As Boolean
        Get
            Return _readonly
        End Get
        Set(value As Boolean)
            _readonly = value

        End Set
    End Property

    Private Sub UpdateReadonlyElements()
        ImportSpf.Enabled = Not [Readonly]
    End Sub

    Private Sub UpdateEnabledElements()
        RootTableLayoutPanel.Enabled = Me.Enabled
    End Sub

    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        UpdateEnabledElements()
    End Sub

    Private _enabled As Boolean = False



    Private Sub ImportSpf_Click(sender As Object, e As EventArgs) Handles ImportSpf.Click
        RaiseEvent ImportSpfClicked(Me, New EventArgs)
    End Sub

    Private Sub ImportDxf_Click(sender As Object, e As EventArgs) Handles ImportDxf.Click
        RaiseEvent ImportDxfClicked(Me, New EventArgs)
    End Sub

    Private Sub ExportDxf_Click(sender As Object, e As EventArgs) Handles ExportDxf.Click
        RaiseEvent ExportDxfClicked(Me, New EventArgs)
    End Sub

    Private Sub ExportSpf_Click(sender As Object, e As EventArgs) Handles ExportSpf.Click
        RaiseEvent ExportSpfClicked(Me, New EventArgs)
    End Sub


    Private Sub btnSubmitTemplate_Click(sender As Object, e As EventArgs) Handles btnSubmitTemplate.Click
        RaiseEvent SubmitToDatabaseClicked(Me, New EventArgs)
    End Sub




    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub


End Class

