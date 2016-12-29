<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadEdit.aspx.cs" Inherits="WebPlat.Management.Download.DownloadEdit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载编辑</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/default/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/icon.css" /> 
     <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/color.css" /> 
    <script type="text/javascript" src="../../jqueryuipage/jquery.min.js"></script>  
    <script type="text/javascript" src="../../jqueryuipage/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        function retu() {
            window.location.href = "Download.aspx";
        }
    </script>  
</head>
<body>
    <form id="form1" runat="server">
      <input type="hidden" id="hid" runat="server"/>
      <table width="100%">
          <tr>
             <td colspan="2" style="text-align:left;" class="tb">修改文件下载信息</td>
          </tr>
          <tr>
             <td width="15%" style="text-align:right">文件名:</td>
             <td>
                 <input id="filename" type="text" runat="server" class="inpt "/>
             </td>
          </tr>
          <tr>
                <td style="text-align:right;">文件信息</td>
                <td>
                    <textarea id="fileinfo" cols="20" rows="8" class="inpt" runat="server">
                    </textarea>
                </td>
          </tr>
          <tr>
              <td style="text-align:right;">文件下载地址</td>
              <td>
                   <input id="fileurl" type="text" runat="server" class="inpt" />
              </td>
          </tr>
          <tr>
                <td colspan="2" style="text-align:center;">
                    <asp:Button ID="midify" runat="server" Text="修改" class="button_on" 
                        onclick="midify_Click"/>&nbsp;
                    <asp:Button ID="Button1" runat="server" Text="重置" class="button_on" OnClick="Reset"/>&nbsp;
                    <input class="button_on" id="back" type="button" value="返回" runat="server" onclick="retu();"/>
                </td>
          </tr>
      </table>
    </form>
</body>
</html>
