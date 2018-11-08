namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dish")]
    public partial class Dish
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Dish()
        {
            Category_Dish = new HashSet<Category_Dish>();
            CookBook_Dish = new HashSet<CookBook_Dish>();
            Course_Dish = new HashSet<Course_Dish>();
            Dish_Ingredient = new HashSet<Dish_Ingredient>();
            Reviews = new HashSet<Review>();
            ShoppingLists = new HashSet<ShoppingList>();
            StepBySteps = new HashSet<StepByStep>();
        }

        public Guid Id { get; set; }

        public Guid AuthorId { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public DateTime? CreateOn { get; set; }

        public double? Rate { get; set; }

        [StringLength(50)]
        public string TimeCooking { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDelete { get; set; }

        public string Description { get; set; }

        public string ImageLink { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category_Dish> Category_Dish { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CookBook_Dish> CookBook_Dish { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Course_Dish> Course_Dish { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Dish_Ingredient> Dish_Ingredient { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Review> Reviews { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingList> ShoppingLists { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StepByStep> StepBySteps { get; set; }
    }
}
