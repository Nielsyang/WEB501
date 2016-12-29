﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Download.aspx.cs" Inherits="WebPlat.Management.Download.Download" %>
<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload"
    TagPrefix="Upload" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载</title>
     <link type="text/css" href="../css/right.css" rel="stylesheet" />
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
                $("#tblist").append('<tr ><td  colspan="6" style="text-align:left;" class="tb">下载基本信息</td></tr><tr><th>文件名</th><th>下载地址</th><th>添加时间</th><th>查看详情</th><th>编辑</th><th>删除</th></tr>');
                for (var i = 0; i < jsonArr.length; i++) {
                    var jsondownload = jsonArr[i];
                    var add_time = new Date(parseInt(jsondownload.add_time.replace("/Date(", "").replace(")/", "").split("+")[0]));
                    add_time = add_time.getFullYear() + "年" + (add_time.getMonth() + 1) + "月" + add_time.getDate() + "日 ";
                    $('<tr><td align="center" style="width:29%;">' + jsondownload.filename + "</td>" +
                     '<td style="width:35%;">' + jsondownload.url + "</td>" +
                     '<td  style="width:10%;">' + add_time + "</td>" +
                     '<td align="center" style="cursor:pointer; width:10%;"><a  href="DownloadDetail.aspx?Id=' + jsondownload.id + '"><img alt="查看" src="../images/button_view.gif"/></a></td>' +
                     '<td align="center" style="cursor:pointer; width:10%;"><a  href="DownloadEdit.aspx?Id=' + jsondownload.id + '"><img  alt="编辑" src="../images/i_edit.gif"/></a></td>' +
                     '<td align="center" style="cursor:pointer; width:10%;"><a  id="aa" aid=' + jsondownload.id + '><img alt="删除" src="../images/i_del.gif"/></a></td></tr>').appendTo("#tblist");
                }
            }
            $("#tblist").on("click", "#aa", function () {
                if (confirm("您确定要删除这条记录吗？")) {
                    var id = $(this).attr("aid");
                    window.location.href = "DownloadDelete.aspx?Id=" + id;
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
