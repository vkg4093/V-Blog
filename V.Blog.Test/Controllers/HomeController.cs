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
using V.Blog.Test.Models;
using AutoMapper;
using System.Collections.Generic;
namespace V.Blog.Test.Controllers
{
    [SessionCheckAttribute]
    public class HomeController : Controller
    {
        private readonly IUserService _userService;
        private IUnitOfWork _persist;

        public HomeController(IUserService userService, IUnitOfWork persist)
        {
            this._userService = userService;
            this._persist = persist;
        }

        public ActionResult Index(int? page)
        {
            IQueryable<Customer> model = _userService.Fetch();
            model = model.OrderBy(s => s.CustomerID);
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(model.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult Add()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.stateList = _userService.Fetch().Select(s => s.City).ToSelectList(x => x, x => x, emptyItem: null).ToList();    //code for binding a dropdown list
            return View(model);
        }
        [HttpPost]
        public ActionResult Add(CustomerViewModel model)
        {
            try
            {
                //var validationResult = GetValidationResult();
                //if (validationResult != null) return validationResult;
                //bool result = _userService.Save(model.ToMap<CustomerViewModel, Customer>());
                //_persist.Commit();
                ////return Json(new { success = true }, JsonRequestBehavior.AllowGet);
                //if (result)
                //    model.result = "true";
                //ModelState.Clear();
                ////return View(model);
                return RedirectToAction("Index");


            }
            catch (DbEntityValidationException e)
            {
                var validationResult = GetEntityValidationResult(e);
                return validationResult;
            }
            catch (Exception e)
            {

                return Json(new JsonErrorMessage("An error occurred while saving customer."),
                           JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Edit(string id)
        {
            using (BlogEntities _db = new BlogEntities())
            {
                //Customer
            }
            return View();
        }
        public ActionResult Details(string id)
        {
            Customer objCusomer = new Customer();
            using (BlogEntities _db = new BlogEntities())
            {
                objCusomer = _userService.FindBy(id);
                if (objCusomer != null)
                {

                }
            }
            return View();
        }
        public ActionResult Delete(string id)
        {
            using (BlogEntities _db = new BlogEntities())
            {
                //implement here
            }
            return View();
        }

        public ActionResult Test()
        {
            return View();
        }

        private JsonResult GetValidationResult()
        {
            if (!ModelState.IsValid)
            {
                //all the errors Key
                var keys = ModelState.Keys.ToList();
                //get all the ModelStateDictionary according to the key
                var sb = (from key in keys from error in ModelState[key].Errors.ToList() select error.ErrorMessage).ToList();
                return Json(new { success = false, showMessage = true, data = sb }, JsonRequestBehavior.AllowGet);
            }
            return null;
        }
        private JsonResult GetEntityValidationResult(DbEntityValidationException e)
        {
            var sb = e.EntityValidationErrors.Select(x => x.ValidationErrors).Select(x => x.Select(z => z.ErrorMessage));
            return Json(new { success = false, showMessage = true, data = sb }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult JQDataTable()
        {
            var customer = new CustomerViewModel();
            return View(customer);
        }
        public ActionResult error()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerData(CustomerViewModel model, DataTableConfig param)
        {
           
            List<Customer> customerList = _userService.Fetch().ToList();
            Mapper.CreateMap<Customer, CustomerViewModel>();
            var list = Mapper.Map<List<CustomerViewModel>>(customerList);
     

            //return Json(new JQueryDataTablesResponse<Customer>(items: listData,
            //    totalRecords: listData.Count(),
            //    totalDisplayRecords: listData.Count(),
            //    sEcho: jQueryDataTablesModel.sEcho));

            return Json(new
            {
                sEcho = param.sEcho,
                iTotalRecords = list.Count(),
                iTotalDisplayRecords = list.Count(),
                aaData = list

            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult AutoCompleteDemo()
        {
            return View();
        }

        public JsonResult getCountryName(string term)
        {
            var customer = new CustomerViewModel();
            customer.countrtlist = _userService.Fetch().Select(s => s.Country).ToList();
            return Json(customer.countrtlist.ToString(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult getCustomerJsonData()
        {
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}
