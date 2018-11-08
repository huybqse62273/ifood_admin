namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Document")]
    public partial class Document
    {
        public int Id { get; set; }

        public Guid ObjectId { get; set; }

        [Required]
        public string Source { get; set; }

        public bool? IsDelete { get; set; }
    }
}
