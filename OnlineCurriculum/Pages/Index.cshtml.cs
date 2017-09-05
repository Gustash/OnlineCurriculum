using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OnlineCurriculum.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string data = System.IO.File.ReadAllText(@"wwwroot/data/main-content.json");
            JObject content = JObject.Parse(data);
            foreach (var header in content)
            {
                string headerTitle = header.Key;
                foreach (var headerContent in header.Value)
                {
                    string title = headerContent["Title"].Value<string>();
                    string description = headerContent["Description"].Value<string>();
                    Console.WriteLine("Title: " + title);
                    Console.WriteLine("Desc: " + description);
                }
            }
        }
    }
}
