<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucSearchPersons.ascx.cs" Inherits="SmartControls_wucSearchPersons" %>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
	<script language="javascript" type="text/javascript">
	    function SetContext(sender, args) {
	        if ("<%= PersonTypeControlName %>" != "") {
	            var combo = document.getElementById("<%= PersonTypeControlName %>");
	            if (combo == null) {
	                args.get_context()["PersonType"] = "";
	            }
	            else {
	                args.get_context()["PersonType"] = combo.value;
	            }
	        }
	        else {
	            args.get_context()["PersonType"] = "";
	        }
	    }
	    function OnClientItemsRequestFailedHandler(sender, eventArgs) {
	        eventArgs.set_cancel(true);
	    }
	</script>
</telerik:RadCodeBlock>
<telerik:RadComboBox ID="ComboBox" runat="server" EnableEmbeddedSkins="false"
	EnableLoadOnDemand="true" EnableItemCaching="true" OnClientItemsRequesting="SetContext"
	Filter="Contains" ShowToggleImage="False" ShowDropDownOnTextboxClick="false" SkinID="SmartCombo"
    OnClientItemsRequestFailed="OnClientItemsRequestFailedHandler" 
    EmptyMessage="Ingrese aquí para buscar..." BackColor="#f0f0f0"
    BorderColor="#ABADB3" BorderStyle="None" LoadingMessage="Buscando..." 
    Skin="WebBlue">
	<WebServiceSettings Path="~/SmartControls/DataService.asmx" Method="LoadPersons"  />
<WebServiceSettings Path="~/SmartControls/DataService.asmx" Method="LoadPersons"></WebServiceSettings>
</telerik:RadComboBox>
