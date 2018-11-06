namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string UserID { get; set; }

        public DateTime? DateOrder { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [StringLength(12)]
        public string Phone { get; set; }

        [StringLength(20)]
        public string CardID { get; set; }

        public bool? Status { get; set; }

        public string Description { get; set; }

        public double? Total { get; set; }
    }
}
