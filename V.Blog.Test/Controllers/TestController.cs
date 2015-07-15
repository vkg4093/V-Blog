using System;
using System.Linq;
using System.Web.Mvc;
using V.Blog.Service;
using V.Blog.Data.POCO;
using PagedList;
using V.Blog.Core.ViewModel;
using V.Blog.Test.Framework;
using System.Data.Entity.Validation;
using V.Blog.Core.Data.Interfaces;
using V.Blog.Test.Framework.JSON;
using V.Blog.Service.Interfaces;
using V.Blog.Test.Framework.MVC.Extensions;
using jquery.dataTable;
using System.Collections.Generic;

namespace V.Blog.Test.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/
        private readonly IUserService _userService;
        private IUnitOfWork _persist;

        public TestController(IUserService userService, IUnitOfWork persist)
        {
            this._userService = userService;
            this._persist = persist;
        }

        public ActionResult Index()
        {
            return View();
        }
      
        public JsonResult getCountryName(string term)
        {
            var customer = new CustomerViewModel();
            //customer.countrtlist = _userService.Fetch().Select(x => x.Country).Take(5).ToList();
            customer.stateList= _userService.Fetch().Select(s => s.City).ToSelectList(x => x, x => x, emptyItem: null).Take(5).ToList();

            return Json(customer.stateList, JsonRequestBehavior.AllowGet);
        }

    }
}
