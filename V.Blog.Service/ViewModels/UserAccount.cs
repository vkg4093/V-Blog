using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace V.Blog.Service.ViewModels
{
    public class UserAccount
    {
        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter last name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gendre { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string City { get; set; }
        [Required(ErrorMessage = "Please select state")]
        public string State { get; set; }
        public string Country { get; set; }
     

    }

    public class DropDown
    {
        public Int32 Id { get; set; }
        public string Name { get; set; }
    }
    public class DropDownItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string optional { get; set; }
    }

}

