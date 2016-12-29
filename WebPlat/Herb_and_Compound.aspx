<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Herb_and_Compound.aspx.cs" Inherits="WebPlat.HerbFormula" %>
<%@ Register Src="graph_bottom.ascx" TagName="graph_foot" TagPrefix="uc3" %>
<%@ Register Src="top.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title></title>
</head>
<body>
        <uc1:head ID="head1" runat="server" />
        <div class="tweetarea">
		     <div class="tweettext"></div>
	    </div>
        <uc3:graph_foot ID="graph_foot1" runat="server" />
</body>
</html>
