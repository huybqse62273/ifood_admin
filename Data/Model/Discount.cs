namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Discount
    {
        public int ID { get; set; }

        public string Description { get; set; }

        public int? Percentary { get; set; }

        public DateTime? DateCreated { get; set; }

        public int? DateCount { get; set; }

        public int ProductID { get; set; }

        public bool? Status { get; set; }
    }
}
