Imports LampClient
Imports LampCommon

Public Class EditTemplateDialogButtons

    Public Event LoadingStart(sender As Object, e As EventArgs)

    Public Event LoadingEnd(sender As Object, e As EventArgs)

    Private _editDisabled As Boolean = False
    Public Property EditDisabled As Boolean
        Get
            Return _editDisabled
        End Get
        Set(value As Boolean)
            _editDisabled = value
            btnSubmitEdit.Enabled = Not value
        End Set
    End Property


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
        ImportDxf.Enabled = Not [Readonly]
        If EditDisabled Then
            btnSubmitEdit.Enabled = False
        End If
    End Sub

    Private Sub UpdateEnabledElements()
        RootTableLayoutPanel.Enabled = Me.Enabled
        If EditDisabled Then
            btnSubmitEdit.Enabled = False
        End If
    End Sub



    Protected Overrides Sub OnEnabledChanged(e As EventArgs)
        MyBase.OnEnabledChanged(e)

        UpdateEnabledElements()
    End Sub



    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call    End Sub
    End Sub



    Public Event ImportSpfClicked(sender As Object, e As EventArgs)

    Public Event ImportDxfClicked(sender As Object, e As EventArgs)

    Public Event ExportSpfClicked(sender As Object, e As EventArgs)

    Public Event ExportDxfClicked(sender As Object, e As EventArgs)

    Public Event SubmitEditClicked(sender As Object, e As EventArgs)

    Public Event DeleteClicked(sender As Object, e As EventArgs)

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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        RaiseEvent DeleteClicked(Me, New EventArgs)
    End Sub

    Private Sub btnSubmit_Click(sender As Object, e As EventArgs) Handles btnSubmitEdit.Click
        RaiseEvent SubmitEditClicked(Me, New EventArgs)
    End Sub







End Class

