Public Class PasswordRichTextBox
    Inherits RichTextBox
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim cp = MyBase.CreateParams
            cp.Style = cp.Style Or &H20 ' enable ES_PASSWORD
            ' taken from here
            ' https://stackoverflow.com/questions/4451592/password-char-for-richtextbox
            Return cp
        End Get
    End Property
End Class
