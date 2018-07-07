Public Class LampInputBox
    Private Sub LampInputBox_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    ''' <summary>
    ''' The text that is inputted by the user
    ''' </summary>
    ''' <returns></returns>
    Public Property InputText As String
        Get
            Return RichTextBox1.Text
        End Get
        Set(value As String)
            RichTextBox1.Text = value
        End Set
    End Property

    ''' <summary>
    ''' The text displayed in the label prompting the user
    ''' </summary>
    ''' <returns></returns>
    Public Property LabelText As String
        Get
            Return Label1.Text
        End Get
        Set(value As String)
            Label1.Text = value
        End Set
    End Property

    Public Sub New(title As String, labelText As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.Text = title
        Me.LabelText = labelText
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles CancelExitButon.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub RichTextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles RichTextBox1.KeyDown
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class