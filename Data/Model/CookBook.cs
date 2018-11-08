namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CookBook")]
    public partial class CookBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CookBook()
        {
            CookBook_Dish = new HashSet<CookBook_Dish>();
        }

        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public Guid UserId { get; set; }

        public string Description { get; set; }

        public DateTime? CreateOn { get; set; }

        public bool? IsDelete { get; set; }

        public string ImageLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CookBook_Dish> CookBook_Dish { get; set; }

        public virtual User User { get; set; }
    }
}
