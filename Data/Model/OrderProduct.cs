namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class OrderProduct
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int ProductID { get; set; }

        public int? Quantity { get; set; }

        public string Name { get; set; }

        public double? Price { get; set; }
    }
}
