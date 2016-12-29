<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebSite.aspx.cs" Inherits="WebPlat.Management.Website.webSite" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>相关网站管理</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/default/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/icon.css" />  
    <script type="text/javascript" src="../../jqueryuipage/jquery.min.js"></script>  
    <script type="text/javascript" src="../../jqueryuipage/jquery.easyui.min.js"></script> 
    <script type="text/javascript">
        $(function () {
            var total = $("#total").val();
            $.post("getPageData.ashx", { "page": 1, "rows": 5 },
                                            function (data) {
                                                var jsonArr = $.parseJSON(data);
                                                makeTable(jsonArr);
                                            });
            $('#pp').pagination({
                total: total,
                pageSize: 5,
                pageList: [5, 10, 15],
                beforePageText: '第', //页数文本框前显示的汉字             
                afterPageText: '页    共 {pages} 页',
                displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录',
                onSelectPage: function (pageNumber, pageSize) {
                    $.post("getPageData.ashx", { "page": pageNumber, "rows": pageSize },
                                            function (data) {
                                                var jsonArr = $.parseJSON(data);
                                                makeTable(jsonArr);
                                            });
                }
            });
            function makeTable(jsonArr) {
                $("#tblist").empty();
                $("#tblist").append('<tr ><td  colspan="5" style="text-align:left;" class="tb">相关网站基本信息</td></tr><tr><th>网站名称</th><th>网址</th><th>网站Logo</th> <th>编辑</th><th>删除</th></tr>');
                for (var i = 0; i < jsonArr.length; i++) {
                    var jsonwebsite = jsonArr[i];
                    $('<tr><td align="center" style="width:20%;">' + jsonwebsite.web_name + "</td>" +
                     '<td style="width:35%; text-align:center;">' + jsonwebsite.link + "</td>" +
                     '<td style="width:15%;text-align:center;"><img alt="" src="../../' + jsonwebsite.logo + '"  height="40px" width="70px" /></td>' +
                     '<td align="center" style="cursor:pointer; width:15%;"><a  href="edit_WebSite.aspx?Id=' + jsonwebsite.id + '"><img  alt="编辑" src="../images/i_edit.gif"/></a></td>' +
                     '<td align="center" style="cursor:pointer; width:15%;"><a  id="aa" aid=' + jsonwebsite.id + '><img alt="删除" src="../images/i_del.gif"/></a></td></tr>').appendTo("#tblist");
                }
            }
            $("#tblist").on("click", "#aa", function () {
                if (confirm("您确定要删除这条记录吗？")) {
                    var id = $(this).attr("aid");
                    window.location.href = "delete_WebSite.aspx?Id=" + id;
                }
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
             <table width="100%" id="tblist" runat="server">
             </table>
             <div  id="pp"  style="background:#efefef;border:1px solid #ccc;"></div>
             <input type="hidden" id="total" value="<%=total%>"/>
    </form>
</body>
</html>
