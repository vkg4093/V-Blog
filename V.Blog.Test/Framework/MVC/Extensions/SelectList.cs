using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;

namespace V.Blog.Test.Framework.MVC.Extensions
{
	public static class SelectList
	{
		public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> list, Func<T, string> value,
															   Func<T, string> text, string emptyItem = null)
		{
			var result = new List<SelectListItem>();
            //if (emptyItem != null)
            //{
            //    result.Add(new SelectListItem { Text = emptyItem, Value = "" });
            //}
			result.AddRange(list.AsEnumerable().Select(item => new SelectListItem { Value = value(item), Text = text(item) }));
			return result;
		}

		public static IEnumerable<SelectListItem> ToSelectList<T>(this IEnumerable<T> list, Func<T, int> value,
															   Func<T, string> text, string emptyItem = null)
		{
			var result = new List<SelectListItem>();
			if (emptyItem != null)
			{
				result.Add(new SelectListItem { Text = emptyItem, Value = "" });
			}
			result.AddRange(list.AsEnumerable().Select(item => new SelectListItem { Value = value(item).ToString(CultureInfo.InvariantCulture), Text = text(item) }));
			return result;
		}
	}
}
