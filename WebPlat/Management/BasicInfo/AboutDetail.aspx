<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutDetail.aspx.cs" Inherits="WebPlat.Management.BasicInfo.AboutDetail"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>基本信息详情</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet"/>
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <table width="100%">
               <tr>
                     <td  colspan="2" style="text-align:left;" class="tb">基本信息详情</td>
               </tr>
               <tr>
                     <td width="15%" style="text-align:right;">标题:</td>
                     <td>
                         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></td>
               </tr>
               <tr>
                    <td width="15%" style="text-align:right;">内容:</td>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label></td>
               </tr>
               <tr>
                     <td width="15%" style="text-align:right;">添加时间:</td>
                     <td>
                         <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label></td>
               </tr>
               <tr>
                    <td colspan="2" style="text-align:center">
                        <asp:Button ID="Button1" runat="server" Text="返回" onclick="Button1_Click" class="button_on"/>
                    </td>
               </tr>
         </table>
    </div>
    </form>
</body>
</html>
