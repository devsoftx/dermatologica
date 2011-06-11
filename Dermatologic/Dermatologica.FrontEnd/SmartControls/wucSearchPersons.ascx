<%@ Control Language="C#" AutoEventWireup="true" CodeFile="wucSearchPersons.ascx.cs" Inherits="SmartControls_wucSearchPersons" %>
<telerik:RadCodeBlock ID="RadCodeBlock1" runat="server">
	<script language="javascript" type="text/javascript">
	    function SetContext(sender, args) {
	        if ("<%= CycleControlName %>" != "") {
	            var combo = $find("<%= CycleControlName %>");
	            if (combo == null) {
	                args.get_context()["EvaluationCycle"] = "";
	            }
	            else {
	                args.get_context()["EvaluationCycle"] = combo._value;
	            }
	        }
	        else {
	            args.get_context()["EvaluationCycle"] = "";
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
    OnClientItemsRequestFailed="OnClientItemsRequestFailedHandler">
	<WebServiceSettings Path="~/SmartControls/DataService.asmx" Method="LoadPersons"  />
</telerik:RadComboBox>
