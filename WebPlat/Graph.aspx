<%@ Page Language="C#" enableViewStateMac="false" AutoEventWireup="true" CodeBehind="Graph.aspx.cs" Inherits="WebPlat.Graph" %>
<%@ Register Src="top.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <uc1:head ID="head2" runat="server" />
        <div class="tweetarea">
		     <div class="tweettext"></div>
	    </div>
        <div id="block">
        <form id="form1" runat="server">
        <asp:DropDownList ID="dropdown" runat="server" DataTextField="ModelName" DataValueField="ModelId" Width:500px>
        </asp:DropDownList>
        </form>
        </div>
</body>
</html>
