Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports LampClient
Imports LampCommon

Public Module ToolbarUtilities
    Public ReadOnly Property PreviousForms As New List(Of LampForm)

    <Extension>
    Public Sub AddPreviousForm(this As IToolbar, form As Form)
        Select Case form.GetType()
            Case GetType(HomeForm)
                PreviousForms.Add(LampForm.HomeForm)
            Case GetType(ViewOrdersForm)
                PreviousForms.Add(LampForm.ViewOrdersForm)
            Case GetType(ViewTemplatesForm)
                PreviousForms.Add(LampForm.ViewTemplatesForm)
            Case GetType(NewOrderForm)
                PreviousForms.Add(LampForm.NewOrderForm)

            Case GetType(AdminForm)
                PreviousForms.Add(LampForm.AdminForm)
            Case GetType(NewTemplateForm)
                PreviousForms.Add(LampForm.NewTemplateForm)
            Case GetType(ViewEditJobsForm)
                PreviousForms.Add(LampForm.ViewEditJobsForm)
            Case GetType(ViewEditTemplateForm)
                PreviousForms.Add(LampForm.ViewEditTemplateForm)
            Case GetType(ApproveTemplateForm)
                PreviousForms.Add(LampForm.ApproveTemplateForm)
            Case GetType(ManageUsersForm)
                PreviousForms.Add(LampForm.ManageUsersForm)




#If DEBUG Then
            Case Else
                Throw New ArgumentOutOfRangeException(form.GetType().ToString)
#End If
        End Select
    End Sub

    ''' <summary>
    ''' Pops and shows the last saved form
    ''' assumes that at least 1 saved form exists
    ''' </summary>
    ''' <param name="this"></param>
    <Extension>
    Private Sub PopPreviousForm(this As IToolbar)
        Dim last = PreviousForms(PreviousForms.Count - 1)
        PreviousForms.RemoveAt(PreviousForms.Count - 1)
        Select Case last
            Case LampForm.HomeForm
                HomeForm.Show()
            Case LampForm.ViewOrdersForm
                ViewOrdersForm.Show()
            Case LampForm.ViewTemplatesForm
                ViewTemplatesForm.Show()
            Case LampForm.NewOrderForm
                NewOrderForm.Show()

            Case LampForm.AdminForm
                AdminForm.Show()
            Case LampForm.NewTemplateForm
                NewTemplateForm.Show()
            Case LampForm.ViewEditJobsForm
                ViewEditJobsForm.Show()
            Case LampForm.ViewEditTemplateForm
                ViewEditTemplateForm.Show()
            Case LampForm.ApproveTemplateForm
                ApproveTemplateForm.Show()


#If DEBUG Then
            Case Else
                Throw New ArgumentOutOfRangeException(last.GetType.ToString())
#End If
        End Select
    End Sub

    ''' <summary>
    ''' Adds the previous form storage and opens the new form, then closes the previous form
    ''' </summary>
    ''' <param name="this"></param>
    ''' <param name="previousForm"></param>
    ''' <param name="newForm"></param>
    <Extension>
    Public Sub ShowNewForm(this As IToolbar, previousForm As Form, newForm As Form)
        this.AddPreviousForm(previousForm)
        newForm.Show()
        previousForm.Close()
    End Sub

    ''' <summary>
    ''' Closes the current form, then opens last closed form
    ''' </summary>
    ''' <param name="this"></param>
    ''' <param name="currentForm"></param>
    <Extension>
    Public Sub ShowPreviousForm(this As IToolbar, currentForm As Form)
        If Not this.HasSavedForms() Then
            Throw New InvalidOperationException("No previous forms")
        End If
        this.PopPreviousForm()
        currentForm.Close()
    End Sub

    <Extension>
    Public Function HasSavedForms(this As IToolbar) As Boolean
        Return PreviousForms.Count > 0
    End Function

    <Extension>
    Public Function Logout(this As IToolbar, parentForm As Form) As Boolean
        If LogoutBox.ShowDialog() = DialogResult.OK Then
            PreviousForms.Clear()
            LoginForm.Show()

            parentForm.Close()
            Return True
        End If
        Return False
    End Function
End Module

Public Interface IToolbar
    Sub SetUsername(username As String)

End Interface

Public Class ToolBar
    Implements IToolbar

#Region "DesignerProperties"
    <Category("DisableButtons")>
    Public Property HomeEnabled As Boolean
        Get
            Return btnHome.Enabled
        End Get
        Set(value As Boolean)
            btnHome.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property ViewTemplateEnabled As Boolean
        Get
            Return btnDesigns.Enabled
        End Get
        Set(value As Boolean)
            btnDesigns.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property NewTemplateEnabled As Boolean
        Get
            Return btnNewTemplate.Enabled
        End Get
        Set(value As Boolean)
            btnNewTemplate.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property ViewOrderEnabled As Boolean
        Get
            Return btnOrders.Enabled
        End Get
        Set(value As Boolean)
            btnOrders.Enabled = value
        End Set
    End Property

    <Category("DisableButtons")>
    Public Property NewOrderEnabled As Boolean
        Get
            Return btnNewOrder.Enabled
        End Get
        Set(value As Boolean)
            btnNewOrder.Enabled = value
        End Set
    End Property








#End Region

    Public Sub SetUsername(username As String) Implements IToolbar.SetUsername
        Me.Username.Text = String.Format("Welcome {0}", username)
    End Sub

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub


    ''' <summary>
    ''' Closes the first form that is a parent of control
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btnQY_Click(sender As Object, e As EventArgs)
        Me.ParentForm.Close()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Logout(ParentForm)
    End Sub


    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ShowNewForm(ParentForm, HomeForm)
    End Sub

    Private Sub btnNewOrder_Click(sender As Object, e As EventArgs) Handles btnNewOrder.Click
        ShowNewForm(ParentForm, NewOrderForm)
    End Sub

    Private Sub btnDesigns_Click(sender As Object, e As EventArgs) Handles btnDesigns.Click
        ShowNewForm(ParentForm, ViewTemplatesForm)
    End Sub

    Private Sub btnOrders_Click(sender As Object, e As EventArgs) Handles btnOrders.Click
        ShowNewForm(ParentForm, ViewOrdersForm)
    End Sub

    Private Sub btnNewTemplate_Click(sender As Object, e As EventArgs) Handles btnNewTemplate.Click
        ShowNewForm(ParentForm, NewTemplateForm)
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        HelpBox.ShowDialog()
    End Sub

    Private Sub btnAbout_Click(sender As Object, e As EventArgs) Handles btnAbout.Click
        AboutBox.ShowDialog()
    End Sub




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
        ' dont have permission to 
        If CurrentUser.PermissionLevel <= UserPermission.Standard Then
            ViewOrderEnabled = False
            NewOrderEnabled = False
        End If
		
		'tooltips
        ' this handles all buttons on the toolbar on all forms
        Tooltip1.SetToolTip(Me.btnHome, "go back to start screen")
        Tooltip1.SetToolTip(Me.btnDesigns, "view your designs")
        Tooltip1.SetToolTip(Me.btnAbout, "about this software")
        Tooltip1.SetToolTip(Me.btnBack, "go back to the previous page")
        Tooltip1.SetToolTip(Me.btnHelp, "open program help")
        Tooltip1.SetToolTip(Me.btnNewOrder, "order a trophy")
        Tooltip1.SetToolTip(Me.btnLogOut, "log out of your LAMP account")
        Tooltip1.SetToolTip(Me.btnOrders, "view your current orders")
        Tooltip1.SetToolTip(Me.btnQuit, "close the program")
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        If PreviousForms.Count = 0 Then
            btnBack.Enabled = False
            MessageBox.Show("ProgramException: PreviousForm not found")
            ' note: this shouldnt be possilbe unless you twiddle w/ the values of PreviousForm urself
            Return
        End If

        ShowPreviousForm(ParentForm)
    End Sub



    Private Sub btnQuit_Click(sender As Object, e As EventArgs) Handles btnQuit.Click
        If CloseBox.ShowDialog() = DialogResult.OK Then
            End
        End If
    End Sub


End Class


Public Enum LampForm
    HomeForm
    ViewOrdersForm
    ViewTemplatesForm
    NewOrderForm
    TemplateSelectForm
    AdminForm
    NewTemplateForm
    ViewEditJobsForm
    ViewEditTemplateForm
    ApproveTemplateForm
    ManageUsersForm
End Enum