using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineCurriculum
{
    public class Category
    {
        public string Title;
        public List<CategoryContent> Content;

        public Category()
        {
            Title = "";
            Content = new List<CategoryContent>();
        }
    }

    public struct CategoryContent
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
