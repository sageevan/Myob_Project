using System.Collections.Generic;
using System.Web.Mvc;

namespace MYOB_Project.WebGUI.Controllers
{
    public static class DropDownListUtil
    {
        public static IEnumerable<SelectListItem> GetMonths()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="January", Value = "1" },
                new SelectListItem{ Text="February", Value = "2" },
                new SelectListItem{ Text="March", Value = "3" },
                new SelectListItem{ Text="April", Value = "4" },
                new SelectListItem{ Text="May", Value = "5" },
                new SelectListItem{ Text="June", Value = "6" },
                new SelectListItem{ Text="July", Value = "7" },
                new SelectListItem{ Text="August", Value = "8" },
                new SelectListItem{ Text="September", Value = "9" },
                new SelectListItem{ Text="October", Value = "10" },
                new SelectListItem{ Text="November", Value = "11" },
                new SelectListItem{ Text="December", Value = "12" }
            };

            return list;
        }

        public static IEnumerable<SelectListItem> GetYears()
        {
            var list = new List<SelectListItem>
            {
                new SelectListItem{ Text="2017", Value = "2017" },
                new SelectListItem{ Text="2016", Value = "2016" },
                new SelectListItem{ Text="2015", Value = "2015" },
                new SelectListItem{ Text="2014", Value = "2014" },
                new SelectListItem{ Text="2013", Value = "2013" },
                new SelectListItem{ Text="2012", Value = "2012" },
                new SelectListItem{ Text="2011", Value = "2011" },
                new SelectListItem{ Text="2010", Value = "2010" },
                new SelectListItem{ Text="2009", Value = "2009" },
                new SelectListItem{ Text="2008", Value = "2008" }
            };

            return list;
        }
    }
}