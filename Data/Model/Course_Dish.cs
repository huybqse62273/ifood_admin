namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Course_Dish
    {
        public int Id { get; set; }

        public Guid CourseId { get; set; }

        public Guid DishId { get; set; }

        public string Description { get; set; }

        public virtual Course Course { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
