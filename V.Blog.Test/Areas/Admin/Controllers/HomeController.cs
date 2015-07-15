using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V.Blog.Core.Data.Interfaces;
using V.Blog.Service.Interfaces;
using V.Blog.Service.ViewModels;
using V.Blog.Test.Framework.MVC.Extensions;


namespace V.Blog.Test.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        private readonly IUserService _userService;
        private IUnitOfWork _persist;

        public HomeController(IUserService userService, IUnitOfWork persist)
        {
            this._userService = userService;
            this._persist = persist;
        }
        public ActionResult Home()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Home(UserAccount model)
        {
            var allErrors = ModelState.Values.SelectMany(v => v.Errors);//Check if any model error
            if (ModelState.IsValid)
            {
                return View();
            }
            return View(model);
        }

    }
}
