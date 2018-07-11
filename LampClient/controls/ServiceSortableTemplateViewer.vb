
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports LampCommon

Public Class ServiceSortableTemplateViewer
    Public Event TemplateClick(sender As Object, e As TemplateClickedEventArgs)

    Private Sub ServiceTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceTemplateViewer1.TemplateClick
        RaiseEvent TemplateClick(Me, e)
        ' just bubble the event
    End Sub


    Public Property TitleText As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public ReadOnly Property Templates As ObservableCollection(Of LampTemplate)

    Private tags As List(Of String) ' lower case

    Private _sortHidden As Boolean

    Public Property SidebarHidden As Boolean
        Get
            Return _sortHidden
        End Get
        Set(value As Boolean)
            _sortHidden = value
            If value = True Then
                HideSidebar()
            Else
                UnhideSidebar()
            End If
        End Set
    End Property

    Private Sub HideSidebar()
        btnHideShowSort.Text = "<<"
        SplitContainer1.Panel2Collapsed = True
    End Sub

    Private Sub UnhideSidebar()
        btnHideShowSort.Text = ">>"
        SplitContainer1.Panel2Collapsed = False
    End Sub


    Private Sub MultiTemplateViewer1_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub TemplateSelect_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'CurrentSender.RequestTemplates(CurrentUser, tags)
        LoadHiddenFromSettings()
        ComboBox1.SelectedIndex = 0
    End Sub

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Templates = New ObservableCollection(Of LampTemplate)

    End Sub




    Private Sub ServiceTemplateViewer1_Load(sender As Object, e As EventArgs)
        ComboBox1.SelectedIndex = 0
    End Sub



    Private Sub LoadHiddenFromSettings()
        Me.SidebarHidden = My.Settings.SortSidebarHidden
    End Sub



    Public Sub ToggleSidebar() 
        SidebarHidden = Not SidebarHidden
    End Sub

    Private Sub btnHideShowSort_Click(sender As Object, e As EventArgs) Handles btnHideShowSort.Click
        ToggleSidebar()
        My.Settings.SortSidebarHidden = SidebarHidden
    End Sub

    Private Sub TemplateSelectForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.SplitContainer1.SplitterDistance = Me.Width / 5 * 4
    End Sub

    Private Sub radioButtonClicked(sender As Object, e As EventArgs) Handles rdbtnAsc.CheckedChanged, rdbtnDesc.CheckedChanged, ComboBox1.SelectedIndexChanged
        Select Case ComboBox1.SelectedItem
            Case "Submit Date"
                If rdbtnAsc.Checked Then
                    ServiceTemplateViewer1.SortOrder = LampSort.SubmitDateAsc
                Else
                    ServiceTemplateViewer1.SortOrder = LampSort.SubmitDateDesc
                End If
            Case "Name"
                If rdbtnAsc.Checked Then
                    ServiceTemplateViewer1.SortOrder = LampSort.TemplateNameAsc
                Else
                    ServiceTemplateViewer1.SortOrder = LampSort.TemplateNameDesc
                End If
        End Select

    End Sub


End Class

