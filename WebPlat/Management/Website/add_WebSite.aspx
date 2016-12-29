<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="add_WebSite.aspx.cs" Inherits="WebPlat.Management.Website.add_WebSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加相关网站</title>
     <link type="text/css" href="../css/right.css" rel="stylesheet" />
     <script type="text/javascript">
         function retu() {
             window.location.href = "WebSite.aspx";
         }
         function checkForm() {
             var httpurl = document.getElementById("websiteurl").value;
             if (httpurl.length != 0) {
                 reg = "^[a-zA-z]://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";  
                 if (!reg.match(httpurl)) {
                     alert("网址不正确，请重新输入！");
                     return false;
                 }
                 else {
                     return true;
                 }
             }
             return false;
         }
     </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkForm();">
    <div>
         <table width="100%">
             <tr>
                <td colspan="2" style="text-align:left;" class="tb">相关网站添加</td>
             </tr>
             <tr>
                <td style="text-align:right;" width="15%">网站名称:</td>
                <td>
                    <input id="websitename" type="text" runat="server" class="inpt"/>
                </td>
             </tr>
             <tr>
               <td style="text-align:right;">网址:</td>
               <td>
                   <input id="websiteurl" type="text" runat="server" class="inpt"/>
               </td>
             </tr>
             <tr>
                <td style="text-align:right;">网站Logo:</td>
                <td>
                    <asp:FileUpload  ID="ImageUpload" runat="server" />
                </td>
             </tr>
             <tr>
                 <td colspan="2" style="text-align:center;">
                     <asp:Button ID="submit" runat="server" Text="添加" class="button_on" OnClick="AddWebSite"/>&nbsp;
                     <input id="back" type="button" value="返回" onclick="retu();" runat="server" class="button_on"/>
                 </td>
             </tr>
         </table>
    </div>
    </form>
</body>
</html>
