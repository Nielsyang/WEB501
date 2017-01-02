<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GenerateNet.aspx.cs" Inherits="WebPlat.GenerateNet" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
        <meta charset="utf-8">
        <title>Generate Net</title>
        <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.1/themes/base/jquery-ui.css">
        <script type="text/javascript" src="http://code.jquery.com/jquery-1.12.4.js"></script>
        <script type="text/ecmascript" src="http://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
        <link rel="stylesheet" href="http://jqueryui.com/resources/demos/style.css">
        <style>
        .ui-autocomplete
        {
            max-height: 260px;
            overflow-y: auto;
            overflow-x: hidden; 
        }
        text 
        {
           font: "Arial Unicode", Arial, Unicode, sans-serif;
           pointer-events: none;
        }

        line 
        {
            stroke: black;
            stroke-opacity: 0.6;
            stroke-width: 1px;
        }
        </style>
<script type="text/javascript">
    $(function () {
        $.ajax(
                {
                    url: 'ajax/GetDiseaseName.ashx',
                    type: 'post',
                    data: {},
                    dataType: 'text',
                    timeout: 3000,
                    error: function () { alert("error_D"); },
                    success: function (data) {
                        $(".DTextbox").autocomplete({ source: data.split(","),
                            minLength: 1,
                            delay: 100,
                            max: 15
                        });

                    }
                });
        $.ajax(
                {
                    url: 'ajax/GetAllFormulaName.ashx',
                    type: 'post',
                    //data: { "required_data": "all_disease_name" },
                    dataType: 'text',
                    timeout: 3000,
                    error: function () { alert("error_F"); },
                    success: function (data) {
                        $(".FTextbox").autocomplete({ source: data.split(","),
                            minLength: 1,
                            delay: 100,
                            max: 15
                        });

                    }
                });

        $.ajax(
                {
                    url: 'ajax/GetAllTissueName.ashx',
                    type: 'post',
                    //data: { "required_data": "all_disease_name" },
                    dataType: 'text',
                    timeout: 3000,
                    error: function () { alert("error_T"); },
                    success: function (data) {
                        $(".TTextbox").autocomplete({ source: data.split(","),
                            minLength: 1,
                            delay: 100,
                            max: 15
                        });

                    }
                });

        $.ajax(
                {
                    url: 'ajax/GetAllHerbName.ashx',
                    type: 'post',
                    //data: { "required_data": "all_disease_name" },
                    dataType: 'text',
                    timeout: 3000,
                    error: function () { alert("error_H"); },
                    success: function (data) {
                        $(".HTextbox").autocomplete({ source: data.split(","),
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
    <form id="form1" runat="server">
    <input type="hidden" id="JsonLinks" value="" runat="server"/>
    <input type="hidden" id="JsonNodes" value="" runat="server"/>
    <table border="1">
        <tr>
            <td style="text-align:center;">
                <asp:Label ID="Disease" runat="server" Text="Disease:"></asp:Label>
            </td>
            <td>
                <asp:TextBox class="DTextbox" runat="server" ID="Dbox" OnTextChanged="Dbox_onchanged" AutoPostBack="true"/>
                <asp:Label ID="DiseaseCnEn" runat="server" Text=""></asp:Label>
            </td>

        </tr>
        <tr> 
            <td style="text-align:center;">
                <asp:Label ID="formula" runat="server" Text="Formula:"></asp:Label>
            </td>
            <td>
                <asp:TextBox class="FTextbox" runat="server" ID="Formulatextbox"/>
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
                <asp:Label ID="herb" runat="server" Text="Herb:"></asp:Label>
            </td>
            <td>
                <asp:TextBox class="HTextbox" runat="server" ID="Herbtextbox"/>
            </td>
        </tr>
                <tr>
            <td style="text-align:center;">
                <asp:Label ID="Tissue" runat="server" Text="Tissue:"></asp:Label>
            </td>
            <td>
                <asp:TextBox class="TTextbox" runat="server" ID="Tissuetextbox"/>
            </td>
        </tr>
        <tr style="text-align:center;">
            <td>
                <input id="Radio1" name="type" value="Disease" type="radio" runat="server"/>Disease
            </td>
            <td>
                <input id="Radio2" name="type" value="Tissue" type="radio" runat="server" />Tissue
            </td>
            <td>
                <input id="Radio3" name="type" value="DiseaseAndTissue" checked="true"  type="radio" runat="server"/>DiseaseAndTissue
            </td>
        </tr>
        <tr style="text-align:center;">
            <td>
                <input id="Radio4" name="Analyse_type" value="Formula" type="radio" runat="server"/>Formula
            </td>
            <td>
                <input id="Radio5" name="Analyse_type" value="Herb" type="radio" runat="server" />Herb
            </td>
        </tr>
        <tr>
            <td style="text-align:center;">
            <asp:Label ID="Label1" runat="server" Text="PValue_Disease"></asp:Label>
            <asp:DropDownList ID="PDiseaseDropdown" runat="server" Width="100px">
                <asp:ListItem>don't care</asp:ListItem>
                <asp:ListItem>0.05</asp:ListItem>
                <asp:ListItem>0.01</asp:ListItem>
                <asp:ListItem>0.001</asp:ListItem>
                <asp:ListItem>0.0001</asp:ListItem>
                <asp:ListItem>0.00001</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td style="text-align:center;">
            <asp:Label ID="Label2" runat="server" Text="PValue_Tissue"></asp:Label>
            <asp:DropDownList ID="PTissueDropdown" runat="server" Width="100px">
                <asp:ListItem>don't care</asp:ListItem>
                <asp:ListItem>0.05</asp:ListItem>
                <asp:ListItem>0.01</asp:ListItem>
                <asp:ListItem>0.001</asp:ListItem>
                <asp:ListItem>0.0001</asp:ListItem>
                <asp:ListItem>0.00001</asp:ListItem>
            </asp:DropDownList>
            </td>
            <td style="text-align:center;">
            <asp:Label ID="Label3" runat="server" Text="Node Shape"></asp:Label>
            <asp:DropDownList ID="node_shape" runat="server" Width="100px">
                <asp:ListItem>circle</asp:ListItem>
                <asp:ListItem>rectangle</asp:ListItem>
                <asp:ListItem>oval</asp:ListItem>
            </asp:DropDownList>
            </td>
        </tr>
        <tr style="text-align:center;">
            <td colspan="6">
            <asp:Button ID="Button1" runat="server" Text="提交"
            onclick="Button1_Click"/>
            </td>
        </tr>
        <tr>
        <td>
            <asp:Label ID="LabelF" runat="server" Text="FormulaNode"></asp:Label>
            <asp:Label ID="LabelFN" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelH" runat="server" Text="HerbNode"></asp:Label>
            <asp:Label ID="LabelHN" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelC" runat="server" Text="CompoundNode"></asp:Label>
            <asp:Label ID="LabelCN" runat="server" Text=""></asp:Label>
        </td>
        <td>
            <asp:Label ID="LabelT" runat="server" Text="TargetNode"></asp:Label>
            <asp:Label ID="LabelTN" runat="server" Text=""></asp:Label>
        </td>
        </tr>
        </table>
    </form>

    <svg width="1500" height="1000"></svg>
    <script type="text/javascript" src="https://d3js.org/d3.v4.min.js"></script>
    <script type="text/javascript">
        var svg = d3.select("svg"),
            width = +svg.attr("width"),
            height = +svg.attr("height"),
            color = d3.scaleOrdinal(d3.schemeCategory10);
        var nodes_str = $("#JsonNodes").val(),
            links_str = $("#JsonLinks").val(),
            nodes_to_inds = [];

        var nodes_array = nodes_str.split(";"),
            links_array = links_str.split(";"),
            index = 0;

        var d = document.getElementById("node_shape");
        var shapeValue = d.options[d.selectedIndex].value;
        if (shapeValue == "rectangle")
            shapeValue = "rect";
         
        for (i in nodes_array) {
            nodes_to_inds[nodes_array[i].split("~")[0].toLowerCase()] = index
            index++
        }

        var temp_node = new Object(),
            temp_link = new Object();

        temp_node.id = nodes_array[0].split("~")[0];
        temp_node.r = "40";
        temp_node.img = "NodeImg/" + temp_node.id + ".jpg"

        var nodes = [],
            links = [];

        var nodet,
            nodeq,
            node_enter_g;

        nodes.push(temp_node);

        var simulation = d3.forceSimulation()
        .force("charge", d3.forceManyBody().strength(-380))
        .force("link", d3.forceLink(links).distance(95))
        .force("x", d3.forceX())
        .force("y", d3.forceY())
        .alphaTarget(0.6)
        .on("tick", ticked);

        var g = svg.append("g").attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");
        link_ = g.append("g").attr("stroke", "#000").attr("stroke-width", 1.5);
        //            node = g.append("g").attr("stroke", "#fff").attr("stroke-width", 1.5).selectAll(".mynode");

        restart();

        d3.timeout(function () {
            for (var i = nodes.length; i < nodes_array.length && nodes_array[i].split("~")[1] == "2"; i++) {
                var temp_node_ = new Object();
                temp_node_.id = nodes_array[i].split("~")[0];
                temp_node_.r = "25";
                temp_node_.img = "NodeImg/" + temp_node_.id + ".jpg"
                nodes.push(temp_node_);
                temp_node_ = null;
            }


            for (var i = 0; i < links_array.length && links_array[i].split("~")[2] == "1"; i++) {
                var temp_link_ = new Object();
                temp_link_.source = nodes_to_inds[links_array[i].split("~")[0].toLowerCase()];
                temp_link_.target = nodes_to_inds[links_array[i].split("~")[1].toLowerCase()];
                links.push(temp_link_);
                temp_link_ = null;
            }

            //alert(nodes[1].id)
            //alert(links[1].target)

            restart();
        }, 1000);



        d3.timeout(function () {
            for (var i = nodes.length; i < nodes_array.length && nodes_array[i].split("~")[1] == "3"; i++) {
                var temp_node_ = new Object();
                temp_node_.id = nodes_array[i].split("~")[0];
                temp_node_.r = "24";
                temp_node_.img = "NodeImg/" + temp_node_.id + ".jpg"
                nodes.push(temp_node_);
                temp_node_ = null;
            }

            for (var i = links.length; i < links_array.length && links_array[i].split("~")[2] == "2"; i++) {
                var temp_link_ = new Object();
                temp_link_.source = nodes_to_inds[links_array[i].split("~")[0].toLowerCase()];
                temp_link_.target = nodes_to_inds[links_array[i].split("~")[1].toLowerCase()];
                links.push(temp_link_);
                temp_link_ = null;
            }

            restart();
        }, 2000);

        //alert("3")
        //alert(nodes.length)
        d3.timeout(function () {
            for (var i = nodes.length; i < nodes_array.length && nodes_array[i].split("~")[1] == "4"; i++) {
                //alert("access")
                var temp_node_ = new Object();
                temp_node_.id = nodes_array[i].split("~")[0];
                temp_node_.r = "16";
                temp_node_.img = "NodeImg/" + temp_node_.id + ".jpg"
                nodes.push(temp_node_);
                //alert(nodes.length)
                temp_node_ = null;
            }
            //alert(links_array[22].split("~")[2])
            for (var i = links.length; i < links_array.length && links_array[i].split("~")[2] == "3"; i++) {
                //alert("a")
                var temp_link_ = new Object();
                temp_link_.source = nodes_to_inds[links_array[i].split("~")[0].toLowerCase()];
                temp_link_.target = nodes_to_inds[links_array[i].split("~")[1].toLowerCase()];
                links.push(temp_link_);
                //alert(links.length)
                temp_link_ = null;
            }

            restart();
        }, 3000);

        d3.timeout(function () { simulation.stop(); }, 25000);

        function restart() {


            // Apply the general update pattern to the nodes.
            // node = node.data(nodes, function (d) { return d.id; });
            // node.exit().remove();
            // node = node.enter().append("circle").attr("fill", function (d) { return color(d.id); }).attr("r", 8).merge(node);

            node = g.selectAll(".mynode");
            link = link_.selectAll(".mylink");
            nodeq = node.data(nodes, function (d) { return d.id; });
            nodeq.exit().remove();
            node_enter_g = nodeq.enter().append("g").attr("class", "mynode").merge(nodeq);
            node_shape = node_enter_g.append(shapeValue).attr("fill", function (d, i) {
                if (d.r != 40)
                    return "aquamarine";
                else {
                    var defs = svg.append("defs").attr("id", "imgdefs")
                    var img_h = 80
                    var img_w = 80
                    var catpattern = defs.append("pattern").attr("id", "catpattern" + i)
                                                       .attr("height", 1)
                                                       .attr("width", 1)

                    catpattern.append("image").attr("x", -(img_w / 2 - d.r))
                                          .attr("y", -(img_h / 2 - d.r))
                                          .attr("width", img_w)
                                          .attr("height", img_h)
                                          .attr("xlink:href", d.img)

                    return "url(#catpattern" + i + ")";
                }
            }); //.attr("r", function (d) { return d.r; });
            if (shapeValue == "circle") {
                node_shape = node_shape.attr("r", function (d) { return d.r; });
            }
            else if (shapeValue == "rect") {
                node_shape = node_shape.attr("width", function (d) { return d.r; }).attr("height", function (d) { return d.r; });
            }
            nodet = node_enter_g.append("text").attr("font-size", function (d) { return d.r / 2 > 10 ? (d.r / 2 + "px") : "10px"; }).attr("dy", ".35em").style("text-anchor", "middle").text(function (d) { return d.id; });

            // Apply the general update pattern to the links.
            link = link.data(links, function (d) { return d.source.id + "-" + d.target.id; });
            link.exit().remove();
            link = link.enter().append("line").attr("class", "mylink").merge(link);

            // Update and restart the simulation.
            simulation.nodes(nodes);
            simulation.force("link").links(links);
            simulation.alpha(1).restart();
        }

        function ticked() {
            //    node.attr("cx", function (d) { return d.x; })
            //        .attr("cy", function (d) { return d.y; })

            node_enter_g.attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")" });

            link.attr("x1", function (d) { return compute(d, "sx"); })
                .attr("y1", function (d) { return compute(d, "sy"); })
                .attr("x2", function (d) { return compute(d, "tx"); })
                .attr("y2", function (d) { return compute(d, "ty"); });

            //svg_texts.attr("x", function (d) { return d.x; })
            //        .attr("y", function (d) { return d.y; });
        }

        function compute(d, cls) {
            if (cls == "sx") {
                if (d.source.x > d.target.x) {
                    return d.source.x - Math.abs(d.source.x - d.target.x) * d.source.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else if (d.source.x < d.target.x) {
                    return d.source.x + Math.abs(d.source.x - d.target.x) * d.source.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else {
                    return d.source.x;
                }
            }
            else if (cls == "sy") {
                if (d.source.y > d.target.y) {
                    return d.source.y - Math.abs(d.source.y - d.target.y) * d.source.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else if (d.source.x < d.target.x) {
                    return d.source.y + Math.abs(d.source.y - d.target.y) * d.source.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else {
                    return d.source.y;
                }
            }
            else if (cls == "tx") {
                if (d.source.x > d.target.x) {
                    return d.target.x + Math.abs(d.source.x - d.target.x) * d.target.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else if (d.source.x < d.target.x) {
                    return d.target.x - Math.abs(d.source.x - d.target.x) * d.target.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else {
                    return d.target.x;
                }
            }
            else if (cls == "ty") {
                if (d.source.y > d.target.y) {
                    return d.target.y + Math.abs(d.source.y - d.target.y) * d.target.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else if (d.source.y < d.target.y) {
                    return d.target.y - Math.abs(d.source.y - d.target.y) * d.target.r / Math.sqrt(Math.pow(d.source.y - d.target.y, 2) + Math.pow(d.source.x - d.target.x, 2));
                }
                else {
                    return d.target.y;
                }
            }

        }

</script>
</body>
</html>
