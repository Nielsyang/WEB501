<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebPlat.Management.Administrator.login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=gb2312"/>
<title>登录</title>
<link rel="stylesheet" href="../css/style.css" type="text/css" />
</head>
	<body>
		<div id="container">
			<form id="Form1" runat="server">
				<div class="login">登录</div>
				<div class="username-text">用户名:</div>  
				<div class="password-text">密码:</div>
				<div class="username-field">
					<input type="text" id="username" runat="server"/>
				</div>
				<div class="password-field">
					<input type="password" id="passWord" runat="server"/>
				</div>
				<input type="checkbox" id="remember_me"  runat="server"/><label for="remember-me">Remember me</label>
				<div class="forgot-usr-pwd"><a href="#">修改密码</a> or <a href="#">忘记密码</a>?</div>
                <asp:Button ID="Button1" runat="server" Text="GO"  OnClick="login_click"/>
			</form>
		</div>
		<div id="footer">
		</div>
<div style="display:none"><script type="text/javascript" src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540' language='JavaScript' 
charset='gb2312'></script></div>
</body>
</html>
