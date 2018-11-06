using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data.Model;
using PagedList;
using Data;

namespace OtakuStore.ViewModels
{
    public class SearchViewModel
    {
        public IPagedList<Product> list { get; set; }
        public IEnumerable<Image> images { get; set; }
        public IEnumerable<Manufactor> manufactors { get; set; }
        public IEnumerable<WishList> wishLists { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Anime> animes { get; set; }
        public IEnumerable<Product> productAll { get; set; }
        public SearchViewModel()

        {
            list = null;
        }
    }
}