Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports LampCommon
Imports Microsoft.VisualStudio.TestTools.UnitTesting.Assert


<TestClass()>
Public Class TestWcfLocalService

    Public Service As LampClient.LampLocalWcfClient = LampClient.LampLocalWcfClient.Local

    ' filled in in Setup()
    Public Admin As LampUser

    Public Elevated1 As LampUser
    Public Elevated2 As LampUser

    Public Standard1 As LampUser
    Public Standard2 As LampUser

    Public ApprovedTemplate As LampTemplate

    ''' <summary>
    ''' Submitted by standard 1
    ''' </summary>
    Public UnApprovedTemplate1 As LampTemplate

    <TestInitialize>
    Public Sub Setup()
        Service.Channel.DeleteDebug()
        Using conn = Service.Channel.Database.Connection.OpenConnection, trans = Service.Channel.Database.Transaction.LockTransaction()
            Admin = New LampUser("059fa948-fba2-4dd1-837e-6846226f6edf", UserPermission.Admin, "admin@test.com", "admin", "12345", "Admin Admin Admin")
            Service.Channel.Database.SetUser(Admin, trans)

            Elevated1 = New LampUser("ffa68d62-ba6d-49aa-aefc-1896240dc4c3", UserPermission.Elevated, "elevated1@test.com", "elevated1", "12345", "Teacher Elevcated not admin")
            Service.Channel.Database.SetUser(Elevated1, trans)

            Elevated2 = New LampUser("dda68d62-ba6d-49aa-aefc-1896240dc4c3", UserPermission.Elevated, "elevated2@test.com", "elevated2", "12345", "2  Elevcated not admin")
            Service.Channel.Database.SetUser(Elevated2, trans)

            Standard1 = New LampUser("ed44e4e8-cf13-40d7-b110-89f7e5118204", UserPermission.Standard, "standard1@test.com", "standard1", "12345", "1 1 1")
            Service.Channel.Database.SetUser(Standard1, trans)

            Standard2 = New LampUser("12345678-cf13-40d7-b110-89f7e5118204", UserPermission.Standard, "standard2@test.com", "standard2", "12345", "2 2 2")
            Service.Channel.Database.SetUser(Standard2, trans)

            ApprovedTemplate = LampTemplate.FromFile("../../../templates/spf/1.spf")
            Service.Channel.Database.SetTemplate(ApprovedTemplate, Standard1.UserId, Admin.UserId, optTrans:=trans)

            UnApprovedTemplate1 = LampTemplate.FromFile("../../../templates/spf/2.spf")
            Service.Channel.Database.SetTemplate(UnApprovedTemplate1, Standard1.UserId, optTrans:=trans)



            trans.Commit()
        End Using
    End Sub


    <TestMethod()>
    Public Sub TestGetTemplate()
        Dim response = Service.GetTemplate(Standard1.ToCredentials, ApprovedTemplate.GUID)
        Assert.IsTrue(response.Status = LampStatus.OK)
        Assert.IsTrue(response.Template IsNot Nothing)

        response = Service.GetTemplate(Standard2.ToCredentials, ApprovedTemplate.GUID)
        Assert.IsTrue(response.Status = LampStatus.OK)
        Assert.IsTrue(response.Template IsNot Nothing)

        response = Service.GetTemplate(Standard1.ToCredentials, UnApprovedTemplate1.GUID)
        Assert.IsTrue(response.Status = LampStatus.OK)
        Assert.IsTrue(response.Template IsNot Nothing)

        response = Service.GetTemplate(Standard2.ToCredentials, UnApprovedTemplate1.GUID)
        Assert.IsTrue(response.Status = LampStatus.NoAccess)
        Assert.IsTrue(response.Template Is Nothing)
    End Sub

End Class