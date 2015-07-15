using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using V.Blog.Data.POCO;
//using V.Blog.Service.Interfaces;
//using V.Blog.Service.Implementations;

namespace V.Blog.WebAPI.Controllers
{
    public class CustomerApiController : ApiController
    {
        BlogEntities _db = new BlogEntities();
        // GET api/customers
        public IEnumerable<Customer> Get()
        {
            var custs = _db.Customers.AsEnumerable();
            if (custs == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            return custs;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this._db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
