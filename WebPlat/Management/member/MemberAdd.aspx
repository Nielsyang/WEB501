<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberAdd.aspx.cs" Inherits="WebPlat.Management.member.MemberAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>添加成员</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet" />
    <script type="text/javascript" src="../city/jquery.js"></script>
    <script type="text/javascript" src="../Calendar/WdatePicker.js"></script>
    <style type="text/css">
        .ddldisplay{ float:left;height:27px;position:relative; cursor:pointer; top:0px; left:0px; font-size:12px; margin-right:10px;}
        .ddldisplay span{ padding-left:5px;height:27px; line-height:27px; top:200px; left:0px;}
        .ddldisplay div{ display:none; position:absolute; top:27px; left:0px;border:1px solid #bfbfbf; border-top:none; width:280px; height:auto; overflow:hidden; background:#ffffff;}
        .ddldisplay div a{ display:block; padding-left:5px;height:20px; line-height:20px; color:#666; text-decoration:none; background:#ffffff; float:left; width:60px;}
        .ddldisplay div a:hover{ color:Blue; text-decoration:underline;}
        .ddlShouhuo{width:101px;background:url(../city/ddlAdderss.gif) no-repeat;}
        #ddlQu div{width:140px; border-top:1px solid #d2d2d2;}
        #ddlShi div{width:140px;}
    </style>
    <script type="text/javascript">
        $(document).ready(function () {
            cityArea();
            $('.ddldisplay').hover(
		            function () { return false; },
		            function () {
		                $(this).children("div").hide(); $('.ddldisplay').toggle(
			                function () { $(this).children("div").show(); },
			                function () { $(this).children("div").hide(); });
		            });
              });
            function cityArea() {
                 $.ajax({
                      url: "../city/Area.xml", //地址
                      type: "GET",
                     dataType: "xml",
                     error: function (xdata) { alert("fail:加载失败。"); },
                     success: function (xdata) {
                            if ($(xdata) != null) {
                                $("#ddlSheng div").html("");
                                     for (var i = 0; i < $(xdata).find("address > province").length; i++) {
                                          $("#ddlSheng div").append("<a href='javascript:;'>" + $(xdata).find("address > province:eq(" + i + ")").attr("name") + "</a>");
                        }
                    }
                    //下面是下拉框
                    $(".ddldisplay").toggle(
                                function () { $(this).children("div").show(); },
                                function () { $(this).children("div").hide(); });
                    $("#ddlSheng a").click(function () {
                        $(this).parents(".ddldisplay").find("span").text($(this).text());
                        $("#hid2").val($("#txtSheng").text()+" "+ $("#txtShi").text() +" "+ $("#txtqu").text());
                        var provinceName = $(this).parent().prev().text();
                        $("#ddlShi div").html("");
                        //根据省查找该省的所有下级市
                        for (var i = 0; i < $(xdata).find("address > province[name='" + provinceName + "'] > city").length; i++) {
                            $("#ddlShi div").append("<a href='javascript:;'>" + $(xdata).find("address > province[name='" + provinceName + "'] > city:eq(" + i + ")").attr("name") + "</a>");
                        }
                        $(this).parents(".ddldisplay").find("div").hide();
                        $("#ddlShi a").click(function () {
                            var provinceName = $("#ddlSheng").find("span").text(); //省
                            var cityName = $(this).text(); //市
                            $("#ddlShi span").text(cityName);
                            $("#hid2").val($("#txtSheng").text() +" "+ $("#txtShi").text() +" "+ $("#txtqu").text());
                            var country = $(xdata).find("address > province[name='" + provinceName + "'] > city[name='" + cityName + "'] > country");
                            var len = country.length;
                            $("#ddlQu div").html("");
                            for (var i = 0; i < len; i++) {
                                var countryName = $(xdata).find("address > province[name='" + provinceName + "'] > city[name='" + cityName + "'] > country:eq(" + i + ")").attr("name");
                                $("#ddlQu div").append("<a href='javascript:;'>" + countryName + "</a>");
                            }
                            $(this).parents(".ddldisplay").find("div").hide();
                            $("#ddlQu a").click(function () {
                                $("#ddlQu span").text($(this).text());
                                $("#hid2").val($("#txtSheng").text() +" "+ $("#txtShi").text() +" "+ $("#txtqu").text());
                            });
                        });
                    });
                }
            });
          }
         function retu() {
            window.location.href = "Member.aspx";
        }
        function show() {
            var path = document.getElementById("ImageUpload").value;
            if (path == null || path == "") {
                alert("上传图片不能为空！");
            }
            var s = path.lastIndexOf(".");
            if (path.substring(s, path.length) != ".png" && path.substring(s, path.length) != ".jpg") {
                alert("请选择图片上传！");
            }
            else {
                var files = path.lastIndexOf("\\");
                var filename = path.substring(files + 1, path.length);
                document.getElementById("photo").setAttribute("src", "../../Management/upload/image/" + filename);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
          <input type="hidden" id="hid2" runat="server" />
          <table width="100%">
                <tr>
                    <td colspan="4" style="text-align:left;" class="tb">添加成员</td>
                </tr>
                <tr>
                    <td  style="text-align:right; width:15%;">姓名:</td>
                    <td style="width:35%;">
                        <input id="Name" type="text" runat="server" class="inpt" width="263px;"/>
                    </td>
                    <td style="text-align:right;width:15%;" rowspan="5">照片:</td>
                    <td  rowspan="5" style="width:35%;">
                           <img alt="" id="photo" src="" runat="server" style="width:300px;height:150px;"/><br />
                           <asp:FileUpload ID="ImageUpload" runat="server" Width="265px"  onchange="show();"/>
                    </td>
                </tr>
                <tr >
                      <td style="text-align:right;">性别:</td>
                     <td>
                         <asp:RadioButtonList ID="sex" runat="server" RepeatDirection="Horizontal">
                              <asp:ListItem  Selected="True" Value="男">男</asp:ListItem>
                              <asp:ListItem  Value="女">女</asp:ListItem>
                          </asp:RadioButtonList>
                     </td>
                </tr>
                <tr>
                    <td style="text-align:right;">出生日期:</td>
                    <td>
                         <input  id="Birthday" class="Wdate" type="text" onclick="WdatePicker()" runat="server" style="width:261px;"/>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right; height:auto;">籍贯:</td>
                    <td>
                          <div class="ddlShouhuo ddldisplay" id="ddlSheng" runat="server">
                             <span id="txtSheng" runat="server"></span>
                               <div>
	                                  
                               </div>
                         </div>
                         <div class="ddlShouhuo ddldisplay" id="ddlShi" runat="server">
                            <span id="txtShi" runat="server"></span>
                              <div>
	        
                             </div>
                        </div>
                        <div class="ddlShouhuo ddldisplay" id="ddlQu" runat="server">
                             <span id="txtqu" runat="server"></span>
                               <div>
	        
                               </div>
                       </div>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">学历:</td>
                    <td> 
                        <asp:DropDownList ID="degree" runat="server">
                             <asp:ListItem Text="本科" Value="本科"></asp:ListItem>
                             <asp:ListItem Text="硕士" Value="硕士"></asp:ListItem> 
                             <asp:ListItem Text="博士" Value="博士"></asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">毕业学校:</td>
                    <td>
                        <input id="college" type="text" runat="server" class="inpt"/>
                    </td>
                    <td style="text-align:right;">专业:</td>
                    <td>
                       <input id="major" type="text" runat="server" class="inpt"/>
                    </td>
                </tr>
                <tr>
                   <td style="text-align:right;">电子邮件:</td>
                   <td>
                        <input id="email" type="text" runat="server" class="inpt"/>
                   </td>
                   <td style="text-align:right;">添加时间:</td>
                   <td>
                         <input id="AddTime"  class="Wdate" type="text" onclick="WdatePicker()" runat="server"  style="width:261px;"/>
                   </td>
                </tr>
                <tr>
                    <td style="text-align:right;">简历:</td>
                    <td colspan="3">
                        <textarea id="introduce" rows="5" cols="100" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:right;">团队职责:</td>
                    <td colspan="3">
                         <textarea id="assignment" rows="5" cols="100" runat="server"></textarea>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" style="text-align:center;">
                        <asp:Button ID="add" runat="server" Text="添加" class="button_on" OnClick="addMember"/>&nbsp;
                        <asp:Button ID="reset" runat="server" Text="重置" class="button_on" OnClick="Reset"/>&nbsp;
                        <input id="back" type="button" value="返回" class="button_on" onclick="retu();"/>
                    </td>
                </tr>
          </table>
    </form>
</body>
</html>