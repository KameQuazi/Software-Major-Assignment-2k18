Imports System.Runtime.CompilerServices
Imports LampCommon

Public Class ValidateHelper
    Public Shared Function ValidJob(job As LampJob) As Boolean
        If job Is Nothing Then
            Return False
        End If
        If job.JobId Is Nothing Then
            Return False
        End If
        If job.SubmitId Is Nothing Then
            Return False
        End If
        If job.Summary Is Nothing Then
            Return False
        End If
        If job.InsertionPages Is Nothing Then
            Return False
        End If
        If job.Parameters Is Nothing Then
            Return False
        End If
        If Not ValidTemplate(job.Template) Then
            Return False
        End If

        Return True

    End Function

    Public Shared Function ValidTemplate(template As LampTemplate)
        If template Is Nothing Then
            Return False
        End If
        If template.DynamicTextList Is Nothing Then
            Return False
        End If
        If template.BaseDrawing Is Nothing Then
            Return False
        End If
        If template.ShortDescription Is Nothing Then
            Return False
        End If
        If template.LongDescription Is Nothing Then
            Return False
        End If
        If template.GUID Is Nothing Then
            Return False
        End If
        If template.Name Is Nothing Then
            Return False
        End If
        If template.PreviewImages Is Nothing Then
            Return False
        End If
        If template.Tags Is Nothing Then
            Return False
        End If



        Return True
    End Function
End Class

Public Class PermsHelper
#Region "HasPermissions"
    Public Shared Function HasGetUserList(user As LampUser)
        Return user IsNot Nothing AndAlso user.PermissionLevel >= UserPermission.Admin
    End Function

    Public Shared Function HasGetTemplateListPerms(user As LampUser, approveStatus As LampApprove, byUser As IEnumerable(Of String)) As Boolean
        ' allow anyone to access approved
        If approveStatus = LampApprove.Approved And user.PermissionLevel >= UserPermission.Standard Then
            Return True
        End If

        '  deny if standard user tries to get unapproved templates from other users
        If user.PermissionLevel < UserPermission.Elevated Then
            If byUser.Count() = 0 Then
                Return False
            End If
            Dim notUser As Boolean = False
            For Each item In byUser
                If item <> user.UserId Then
                    notUser = True
                    Exit For
                End If
            Next
            If notUser Then
                Return False
            End If
        End If
        Return user.PermissionLevel >= UserPermission.Standard
    End Function

    Public Shared Function HasGetTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If template.Approved = True Then
            ' anyone can access approved templates
            Return True
        End If

        If user.UserId = template.CreatorId Then
            Return True
            ' same user can access template
        End If

        If user.PermissionLevel >= UserPermission.Elevated Then
            ' greater than normal can access all templates
            Return True
        End If

        Return False
    End Function


    Public Shared Function HasAddTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function

    Public Shared Function HasEditTemplatePerms(user As LampUser, original As LampTemplate, altered As LampTemplate) As Boolean
        If original IsNot Nothing AndAlso user.UserId = original.CreatorId Then
            Return True
        End If
        If user.PermissionLevel >= UserPermission.Elevated Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function HasRemoveTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.PermissionLevel >= UserPermission.Elevated Then
            Return True
        End If
        If template IsNot Nothing AndAlso template.CreatorId = user.UserId Then
            Return True
        End If
        Return False
    End Function




    Public Shared Function HasGetUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.PermissionLevel >= UserPermission.Elevated Or user.UserId = template.CreatorId
    End Function

    Public Shared Function HasAddUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.PermissionLevel >= UserPermission.Standard Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function HasEditUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        If user.PermissionLevel >= UserPermission.Elevated OrElse user.UserId = template.CreatorId Then
            Return True
        End If
        Return False
    End Function

    Public Shared Function HasRemoveUnapprovedTemplatePerms(user As LampUser, template As LampTemplate) As Boolean
        Return user.UserId = template.CreatorId Or user.PermissionLevel >= UserPermission.Elevated
    End Function





    Public Shared Function HasGetUserPerms(thisUser As LampUser, otherUser As LampUser)
        Return thisUser.PermissionLevel >= UserPermission.Admin
    End Function

    Public Shared Function HasAddUserPerms(thisUser As LampUser, otherUser As LampUser)
        ' allow standard users to be signed up
        If otherUser.PermissionLevel = UserPermission.Standard Then
            Return True
        End If
        Return thisUser IsNot Nothing AndAlso thisUser.PermissionLevel >= UserPermission.Admin
    End Function

    Public Shared Function HasEditUserPerms(user As LampUser, oldUser As LampUser, newUser As LampUser) As Boolean

        If user.PermissionLevel >= UserPermission.Admin Then
            Return True
        End If
        If oldUser Is Nothing Then
            Return False
        End If
        Return oldUser.UserId = user.UserId
    End Function

    Public Shared Function HasRemoveUserPerms(user As LampUser, otherUser As LampUser)
        Return user.PermissionLevel >= UserPermission.Admin
    End Function





    Public Shared Function HasGetJobPerms(user As LampUser, job As LampJob)
        Return user.PermissionLevel >= UserPermission.Admin OrElse job.SubmitId = user.UserId
    End Function

    Public Shared Function HasAddJobPerms(user As LampUser, job As LampJob) As Boolean
        If user.PermissionLevel = UserPermission.Elevated Then
            ' only can submit for itself
            ' they also cant approve
            Return job.SubmitId = user.UserId AndAlso job.Approved = False
        ElseIf user.PermissionLevel >= UserPermission.Admin Then
            ' can submit for everyone
            Return True
        Else
            Return False

        End If
    End Function

    Public Shared Function HasEditJobPerms(thisUser As LampUser, job As LampJob)
        Return thisUser.PermissionLevel >= UserPermission.Admin OrElse thisUser.UserId = job.SubmitId
    End Function

    Public Shared Function HasRemoveJobPerms(user As LampUser, job As LampJob)
        Return user.PermissionLevel >= UserPermission.Admin OrElse job.SubmitId = user.UserId
    End Function





    Public Shared Function HasApproveTemplatePerms(user As LampUser, template As LampTemplate)
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function


    Public Shared Function HasRevokeTemplatePerms(user As LampUser, template As LampTemplate)
        Return user.PermissionLevel >= UserPermission.Elevated
    End Function



    Public Shared Function HasGetJobListPerms(user As LampUser, byUser As IEnumerable(Of String))
        If user.PermissionLevel >= UserPermission.Admin Then
            Return True
        End If
        ' only allow elevated to view own jobs
        If user.PermissionLevel >= UserPermission.Elevated Then
            For Each item In byUser
                If item <> user.UserId Then
                    Return False
                End If
            Next
            Return True
        End If
        Return False

    End Function




    Public Shared Function HasApproveJobPerms(user As LampUser, job As LampJob)
        Return user IsNot Nothing AndAlso user.PermissionLevel >= UserPermission.Admin
    End Function

    Public Shared Function HasRevokeJobPerms(user As LampUser, job As LampJob)
        Return user IsNot Nothing AndAlso user.PermissionLevel >= UserPermission.Admin
    End Function











#End Region
End Class
