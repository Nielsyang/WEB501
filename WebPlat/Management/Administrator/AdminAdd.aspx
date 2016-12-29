<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="WebPlat.Management.Administrator.AdminAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加管理员</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet" />
    <script type="text/javascript">
        function checkform() {
            document.getElementById("usernameLable").innerHTML = "";
            document.getElementById("pwdLable").innerHTML = "";
            document.getElementById("pwd2Lable").innerHTML = "";
            var flat = true;
            var admin = document.getElementById("hi").value;
            var array = new Array();
            array = admin.split(",");
            var username = document.getElementById("username").value;
            for(var i=0;i<array.length; i++)
            {
                  if(username==array[i])
                  {
                       document.getElementById("usernameLable").innerHTML = "用户名已经存在！";
                       flat=false;
                  }
            }
            var pwd = document.getElementById("pwd").value;
            var pwd2 = document.getElementById("pwd2").value;
            if (username == "") {
                document.getElementById("usernameLable").innerHTML = "用户名不能为空！";
                flat = false;
            }
            if (pwd == "") {
                document.getElementById("pwd2Lable").innerHTML = "";
                document.getElementById("pwdLable").innerHTML="密码不能为空！";
                flat = false;
            }
            if (pwd != pwd2) {
                document.getElementById("pwd2Lable").innerHTML="两次输入的密码不一致！";
                flat = false;
            }
            return flat;
        }
        function retu() {
            window.location.href = "Admin.aspx";
        }
    </script>
</head>
<body>
  <%
             
   %>
   <input type="hidden" value="<%=jsonAdmin %>" id="hi"/>
    <form id="form1" runat="server" onsubmit="return checkform();">
    <div>
          <table width="100%">
               <tr>
                   <td  colspan="2" class="tb" style="text-align:center;">添加管理员</td>
               </tr>
               <tr>
                    <td style="text-align:right; width:50%">用户名:</td>
                    <td><input type="text"  id="username" class="inpt" runat="server"/>
                             <label id="usernameLable" runat="server"></label>
                    </td>
               </tr>
               <tr>
                    <td style="text-align:right; width:50%">密码:</td>
                    <td><input type="password" id="pwd" class="inpt" runat="server"/>
                               <label id="pwdLable" runat="server"></label>
                    </td>
               </tr>
               <tr>
                   <td style="text-align:right; width:50%;">确认密码:</td>
                   <td><input type="password"  id="pwd2" class="inpt" runat="server"/>
                             <label id="pwd2Lable" runat="server"></label>
                   </td>
               </tr>
               <tr>
                    <td colspan="2" style="text-align:center;">
                            <asp:Button ID="submit" runat="server" Text="添加"  class="button_on" OnClick="admin_Add"/>&nbsp;
                            <input id="Reset1" type="reset" value="重置" runat="server" class="button_on"/>&nbsp;
                            <input type="button" value="返回" runat="server" onclick="retu();" class="button_on" />
                    </td>
               </tr>
          </table>
    </div>
    </form>
</body>
</html>
