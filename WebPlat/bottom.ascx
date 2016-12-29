<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="bottom.ascx.cs" Inherits="WebPlat.foot" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN">
<html>
<head>
        <title>底部模板</title>
        <link rel="stylesheet" href="stylesheets/style.css"/>
        <link rel="stylesheet" href="stylesheets/homepage.css"/>
        <link rel="stylesheet" href="stylesheets/skins/teal.css"/>
        <link rel="stylesheet" href="stylesheets/responsive.css"/>
        <script  type="text/javascript" src="javascripts/foundation.min.js"></script>
        <script  type="text/javascript" src="javascripts/jquery.carouFredSel-6.0.5-packed.js"></script>
        <script type="text/javascript" src="javascripts/jquery.cycle.js"></script>
        <script  type="text/javascript" src="javascripts/app.js"></script>
        <script  type="text/javascript" src="javascripts/modernizr.foundation.js"></script>
        <script  type="text/javascript" src="javascripts/slidepanel.js"></script>
        <script  type="text/javascript" src="javascripts/scrolltotop.js"></script>
        <script  type="text/javascript" src="javascripts/hoverIntent.js"></script>
        <script  type="text/javascript" src="javascripts/superfish.js"></script>
        <script type="text/javascript"  src="javascripts/responsivemenu.js"></script>
        <script type="text/javascript"  src="javascripts/jquery.tweet.js"></script>
        <script type="text/javascript"  src="javascripts/twitterusername.js"></script>
        <style>

        .links line {
        stroke: #999;
        stroke-opacity: 0.6;
        }

        .nodes circle {
        stroke: #fff;
        stroke-width: 1.5px;
        }
        .nodes text{
        pointer-events : none;
        font-size : 16;
        font-family:MicrosoftJhengHei;
        }

        </style>
</head>
<body>
<!-- FOOOTER 
================================================== -->
  <div class="row">
		<div class="twelve columns">
			<div class="centersectiontitle">
				<h4>What we do</h4>
			</div>
		</div>
		<div class="four columns">
			<h5>Photography</h5>
			<p>Swine short ribs meatball irure bacon nulla pork belly
				cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui
				bresaola enim jowl. Capicola short ribs minim salami nulla nostrud
				pastrami.</p>
			<p>
				<a href="#" class="readmore">Learn more</a>
			</p>
		</div>
		<div class="four columns">
			<h5>Artwork</h5>
			<p>Swine short ribs meatball irure bacon nulla pork belly
				cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui
				bresaola enim jowl. Capicola short ribs minim salami nulla nostrud
				pastrami.</p>
			<p>
				<a href="#" class="readmore">Learn more</a>
			</p>
		</div>
		<div class="four columns">
			<h5>Logos</h5>
			<p>Swine short ribs meatball irure bacon nulla pork belly
				cupidatat meatloaf cow. Nulla corned beef sunt ball tip, qui
				bresaola enim jowl. Capicola short ribs minim salami nulla nostrud
				pastrami.</p>
			<p>
				<a href="#" class="readmore">Learn more</a>
			</p>
		</div>
	</div>
	<!--<div class="hr"></div>-->
            <div class="tweetarea">
		     <div class="tweettext"></div>
	    </div>
    <div class="row">
	   </div>
       <div class="row">
		<div class="twelve columns">
			<div class="centersectiontitle">
				<h4>Network</h4>
			</div>
		</div>
		<div class="t1" style="width:inherit; height: 300px; ">
            <div class="choose" style="float: left; height: 300px; width: 350px">
            <form id="dfh" runat="server" style="padding-left: 100px; padding-top: 50px; font-size: 20px">
            Task:
         <!--   <input type="hidden" id="queryclass" name="query" value="" runat="server" /> -->
         <div>
            <asp:Button Width=200 ID="button1" runat="server" Text="Formula:Disease:Tissue" OnClick="Button1_click" />
         </div>
        <!--0    <li style="text-align: right; font-size: 16px">Task:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a id="herb" href= "javascript:void(0);" onclick="jump_to_graphpage(this.id)" style="font-size: 16px">Herb:Disease:Tissue</a></li>
            <li style="text-align: right"><a id="formula" href= "javascript:void(0);" onclick="jump_to_graphpage(this.id)" style="font-size: 16px; margin-left: 20px">Formula:Disease:Tissue</a></li>
            <li style="text-align: right"><a id="disease" href= "javascript:void(0);" onclick="jump_to_graphpage(this.id)" style="font-size: 16px">Compound:Disease;Tissue</a></li> -->
            <div>
            <asp:Button Width=200 ID="button2" runat="server" Text="Herb:Disease:Tissue" OnClick="Button1_click" />
            </div>
            <div>
            <asp:Button Width=200 ID="button3" runat="server" Text="Compound:Disease:Tissue" OnClick="Button1_click" />
            </div>
            </form>
            </div>
				<div class="clearfix" style="float: left; clear:none; padding-left: 150px">         
<svg width="320" height="300"></svg>
<script src="https://d3js.org/d3.v4.min.js"></script>
<script>
    var graph = {
        "nodes": [
        { "id": "F/H/C", "group": 1 },
        { "id": "D", "group": 2 },
        { "id": "Ti", "group": 3 },
        ],
        "links": [
         { "source": "F/H/C", "target": "D", "value": 9 },
         { "source": "D", "target": "F/H/C", "value": 9 },
         { "source": "F/H/C", "target": "Ti", "value": 9 },
         { "source": "Ti", "target": "F/H/C", "value": 9 },
         { "source": "Ti", "target": "D", "value": 9 },
         { "source": "D", "target": "Ti", "value": 9 }
         ]
    };
    var svg = d3.select("svg"),
    width = +svg.attr("width"),
    height = +svg.attr("height");

    var defs = svg.append("defs");

    var arrowMarker = defs.append("marker")
                    .attr("id", "arrow")
                    .attr("markerUnit", "strokeWidth")
                    .attr("markerWidth", "40")
                    .attr("markerHeight", "40")
                    .attr("viewBox", "0 0 40 40")
                    .attr("refX", "19")
                    .attr("refY", "3")
                    .attr("orient", "auto");
    var arrow_path = "M0,0 L0,6 L10,3 z";

    arrowMarker.append("path")
           .attr("d", arrow_path)
           .attr("fill", "#999");

    var color = d3.scaleOrdinal(d3.schemeCategory20);

    var simulation = d3.forceSimulation()
    .force("link", d3.forceLink().id(function (d) { return d.id; }))
    .force("charge", d3.forceManyBody().strength(-10000))
    .force("center", d3.forceCenter(width / 2, height / 2));



    var link = svg.append("g")
      .attr("class", "links")
    .selectAll("line")
    .data(graph.links)
    .enter().append("line")
    .attr("stroke-width", function (d) { return Math.sqrt(d.value); })
    .attr("marker-end", "url(#arrow)");

    var node = svg.append("g")
      .attr("class", "nodes")
      .selectAll("circle")
      .data(graph.nodes)
      .enter()
      .append("circle")
      .attr("r", 30)
      .attr("fill", function (d) { return color(d.group); })
      .call(d3.drag()
            .on("start", dragstarted)
            .on("drag", dragged)
            .on("end", dragended));


    var text = svg.select(".nodes")
      .selectAll("text")
      .data(graph.nodes)
      .enter()
      .append("text")
      .text(function (d) { return d.id; });

    simulation
      .nodes(graph.nodes)
      .on("tick", ticked);

    simulation.force("link")
      .links(graph.links);

    function ticked() {
        link
        .attr("x1", function (d) { return d.source.x; })
        .attr("y1", function (d) { return d.source.y; })
        .attr("x2", function (d) { return d.target.x; })
        .attr("y2", function (d) { return d.target.y; });
        node
        .attr("cx", function (d) { return d.x; })
        .attr("cy", function (d) { return d.y; });
        text
        .attr("transform", function (d) { return "translate(" + d.x + "," + d.y + ")"; });
    }

    function dragstarted(d) {
        if (!d3.event.active) simulation.alphaTarget(0.3).restart();
        d.fx = d.x;
        d.fy = d.y;
    }

    function dragged(d) {
        d.fx = d3.event.x;
        d.fy = d3.event.y;
    }

    function dragended(d) {
        if (!d3.event.active) simulation.alphaTarget(0);
        d.fx = null;
        d.fy = null;
    }

</script>

         </div>
			</div>
		
	</div>
    <div class="tweetarea">
		<div class="tweettext"></div>
	</div>
    <div class="twelve columns">
	    <div class="centersectiontitle" style="margin-left: 170px; margin-right: 170px">
				<h4>overview</h4>
		</div>
	</div>
    <div class="overview" style="height: 100px;">
    </div>
        <div id="footer">
	        <footer class="row">
	        <p class="back-top  floatright">
		        <a href="#top"><span></span></a>
	        </p>
	        <div class="four columns">
		        <h1>ABOUT US</h1>
		         Our goal is to keep clients satisfied!
	        </div>
	        <div class="four columns">
		        <h1>GET SOCIAL</h1>
		        <div class="social facebook">
			        <a href="#"></a>
		        </div>
		        <div class="social twitter">
			        <a href="#"></a>
		        </div>
		        <div class="social deviantart">
			        <a href="#"></a>
		        </div>
		        <div class="social flickr">
			        <a href="#"></a>
		        </div>
		        <div class="social dribbble">
			        <a href="#"></a>
		        </div>
	        </div>
	        <div class="four columns">
		        <h1 class="newsmargin">NEWSLETTER</h1>
		        <div class="row collapse newsletter floatright">
			        <div class="ten mobile-three columns">
				        <input type="text" class="nomargin" placeholder="Enter your e-mail address..."/>
			        </div>
			        <div class="two mobile-one columns">
				        <a href="#" class="postfix button expand">GO</a>
			        </div>
		        </div>
	        </div>
	        </footer>
        </div>
        <div class="copyright">
	        <div class="row">
		        <div class="six columns">
			         &copy;<span class="small">Copyright &copy; 2014.Company name All rights reserved.<a target="_blank" href="http://sc.chinaz.com/moban/">&#x7F51;&#x9875;&#x6A21;&#x677F;</a></span>
		        </div>
		        <div class="six columns">
			        <span class="small floatright"> Purchase "Studio Francesca" - sc.chinaz.com</span>
		        </div>
	        </div>
        </div>
        <script  type="text/javascript" src="javascripts/foundation.min.js"></script>
	    <script  type="text/javascript" src="javascripts/jquery.carouFredSel-6.0.5-packed.js"></script>
	    <script  type="text/javascript" src="javascripts/jquery.cycle.js"></script>
	    <script  type="text/javascript" src="javascripts/app.js"></script>
	    <script  type="text/javascript" src="javascripts/modernizr.foundation.js"></script>
	    <script  type="text/javascript" src="javascripts/slidepanel.js"></script>
	    <script  type="text/javascript" src="javascripts/scrolltotop.js"></script>
	    <script  type="text/javascript" src="javascripts/hoverIntent.js"></script>
	    <script  type="text/javascript" src="javascripts/superfish.js"></script>
	    <script  type="text/javascript" src="javascripts/responsivemenu.js"></script>
	    <script  type="text/javascript" src="javascripts/jquery.tweet.js"></script>
	    <script  type="text/javascript" src="javascripts/twitterusername.js"></script>
        <script type="text/javascript">
            function jump_to_graphpage(v) {
                $("#queryclass").val("v")
                var form = window.document.getElementById("dfh")
                form.submit()
                //window.location.href = "Graph.aspx"
            }
        
        
        </script>
	    <div style="display:none">
		    <script  type="text/javascript"  src='http://v7.cnzz.com/stat.php?id=155540&web_id=155540'
			    charset='gb2312'></script>
	    </div>
     </body>
</html>