'
' Copyright (c) 2014
' by Siliqon Inc.
' http://www.siliqon.com
'
Imports System.IO
Imports DotNetNuke

Namespace Siliqon.SiteGallery

    Public Partial Class Edit

        Inherits Entities.Modules.PortalModuleBase

        Private Sub LoadSites()
            cboSite.Items.Clear()
            cboSite.Items.Add(New ListItem("<Create New Site>", "-1"))
            Dim objSiteGallery As New SiteGalleryController
            Dim lstSites As List(Of SiteGalleryInfo) = objSiteGallery.GetGallerySitesByUser(ModuleId, UserId)
            For Each objSite As SiteGalleryInfo In lstSites
                cboSite.Items.Add(New ListItem(objSite.Title, objSite.SiteID.ToString()))
            Next 

            txtURL.Text = ""
            txtTitle.Text = ""
            txtDescription.Text = ""
            txtOwner.Text = ""
            txtOwnerURL.Text = ""
            chkActive.Checked = True
            imgThumbnail.ImageUrl = ""
            plThumbnail.Visible = False
            cboThumbnail.Visible = False
        End Sub

        #Region "Event Handlers"
    
        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Page.IsPostBack Then
                LoadSites()
            End If
        End Sub

        Protected Sub cboSite_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboSite.SelectedIndexChanged
            Dim objSiteGallery As New SiteGalleryController
            Dim objSite As SiteGalleryInfo = objSiteGallery.GetGallerySite(Integer.Parse(cboSite.SelectedValue), ModuleId, UserId)
            If Not objSite Is Nothing Then
                txtURL.Text = objSite.URL
                txtTitle.Text = objSite.Title
                txtDescription.Text = objSite.Description
                txtOwner.Text = objSite.Owner
                txtOwnerURL.Text = objSite.OwnerURL
                chkActive.Checked = objSite.IsActive
                imgThumbnail.ImageUrl = objSite.Thumbnail

                cboThumbnail.Items.Clear()
                Dim strFiles As String() = Directory.GetFiles(PortalSettings.HomeDirectoryMapPath & Settings("folder").Replace("/","\"), "Site" & Integer.Parse(cboSite.SelectedValue).ToString("00000") & "_*")
                For Each strFile In strFiles
                    cboThumbnail.Items.Insert(0, New ListItem(strFile.Substring(strFile.IndexOf("_") + 1), strFile))
                Next
                If cboThumbnail.Items.Count > 0 Then
                    plThumbnail.Visible = True
                    cboThumbnail.Visible = True
                    cboThumbnail.SelectedIndex = 0
                End If
            End If
        End Sub

        Protected Sub cmdSave_Click(sender As Object, e As EventArgs) Handles cmdSave.Click
            Dim objSiteGallery As New SiteGalleryController
            Dim strURL As String = Common.Globals.AddHTTP(txtURL.Text)
            If objSiteGallery.ValidateSite(Settings, Integer.Parse(cboSite.SelectedValue), strURL)
                Dim objSite As New SiteGalleryInfo()
                objSite.SiteID = Integer.Parse(cboSite.SelectedValue)
                objSite.ModuleID = ModuleId
                objSite.UserID = UserId
                objSite.URL = strURL
                objSite.Title = HttpUtility.HtmlEncode(txtTitle.Text)
                objSite.Description = HttpUtility.HtmlEncode(txtDescription.Text)
                objSite.Owner = HttpUtility.HtmlEncode(txtOwner.Text)
                objSite.OwnerURL = Common.Globals.AddHTTP(txtOwnerURL.Text)
                objSite.Thumbnail = ""
                objSite.IsActive = chkActive.Checked
                objSite.LastModifiedByUserID = UserId
                objSite.SiteID = objSiteGallery.UpdateGallerySite(objSite)
                Dim strThumbnail As String = objSiteGallery.CreateThumbnail(Settings, objSite.SiteID, strURL, PortalSettings.HomeDirectoryMapPath, PortalSettings.HomeDirectory) 
                If strThumbnail <> "" Then
                    objSite.Thumbnail = strThumbnail
                    objSiteGallery.UpdateGallerySite(objSite)
                    Skins.Skin.AddModuleMessage(Me, "Site Saved Successfully", Skins.Controls.ModuleMessage.ModuleMessageType.GreenSuccess)
                    LoadSites()
                End If
            Else
                Skins.Skin.AddModuleMessage(Me, "Site Can Not Be Validated. " & Settings("instructions"), Skins.Controls.ModuleMessage.ModuleMessageType.RedError)
            End If
        End Sub

        Protected Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
            Response.Redirect(NavigateURL(), True)
        End Sub

        Protected Sub cboThumbnail_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboThumbnail.SelectedIndexChanged
            imgThumbnail.ImageUrl = cboThumbnail.SelectedValue.Replace(PortalSettings.HomeDirectoryMapPath, PortalSettings.HomeDirectory).Replace("\","/")
        End Sub

      #End Region

    End Class

End Namespace

