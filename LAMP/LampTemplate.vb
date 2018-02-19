Imports System.Reflection

Public Class LampTemplate
    ''' <summary>
    ''' The completed drawing, w/ all the templates laid out appropriately
    ''' </summary>
    Private _completedDrawing As LampDxfDocument
    Public Property IsComplete As Boolean


    ''' <summary>
    ''' The actual template : contains just 1 of drawing
    ''' </summary>
    Private _template As LampDxfDocument

    Public Property DynamicTextList As New List(Of DynamicText)

    Public ReadOnly Property HasDynamicText As Boolean
        Get
            Return DynamicTextList.Count() = 0
        End Get
    End Property

    Public Property PreviewImages As New List(Of Image)

    Public Property CreatorName As String
    Public Property CreatorId As Integer

    Public Property ApproverName As String
    Public Property ApproverId As Integer

End Class














Public Class OwO
    Sub Main()
        InitalizeLibraries()
        Application.EnableVisualStyles()
        Application.SetCompatibleTextRenderingDefault(False)
        Application.Run(New Form1())
    End Sub

    Sub InitalizeLibraries()
        ' extract necessary dll files
        ' put folder in DLL path
    End Sub




End Class