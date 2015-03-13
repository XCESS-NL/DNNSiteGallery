'
' Copyright (c) 2014
' by Siliqon Inc.
' http://www.siliqon.com
'
Imports System
Imports DotNetNuke
Imports DotNetNuke.Entities.Modules
Imports DotNetNuke.Services.Exceptions
Imports DotNetNuke.Services.FileSystem

Namespace Siliqon.SiteGallery

    Partial Public Class Settings

        Inherits ModuleSettingsBase

        Public Overrides Sub LoadSettings()
            Try
                If Not Page.IsPostBack Then
                    For Each objFolder As FolderInfo In FolderManager.Instance.GetFolders(PortalId)
                        cboFolder.Items.Add(New ListItem("/" & objFolder.FolderPath))
                    Next

                    If DirectCast(TabModuleSettings("rows"), String) <> "" Then
                        txtRows.Text = DirectCast(TabModuleSettings("rows"), String)
                    Else
                        txtRows.Text = "10"
                    End If
                    If DirectCast(TabModuleSettings("columns"), String) <> "" Then
                        txtColumns.Text = DirectCast(TabModuleSettings("columns"), String)
                    Else
                        txtColumns.Text = "1"
                    End If
                    If DirectCast(TabModuleSettings("template"), String) <> "" Then
                        txtTemplate.Text = DirectCast(TabModuleSettings("template"), String)
                    Else
                        txtTemplate.Text = "<a href=""[URL]"" title=""[TITLE]"" target=""_new""><img src=""[THUMBNAIL]"" alt=""[TITLE]"" width=""341"" height=""256""></a>"
                    End If

                    If DirectCast(ModuleSettings("url"), String) <> "" Then
                        txtURL.Text = DirectCast(ModuleSettings("url"), String)
                    Else 
                        txtURL.Text = "<Use Internal Thumbnail Generator>"
                    End If
                    If DirectCast(ModuleSettings("width"), String) <> "" Then
                        txtWidth.Text = DirectCast(ModuleSettings("width"), String)
                    Else
                        txtWidth.Text = "1024"
                    End If
                    If DirectCast(ModuleSettings("height"), String) <> "" Then
                        txtHeight.Text = DirectCast(ModuleSettings("height"), String)
                    Else
                        txtHeight.Text = "768"
                    End If
                    If Not cboFolder.Items.FindByValue("/" & ModuleSettings("folder")) Is Nothing Then
                        cboFolder.Items.FindByValue("/" & ModuleSettings("folder")).Selected = True
                    End If
                    If DirectCast(ModuleSettings("refresh"), String) <> "" Then
                        txtRefresh.Text = DirectCast(ModuleSettings("refresh"), String)
                    Else
                        txtRefresh.Text = "7"
                    End If
                    If ModuleSettings("history") <> "" Then
                        chkHistory.Checked = Convert.ToBoolean(ModuleSettings("history"))
                    Else
                        chkHistory.Checked = False
                    End If
                    txtValidation.Text = DirectCast(ModuleSettings("validation"), String)
                    txtInstructions.Text = DirectCast(ModuleSettings("instructions"), String)
                End If
            Catch exc As Exception
                ' Module failed to load
                Exceptions.ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

        Public Overrides Sub UpdateSettings()
            Try
                ModuleController.Instance.UpdateTabModuleSetting(TabModuleId, "rows", txtRows.Text)
                ModuleController.Instance.UpdateTabModuleSetting(TabModuleId, "columns", txtColumns.Text)
                ModuleController.Instance.UpdateTabModuleSetting(TabModuleId, "template", txtTemplate.Text)

                If txtURL.Text <> "<Use Internal Thumbnail Generator>" Then
                    ModuleController.Instance.UpdateModuleSetting(ModuleId, "url", Common.Globals.AddHTTP(txtURL.Text))
                Else
                    ModuleController.Instance.UpdateModuleSetting(ModuleId, "url", "")
                End If
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "width", txtWidth.Text)
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "height", txtHeight.Text)
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "folder", cboFolder.SelectedValue.SubString(1))
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "refresh", txtRefresh.Text)
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "history", chkHistory.Checked.ToString())
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "validation", txtValidation.Text)
                ModuleController.Instance.UpdateModuleSetting(ModuleId, "instructions", txtInstructions.Text)
            Catch exc As Exception
                ' Module failed to load
                Exceptions.ProcessModuleLoadException(Me, exc)
            End Try
        End Sub

    End Class

End Namespace

