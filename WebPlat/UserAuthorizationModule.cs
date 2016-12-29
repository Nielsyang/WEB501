using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebPlat.Common;

namespace WebPlat
{
    public class UserAuthorizationModule:IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.AcquireRequestState += new EventHandler(context_AcquireRequestState);
        }
        void context_AcquireRequestState(object sender, EventArgs e)
        {
            // 获取应用程序
            HttpApplication application = (HttpApplication)sender;
            // 获取Url
            string requestUrl = application.Request.Url.ToString();
            // 如果请求的页面不是登录页面，刚重定向到登录页面。
            string requestPage = requestUrl.Substring(requestUrl.LastIndexOf('/') + 1);
            string ext = requestUrl.Substring(requestUrl.LastIndexOf('.')+1);
            if (requestUrl.Contains("Management") && ext=="aspx")
            {
                // 检查用户是否已经登录
                if (application.Context.Session["username"] == null || application.Context.Session["username"].ToString().Trim() == "")
                {
                    if (requestPage != "login.aspx")
                        application.Context.Response.Write(MessageHelper.showMessage("您还没有登录!", "/Management/Administrator/login.aspx"));
                }
            }
        }
    }
}