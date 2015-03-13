<%@ Control language="vb" CodeFile="Edit.ascx.vb" AutoEventWireup="false" Explicit="True" Inherits="Siliqon.SiteGallery.Edit" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>
<br />
<div class="dnnForm dnnEdit dnnClear" id="dnnEdit">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label id="plSite" runat="server" text="Site:" controlname="cboSite" />
            <asp:dropdownlist id="cboSite" runat="server" CssClass="Normal" autopostback="true" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plURL" runat="server" text="URL:" controlname="txtURL" />
            <asp:textbox id="txtURL" runat="server" maxlength="255" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plTitle" runat="server" text="Title:" controlname="txtTitle" />
            <asp:textbox id="txtTitle" runat="server" maxlength="255" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plDescription" runat="server" text="Description:" controlname="txtDescription" />
            <asp:textbox id="txtDescription" runat="server" maxlength="2000" textmode="multiline" rows="5" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plOwner" runat="server" text="Owner:" controlname="txtOwner" />
            <asp:textbox id="txtOwner" runat="server" maxlength="255" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plOwnerURL" runat="server" text="Owner URL:" controlname="txtOwnerURL" />
            <asp:textbox id="txtOwnerURL" runat="server" maxlength="255" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plActive" runat="server" text="Active?" controlname="chkActive" />
            <asp:checkbox id="chkActive" runat="server" checked="true" />
        </div>
    </fieldset>
    <ul class="dnnActions dnnClear">
        <li><asp:linkbutton id="cmdSave" text="Save" runat="server" cssclass="dnnPrimaryAction" /></li>
        <li><asp:linkbutton id="cmdCancel" text="Cancel" runat="server" cssclass="dnnSecondaryAction" /></li>
    </ul>
</div>
<div class="dnnForm dnnEdit dnnClear" id="dnnThumbnail">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label id="plThumbnail" runat="server" text="Thumbnail:" controlname="cboThumbnail" />
            <asp:dropdownlist id="cboThumbnail" runat="server" autopostback="true" />
        </div>
   </fieldset>
</div>
<p align="center">
    <asp:Image id="imgThumbnail" runat="server" />
</p>

