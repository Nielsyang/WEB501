<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="right.aspx.cs" Inherits="WebPlat.Management.right.right" %>
<!DOCTYPE html>
<html>
<head>
<title>right.aspx</title>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<link href="css/right.css" type="text/css" rel="stylesheet"/>
</head>
<body>
	<form action="" method="post" name="form1">
		<table style="width: 100%;" cellspacing="1" border="0"
			bgcolor="#3e97b9" cellpadding="0">
			<tr>
				<td class="tb" align="left" width="100%" colspan="4"
					style="height: 24px; text-align: left;">.NET 服务器相关信息</td>
			</tr>
			<tr>
				<td width="147">服务器名称：</td>
				<td width="212">
					</td>
				<td width="148">服务器操作系统：</td>
				<td width="220"><asp:Label ID="serverms" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td width="147">服务器IP地址：</td>
				<td width="212"><asp:Label ID="serverip" runat="server"></asp:Label>
				</td>
				<td width="148">服务器域名：</td>
				<td width="220"><asp:Label ID="server_name" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td width="147">服务器IIS版本：</td>
				<td width="212">&nbsp;<asp:Label ID="serversoft" runat="server"></asp:Label>
				</td>
				<td width="148">.NET解释引擎版本：</td>
				<td width="220"><asp:Label ID="servernet" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td width="147">HTTPS：</td>
				<td width="212">&nbsp;<asp:Label ID="serverhttps"
						runat="server"></asp:Label>
				</td>
				<td width="148">HTTP访问端口：</td>
				<td width="220"><asp:Label ID="serverport" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td width="147">服务端脚本执行超时：</td>
				<td width="212"><asp:Label ID="serverout" runat="server"></asp:Label>秒</td>
				<td width="148">服务器现在时间：</td>
				<td width="220"><asp:Label ID="servertime" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>AspNet内存占用：</td>
				<td width="212"><asp:Label ID="aspnetn" runat="server"></asp:Label>
				</td>
				<td>AspNet CPU时间：</td>
				<td><asp:Label ID="aspnetcpu" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>正在使用内存：</td>
				<td width="212"><asp:Label ID="LbdwMemoryLoad" runat="server"></asp:Label>
				</td>
				<td>共有物理内存：</td>
				<td><asp:Label ID="LbdwTotalPhys" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="height: 32px">剩余物理内存：</td>
				<td width="212" style="height: 32px"><asp:Label
						ID="LbdwAvailPhys" runat="server"></asp:Label>
				</td>
				<td style="height: 32px">交换文件</td>
				<td style="height: 32px"><asp:Label ID="LbdwTotalPageFile"
						runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>剩余交换文件</td>
				<td width="212"><asp:Label ID="LbdwAvailPageFile"
						runat="server"></asp:Label>
				</td>
				<td>总虚拟内存</td>
				<td><asp:Label ID="LbdwTotalVirtual" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>开机运行时长：</td>
				<td width="212"><asp:Label ID="serverstart" runat="server"></asp:Label>小时</td>
				<td>进程开始时间：</td>
				<td><asp:Label ID="prstart" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>CPU数：</td>
				<td width="212"><asp:Label ID="cpuc" runat="server"></asp:Label>个
				</td>
				<td>服务器所在时区：</td>
				<td><font face="宋体"> <asp:Label ID="serverarea"
							runat="server"></asp:Label>
				</font>
				</td>
			</tr>
			<tr>
				<td>CPU类型：</td>
				<td width="212"><asp:Label ID="cputype" runat="server"></asp:Label>
				</td>
				<td>Sql数据库：</td>
				<td>&nbsp;<asp:Label ID="serveraccess" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td>网站Session总数：</td>
				<td><asp:Label ID="servers" runat="server"></asp:Label>
				</td>
				<td>网站Application总数：</td>
				<td><asp:Label ID="servera" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td width="147">网站目录绝对路径：</td>
				<td colspan="3"><asp:Label ID="serverppath" runat="server"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="height: 19px">执行文件绝对路径：</td>
				<td colspan="3" style="height: 19px"><asp:Label
						ID="servernpath" runat="server"></asp:Label>
				</td>
			</tr>
		</table>
		<br />
		<table style="width: 100%;" cellspacing="1" border="0"
			bgcolor="#3e97b9" cellpadding="0">
			<tr>
				<td align="left" class="tb" width="100%" colspan="4"
					style="height: 24px; text-align: left;">执行效率相关情况</td>
			</tr>
			<tr>
				<td style="width: 125px">
					<div align="right">本页执行时间：</div></td>
				<td style="width: 179px"><asp:Label ID="runtime" runat="server"></asp:Label>毫秒</td>
				<td height="21" style="width: 180px">
					<div align="right">五千万次加法循环测试：</div></td>
				<td width="221">&nbsp; <asp:Label ID="showtest" runat="server"></asp:Label>
				</td>
			</tr>
		</table>
		<br />
		<table style="width: 100%;" cellspacing="1" border="0"
			bgcolor="#3e97b9" cellpadding="0">
			<tr>
				<td class="tb" align="left" width="100%"
					style="height: 24px; text-align: left;" colspan="3">测 试 环 境</td>
			</tr>
			<tr>
				<td width="21%" height="23">CPU</td>
				<td width="79%">
					<p>P4 3.30G HT</p></td>
			</tr>
			<tr>
				<td>内存</td>
				<td>8.00GB * 4 双通道</td>
			</tr>
			<tr>
				<td>环境</td>
				<td>Windows 7+SQL Server 2008</td>
			</tr>

		</table>
		<div id="Loading">
			<font face="宋体"></font>
		</div>
	</form>
</body>
</html>

