using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace OnlineCurriculum.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string data = System.IO.File.ReadAllText(@"wwwroot/data/main-content.json");
            Content content = JsonConvert.DeserializeObject<Content>(data);
            Console.WriteLine(content);
        }
    }
}
