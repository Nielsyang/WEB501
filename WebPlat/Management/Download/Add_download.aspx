<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_download.aspx.cs" Inherits="WebPlat.Management.Download.Add_download" %>

<%@ Register Assembly="Brettle.Web.NeatUpload" Namespace="Brettle.Web.NeatUpload"
    TagPrefix="Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>下载添加</title>
    <link type="text/css" href="../css/right.css" rel="stylesheet" />
    <script type="text/javascript">
        function WebForm_OnSubmit()
        {
            var filedescription = document.getElementById("fileDescription").value;
            if (filedescription == "") {
                alert("文件描述不能为空！");
                document.getElementById("progress").style.display = "none";
                return false;
            }
            return true;
        }
        function ToggleVisibility(id, type)   //进度条的隐藏和显示  
        {
            el = document.getElementById(id);
            if (el.style) {
                if (type == 'on') {
                    el.style.display = 'block';
                }
                else {
                    el.style.display = 'none';
                }
            }
            else {
                if (type == 'on') {
                    el.display = 'block';
                }
                else {
                    el.display = 'none';
                }
            }
        }  
</script>  
</head>
<body>
    <form id="form1" runat="server" onsubmit="return WebForm_OnSubmit();">
          <table width="100%">
               <tr>
                  <td style="text-align:right;" width="100px">文件描述:</td>
                  <td>
                      <textarea id="fileDescription" cols="40" rows="8" runat="server" class="inpt"></textarea>
                  </td>
               </tr>
              <tr>
                  <td style="text-align:right;" width="100px">文件上传:</td>
                  <td>
                      <Upload:InputFile  ID="AttachFile" runat="server"/>
                  </td>
              </tr>
              <tr>
                  <td style="text-align:right">上传进度:</td>
                  <td style="height:auto;">
                      <div id="progress" style="display:none; width:auto;">
                          <Upload:ProgressBar ID="fileProgress" runat="server" Inline="true" Width="450px">
                          </Upload:ProgressBar>
                      </div>
                  </td>
              </tr>
              <tr>
                   <td colspan="2" style="text-align:center;">
                       <asp:Button ID="btnUpload" runat="server" Text="上传" OnClick="upload_Click" class="button_on" OnClientClick="ToggleVisibility('progress', 'on')"/>
                   </td>
              </tr>
          </table>
    </form>
</body>
</html>
