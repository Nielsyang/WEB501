<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="getCytoscapeWeb.aspx.cs" Inherits="WebPlat.disease.getCytoscapeWeb" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <meta http-equiv="Content-Type" content="text/html; charset=GBK"/>     
        <title>Cytoscape Web &#187; Demos &#187; Simple</title>
        <link rel="shortcut icon" href="http://cytoscapeweb.cytoscape.org/img/layout/favicon.png"/>
         <link rel="stylesheet" href="../stylesheets/style.css"/>
        <link rel="stylesheet" href="../stylesheets/homepage.css"/>
        <link rel="stylesheet" href="../stylesheets/skins/teal.css"/>
        <link rel="stylesheet" href="../stylesheets/responsive.css"/>
        <script type="text/javascript" src="../Cytoscapejs/jquery-1.3.2.min.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/jquery.qtip-1.0.0-rc3.min.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/layout.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/json2.min.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/AC_OETags.min.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/cytoscapeweb.min.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/ga.js"></script>
        <script type="text/javascript" src="../Cytoscapejs/ga(1).js"></script>
        <script  type="text/javascript">
            $(function () {
                var div_id = "cytoscapeweb";
                var vis;
                // options used for Cytoscape Web
                var options = {
                    nodeTooltipsEnabled: true,
                    edgeTooltipsEnabled: true,
                    panZoomControlVisible: true,
                    edgesMerged: false
                };
                function draw(data) {
                    var xgmml = $("#xgmmlurl").val();
                    if (xgmml != "") {
                    $("input, select").attr("disabled", true);
                    if (data) {
                        options.layout = { name: "ForceDirected" };
                        options.network = data;
                        options.nodeLabelsVisible = $("#showNodeLabels").is(":checked");
                        d1 = new Date();
                        vis.draw(options);
                    } else {
                        var url = "../result_S/" + xgmml;
                        $.get(url, function (dt) {
                            if (typeof dt !== "string") {
                                if (window.ActiveXObject) {
                                    dt = dt.xml;
                                } else {
                                    dt = (new XMLSerializer()).serializeToString(dt);
                                }
                            }
                            draw(dt);
                        });
                        }
                    }
                }
                $("input").attr("disabled", true);
                // init and draw
                vis = new org.cytoscapeweb.Visualization(div_id, { swfPath: "../Cytoscapejs/swf/CytoscapeWeb" });
                vis.ready(function () {
                    var layout = vis.layout();
                    $("#layouts").val(layout.name);
                    $("input, select").attr("disabled", false);
                    $("#showNodeLabels").attr("checked", vis.nodeLabelsVisible());
                });
                vis.addListener("error", function (err) {
                    alert(err.value.msg);
                });
                // Register control liteners:
                $("#layouts").change(function (evt) {
                    vis.layout($("#layouts").val());
                });
                $("#showNodeLabels").change(function (evt) {
                    vis.nodeLabelsVisible($("#showNodeLabels").is(":checked"));
                });
                draw();
            });
    </script>     
</head>
<body>
       <div class="row">
          <div class="six columns">
                Layout:
                <select id="layouts">                
                <option value="ForceDirected" selected="selected">Force Directed</option>                
                <option value="Circle">Circle</option>                
                <option value="Radial">Radial</option>                
                <option value="Tree">Tree</option>            
                </select>
           </div>
            <div  class="six  columns">
                  Node Labels:         
                 <input type="checkbox" id="showNodeLabels" checked="checked"/>   
           </div>
           <div id="cytoscapeweb"  style="height:500px;width:100%;background-color:ButtonShadow;" >
           </div>  
       </div>
   <input type="hidden" id="xgmmlurl"  value="<%=xgmmlurl %>"/>
</body>
</html>
