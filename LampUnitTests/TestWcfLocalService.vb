Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting

<TestClass()>
Public Class TestWcfLocalService

    Private Service As LampClient.LampLocalWcfClient = LampClient.LampLocalWcfClient.Local

    <TestInitialize>
    Public Sub Setup()
        Dim local = Service.Channel
        local.ResetDatabase()
    End Sub
    <TestMethod()>
    Public Sub TestMethod1()
    End Sub

End Class