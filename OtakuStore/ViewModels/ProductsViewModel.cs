using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PagedList;

namespace OtakuStore.ViewModels
{
    public class ProductsViewModel
    {
        public IPagedList<Product> products { get; set; }
        public Product product { get; set; }
        public string product_tags { get; set; }
        public List<Tag> tags { get; set; }
        public List<Category> categories { get; set; }
        public List<Manufactor> manufactors { get; set; }
        public List<Status> status { get; set; }
        public List<Image> images { get; set; }
    }
}