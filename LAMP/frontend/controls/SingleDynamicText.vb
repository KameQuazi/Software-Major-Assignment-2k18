Public Class SingleDynamicText
    Private Sub SingleDynamicTExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Public Property InputType As InputType = InputType.RichTextBox

    Private _inputControl As Control
    Public Property InputControl As Control
        Get
            Return _inputControl
        End Get
        Private Set(value As Control)
            _inputControl = value
            RefreshInputControl
        End Set
    End Property

    Public Function GetInputControl() As Control
        Return InputControl
    End Function

    Public Sub SetParameterText(text As String)
        ParameterName.Text = text
    End Sub

    Public Sub SetDescriptionText(text As String)
        DescriptionText.Text = text
    End Sub

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RefreshInputControl
    End Sub

    Private Sub RefreshInputControl()
        If InputControl IsNot Nothing Then
            Me.TablePanel.Controls.Remove(InputControl)
        End If

        Select Case InputType
            Case InputType.RichTextBox

                Dim newControl As New RichTextBox()
                _inputControl = newControl
                newControl.AutoSize = False
                newControl.Dock = DockStyle.Fill

                Me.TablePanel.Controls.Add(InputControl)
            Case Else
                Throw New Exception("InputType must be from enum InputType")
        End Select
    End Sub
End Class


Public Enum InputType
    RichTextBox
    CheckBox

End Enum