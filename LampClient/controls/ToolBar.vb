Public Class ToolBar
    Public Property NewOrderEnabled As Boolean
        Get
            Return btnNewOrder.Enabled
        End Get
        Set(value As Boolean)
            btnNewOrder.Enabled = value
        End Set
    End Property

    Public Property HomeEnabled As Boolean
        Get
            Return btnHome.Enabled
        End Get
        Set(value As Boolean)
            btnHome.Enabled = value
        End Set
    End Property

    Public Property MyTrophyEnabled As Boolean
        Get
            Return btnDesigns.Enabled
        End Get
        Set(value As Boolean)
            btnDesigns.Enabled = value
        End Set
    End Property


    Public Property MyOrdersEnabled As Boolean
        Get
            Return btnOrders.Enabled
        End Get
        Set(value As Boolean)
            btnOrders.Enabled = value
        End Set
    End Property

    Public Sub SetUsername(username As String)
        Me.Username.Text = String.Format("hewwo {0}?", username)
    End Sub


    ''' <summary>
    ''' Closes the first form that is a parent of control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnQY_Click(sender As Object, e As EventArgs)
        Dim currentParent As Control = Me.Parent
        Dim closed As Boolean = False

        While currentParent IsNot Nothing
            If currentParent.GetType().IsSubclassOf(GetType(Form)) Then
                Dim parent As Form = DirectCast(currentParent, Form)
                parent.Close()
                closed = True
                Exit While
            End If

            currentParent = currentParent.Parent
        End While

#If DEBUG Then
        If Not closed Then
            Throw New Exception("Control must be on top level (must not be in a panel etc)")
        End If
#End If

    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        If LogoutBox.ShowDialog() = DialogResult.OK Then
            PreviousForms.Clear()
            LoginForm.Show()

            ParentForm.Close()
        End If
    End Sub


    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        AddPreviousForm(ParentForm)
        HomeForm.Show()

        ParentForm.Close()
    End Sub

    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        AddPreviousForm(ParentForm)
        NewOrderForm.Show()

        ParentForm.Close()
    End Sub

    Private Sub btnDesigns_Click(sender As Object, e As EventArgs) Handles btnDesigns.Click
        AddPreviousForm(ParentForm)
        MyTemplatesForm.Show()

        ParentForm.Close()
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        AddPreviousForm(ParentForm)
        MyOrdersForm.Show()

        ParentForm.Close()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        HelpForm.ShowDialog()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox.ShowDialog()
    End Sub

    Private Shared PreviousForms As New List(Of LampForm)

    ''' <summary>
    ''' Checks if previousform is set to disable/enable it
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub ToolBar_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If PreviousForms.Count() = 0 Then
            btnBack.Enabled = False
        Else
            btnBack.Enabled = True
        End If
        SetUsername(CurrentUser.Username)
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If PreviousForms.Count = 0 Then
            btnBack.Enabled = False
            MessageBox.Show("ProgramException: PreviousForm not found")
            ' note: this shouldnt be possilbe unless you twiddle w/ the values of PreviousForm urself
            Return
        End If

        Dim last = PreviousForms(PreviousForms.Count - 1)
        PreviousForms.RemoveAt(PreviousForms.Count - 1)
        Select Case last
            Case LampForm.HomeForm
                HomeForm.Show()
            Case LampForm.MyOrdersForm
                MyOrdersForm.Show()
            Case LampForm.MyTemplatesForm
                MyTemplatesForm.Show()
            Case LampForm.NewOrderForm
                NewOrderForm.Show()
            Case LampForm.TemplateSelectForm
                TemplateSelectForm.Show()
        End Select

        ParentForm.Close()
    End Sub

    Private Sub AddPreviousForm(form As Form)
        Select Case form.GetType()
            Case GetType(HomeForm)
                PreviousForms.Add(LampForm.HomeForm)
            Case GetType(MyOrdersForm)
                PreviousForms.Add(LampForm.MyOrdersForm)
            Case GetType(MyTemplatesForm)
                PreviousForms.Add(LampForm.MyTemplatesForm)
            Case GetType(NewOrderForm)
                PreviousForms.Add(LampForm.NewOrderForm)
            Case GetType(TemplateSelectForm)
                PreviousForms.Add(LampForm.TemplateSelectForm)
        End Select
    End Sub

    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If CloseBox.ShowDialog() = DialogResult.OK Then
            End
        End If
    End Sub


End Class


Public Enum LampForm
    HomeForm
    MyOrdersForm
    MyTemplatesForm
    NewOrderForm
    TemplateSelectForm

End Enum