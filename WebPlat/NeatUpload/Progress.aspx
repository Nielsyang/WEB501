<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN"
        "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Page language="c#" AutoEventWireup="false" Inherits="Brettle.Web.NeatUpload.ProgressPage" %>
<%@ Register TagPrefix="Upload" Namespace="Brettle.Web.NeatUpload" Assembly="Brettle.Web.NeatUpload" %>
<%--
NeatUpload - an HttpModule and User Controls for uploading large files
Copyright (C) 2005  Dean Brettle

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
--%>
<html>
	<head runat="server">
		<title>Upload Progress</title>
		<link rel="stylesheet" type="text/css" title="default" href="default.css" />		
		<style type="text/css">
		body, form, table, tr, td {
			margin: 0px;
			border: 0px none;
			padding: 0px;
		}

		html, body, form, #progressDisplayCenterer {
			width: 100%;
			height: 100%;
		}
		
		#progressDisplayCenterer {
			vertical-align: middle;
			margin: 0 auto;
		}
		
		#progressDisplay {
			vertical-align: middle;
			width: 100%;
		}
		
		#barTd {
			width: 100%;
		}
		
		#statusDiv {
			border-width: 1px;
			border-style: solid;
			padding: 0px;
			position: relative;
			width: 100%;
			text-align: center;
			z-index: 1; 
		}
		
		#barDiv,#barDetailsDiv {
			border: 0px none ; 
			margin: 0px; 
			padding: 0px; 
			position: absolute; 
			top: 0pt; 
			left: 0pt; 
			z-index: -1; 
			height: 100%;
			width: 75%;
		}
	    #normalInProgress
		{
		    color:Red;   /*正在上传时进度条的字体颜色*/  
        }  
         #completed  
         {
             color:Blue; /*上传完成的字体颜色*/  
        }  		
		</style>
	</head>
	<body>
		<form id="dummyForm" runat="server">
		<table id="progressDisplayCenterer">
		<tr>
		<td>
		<table id="progressDisplay" class="ProgressDisplay">
		<tr>
		<td>
			<span id="label" runat="server" class="Label">Upload&#160;Status:</span>
		</td>
		<td id="barTd" >
			<div id="statusDiv" runat="server" class="StatusMessage">&#160;
				<Upload:DetailsSpan id="normalInProgress" runat="server" WhenStatus="NormalInProgress" style="font-weight: normal; white-space: nowrap;">
					<%# FormatCount(BytesRead) %>/<%# FormatCount(BytesTotal) %> <%# CountUnits %>
                  <%# FormatRate(BytesPerSec) %>          <%# String.Format("{0:0%}", FractionComplete) %>
				</Upload:DetailsSpan>
				<Upload:DetailsSpan id="chunkedInProgress" runat="server" WhenStatus="ChunkedInProgress" style="font-weight: normal; white-space: nowrap;">
					<%# FormatCount(BytesRead) %> <%# CountUnits %>
					at <%# FormatRate(BytesPerSec) %>
					- <%# FormatTimeSpan(TimeElapsed) %> elapsed
				</Upload:DetailsSpan>
				<Upload:DetailsSpan id="processing" runat="server" WhenStatus="ProcessingInProgress ProcessingCompleted" style="font-weight: normal; white-space: nowrap;">
					<%# ProcessingHtml %>
				</Upload:DetailsSpan>
				<Upload:DetailsSpan id="completed" runat="server" WhenStatus="Completed">
					文件大小: <%# FormatCount(BytesRead) %> <%# CountUnits %>  
				</Upload:DetailsSpan>
				<Upload:DetailsSpan id="cancelled" runat="server" WhenStatus="Cancelled">
					上传已被取消！
				</Upload:DetailsSpan>
				<Upload:DetailsSpan id="rejected" runat="server" WhenStatus="Rejected">
					禁止: <%# Rejection != null ? Rejection.Message : "" %>
				</Upload:DetailsSpan>
				<Upload:DetailsSpan id="error" runat="server" WhenStatus="Failed">
					错误: <%# Failure != null ? Failure.Message : "" %>
				</Upload:DetailsSpan>
				<Upload:DetailsDiv id="barDetailsDiv" runat="server" UseHtml4="true"
					 Width='<%# Unit.Percentage(Math.Floor(100*FractionComplete)) %>' CssClass="ProgressBar"></Upload:DetailsDiv>	
			</div>
		</td>
		<td>
			<asp:HyperLink id="cancel" runat="server" Visible='<%# CancelVisible %>' NavigateUrl='<%# CancelUrl %>' ToolTip="Cancel Upload" CssClass="ImageButton" ><img id="cancelImage" src="cancel.png" alt="Cancel Upload" /></asp:HyperLink>
			<asp:HyperLink id="refresh" runat="server" Visible='<%# StartRefreshVisible %>' NavigateUrl='<%# StartRefreshUrl %>' ToolTip="Refresh" CssClass="ImageButton" ><img id="refreshImage" src="refresh.png" alt="Refresh" /></asp:HyperLink>
			<asp:HyperLink id="stopRefresh" runat="server" Visible='<%# StopRefreshVisible %>' NavigateUrl='<%# StopRefreshUrl %>' ToolTip="Stop Refreshing" CssClass="ImageButton"><img id="stopRefreshImage" src="stop_refresh.png" alt="Stop Refreshing" /></asp:HyperLink>
		</td>
		</tr>
		</table>
		</td>
		</tr>
		</table>
		</form>
	</body>
</html>
