using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using System.Web.Http.Routing;
using Microsoft.Data.OData;
using Microsoft.Data.OData.Query;

namespace V.Blog.Test.Controllers
{
    public class ProductController : ODataController
    {
        //
        // GET: /Product/

        public string Index()
        {
            return "";
        }

    }
}
