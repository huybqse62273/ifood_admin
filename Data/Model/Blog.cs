namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Blog
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string BlogImage { get; set; }

        public string Description { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Publisher { get; set; }

        public bool IsHidden { get; set;}
    }
}
