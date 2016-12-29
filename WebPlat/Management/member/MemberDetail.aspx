<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberDetail.aspx.cs" Inherits="WebPlat.Management.member.MemberDetail" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" href="../css/right.css" rel="stylesheet" />
    <script type="text/javascript">
        function retu() {
            window.location.href = "Member.aspx";
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
         <table width="100%">
                <tr>
                    <td colspan="4" style="text-align:left;" class="tb">人员详细信息</td>
                </tr>
                <tr>
                    <td  style="text-align:right; width:15%;">姓名:</td>
                    <td style="width:35%;">
                        <asp:Label  ID="Name" runat="server" Text=""></asp:Label>
                    </td>
                    <td style="text-align:right;width:15%;" rowspan="5">照片:</td>
                    <td  rowspan="5" style="width:35%;">
                           <img alt="" id="photo" src="" runat="server" style="width:300px;height:150px;"/>
                    </td>
                </tr>
                <tr >
                      <td style="text-align:right;">性别:</td>
                     <td>
                         <asp:Label ID="sex" runat="server" Text="Label"></asp:Label>
                     </td>
                </tr>
                <tr>
                    <td style="text-align:right;">出生日期:</td>
                    <td>
                        <asp:Label ID="birthday" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; height:auto;">籍贯:</td>
                    <td>
                        <asp:Label ID="address" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">学历:</td>
                    <td> 
                        <asp:Label ID="degree" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">毕业学校:</td>
                    <td>
                        <asp:Label ID="college" runat="server" Text="Label"></asp:Label>
                    </td>
                    <td style="text-align:right;">专业:</td>
                    <td>
                        <asp:Label ID="major" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                   <td style="text-align:right;">电子邮件:</td>
                   <td>
                       <asp:Label ID="email" runat="server" Text="Label"></asp:Label>
                   </td>
                   <td style="text-align:right;">添加时间:</td>
                   <td>
                       <asp:Label ID="addtime" runat="server" Text="Label"></asp:Label>
                   </td>
                </tr>
                <tr>
                    <td style="text-align:right;">简历:</td>
                    <td colspan="3">
                        <textarea id="introduce" rows="5" cols="100" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">团队职责:</td>
                    <td colspan="3">
                         <textarea id="assignment" rows="5" cols="100" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center;">
                        <input id="back" type="button" value="返回" class="button_on" onclick="retu();"/>
                    </td>
                </tr>
          </table>
    </form>
</body>
</html>
