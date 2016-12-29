<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutAdd.aspx.cs" Inherits="WebPlat.Management.BasicInfo.aboutAdd" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="../css/right.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/default/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/icon.css" /> 
     <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/color.css" /> 
    <script type="text/javascript" src="../../jqueryuipage/jquery.min.js"></script>  
    <script type="text/javascript" src="../../jqueryuipage/jquery.easyui.min.js"></script>  
   <script  type="text/javascript">
       function retu() {
           window.location.href = "About.aspx";
       }
   </script>
</head>
<body>
   <form  id="form1"  runat="server">
        <table width="100%" style="height: 121px">
                <tr>
                    <td colspan="2" style="text-align:left;" class="tb">添加网站基本信息</td>
                </tr>
               <tr>
                  <td style="text-align:right; width:100px;">标题:</td>
                  <td>
                      <textarea  id="title" rows="5" runat="server" cols="50" class="inpt"/>
                  </td>
               </tr>
               <tr>
                   <td style="text-align:right;">内容:</td>
                   <td>
                       <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" class="inpt"></CKEditor:CKEditorControl>
                   </td>
               </tr>
               <tr>
                  <td style="text-align:right;" class="style1">添加时间:</td>
                  <td>
                       <input  id="Add_time" class="easyui-datebox" runat="server" style="width:200px;"/>
                  </td>
               </tr>
               <tr align="center">
                  <td colspan="2">
                        <asp:Button ID="submit" runat="server" Text="添加" class="button_on" OnClick="about_add"/>&nbsp;
                        <input type="reset" value="重置" class="button_on"  runat="server"/>&nbsp;
                        <input type="button" value="返回" class="button_on"  runat="server" onclick="retu();" />
                  </td>
               </tr>
        </table>
   </form>
</body>
</html>
