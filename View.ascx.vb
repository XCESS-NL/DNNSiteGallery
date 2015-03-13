'
' Copyright (c) 2014
' by Siliqon Inc.
' http://www.siliqon.com
'
Imports DotNetNuke

Namespace Siliqon.SiteGallery

    Public Partial Class View

        Inherits Entities.Modules.PortalModuleBase

        Private intPage As Integer = 1

        Private Sub Page_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not Request.QueryString("p") Is Nothing Then
                intPage = CType(Request.QueryString("p"), Integer)
            End If

            If Not Page.IsPostBack Then
                If Request.IsAuthenticated Then
                    lblLogin.Visible = False
                    cmdAdd.Visible = True
                Else
                    lblLogin.Visible = True
                    cmdAdd.Visible = False
                End If
                If Settings("template") = "" Then
                    lblLogin.Text = "<br />Please Configure The Site Gallery Using The Module Settings"
                    lblLogin.Visible = True
                End If
                BindData()
            End If
        End Sub

        Private Sub BindData()
            Dim intColumns As Integer = 1
            Dim intRows As Integer = 10
            Dim intPages As Integer = 1
            If Settings("columns") <> "" Then
                intColumns = Integer.Parse(Settings("columns")) 
            End If
            If Settings("rows") <> "" Then
                intRows = Integer.Parse(Settings("rows")) 
            End If

            Dim objSiteGallery As New SiteGalleryController
            Dim lstSites As List(Of SiteGalleryInfo) = objSiteGallery.GetGallerySites(ModuleId, (intRows * intColumns), intPage)
            lstGallery.DataSource = lstSites
            lstGallery.RepeatColumns = intColumns 
            lstGallery.DataBind()

            If lstSites.Count > 0 Then
                intPages = CType(System.Math.Ceiling(lstSites(0).Rows / (intRows * intColumns)), Integer)               
            End If

            lblPage.Text = intPage.ToString()
            lblPages.Text = intPages.ToString()
            If intPage = 1 Then
                cmdPrevious.Visible = False
            Else
                cmdPrevious.NavigateUrl = NavigateURL(TabID, "", "p=" & (intPage - 1).ToString())
            End If
            If intPage >= intPages Then
                cmdNext.Visible = False
            Else
                cmdNext.NavigateUrl = NavigateURL(TabID, "", "p=" & (intPage + 1).ToString())
            End If
        End Sub

        Public Function DisplaySite(ByVal SiteID As Object, ByVal URL As Object, ByVal Title As Object, ByVal Description As Object, ByVal Owner As Object, ByVal OwnerUrl As Object, ByVal Thumbnail As Object, ByVal CreatedOnDate As Object) As String
            Dim strTemplate As String = "<a href=""[URL]"" title=""[TITLE]"" target=""_new""><img src=""[THUMBNAIL]"" alt=""[TITLE]"" width=""341"" height=""256""></a>"
            If Settings("template") <> "" Then
                strTemplate = Settings("template")
            End If
            strTemplate = strTemplate.Replace("[URL]", URL.ToString())
            strTemplate = strTemplate.Replace("[TITLE]", Title.ToString())
            strTemplate = strTemplate.Replace("[DESCRIPTION]", Description.ToString().Replace(vbCrLf,"<br />"))
            strTemplate = strTemplate.Replace("[OWNER]", Owner.ToString())
            strTemplate = strTemplate.Replace("[OWNERURL]", OwnerUrl.ToString())
            strTemplate = strTemplate.Replace("[THUMBNAIL]", Thumbnail.ToString())
            strTemplate = strTemplate.Replace("[CREATED]", Convert.ToDateTime(CreatedOnDate).ToShortDateString())
            strTemplate = strTemplate.Replace("[WIDTH]", Settings("width"))
            strTemplate = strTemplate.Replace("[HEIGHT]", Settings("height"))
            Return strTemplate
        End Function

    End Class

End Namespace

