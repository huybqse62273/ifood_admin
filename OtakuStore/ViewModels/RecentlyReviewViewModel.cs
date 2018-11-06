using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtakuStore.ViewModels
{
    public class RecentlyReviewViewModel
    {
        public List<Product> products { get; set; }
        public List<Image> images { get; set; }
        public List<Manufactor> manufactors { get; set; }
        public IEnumerable<WishList> wishLists { get; set; }
    }
}