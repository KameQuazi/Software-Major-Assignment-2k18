Imports System.ComponentModel
Imports LampCommon

Public Class NewOrderFormChooseParameter

    Private _selectedTemplate As LampTemplate
    Public Property SelectedTemplate As LampTemplate
        Get
            Return _selectedTemplate
        End Get
        Set(value As LampTemplate)
            _selectedTemplate = value
            UpdateContents()
        End Set
    End Property

    Private Sub UpdateContents()
        TemplateDisplay1.Template = SelectedTemplate
    End Sub


    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs)
        Select Case e.KeyCode

        End Select
    End Sub

    Private dataSource As New MultipleTemplateDynamicTextDictionary

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        dataSource.Add(New DynamicTextDictionary() From {
            {New DynamicTextKey("hello", "this is", New netDxf.Vector3(0, 0, 0), 10, 20), New DynamicTextValue("none")}
                       })
        DataGridView1.DataSource = dataSource
    End Sub



    Private Sub DxfViewerControl1_Click(sender As Object, e As EventArgs)
        Using dialog As New TemplateSelectBox ' 
            If dialog.ShowDialog() = DialogResult.OK Then
                SelectedTemplate = dialog.SelectedTemplate
            End If
        End Using
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim job = New LampJob(Me.SelectedTemplate, CurrentUser.ToProfile, "hello summary")
        job.Pages = 3

        For i = 0 To 2
            job.AddInsertionPoint(New LampSingleDxfInsertLocation(New netDxf.Vector3(0, 0, 0)), i, True)

        Next


        Dim response = CurrentSender.AddJob(CurrentUser.ToCredentials, job)
        Select Case response
            Case LampStatus.OK
                MessageBox.Show("Successfully added job")
                ShowNewForm(Nothing, Me, HomeForm)
            Case Else
                ShowError(response)
        End Select
    End Sub

    Private Sub ServiceSortableTemplateViewer1_TemplateClick(sender As Object, e As TemplateClickedEventArgs)
        Console.WriteLine("owo")
    End Sub


End Class

Public Class MultipleTemplateDynamicTextDictionary
    Inherits List(Of DynamicTextDictionary)

    Public Function CommonKeys() As DynamicTextKey()
        Return If(Me.Count > 0, Me(0).Keys.ToArray, Nothing)
    End Function
End Class

'' original typed list taken from here, converted to dictionaries
'' https://stackoverflow.com/questions/4716092/winforms-datagridview-databind-to-an-object-with-a-list-property-variable-num


'Public Class MultipleTemplateDynamicTextDictionary
'    Inherits List(Of DynamicTextDictionary)
'    Implements ITypedList

'    Public Function GetItemProperties(ByVal listAccessors As PropertyDescriptor()) As PropertyDescriptorCollection Implements ITypedList.GetItemProperties
'        Dim newProps As List(Of PropertyDescriptor) = New List(Of PropertyDescriptor)

'        For Each Item As DynamicTextDictionary In Me
'            For Each key As DynamicTextKey In Item.Keys
'                newProps.Add(New ListItemDescriptor(key))
'            Next
'        Next
'        Return New PropertyDescriptorCollection(newProps.ToArray())
'    End Function

'    Public Function GetListName(ByVal listAccessors As PropertyDescriptor()) As String Implements ITypedList.GetListName
'        Return ""
'    End Function

'End Class

'Class ListItemDescriptor
'    Inherits PropertyDescriptor

'    Private Shared ReadOnly nix As Attribute() = New Attribute(-1) {}
'    Private ReadOnly type As Type = GetType(DynamicTextKey)
'    Private ReadOnly key As DynamicTextKey


'    Public Sub New(ByVal key As DynamicTextKey)
'        MyBase.New(key.ParameterName, nix)
'        Me.key = key
'    End Sub

'    Public Overrides Function GetValue(ByVal component As Object) As Object
'        Return key
'    End Function

'    Public Overrides ReadOnly Property PropertyType As Type
'        Get
'            Return type
'        End Get
'    End Property

'    Public Overrides ReadOnly Property IsReadOnly As Boolean
'        Get
'            Return True
'        End Get
'    End Property

'    Public Overrides ReadOnly Property ComponentType As Type
'        Get
'            Throw New NotImplementedException()
'        End Get
'    End Property

'    Public Overrides Sub SetValue(ByVal component As Object, ByVal value As Object)
'        Throw New NotSupportedException()
'    End Sub

'    Public Overrides Sub ResetValue(ByVal component As Object)
'        Throw New NotSupportedException()
'    End Sub

'    Public Overrides Function CanResetValue(ByVal component As Object) As Boolean
'        Return False
'    End Function


'    Public Overrides Function ShouldSerializeValue(ByVal component As Object) As Boolean
'        Return False
'    End Function
'End Class
