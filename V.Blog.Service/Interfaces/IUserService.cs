using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using V.Blog.Data.POCO;
using V.Blog.Service.ViewModels;

namespace V.Blog.Service.Interfaces
{
    public interface IUserService
    {
        IQueryable<Customer> Fetch();
        Customer FindBy(string id);
        bool Save(Customer model);
      
    }

}
