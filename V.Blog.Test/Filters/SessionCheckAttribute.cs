using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;
//session expire
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class SessionCheckAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (filterContext.HttpContext.Session != null)
        {
            if (filterContext.HttpContext.Session.IsNewSession)
            {
                ActionResult result = null;
                var sessionCookie = filterContext.HttpContext.Request.Headers["Cookie"];
                if ((sessionCookie != null) && (sessionCookie.IndexOf("ASP.NET_SessionId") >= 0))
                {
                    string redirectTo = "~/home/index";
                    result = new RedirectResult(redirectTo);
                    return;
                }
            }
        }

        base.OnActionExecuting(filterContext);
    }
}