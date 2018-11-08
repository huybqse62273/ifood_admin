namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public int Id { get; set; }

        public Guid DishId { get; set; }

        public Guid? UserId { get; set; }

        public string Comment { get; set; }

        public double? Rate { get; set; }

        public DateTime? ReviewOn { get; set; }

        public bool? IsDelete { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual User User { get; set; }
    }
}
