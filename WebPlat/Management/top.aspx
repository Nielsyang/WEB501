<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="top.aspx.cs" Inherits="WebPlat.Management.top.top" %>

<!DOCTYPE html>
<html>
<head>
<title></title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="css/top.css" type="text/css" rel="stylesheet" />
</head>
<body>
	<div id="top">
		<div id="logo">
			<div class="logo">
				<img  src="images/logo.jpg">
			</div>
			<div class="logoright">欢迎<%=Session["username"]%>登录系统！ |<a href="Administrator/loginout.aspx" target="_top"
					onclick="return confirm('确定退出网站后台管理页面');"> 安全退出</a>
			</div>
		</div>
		<div id="link">
			<ul>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(0,'网站基本信息');" target="frmright"><span>网站基本信息</span>
				</a>
				</li>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(1,'管理员设置');" target="frmright"><span>管理员设置</span>
				</a>
				</li>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(2,'问题管理');" target="frmright"><span>问题管理</span>
				</a>
				</li>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(3,'下载中心管理');" target="frmright"><span>下载中心管理</span>
				</a>
				</li>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(4,'发表文献管理');" target="frmright"><span>发表文献管理</span>
				</a>
				</li>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(5,'关于我们管理');" target="frmright"><span>关于我们管理</span>
				</a>
				</li>
				<li><a href="right.aspx"
					onclick="parent.frmleft.disl(6,'相关网站管理');" target="frmright"><span>相关网站管理</span>
				</a>
				</li>

			</ul>
		</div>
	</div>
</body>
</html>

