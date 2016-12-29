<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Disease.aspx.cs" Inherits="WebPlat.Disease" %>
<%@ Register Src="top.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="bottom.ascx" TagName="foot" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
        <title>疾病</title>
        <link rel="stylesheet" href="stylesheets/style.css"/>
        <link rel="stylesheet" href="stylesheets/homepage.css"/>
        <link rel="stylesheet" href="stylesheets/skins/teal.css"/>
        <link rel="stylesheet" href="stylesheets/responsive.css"/>
        <link rel="stylesheet" href="stylesheets/skins/teal.css"/><!-- skin color -->
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
</head>
<body>
               <uc1:head ID="head2" runat="server" />
               <div id="subheader" class="blogstyle">
	            <div class="row">
		            <div class="six columns">
			            <p class="bread leftalign">
				                You are here: <a href="#"> Home</a> / <a href="#">Project</a>
			            </p>
		            </div>
		            <div class="six columns">
			            <div class="row collapse">
				            <div class="ten mobile-three columns">
					            <input type="text" class="nomargin" placeholder="输入药物PPI或Pathway，例如，当归PPI">
				            </div>
				            <div class="two mobile-one columns">
					            <a href="#" class="postfix button expand">Go</a>
				            </div>
			            </div>
		            </div>
	            </div>
            </div>
            <div class="hr">
            </div>
            <div class="row">
    <!-- TABS-->
	        <div class="six columns">
		        <h5>TABS</h5>
		        <dl class="tabs">
			        <dd class="active"><a href="#simple1">疾病</a></dd>
			        <dd><a href="#simple2">症候</a></dd>
			        <dd><a href="#simple3">综合症</a></dd>
		        </dl>
		        <ul class="tabs-content">
			        <li class="active" id="simple1Tab">
			        <p  style="font-size: 15px; ">
				          项目中挖掘的与疾病相关的药物之间的联系。
			        </p>
			        <p>
				       
			        </p>
			        <p>
				         
			        </p>
			        </li>
			        <li id="simple2Tab">This is simple tab 2's content. Now you see it! Lorem ipsum dolor sit amet, consectetur adipiscing elit. Et non ex maxima parte de tota iudicabis? Item de contrariis, a quibus ad genera formasque generum.</li>
			        <li id="simple3Tab">This is simple tab 3's content. It's, you know...okay. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Et non ex maxima parte de tota iudicabis? Item de contrariis, a quibus ad genera formasque generum.</li>
		        </ul>
	        </div>
       <div class="six columns">
		  <h5>ACCORDIONS</h5>
		      <ul class="accordion">
			         <li class="active">
			                <div class="title">
				        <b  style="font-size:15px;">疾病</b>
			</div>
			<div class="content" style="overflow: hidden; display: block; ">
				<p  style="font-size:15px;" >
					疾病包括内科和外科。
				</p>
			</div>
			</li>
			<li class="">
			<div class="title">
				<b  style="font-size:15px;">症候</b>
			</div>
			<div class="content" style="overflow: hidden; display: none; ">
				<p  style="font-size:15px;">
					Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
				</p>
			</div>
			</li>
			<li class="">
			<div class="title">
				<b  style="font-size:15px;">综合症</b>
			</div>
			<div class="content" style="overflow: hidden; display: none; ">
				<p  style="font-size:15px;">
					Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
				</p>
				</div>
				</li>
			</ul>
	    </div>
   </div>
        
		       <p>
			           <iframe  scrolling="auto"  name="left"  height="80px" width="100%"  frameborder="0"  src="/disease/diseaselist.htm">
                       </iframe>
		        </p>
		        <p>
			            <iframe  scrolling="auto"  name="right" height="600px"  width="100%"   frameborder="0"  src="/disease/getCytoscapeWeb.aspx">
                        </iframe>
		        </p>
               <uc2:foot ID="foot1" runat="server" />
 </body>
</html>
