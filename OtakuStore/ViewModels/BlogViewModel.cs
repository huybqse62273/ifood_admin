using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace OtakuStore.ViewModels
{
    public class BlogViewModel
    {
        public Blog blog { get; set; }
        public List<Blog> listBlog { get; set; }
        public IPagedList<Blog> PagedList { get; set; }
    }

    public class FAQViewModel
    {
        public FAQ faq { get; set; }
        public List<FAQ> listFAQ { get; set; }
        public IPagedList<FAQ> PagedList { get; set; }
    }
}