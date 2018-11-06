namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? ManufactorID { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int StatusID { get; set; }

        public int CategoryID { get; set; }

        [Column("_View")]
        public int? C_View { get; set; }

        public int? OrderCounter { get; set; }

        public string Size { get; set; }

        public DateTime? DateCreated { get; set; }
        public int? Rate { get; set; }
        public bool isDelete { get; set; }
        public int SaleRate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}
