<%@ Page Title="主页" Language="C#"  AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="WebPlat.Default" %>
<%@ Register Src="top.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="bottom.ascx" TagName="foot" TagPrefix="uc2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
      <title>TCM2B</title>
</head>
<body>
        <uc1:head ID="head2" runat="server" />
        <div class="tweetarea">
		     <div class="tweettext"></div>
	    </div>
        <uc2:foot ID="foot1" runat="server" />
</body>
</html>
