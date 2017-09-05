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

namespace OnlineCurriculum.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
            string data = "";
            string JSONUrl = "https://www.jasonbase.com/things/2MJm.json";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(JSONUrl);
            request.ContentType = "application/json; charset=utf-8";
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            using (Stream responseStream = response.GetResponseStream())
            {
                StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                data = reader.ReadToEnd();
            }

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
