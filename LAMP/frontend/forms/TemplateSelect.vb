Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Public Class TemplateSelect

    Public ReadOnly Property Templates As ObservableCollection(Of LampTemplate)

    Private tags As List(Of String) ' lower case

    Private Sub MultiTemplateViewer1_Load(sender As Object, e As EventArgs) Handles MultiTemplateViewer1.Load

    End Sub

    Private Sub TemplateSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CurrentSender.RequestTemplates(CurrentUser, tags)
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Templates = New ObservableCollection(Of LampTemplate)
        AddHandler Templates.CollectionChanged, AddressOf AddTemplatesToViewer
    End Sub

    Private Sub AddTemplatesToViewer(sender As Object, e As NotifyCollectionChangedEventArgs)

    End Sub

    Private Sub RefreshTemplates()

    End Sub

    Private Sub ToolBar1_Load(sender As Object, e As EventArgs) Handles ToolBar1.Load

    End Sub
End Class