namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WishList
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public int ProductID { get; set; }

    }
}
