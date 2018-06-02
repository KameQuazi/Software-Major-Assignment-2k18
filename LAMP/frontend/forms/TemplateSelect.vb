Imports System.Collections.ObjectModel
Imports System.Collections.Specialized

Public Class TemplateSelect
    Public ReadOnly Property Templates As ObservableCollection(Of LampTemplate)
    ' templates will be laid out in a 2x4 grid
    ' 1 3 5 7
    ' 2 4 6 8

    Private _columnOffset As Integer
    Public Property ColumnOffset As Integer
        Get
            Return _columnOffset
        End Get
        Set(value As Integer)
            _columnOffset = value
            RefreshTemplates
        End Set
    End Property

    Public ReadOnly Property Rows As Integer = 2
    Public ReadOnly Property Columns As Integer = 4

    Private Sub MultiTemplateViewer1_Load(sender As Object, e As EventArgs) Handles MultiTemplateViewer1.Load

    End Sub

    Private Sub TemplateSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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
End Class