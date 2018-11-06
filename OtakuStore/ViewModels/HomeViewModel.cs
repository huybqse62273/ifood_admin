using Data;
using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtakuStore.ViewModels
{
    public class HomeViewModel
    {
        public List<Product> products { get; set; }
        public List<Image> images { get; set; }
        public List<Manufactor> manufactors { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Anime> animes { get; set; }
        public IEnumerable<WishList> wishLists { get; set; }
    }
}