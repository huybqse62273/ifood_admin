using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model
{
    public partial class WebsiteAttribute
    {
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string district { get; set; }
        public string phone { get; set; }
        public string location { get; set; }
        public string logo { get; set; }
        public string description { get; set; }
    }
}
