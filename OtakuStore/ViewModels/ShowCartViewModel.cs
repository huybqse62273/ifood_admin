using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtakuStore.ViewModels
{
    public class ShowCartViewModel
    {
        public List<OrderProduct> list { get; set; }
        public IEnumerable<Image> image { get; set; }
        public IEnumerable<Manufactor> manufactor { get; set; }
    }
}