
Imports System.Collections.ObjectModel
Imports System.Collections.Specialized
Imports LampCommon

Public Class ServiceSortableTemplateViewer
    Public Event TemplateClick(sender As Object, e As TemplateClickedEventArgs)

    Private Sub ServiceTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs) Handles ServiceTemplateViewer1.TemplateClick
        RaiseEvent TemplateClick(Me, e)
        ' just bubble the event
    End Sub

    Private _justMyTemplates As Boolean
    ''' <summary>
    ''' true = just mine, false = all publically available
    ''' </summary>
    ''' <returns></returns>
    Public Property JustMyTemplates As Boolean
        Get
            Return _justMyTemplates
        End Get
        Set(value As Boolean)
            _justMyTemplates = value
            ServiceTemplateViewer1.JustMyTemplates = value
        End Set
    End Property


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



    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Templates = New ObservableCollection(Of LampTemplate)

    End Sub



    Private finishedLoading As Boolean = False

    Private Sub ServiceTemplateViewer1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.SelectedIndex = 0
        ' finished load
        finishedLoading = True
        LoadSettings()
    End Sub






    Public Sub ToggleSidebar() 
        SidebarHidden = Not SidebarHidden
    End Sub

    Private Sub btnHideShowSort_Click(sender As Object, e As EventArgs) Handles btnHideShowSort.Click
        ToggleSidebar()
        WriteSettings()
    End Sub

    Private Sub TemplateSelectForm_SizeChanged(sender As Object, e As EventArgs) Handles MyBase.SizeChanged
        Me.SplitContainer1.SplitterDistance = Me.Width / 5 * 4
    End Sub

    Private _sortOrder As LampSort
    Public Property SortOrder As LampSort
        Get
            Return _sortOrder
        End Get
        Set(value As LampSort)
            Select Case value
                Case LampSort.SubmitDateAsc
                    rdbtnAsc.Checked = True
                    ComboBox1.SelectedItem = "Submit Date"
                Case LampSort.SubmitDateDesc
                    rdbtnDesc.Checked = True
                    ComboBox1.SelectedItem = "Submit Date"
                Case LampSort.TemplateNameAsc
                    rdbtnAsc.Checked = True
                    ComboBox1.SelectedItem = "Name"
                Case LampSort.TemplateNameDesc
                    rdbtnDesc.Checked = True
                    ComboBox1.SelectedItem = "Name"
            End Select
            _sortOrder = value

        End Set
    End Property

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
        WriteSettings()
    End Sub

    Public Sub WriteSettings()
        If finishedLoading Then
            My.Settings.SortSettings = New SortSettings(SidebarHidden, ServiceTemplateViewer1.SortOrder)
        End If
    End Sub


    Private Sub LoadSettings()
        If My.Settings.SortSettings IsNot Nothing Then
            Me.SidebarHidden = My.Settings.SortSettings.SortHidden
            Me.SortOrder = My.Settings.SortSettings.SortType
        End If
    End Sub

    Private Sub btnUserFilter_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles rdbtnPublic.CheckedChanged, rdbtnMe.CheckedChanged
        If rdbtnPublic.Checked Then
            JustMyTemplates = False
        Else
            JustMyTemplates = True
        End If
    End Sub


End Class

