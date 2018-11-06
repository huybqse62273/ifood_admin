namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductTag
    {
        public int Id { get; set; }

        public int ProductID { get; set; }

        public int TagID { get; set; }
    }
}
