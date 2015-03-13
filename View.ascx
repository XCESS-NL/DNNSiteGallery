<%@ Control language="vb" CodeFile="View.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="Siliqon.SiteGallery.View" %>
<%@ Register TagPrefix="dnn" Namespace="DotNetNuke.UI.WebControls" Assembly="DotNetNuke" %>

<p align="center">
    <dnn:ActionLink id="cmdAdd" runat="server" Title="Add Site" ControlKey="Edit" />
    <asp:Label id="lblLogin" runat="server" text="<br />Please Login To Add Your Site" />
</p>
<p align="center">
    <asp:DataList id="lstGallery" runat="server" HorizontalAlign="Center" RepeatDirection="Horizontal">
	    <ItemTemplate>
            <%# DisplaySite(DataBinder.Eval(Container.DataItem,"SiteID"), DataBinder.Eval(Container.DataItem,"URL"), DataBinder.Eval(Container.DataItem,"Title"), DataBinder.Eval(Container.DataItem,"Description"), DataBinder.Eval(Container.DataItem,"Owner"), DataBinder.Eval(Container.DataItem,"OwnerURL"), DataBinder.Eval(Container.DataItem,"Thumbnail"), DataBinder.Eval(Container.DataItem,"CreatedOnDate")) %>
	    </ItemTemplate>
    </asp:DataList>
</p>
<p align="center">
    <asp:Hyperlink ID="cmdPrevious" Runat="server" CssClass="dnnPrimaryAction">Previous</asp:Hyperlink>
    Page <asp:Label ID="lblPage" Runat="server" /> of <asp:Label ID="lblPages" Runat="server" />
    <asp:Hyperlink ID="cmdNext" Runat="server" CssClass="dnnPrimaryAction">Next</asp:Hyperlink>
</p>
