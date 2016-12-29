<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testpost.aspx.cs" Inherits="WebPlat.testpost" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
            <title>网络的底部模板</title>
                <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script type="text/javascript" src="http://code.jquery.com/jquery-1.12.4.js"></script>
        <script type="text/ecmascript" src="http://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css">
        <script type="text/javascript" src="Jquery/jquery-1.10.2.min.js"></script>
        <script type="text/javascript">
            $(function () {
                var Type = "Herb";
                $.ajax(
                {
                    url: 'ajax/GetCompoundAndHerb.ashx',
                    type: 'post',
                    data: { "analyse_type" : "Herb" },
                    dataType: 'json',
                    timeout: 1000,
                    error: function () { alert("error"); },
                    success: function (result) { alert(result[1]); }
                });
            });

        </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    </form>
</body>
</html>
