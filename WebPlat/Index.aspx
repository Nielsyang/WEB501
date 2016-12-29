<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Test.Index" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="Style/bootstrap.css">
    <link href="Style/jquery-webox.css" rel="stylesheet" type="text/css" />
    <script src="Jquery/jquery-1.10.2.js" type="text/javascript"></script>
    <script src="Jquery/jquery-webox.js" type="text/javascript"></script>
    <title>首页导航</title>
    <style  type="text/css">
         *{margin:0;padding:0;list-style-type:none;}
         a,img{border:0;}
         .mainlist{padding:10px;}
         .mainlist li{height:28px;line-height:28px;font-size:12px;}
         .mainlist li span{margin:0 5px 0 0;font-family:"宋体";font-size:12px;font-weight:400;color:#ddd;}
    </style>
    <script type="text/javascript">
        $(function () {
            //内嵌弹出层调用
            $('#HuaHeWu').click(function () {
                $.webox({
                    height: 280,
                    width: 600,
                    bgvisibel: true,
                    title: '化合物和疾病靶蛋白通路富集分析',
                    html: $("#CompoundBox").html()
                });
            });
            $('#CaoYao').click(function () {
                $.webox({
                    height: 280,
                    width: 600,
                    bgvisibel: true,
                    title: '草药和疾病靶蛋白通路富集分析',
                    html: $("#HerbBox").html()
                });
            });
            $('#FangJi').click(function () {
                $.webox({
                    height: 280,
                    width: 600,
                    bgvisibel: true,
                    title: '方剂和疾病靶蛋白通路富集分析',
                    html: $("#FangJiBox").html()
                });
            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div id="CompoundBox" style="display:none;">
           <div class="mainlist">
             <ul>
                <li><span>▪</span>疾病和化合物对应的靶蛋白富集到通路上的分析。</li>
                <li><span>▪</span>pDValue是疾病对应的超几何分布的阈值，PCValue是化合物对应的阈值。</li>
                <li><span>▪</span>有可能数据量很大</li>
             </ul>
           </div>
           <div style="text-align:center;">
              <a href="Compound.aspx" class="btn btn-default btn-link" >点击进入</a>
           </div>
        </div>
         <div id="HerbBox" style="display:none;">
           <div class="mainlist">
             <ul>
                <li><span>▪</span>疾病和草药对应的靶蛋白富集到通路上的分析。</li>
                <li><span>▪</span>pDValue是疾病对应的超几何分布的阈值，PHValue是化合物对应的阈值。</li>
                <li><span>▪</span>有可能数据量很大</li>
             </ul>
           </div>
           <div style="text-align:center;">
              <a href="Herb.aspx" class="btn btn-default btn-link" >点击进入</a>
           </div>
        </div>
         <div id="FangJiBox" style="display:none;">
           <div class="mainlist">
             <ul>
                <li><span>▪</span>疾病和方剂对应的靶蛋白富集到通路上的分析。</li>
                <li><span>▪</span>pDValue是疾病对应的超几何分布的阈值，PFValue是化合物对应的阈值。</li>
                <li><span>▪</span>有可能数据量很大</li>
             </ul>
           </div>
           <div style="text-align:center;">
              <a href="Formula.aspx" class="btn btn-default btn-link" >点击进入</a>
           </div>
        </div>
        <div style="text-align:center; width:300px; margin-top:20%; margin-left:40%;">
            <a href="#" class="btn btn-large btn-block btn-primary" id="HuaHeWu">化合物</a>
            <a href="#" class="btn btn-large btn-block btn-primary" id="CaoYao">草药</a>
            <a href="#" class="btn btn-large btn-block btn-primary" id="FangJi">方剂</a>
        </div>
    </form>
</body>
</html>
