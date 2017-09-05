using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http;

namespace OnlineCurriculum.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            ViewData["test"] = "This is a test";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");
            IConfigurationRoot configuration = builder.Build();

            string data = GetOnlineJSONData(configuration);
            JObject content = JObject.Parse(data);

            List<Category> categories = new List<Category>();

            foreach (var categoryData in content)
            {
                Category category = new Category();
                category.Title = categoryData.Key;

                foreach (var value in categoryData.Value)
                {
                    CategoryContent categoryContent = new CategoryContent();
                    categoryContent.Title = value["Title"].Value<string>();
                    categoryContent.Description = value["Description"].Value<string>();
                    category.Content.Add(categoryContent);
                }
                categories.Add(category);
            }

            ViewData["Categories"] = categories;
        }

        string GetOnlineJSONData(IConfigurationRoot configuration)
        {
            string JSONUrl = configuration["Data:URL"];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(JSONUrl);
            request.ContentType = "application/json; charset=utf-8";
            try
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                using (Stream responseStream = response.GetResponseStream())
                {
                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return GetOfflineJSONData(configuration);
            }
        }

        string GetOfflineJSONData(IConfigurationRoot configuration)
        {
            string fallbackURL = configuration["Data:Fallback"];
            StreamReader reader = new StreamReader(fallbackURL, Encoding.UTF8);
            return reader.ReadToEnd();
        }
    }
}
