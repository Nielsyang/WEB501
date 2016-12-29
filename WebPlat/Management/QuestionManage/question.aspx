<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="question.aspx.cs" Inherits="WebPlat.Management.QuestionManage.question" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css"  href="../css/right.css" rel="stylesheet"/>
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
                $("#tblist").append('<tr ><td  colspan="6" style="text-align:left;" class="tb">问题信息管理</td></tr><tr><th>提问者</th><th>邮件</th><th>主题</th><th>提问时间</th><th>查看详情</th><th>删除</th></tr>');
                for (var i = 0; i < jsonArr.length; i++) {
                    var jsonquestion = jsonArr[i];
                    var sendtime = new Date(parseInt(jsonquestion.Send_time.replace("/Date(", "").replace(")/", "").split("+")[0]));
                    sendtime = sendtime.getFullYear() + "年" + (sendtime.getMonth() + 1) + "月" + sendtime.getDate() + "日 ";
                    $('<tr><td align="center" style="width:16%;">' + jsonquestion.Name + "</td>" +
            '<td style="width:16%;text-align:center;">' + jsonquestion.Email + "</td>" +
            '<td style="width:20%;text-align:center;">' + jsonquestion.Subject + "</td>" +
            '<td style="width:16%;text-align:center;">' + sendtime + "</td>" +
            '<td align="center" style="cursor:pointer; width:16%;"><a  href="QuestionDetail.aspx?Id=' + jsonquestion.Id + '"><img alt="查看" src="../images/button_view.gif"/></a></td>' +
            '<td align="center" style="cursor:pointer; width:16%;"><a  id="aa" aid=' + jsonquestion.Id + '><img alt="删除" src="../images/i_del.gif"/></a></td></tr>').appendTo("#tblist");
                }
            }
            $("#tblist").on("click", "#aa", function () {
                if (confirm("您确定要删除这条记录吗？")) {
                    var id = $(this).attr("aid");
                    window.location.href = "QuestionDelete.aspx?Id=" + id;
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
