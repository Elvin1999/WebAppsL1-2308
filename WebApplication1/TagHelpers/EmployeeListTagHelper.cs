using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.TagHelpers
{
    [HtmlTargetElement("employee-list")]
    public class EmployeeListTagHelper:TagHelper
    {
        static List<Employee> employees = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Firstname="Aysel",
                    Lastname="Memmedova",
                    CityId=1
                },
                new Employee
                {
                    Id=2,
                    Firstname="Huseyn",
                    Lastname="Huseynov",
                    CityId=10
                },
                new Employee
                {
                    Id=3,
                    Firstname="Ruad",
                    Lastname="Dunyamaliyev",
                    CityId=77
                },

            };

        private const string SortAttribute = "sort";
        [HtmlAttributeName(SortAttribute)]
        public string Sort { get; set; }
        private const string CountAttribute = "count";
        [HtmlAttributeName(CountAttribute)]
        public int Count { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";

            StringBuilder sb = new StringBuilder();

            var query = employees.Take(Count);
            
            if (Sort == "a-z")
            {
                query = query.OrderBy(e => e.Firstname).ToList();
            }
            else if (Sort == "z-a")
            {
                query = query.OrderByDescending(e => e.Firstname).ToList();
            }

            foreach (var employee in query)
            {
                sb.AppendFormat("<h2><a href='/home/Employee/{0}'>{1}</a></h2>", employee.Id, employee.Firstname);
            }

            output.Content.SetHtmlContent(sb.ToString());

        }
    }
}
