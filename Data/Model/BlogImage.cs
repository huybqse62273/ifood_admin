namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BlogImage
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public int BlogID { get; set; }
    }
}
