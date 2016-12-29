<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="syndroms pre.aspx.cs" Inherits="WebPlat.syndroms_pre" %>
<%@ Register Src="top.ascx" TagName="head" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Syndromes Predict</title>
</head>
<body>
        <uc1:head ID="head2" runat="server" />
        <div class="tweetarea">
		     <div class="tweettext"></div>
	    </div>

        <div style="padding-top:35px">
        <form id='prediction' runat='server'>
        症状
        <table>
        <tr>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox_1"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox_2"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox_3"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox_4"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox1"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox2"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox3"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox4"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox5"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox6"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox7"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox8"/>
            </td>
        </tr>
        <tr>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox9"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox10"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox11"/>
            </td>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox12"/>
            </td>
        </tr>
        </table>

        <table>
        <tr>
            <td>
                <asp:TextBox class="zz" runat="server" ID="textbox13" TextMode="MultiLine"/>
            </td>

        </tr>
        <tr style="text-align:center;">
                            <td colspan="4">
                            <asp:Button ID="Button1" runat="server" Text="提交"
                            onclick="Button1_Click"/>
                            </td>
        </tr>
        </table>
        </form>
        </div>
</body>
</html>
