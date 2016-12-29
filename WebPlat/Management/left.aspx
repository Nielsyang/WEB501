<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="left.aspx.cs" Inherits="WebPlat.Management.left.left" %>
<!DOCTYPE html>
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title>left.aspx</title>
<link href="css/left.css" type="text/css" rel="stylesheet" />
<script type="text/javascript">
    function disl(n, content) {
        for (var i = 0; i <= 6; i++) {
            if (!document.getElementById("left" + i)) return;
            document.getElementById("left" + i).style.display = "none";
        }
        document.getElementById("left" + n).style.display = "";
        document.getElementById("title").innerHTML = content;
        parent.document.getElementById("title").innerHTML = content;
    }
    </script>
</head>

<body>
	<table width="174" height="100%" border="0" cellpadding="0"
		cellspacing="0">
		<tr>
			<td valign="top" background="images/l_03.jpg" >
				<table width="100%" border="0" cellspacing="0" cellpadding="0">
					<tr>
						<td height="16"><img src="images/l_01.jpg" width="174"
							height="16" alt="" /></td>
					</tr>
					<tr>
						<td width="174" height="27" background="images/l_02.jpg"
							align="left" class="f1" id="title">系统管理</td>
					</tr>
				</table>
				<div class="ml" id="left0">
					<ul>
						<li><a href="BasicInfo/About.aspx" target="frmright">网站基本信息</a>
						</li>
                        <li><a href="BasicInfo/aboutAdd.aspx" target="frmright">添加基本信息</a>
                        </li>
					</ul>
				</div>
				<div class="ml" id="left1" style="display: none;">
					<ul>
						<li><a href="Administrator/Admin.aspx" target="frmright">管理员设置</a>
						</li>
                        <li><a href="Administrator/AdminAdd.aspx" target="frmright">添加管理员</a>
                        </li>
					</ul>
				</div>
				<div class="ml" id="left2" style="display: none;">
					<ul>
						<li><a href="QuestionManage/question.aspx" target="frmright">问题管理</a>
						</li>
					</ul>
				</div> 
				<div class="ml" id="left3" style="display: none;">
					<ul>
						<li><a href="Download/Add_download.aspx" target="frmright">下载添加</a>
						</li>
						<li><a href="Download/Download.aspx" target="frmright">下载管理</a>
						</li>
					</ul>
				</div> 
				<div class="ml" id="left4" style="display: none;">
					<ul>
						<li><a href="publication/Publicaiton.aspx"
							target="frmright">管理文献信息</a></li>
						<li><a href="publication/AddPublication.aspx"
							target="frmright">添加文献信息</a></li>
					</ul>
				</div>
				<div class="ml" id="left5" style="display: none;">
					<ul>
						<li><a href="member/Member.aspx" target="frmright">管理成员信息</a>
						</li>
						<li><a href="member/MemberAdd.aspx" target="frmright">添加成员信息</a>
						</li>
					</ul>
				</div>
				<div class="ml" id="left6" style="display: none;">
					<ul>
						<li><a href="Website/WebSite.aspx" target="frmright">相关网站管理</a>
						</li>
						<li><a href="Website/add_WebSite.aspx" target="frmright">添加相关网站</a>
						</li>
					</ul>
				</div>
			</td>
		</tr>
		<tr>
			<td height="16" valign="bottom" background="images/l_03.jpg"><img
				src="images/l_04.jpg" width="174" height="16" alt="" /></td>
		</tr>
	</table>
</body>
</html>
