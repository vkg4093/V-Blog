using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace V.Blog.Core.ViewModel
{
    public class CustomerViewModel
    {
        public CustomerViewModel()
        {
            //Constr called
        }
        [Required(ErrorMessage = "Enter Customer ID")]
        public string CustomerID { get; set; }
        [Required(ErrorMessage = "Enter Company Name")]
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string result { get; set; }
        public List<SelectListItem> stateList { get; set; }
        public List<string> countrtlist { get; set; }
    }
    public class country
    {
        public string countryname { get; set; }
        //public int countryid { get; set; }
    }
 

    
}
