using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;

namespace OtakuStore.Models
{
    public class WishListViewModel
    {
        public IEnumerable<Image> images { get; set; }
        public IEnumerable<Product> products { get; set; }
        public IEnumerable<Status> status { get; set; }
        public List<WishList> wishList { get; set; }
    }
}