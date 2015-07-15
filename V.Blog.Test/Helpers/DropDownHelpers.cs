using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using V.Blog.Core.Data.Interfaces;
using V.Blog.Service.Interfaces;
using V.Blog.Service.ViewModels;
using AutoMapper;
using V.Blog.Service.Implementations;
using V.Blog.Services.Implementations;


namespace V.Blog.Test.Helpers
{
    public class DropDownHelpers
    {
         // GET: /Admin/Home/


        CommonService _userService = new CommonService();
        public SelectList GetStates(string defaultValue = null)
        {
            if (defaultValue == null)
            {
                defaultValue = "Please Select";
            }

            var result = _userService.GetStateList(defaultValue);

            SelectList selectlst = new SelectList(result, "Id", "Name");

            return selectlst;
        }      
    }
}