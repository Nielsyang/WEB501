<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetailPublication.aspx.cs" Inherits="WebPlat.Management.publication.DetailPublication" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>论文详情</title>
     <link type="text/css" href="../css/right.css" rel="stylesheet"/>
     <script type="text/javascript">
         function retu() {
             window.location.href = "Publicaiton.aspx";
         }
     </script>
</head>
<body>
    <form id="form1" runat="server">
        <table  width="100%">
              <tr>
                   <td colspan="2" style="text-align:left;" class="tb">论文详情</td>
              </tr>
              <tr>
                   <td style="text-align:right; width:15%;">论文题目:</td>
                   <td>
                         <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                   </td>
              </tr>
              <tr>
                 <td style="text-align:right;">论文作者:</td>
                 <td>
                     <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
                 </td>
              </tr>
              <tr>
                  <td style="text-align:right;">论文摘要:</td>
                  <td>
                      <asp:Label ID="Label3" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right;">关键词:</td>
                  <td>
                      <asp:Label ID="Label4" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right;">类型:</td>
                  <td>
                      <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right;">级别:</td>
                  <td>
                      <asp:Label ID="Label6" runat="server" Text=""></asp:Label>
                  </td>
              </tr>
              <tr>
                 <td style="text-align:right;">发表网址:</td>
                 <td>
                     <asp:Label ID="Label7" runat="server" Text=""></asp:Label>
                 </td>
              </tr>
              <tr>
                 <td style="text-align:right;">发表时间:</td>
                 <td>
                     <asp:Label ID="Label8" runat="server" Text=""></asp:Label></td>
              </tr>
              <tr>
                   <td colspan="2" style="text-align:center;">
                       <input id="Button1" type="button" value="返回" class="button_on" onclick="retu();"/>
                   </td>
              </tr>
        </table>
    </form>
</body>
</html>
