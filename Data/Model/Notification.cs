namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Notification
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int CommentID { get; set; }

        [Required]
        [StringLength(128)]
        public string UserID { get; set; }

        public DateTime? TimeReceive { get; set; }

        public int Type { get; set; }

        public int? SaleRate { get; set; }

        public int? StatusID { get; set; }

        public bool isView { get; set; }

        public int ProductID { get; set; }
    }
}
