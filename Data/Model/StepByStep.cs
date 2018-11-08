namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StepByStep")]
    public partial class StepByStep
    {
        public int Id { get; set; }

        public Guid DishId { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageSource { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
