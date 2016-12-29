<%@ Page  ValidateRequest="false" Language="C#" AutoEventWireup="true" CodeBehind="Herb.aspx.cs" Inherits="Test.Herb" %>
<!DOCTYPE html>
<!--[if lt IE 7]>      <html class="lt-ie9 lt-ie8 lt-ie7"> <![endif]-->
<!--[if IE 7]>         <html class="lt-ie9 lt-ie8"> <![endif]-->
<!--[if IE 8]>         <html class="lt-ie9"> <![endif]-->
<!--[if gt IE 8]><!--> <html> <!--<![endif]-->
    <head>
        <meta http-equiv="X-UA-Compatible" content="IE=Edge">
        <meta charset="utf-8">
        <title>DiseaseAndHerb</title>
        <link rel="stylesheet" href="Style/bootstrap.css">
        <link rel="stylesheet" href="Style/style.css">
        <link rel="stylesheet" href="Style/svg.css">
        <style type="text/css">
              .tog {
	                width:100%;
	                height:27px;
	                background:url(/images/top_float_bg.png) 0 top repeat-x;
	                position:absolute;
	                z-index:2;
	                cursor:pointer;
               }
               .tog_contact {
	                height:130px;
	                width:100%;
	                position:absolute;
	                z-index:1;
	                display:none;
	                background-color:Silver;
                }
               .tog span {
	                width:159px;
	                height:30px;
	                margin:0 auto;
	                line-height:24px;
	                color:#FFF;
	                text-align:center;
	                display:block;
	                background:url(/images/tog.png) 0 5px no-repeat;
              }
              .togclose {
	                width:100%;
	                height:27px;
	                background:url(/images/top_float_bg.png) 0 top repeat-x;
	                position:absolute;
	                z-index:2;
	                cursor:pointer;
              }
              .togclose span {
	                font-family:Verdana;
	                font-size:12px;
	                width:159px;
	                height:27px;
	                margin:0 auto;
	                text-align:center;
	                line-height:22px;
	                color:#FFF;
	                display:block;
	                background:url(/images/togclose.png) 0 5px no-repeat;
             }
             .t_con_box {
	                width:982px;
	                margin:0 auto;
	                height:150px;
	                position:relative;
             }
             #nav-list
             {
                     display:none;
             }
             .Textcss
             {  
                     font-size:15px; 
                     font-weight:bold;
             }
             #PValue
             {
                    padding-top:25px;
                    display:none;
                    font-weight:bold;
             }
             #Alterdiv
             {
                    padding-top:20%;
                    text-align:center;
                    display:none;
                    font-size:xx-large;
                    font-weight:bold;
             }
        </style>
    </head>
    <body>
        <!--[if lt IE 9]>
        <div class="unsupported-browser">
            This website does not fully support your browser.  Please get a
            better browser (Firefox or <a href="/chrome/">Chrome</a>, or if you
            must use Internet Explorer, make it version 9 or greater).
        </div>
        <![endif]-->
        
        <div class="tog_contact">
            <div class="t_con_box">
            <form id="form1" runat="server">
                    <input type="hidden" id="JsonId" value="" runat="server"/>
                    <div style="text-align:center;">
                        <asp:DropDownList ID="DiseaseDropdown" DataTextField="ModelName" 
                            DataValueField="ModelId" runat="server" Width="500px">
                        </asp:DropDownList>
                        <asp:DropDownList ID="HerbDropdown" runat="server" 
                            DataTextField="ModelName" DataValueField="ModelId" Width="260px">
                        </asp:DropDownList>
                     </div>
                     <div style="margin-left:350px; margin-top:5px;">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" 
                            RepeatDirection="Horizontal">
                            <asp:ListItem>Disease</asp:ListItem>
                            <asp:ListItem>Herb</asp:ListItem>
                            <asp:ListItem Selected="True">DiseaseAndHerb</asp:ListItem>
                        </asp:RadioButtonList>
                     </div>
                     <div style="margin-left:380px; margin-top:5px;">
                         <asp:Label ID="Label1" runat="server" Text="PDValue" CssClass="Textcss"></asp:Label>
                         <asp:DropDownList ID="PDiseaseDropdown" runat="server" Width="80px">
                             <asp:ListItem>0.05</asp:ListItem>
                             <asp:ListItem>0.01</asp:ListItem>
                             <asp:ListItem>0.001</asp:ListItem>
                             <asp:ListItem>0.0001</asp:ListItem>
                             <asp:ListItem>0.00001</asp:ListItem>
                         </asp:DropDownList>&nbsp;&nbsp;&nbsp;
                         <asp:Label ID="Label2" runat="server" Text="PHValue" CssClass="Textcss"></asp:Label>
                         <asp:DropDownList ID="PHerbDropdown" runat="server" Width="80px">
                             <asp:ListItem>0.05</asp:ListItem>
                             <asp:ListItem>0.01</asp:ListItem>
                             <asp:ListItem>0.001</asp:ListItem>
                             <asp:ListItem>0.0001</asp:ListItem>
                             <asp:ListItem>0.00001</asp:ListItem>
                         </asp:DropDownList>
                     </div>
                     <div style="text-align:center; margin-top:15px;">
                         <asp:Button ID="Button1" runat="server" Text="提交"
                            onclick="Button1_Click"/>
                     </div>
              </form>
            </div>
        </div>
        <div class="tog" id="tog"><span>点击显示提交表单</span></div>
        <div style="text-align:center;" id="PValue">
            <asp:Label ID="PDisease" runat="server" Text=""></asp:Label>&nbsp;&nbsp;&nbsp;
            <asp:Label ID="PHerb" runat="server" Text=""></asp:Label>
        </div>
        <div id="Alterdiv">
            <asp:Label ID="AlterLabel" runat="server" Text=""></asp:Label>
        </div>
        <div id="split-container">
            <a class="btn btn-default nav-button" id="nav-list" href="javascript:downloadPng();" title="Download as .png">
                Download as .png
            </a>
            <div id="graph-container">
                <div id="graph"></div>
            </div>
            <div id="docs-container">
                <a id="docs-close" href="#">&times;</a>
                <div id="docs" class="docs"></div>
            </div>
        </div>
        <script type="text/javascript" src="Jquery/jquery-1.10.2.min.js"></script>
        <script type="text/javascript" src="Jquery/jquery.browser.min.js"></script>
        <script type="text/javascript" src="d3/d3.v3.min.js"></script>
        <script type="text/javascript" src="d3/colorbrewer.js"></script>
        <script type="text/javascript" src="d3/geometry.js"></script>
        <script type="text/javascript" src="http://code.jquery.com/jquery-migrate-1.0.0.js"></script>
        <script type="text/javascript">
            $('#tog').toggle(function () {
                $(this).animate({ top: '130px' }, 320).addClass("togclose").removeClass("tog").html('<span>close</span>');
                $('.tog_contact').slideDown(320);
            }, function () {
                $(this).animate({ top: '0px' }, 320).addClass("tog").removeClass("togclose").html('<span>点击显示提交表单</span>');
                $('.tog_contact').slideUp(320);
            })
            var Data = $("#JsonId").val();
            if (Data == "") {
                $("#Alterdiv").css("display", "block");
            } else{
                var JsonData = eval("(" + Data + ")");
                var pDDisease = $("#PDisease").text();
                var pDCompound = $("#PHerb").text();
                if (pDDisease != "" || pDCompound != "") {
                    $("#PValue").css("display", "block");
                    $("#nav-list").css("display", "block");
                }
                var config = { "title": "Database process documentation",
                    "graph": { "linkDistance": 100, "charge": -200, "height": 800, "numColors": 12, "labelPadding": { "left": 3, "right": 3, "top": 2, "bottom": 2 }, "labelMargin": { "left": 3, "right": 3, "top": 2, "bottom": 2 }, "ticksWithoutCollisions": 50 },
                    "types": {},
                    "constraints": []
                };
            }
        </script>
        <script type="text/javascript" src="d3/saveSvgAsPng.js"></script>
        <script type="text/javascript" src="JScript.js"></script>
        <script type="text/javascript">
            function downloadPng() {
                var ctn = document.getElementById("graph");
                var svg = ctn.getElementsByTagName("svg")[0];
                saveSvgAsPng(svg, "graph.png");
            }
        </script>
    </body>
</html>
