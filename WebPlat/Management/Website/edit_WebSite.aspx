<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="edit_WebSite.aspx.cs" Inherits="WebPlat.Management.Website.edit_WebSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相关网站编辑</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet" />
    <script type="text/javascript">
        function retu() {
            window.location.href = "WebSite.aspx";
        }
        function show() {
            var path = document.getElementById("FileUpload1").value;
            if (path == null || path == "") {
                alert("上传图片不能为空！");
            }
            var s = path.lastIndexOf(".");
            if (path.substring(s, path.length) != ".png" && path.substring(s, path.length) != ".jpg") {
                 alert("请选择图片上传！");
            }
            else {
                var files = path.lastIndexOf("\\");
                var filename = path.substring(files + 1, path.length);
                document.getElementById("websiteImage").setAttribute("src", "../../Management/upload/image/" + filename);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <input type="hidden" id="hid" runat="server"/>
         <table width="100%">
               <tr>
                  <td colspan="2" style="text-align:left;" class="tb">
                        相关网站编辑
                  </td>
               </tr>
               <tr>
                  <td style="text-align:right;" width="15%">网站名称:</td>
                  <td>
                      <input id="websiteName" type="text" runat="server" class="inpt"/>
                  </td>
               </tr>
               <tr>
                  <td style="text-align:right;">网址:</td>
                  <td>
                      <input id="websiteUrl" type="text" runat="server" class="inpt"/>
                  </td>
               </tr>
               <tr>
                  <td style="text-align:right;">网站Logo:</td>
                  <td>
                       <img alt=""  src="" id="websiteImage" height="40" width="100" runat="server"/>
                       <asp:FileUpload ID="FileUpload1" onchange="show();"  runat="server" />
                  </td>
               </tr>
               <tr>
                  <td colspan="2" style="text-align:center;">
                      <asp:Button ID="Button1" runat="server" Text="修改" OnClick="editWebSite" class="button_on"/>&nbsp;
                      <asp:Button ID="Button2" runat="server" Text="重置" OnClick="Reset" class="button_on"/>&nbsp;
                      <input id="Button3" type="button" value="返回" class="button_on" onclick="retu();"/>
                  </td>
               </tr>
         </table>
    </form>
</body>
</html>
