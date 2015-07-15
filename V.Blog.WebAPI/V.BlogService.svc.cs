using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using V.Blog.Data.POCO;

namespace V.Blog.WebAPI
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "V" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select V.svc or V.svc.cs at the Solution Explorer and start debugging.
    public class V : IV
    {
        BlogEntities _db = new BlogEntities();
        public void DoWork()
        {

        }
        public List<Customer> GetAllcustomers()
        {
            List<Customer> listCustomer = new List<Customer>();
            listCustomer = _db.Customers.ToList();
            return listCustomer;
        }
    }
}

