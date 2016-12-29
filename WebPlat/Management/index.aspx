<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebPlat.Management.index.index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>网站后台管理系统</title>
    <style type="text/css">
    body {
	    background-color: #068BAE;
	    margin-left: 0px;
	    margin-top: 0px;
	    margin-right: 0px;
	    margin-bottom: 0px;
	    overflow:hidden;
    }
    #wz {
	    float: left;
	    font-family: "宋体";
	    font-size: 12px;
	    color: #0C7A92;
	    line-height: 20px;
	    margin-top: 5px;
	    margin-left: 10px;
	    padding: 0px;
    }

    #wz a:link,#wz a:visited {
	    font-size: 12px;
	    color: #0C7A92;
	    text-decoration: none
    }

    #wz a:hover {
	    font-size: 12px;
	    color: #FF6600;
	    text-decoration: none
    }

    #sj {
	    float: right;
	    font-family: "宋体";
	    font-size: 12px;
	    color: #0C7A92;
	    line-height: 20px;
	    margin-top: 5px;
	    margin-right: 10px;
	    padding: 0px;
    }
    </style>
    <script type="text/javascript">
        var n = 1;
        function switchSysBar() {
            if (n == 1) {
                n = 2
                document.all("frmTitle").style.display = "none";
                document.getElementById("arrow").src = "images/rz.jpg";
                document.getElementById("arrow").alt = "收缩";
            } else {
                n = 1;
                document.all("frmTitle").style.display = "";
                document.getElementById("arrow").src = "images/rz1.jpg";
                document.getElementById("arrow").alt = "伸展";
            }
        }
    </script>
</head>
<body>
	<table width="100%" border="0" align="center"
		cellpadding="0" cellspacing="0" style="height:600px;">
		<tr>
			<td height="106"><table width="100%" border="0" align="center"
					cellpadding="0" cellspacing="0">
					<tr>
						<td height="106"><iframe frameborder="0" id="frmtop"
								name="frmtop" scrolling="no" src="top.aspx"
								style="height: 100%; visibility: inherit;width: 100%;"></iframe>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td><table width="100%" height="100%" border="0" align="center"
					cellpadding="0" cellspacing="0">
					<tr>
						<td width="174" id="frmTitle" name="fmtitle"><iframe
								frameborder="0" id="frmleft" name="frmleft" scrolling="no"
								src="left.aspx"
								style="height: 100%; visibility: inherit;width: 174px;"
								allowtransparency="true"></iframe>
						</td>
						<td width="8"><a href="javascript:switchSysBar();"
							onFocus="this.blur()"><img src="images/rz1.jpg" border="0"
								width="8" height="8" name="arrow" id="arrow" alt="伸展"> </a>
						</td>
						<td><table width="100%" height="100%" border="0"
								cellpadding="0" cellspacing="0">
								<tr>
									<td height="35"><table width="100%" border="0"
											cellspacing="0" cellpadding="0">
											<tr>
												<td width="15" height="35"><img src="images/r_01.jpg"
													width="15" height="35" alt="">
												</td>
												<td background="images/r_02.jpg" width="100%"><div
														id="wz">
														现在的位置：<span id="title">系统首页</span>
													</div>
													<div id="sj">
														<script>
														    setInterval(
																	"sj.innerHTML=new Date().toLocaleString()+' 星期'+'日一二三四五六'.charAt(new Date().getDay());",
																	1000);
														</script>
													</div>
												</td>
												<td width="19" height="35"><img src="images/r_03.jpg"
													width="19" height="35" alt="">
												</td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td><table width="100%" height="100%" border="0"
											cellpadding="0" cellspacing="0">
											<tr>
												<td width="15" valign="middle" background="images/r_04.jpg">&nbsp;</td>
												<td valign="top" bgcolor="#ACD6E2" id="main"><iframe
														frameborder="0" id="frmright" name="frmright"
														scrolling="yes" src="right.aspx"
														style="height: 100%; visibility: inherit; width:100%; z-index: 1"></iframe>
												</td>
												<td width="5" background="images/r_06.jpg"
													style="background-repeat:repeat-y; background-position:right;"></td>
											</tr>
										</table>
									</td>
								</tr>
								<tr>
									<td height="17"><table width="100%" border="0"
											cellspacing="0" cellpadding="0">
											<tr>
												<td width="15" height="17"><img src="images/r_07.jpg"
													width="15" height="17" alt="">
												</td>
												<td background="images/r_08.jpg" width="100%" height="17"></td>
												<td width="19" height="17"><img src="images/r_09.jpg"
													width="19" height="17" alt="">
												</td>
											</tr>
										</table>
									</td>
								</tr>
							</table>
						</td>
					</tr>
				</table>
			</td>
		</tr>
		<tr>
			<td height="30"><table width="100%" border="0" align="center"
					cellpadding="0" cellspacing="0">
					<tr>
						<td height="30"><iframe frameborder="0" id="frmbottom"
								name="frmbottom" scrolling="no" src="bottom.aspx"
								style="height: 100%; visibility: inherit;width: 100%;"></iframe>
						</td>
					</tr>
				</table>
			</td>
		</tr>
	</table>
</body>
</html>
