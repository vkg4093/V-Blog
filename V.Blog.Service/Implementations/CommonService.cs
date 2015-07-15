using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using V.Blog.Data.POCO;
using V.Blog.Service.ViewModels;

namespace V.Blog.Services.Implementations
{
    public class CommonService
    {
        public List<DropDown> GetStateList(string defaultvalue)
        {
            var mappedResult = new List<DropDown>();

            using (var context = new BlogEntities())
            {
                var list = GetStateListRepo(defaultvalue);
                Mapper.CreateMap<DropDownItem, DropDown>();
                mappedResult = Mapper.Map<List<DropDown>>(list);
            }
            return mappedResult;
        }
        public List<DropDownItem> GetStateListRepo(string defaultvalue)
        {
            var ddlList = new List<DropDownItem>();

            using (var context = new BlogEntities())
            {
                var list = context.Categories.ToList();

                ddlList.AddRange(list.Select(item => new DropDownItem() { Id = item.CategoryID, Name = item.CategoryName }));
            }
            return ddlList;
        }

    }
}
