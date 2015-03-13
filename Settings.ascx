<%@ Control Language="VB" AutoEventWireup="false" Inherits="Siliqon.SiteGallery.Settings" CodeFile="Settings.ascx.vb" %>
<%@ Register TagPrefix="dnn" TagName="Label" Src="~/controls/LabelControl.ascx" %>

<div class="dnnForm dnnSettings dnnClear" id="dnnSettings">
    <fieldset>
        <div class="dnnFormItem">
            <dnn:label id="plRows" runat="server" text="Rows" helptext="Number of Display Rows" controlname="txtRows" />
            <asp:textbox id="txtRows" runat="server" maxlength="3" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plColumns" runat="server" text="Columns" helptext="Number of Display Columns" controlname="txtColumns" />
            <asp:textbox id="txtColumns" runat="server" maxlength="1" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plTemplate" runat="server" text="Template" helptext="An HTML Template for Displaying A Site. The Template Can Specify Tokens For All Site Fields ( [URL], [TITLE], [DESCRIPTION], [OWNER], [OWNERURL], [THUMBNAIL], [CREATED] )." controlname="txtTemplate" />
            <asp:textbox id="txtTemplate" runat="server" maxlength="2000" textmode="multiline" rows="5" />
        </div>
        <hr />
        <div class="dnnFormItem">
            <dnn:label id="plURL" runat="server" text="Thumbnail Service URL" helptext="Optionally Specify The URL Of An External Web Service That Generates Site Thumbnails. The URL Can Specify Tokens For [URL], [WIDTH], [HEIGHT] That Will Be Replaced Dynamically ( ie. http://img.bitpixels.com/getthumbnail?code=68013&url=[URL]&size=200 )." controlname="txtURL" />
            <asp:textbox id="txtURL" runat="server" maxlength="250" /> <a href="http://w3guy.com/alternative-bitpixels-website-thumbnails-generator/" target="_new" class="dnnSecondaryAction">Options</a>
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plWidth" runat="server" text="Thumbnail Width" helptext="The Width of Site Thumbnail Images" controlname="txtWidth" />
            <asp:textbox id="txtWidth" runat="server" maxlength="4" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plHeight" runat="server" text="Thumbnail Height" helptext="The Height of Site Thumbnail Images" controlname="txtHeight" />
            <asp:textbox id="txtHeight" runat="server" maxlength="4" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plFolder" runat="server" text="Thumbnail Folder" helptext="The Folder Where Site Thumbnails Are Stored" controlname="cboFolder" />
            <asp:dropdownlist id="cboFolder" runat="server" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plRefresh" runat="server" text="Refresh Frequency" helptext="The Frequency For Validating And Generating New Site Thumbnail Images" controlname="txtRefresh" />
            <asp:textbox id="txtRefresh" runat="server" maxlength="3" /> Days
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plHistory" runat="server" text="Retain History" helptext="Retain Site Thumbnail History" controlname="chkHistory" />
            <asp:checkbox id="chkHistory" runat="server" />
        </div>
        <hr />
        <div class="dnnFormItem">
            <dnn:label id="plValidation" runat="server" text="Site Validation URL" helptext="A Specific URL That Must Exist For The Site To Be Included In The Gallery ( ie. /js/dnn.js )" controlname="txtValidation" />
            <asp:textbox id="txtValidation" runat="server" maxlength="100" />
        </div>
        <div class="dnnFormItem">
            <dnn:label id="plInstructions" runat="server" text="Validation Instructions" helptext="Instructions For How A User Must Validate Their Site" controlname="txtInstructions" />
            <asp:textbox id="txtInstructions" runat="server" maxlength="200" textmode="multiline" rows="2" />
        </div>
   </fieldset>
</div>


