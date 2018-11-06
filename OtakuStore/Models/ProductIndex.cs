using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
using Data.Model;

namespace OtakuStore.Models
{
    public class ProductIndex
    {
        public Product product { get; set; }
        public List<Tag> tags { get; set; }
        public Category category { get; set; }
        public Manufactor manufactor { get; set; }
        public Status status { get;set; }
        public IEnumerable<Image> images { get; set; }
        public IEnumerable<Comment> comments { get; set; }
        public IEnumerable<WishList> wishLists { get; set; }

        public ProductIndex()
        {

        }
    }
}