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

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        RefreshInputControl
    End Sub

    Private Sub RefreshInputControl()
        Select Case InputType
            Case InputType.RichTextBox
                Me.TablePanel.Controls.Remove(InputControl)
                Dim newControl As New RichTextBox()
                InputControl = newControl
                newControl.AutoSize = False
                newControl.Dock = DockStyle.Fill

                Me.TablePanel.Controls.Add(InputControl)
        End Select
    End Sub
End Class


Public Enum InputType
    RichTextBox
    CheckBox

End Enum