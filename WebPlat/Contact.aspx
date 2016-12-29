<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebPlat.Contact" %>
<%@ Register Src="top.ascx" TagName="head" TagPrefix="uc1" %>
<%@ Register Src="bottom.ascx" TagName="foot" TagPrefix="uc2" %>
<%@ Register  Src="map.ascx"  TagName="map"   TagPrefix="map1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>联系我们</title>
</head>
<body>
       <uc1:head ID="head2" runat="server" />
       <div id="subheader">
	       <div class="row">
		        <div class="twelve columns">
			        <p class="left">
				      CONTACT US
			        </p>
			        <p class="right">
				     Get in touch today!
			        </p>
		        </div>
	     </div>
     </div>
    <div class="hr">
    </div>
    <div class="row" style="height: 400px">
        <!-- GOOGLE MAP IFRAME -->
	    <div class="twelve columns">
		     <map1:map ID="map2" runat="server" />
	    </div>
    </div>

    <div class="row">
	    <!-- CONTACT FORM -->
	    <div class="twelve columns">
		    <div class="wrapcontact">
			    <h5>SEND US A MESSAGE</h5>
			    <div class="done">
				    <div class="alert-box success">
				     Message has been sent! <a href="" class="close">x</a>
				    </div>
			    </div>			
				    <form  id="contact_form"  runat="server">
				    <div class="form">
				        <div class="six columns noleftmargin">
                        <asp:Label ID="Label1"  runat="server">Name</asp:Label>
                        <asp:TextBox  ID="name" runat="server" class="smoothborder"  placeholder="Your name *"></asp:TextBox>
					    </div>
					    <div class="six columns">
                        <asp:Label ID="Label2"  runat="server">E-mail address</asp:Label>
                        <asp:TextBox  ID="email" runat="server" class="smoothborder"  placeholder="Your e-mail address *"></asp:TextBox>
					    </div>
					    <div class="six columns noleftmargin">
                        <asp:Label ID="Label3"  runat="server">Subject</asp:Label>
                         <asp:TextBox ID="subject" runat="server" class="smoothborder" placeholder="Your subject *"></asp:TextBox>
					    </div>
                        <div class="m1" style="float:left; width:100%">
                        <asp:Label ID="Label4"  runat="server">Message</asp:Label>
					    <textarea  id="message" class="smoothborder ctextarea" rows="14" placeholder="Message, feedback, comments *" runat="server"></textarea>
                        <asp:Button ID="submit" runat="server" Text="Send Message" class="readmore" OnClick="submitContact" />
                        </div>
				    </div>
				  </form>			
		    </div>
	    </div>										
    </div>
    <div class="hr">
    </div>
      <div class="tweetarea">
		<div class="tweettext">
		</div>
	  </div>
	</body>
</html>