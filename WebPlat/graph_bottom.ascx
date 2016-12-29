<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="graph_bottom.ascx.cs" Inherits="WebPlat.graph_bottom" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
    <head>
        <meta charset="utf-8"/>
        <title>网络的底部模板</title>
                <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script type="text/javascript" src="http://code.jquery.com/jquery-1.12.4.js"></script>
        <script type="text/ecmascript" src="http://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css">
        <style type="text/css">
        .ui-autocomplete
        {
            max-height: 260px;
            overflow-y: auto;
            overflow-x: hidden; 
        }
        </style>
        <script type="text/javascript">
            $(function () {
                var Type = $(".category").text();
                $.ajax(
                {
                    url: 'ajax/GetCompoundAndHerb.ashx',
                    type: 'post',
                    data: { "analyse_type": Type },
                    dataType: 'text',
                    timeout: 5000,
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        //              $("#p_test").innerHTML = "there is something wrong!";
                                        alert(XMLHttpRequest.status);
                                        alert(XMLHttpRequest.readyState);
                                        alert(textStatus);
                    },
                    success: function (data) {
                        $(".textbox").autocomplete({ source: data.split(","), 
                                                     minLength: 1,
                                                     delay: 100,
                                                     max: 15 });

                    }
                });
                $.ajax(
                {
                    url: 'ajax/GetDiseaseName.ashx',
                    type: 'post',
                    //data: {"required_data" : "all_disease_name"},
                    dataType: 'text',
                    timeout: 1000,
                    error: function () { alert("error_Disease"); },
                    success: function (data) {
                        $(".disease_textbox").autocomplete({ source: data.split(","),
                            minLength: 1,
                            delay: 100,
                            max: 15
                        });

                    }
                });
            });

        </script>
    </head>
    <body>
        <div id="shell" style="width: 100%; height: 400px">
        <div id="choose" style="width:50%; height: 400px; float: left">
        <form id="form1" runat="server" style="width: 100%; padding-top:10px; padding-left:10px">
        <asp:Label class="category" ID="lable" runat="server" Text=""></asp:Label>
        <table style="padding-top: 10px">
            <tr>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text1box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text2box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text3box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text4box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text5box"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text6box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text7box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text8box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text9box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text10box"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text11box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text12box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text13box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text14box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text15box"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text16box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text17box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text18box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text19box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text20box"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text21box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text22box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text23box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text24box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text25box"/>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text26box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text27box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text28box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text29box"/>
                </td>
                <td>
                    <asp:TextBox class="textbox" runat="server" ID="text30box"/>
                </td>
            </tr>
        </table>
        <table>
            <tr>
                <asp:Label ID="Label1" runat="server" Text="Disease"></asp:Label>
                <asp:TextBox class="disease_textbox" runat="server" ID="textbox31"/>
            </tr>
        </table>
        <table>
            <tr>
                <asp:Label ID="Label2" runat="server" Text="Tissue"></asp:Label>
                <asp:TextBox class="tissue_textbox" runat="server" ID="textbox32"/>
            </tr>
        </table>
        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="ButtonClick" />
</form>
</div>
<div id="graph" style="width: 50%; height: 400px; float: left">
</div>

</div>
</body>
</html>