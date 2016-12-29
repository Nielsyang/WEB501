<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPublication.aspx.cs" Inherits="WebPlat.Management.publication.EditPublication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>编辑论文</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/default/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/icon.css" /> 
     <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/color.css" /> 
    <script type="text/javascript" src="../../jqueryuipage/jquery.min.js"></script>  
    <script type="text/javascript" src="../../jqueryuipage/jquery.easyui.min.js"></script>
    <script type="text/javascript">
        function retu() {
            window.location.href = "Publicaiton.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <input type="hidden" id="hid" runat="server" />
          <table width="100%">
              <tr>
                 <td colspan="2" style="text-align:left" class="tb">修改论文基本信息</td>
              </tr>
              <tr>
                 <td style="text-align:right; width:15%;">论文题目:</td>
                 <td>
                      <input id="paperName" type="text" runat="server" class="inpt" />
                 </td>
              </tr>
              <tr>
                 <td style="text-align:right;">论文作者:</td>
                 <td>
                     <input id="author" type="text" runat="server" class="inpt"/>
                 </td>
              </tr>
              <tr>
                   <td style="text-align:right;">摘要:</td>
                   <td>
                       <textarea id="Abstract" cols="35" rows="10" runat="server"></textarea>
                   </td>
                </tr>
                <tr>
                  <td style="text-align:right;">关键词:</td>
                  <td>
                      <textarea id="keyword" cols="35" rows="5" runat="server"></textarea>
                  </td>
                </tr>
                <tr>
                   <td style="text-align:right;">类型:</td>
                   <td>
                       <input id="type" type="text" runat="server" class="inpt"/>
                   </td>
                </tr>
                <tr>
                   <td style="text-align:right;">级别:</td>
                   <td>
                     <input type="text" id="level" runat="server" class="inpt" />
                   </td>
                </tr>
                <tr>
                   <td style="text-align:right;">发表网址:</td>
                   <td>
                       <input id="url" type="text" runat="server" class="inpt"/>
                   </td>
                </tr>
                <tr>
                   <td style="text-align:right;">发表时间:</td>
                   <td>
                         <input  id="publish_time"  class="easyui-datebox" runat="server" style="width:263px;"/>
                   </td>
                </tr>
                <tr>
                   <td colspan="2" style="text-align:center;">
                       <asp:Button ID="Button1" runat="server" Text="修改" class="button_on" OnClick="editPublication"/>&nbsp;
                       <asp:Button ID="Button2" runat="server" Text="重置" class="button_on" OnClick="Reset"/>&nbsp;
                       <input id="Button3" type="button" value="返回" onclick="retu();" class="button_on"/>
                   </td>
                </tr>
          </table>
    </form>
</body>
</html>
