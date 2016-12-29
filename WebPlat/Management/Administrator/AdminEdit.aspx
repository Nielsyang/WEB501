<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminEdit.aspx.cs" Inherits="WebPlat.Management.Administrator.AdminEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>修改管理员基本信息</title>
     <link type="text/css" href="../css/right.css" rel="stylesheet"/>
     <script  type="text/javascript">
         function retu() {
             window.location.href = "Admin.aspx";
         }
         function checkForm() {
             var flag = true;
             document.getElementById("newpwdLable").innerHTML = "";
             document.getElementById("newpwd2Lable").innerHTML = "";
             var newpw = document.getElementById("newpwd").value;
             var newpw2 = document.getElementById("newpwd2").value;
             if (newpw == "" || newpw == null) {
                 document.getElementById("newpwdLable").innerHTML = "密码不能为空！";
                 document.getElementById("newpwd2Lable").innerHTML = "";
                 flag = false;
             }
             if (newpw != newpw2) {
                 document.getElementById("newpwd2Lable").innerHTML = "两次输入的密码不一致！"
                 flag = false;
             }
             return flag;
         }
   </script>
</head>
<body>
    <form id="form1" runat="server" onsubmit="return checkForm();">
        <input type="hidden" id="hid" runat="server"/>
        <table width="100%">
              <tr>
                   <td colspan="2" style="text-align:left;" class="tb">修改管理员密码信息</td>
              </tr>
              <tr>
                   <td style="text-align:right; width:50%;">用户名:</td>
                   <td>
                       <input type="text" id="username" runat="server"/>
                   </td>
              </tr>
              <tr>
                   <td style="text-align:right;">旧密码:</td>
                   <td><input type="text" id="oldpwd" runat="server" class="inpt"/>
                   </td>
              </tr>
              <tr>
                   <td style="text-align:right;">新密码:</td>
                   <td><input type="text" id="newpwd" runat="server" class="inpt" />
                         <label id="newpwdLable" runat="server"></label>
                   </td>
              </tr>
              <tr>
                   <td style="text-align:right;">确认新密码:</td>
                   <td><input type="text" id="newpwd2" runat="server" class="inpt" />
                       <label id="newpwd2Lable" runat="server"></label>
                   </td>
              </tr>
              <tr align="center">
                 <td colspan="2" >
                     <asp:Button ID="submit" runat="server" Text="修改"  OnClick="admin_Edit" class="button_on"/>&nbsp;
                     <input  type="reset" value="重置" runat="server" class="button_on"/> &nbsp;
                     <input type="button" class="button_on" value="返回"  onclick="retu();"/>
                 </td>
              </tr>
        </table>
    </form>
</body>
</html>
