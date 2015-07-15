using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using V.Blog.Core.Data.Interfaces;
using V.Blog.Data.POCO;
using V.Blog.Service.Interfaces;
using V.Blog.Service.ViewModels;

namespace V.Blog.Service.Implementations
{
    public class UserService : IUserService
    {
        private IUnitOfWork _persist;
        private readonly IRepository<Customer> _customerRepository;
        public UserService(IUnitOfWork persist, IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
            this._persist = persist;
        }
        public IQueryable<Customer> Fetch()
        {
            return _customerRepository.FindAll();
        }
        public Customer FindBy(string id)
        {
            return _customerRepository.FindBy(x => x.CustomerID == id);
        }
        public bool Save(Customer model)
        {
            _customerRepository.Add(model);
            return true;
        }
    }
}
