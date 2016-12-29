<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DownloadDetail.aspx.cs" Inherits="WebPlat.Management.Download.DownloadDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载详情</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%">
                  <tr>
                     <td colspan="2" style="text-align:left;" class="tb">下载信息</td>
                  </tr>
                  <tr>
                     <td width="15%" style="text-align:right;">文件名:</td>
                     <td>
                         <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                     </td>
                  </tr>
                  <tr>
                     <td style="text-align:right;">文件信息</td>
                     <td>
                         <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                     </td>
                  </tr>
                  <tr>
                    <td style="text-align:right;">文件下载地址</td>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                    </td>
                  </tr>
                  <tr>
                     <td style="text-align:right;">添加时间</td>
                     <td>
                         <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                     </td>
                  </tr>
                  <tr>
                      <td colspan="2" style="text-align:center;">
                          <asp:Button ID="back" runat="server" Text="返回" class="button_on" 
                              onclick="back_Click"/>
                      </td>
                  </tr>
            </table>
        </div>
    </form>
</body>
</html>
