using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Repo.HtmlHelpers
{
    public class Helper
    {
        public static IHtmlString CheckBoxList(IEnumerable<SelectListItem> list, string selectedCategories)
        {
            string htmlQuery = "";

            foreach (var item in list)
            {
                htmlQuery +=    "<div class='checkbox'>" +
                                    "<label>" +
                                        $"<input type='checkbox' name='{ selectedCategories }' value='{ item.Value }'>{ item.Text }" +
                                    "</label>" +
                                "</div>";
            }

            IHtmlString html = new HtmlString(htmlQuery);

            return html;
        }
    }
}