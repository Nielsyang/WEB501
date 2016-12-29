<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AboutDataGrid.aspx.cs" Inherits="WebPlat.Management.BasicInfo.About3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link type="text/css" href="../css/right.css" rel="stylesheet"/>
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/default/easyui.css" />  
    <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/icon.css" /> 
     <link rel="stylesheet" type="text/css" href="../../jqueryuipage/themes/color.css" /> 
    <script type="text/javascript" src="../../jqueryuipage/jquery.min.js"></script>  
    <script type="text/javascript" src="../../jqueryuipage/jquery.easyui.min.js"></script>  
    <title>网站基本信息</title>
    <script type="text/javascript">
        $(function () {
            $('#list_data').datagrid({
                title: "网站基本信息",
                loadMsg: "正加载，请稍等...",
                iconCls: "icon-edit",
                height: "auto",
                nowrap: false,
                striped: true,
                border: true,
                collapsible: false,
                fit: true,
                singleSelect: true,
                rownumbers: true,
                columns: [[
                    { field: 'Id', title: '编号', width: 80 },
                    { field: 'Title', title: '标题', width: 200 },
                    { field: 'Content', title: '内容', width: 600 },
                    { field: 'Add_time', title: '添加时间', width: 200,
                        formatter: function renderTime(date) {
                            var da = new Date(parseInt(date.replace("/Date(", "").replace(")/", "").split("+")[0]));
                            //return da.getFullYear() + "-" + (da.getMonth() + 1) + "-" + da.getDate() + " " + da.getHours() + ":" + da.getSeconds() + ":" + da.getMinutes();
                            return da.getFullYear() + "年" + (da.getMonth() + 1) + "月" + da.getDate() + "日 ";
                        }
                    }
                    ]],
                url: "getPageData.ashx",
                remoteSort: false,
                idField: 'Id',
                toolbar: [{
                    text: '添加',
                    iconCls: 'icon-add',
                    handler: function () {
                        newAbout();
                    }
                }, '-', {
                    text: '修改',
                    iconCls: 'icon-edit',
                    handler: function () {
                        editAbout();
                    }
                }, '-', {
                    text: '删除',
                    iconCls: 'icon-remove',
                    handler: function () {
                        destroyAbout();
                    }
                }],
                pagination: true, //分页控件  
                rownumbers: true//行号  
            });
            // 设置分页控件         
            var p = $('#list_data').datagrid('getPager');
            $(p).pagination({
                pageSize: 5, //每页显示的记录条数，默认为10             
                pageList: [5, 10, 15], //可以设置每页记录条数的列表             
                beforePageText: '第', //页数文本框前显示的汉字             
                afterPageText: '页    共 {pages} 页',
                displayMsg: '当前显示 {from} - {to} 条记录   共 {total} 条记录'
            });
            function newAbout() {
                $('#dlg').dialog('open').dialog('setTitle', '添加基本信息');
                $('#fm').form('clear');
                url = 'save_user.php';
            }
            function editAbout() {
                var row = $('#dg').datagrid('getSelected');
                if (row) {
                    $('#dlg').dialog('open').dialog('setTitle', '编辑基本信息');
                    $('#fm').form('load', row);
                    url = 'update_user.php?id=' + row.id;
                }
            }
            function saveAbout() {
                $('#fm').form('submit', {
                    url: "",
                    onSubmit: function () {
                        return $(this).form('validate');
                    },
                    success: function (result) {
                        var result = eval('(' + result + ')');
                        if (result.errorMsg) {
                            $.messager.show({
                                title: 'Error',
                                msg: result.errorMsg
                            });
                        } else {
                            $('#dlg').dialog('close');        // close the dialog
                            $('#dg').datagrid('reload');    // reload the user data
                        }
                    }
                });
            }
            function destroyAbout() {
                var row = $('#dg').datagrid('getSelected');
                if (row) {
                    $.messager.confirm('Confirm', 'Are you sure you want to destroy this user?', function (r) {
                        if (r) {
                            $.post('destroy_user.php', { id: row.id }, function (result) {
                                if (result.success) {
                                    $('#dg').datagrid('reload');    // reload the user data
                                } else {
                                    $.messager.show({    // show error message
                                        title: 'Error',
                                        msg: result.errorMsg
                                    });
                                }
                            }, 'json');
                        }
                    });
                }
            }
        }); 
    </script>
    <style type="text/css">
        #fm{
            margin:0;
            padding:10px 30px;
        }
        .ftitle{
            font-size:14px;
            font-weight:bold;
            padding:5px 0;
            margin-bottom:10px;
            border-bottom:1px solid #ccc;
        }
        .fitem{
            margin-bottom:5px;
        }
        .fitem label{
            display:inline-block;
            width:80px;
        }
        .fitem input{
            width:160px;
        }
    </style>
</head>
<body>
         <table id="list_data" cellspacing="0" cellpadding="0" width="100%">  
            <thead>  
                <tr>  
                    <th field="Id" width="80">编号</th>  
                    <th field="Title" width="300">标题</th>  
                    <th field="Content" width="600">内容</th>  
                    <th field="Add_time" width="300">添加时间</th>
                </tr>  
            </thead>  
       </table>
       <div id="dlg" class="easyui-dialog" style="width:800px;height:400px;padding:10px 20px"
             closed="true" buttons="#dlg-buttons">
        <div class="ftitle">网站基本信息</div>
        <form id="fm" method="post" action="#">
            <div class="fitem">
                <label>标题:</label>
                <input  name="Title" class="easyui-textbox" required="true"/>
            </div>
            <div class="fitem">
                <label>内容:</label>
                <input  name="Content" class="easyui-textbox" required="true"/>
            </div>
            <div class="fitem">
                <label>添加时间:</label>
                <input  name="Add_time"  class="easyui-datebox"/>
            </div>
        </form>
    <div id="dlg-buttons">
        <a href="javascript:void(0)" class="easyui-linkbutton c6" iconCls="icon-ok" onclick="saveAbout()" style="width:90px">保存</a>
        <a href="javascript:void(0)" class="easyui-linkbutton" iconCls="icon-cancel" onclick="javascript:$('#dlg').dialog('close')" style="width:90px">取消</a>
    </div>
</body>
</html>
