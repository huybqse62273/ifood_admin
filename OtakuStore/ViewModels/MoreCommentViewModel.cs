using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Data;
namespace OtakuStore.ViewModels
{
    public class MoreCommentViewModel
    {
        public IEnumerable<Comment> comments { get; set; }
        public int offset { get; set; }
        public int size { get; set; }
        public bool isNext { get; set; }
        public int productId { get; set; }
    }
}