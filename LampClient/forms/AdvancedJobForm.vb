Imports LampCommon

Public Class AdvancedJobForm
    Public Property Job As LampJob
        Get
            Return AdvancedJobViewer1.Job
        End Get
        Set(value As LampJob)
            AdvancedJobViewer1.Job = value
        End Set
    End Property

End Class