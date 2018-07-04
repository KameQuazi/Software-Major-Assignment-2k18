Public Class SingleDynamicText
    Private Sub SingleDynamicTExt_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private _inputType As InputType
    Public Property InputType As InputType
        Get
            Return _inputType
        End Get
        Set(value As InputType)
            _inputType = value
            RefreshInputControl()
        End Set
    End Property

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

    ''' <summary>
    ''' Gets the input control (textbox, etc)
    ''' </summary>
    ''' <returns></returns>
    Public Function GetInputControl() As Control
        Return InputControl
    End Function

    ''' <summary>
    ''' Gets the value of control
    ''' </summary>
    ''' <returns></returns>
    Public Function GetValue() As Object
        Select Case InputType
            Case InputType.RichTextBox
                Return DirectCast(InputControl, RichTextBox).Text

            Case InputType.CheckBox
                Return DirectCast(InputControl, CheckBox).Checked

            Case InputType.None
                Return Nothing

            Case Else
                Throw New NotImplementedException(NameOf(InputType))
        End Select
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

            Case InputType.CheckBox

                Dim newControl As New CheckBox()
                _inputControl = newControl
                Me.TablePanel.Controls.Add(InputControl)
            Case InputType.None
                ' do nothin

            Case Else
                Throw New NotImplementedException(NameOf(InputType))
        End Select
    End Sub
End Class


Public Enum InputType
    RichTextBox
    CheckBox
    ' PictureBox
    ' Combobox
    ' ListView
    None
End Enum