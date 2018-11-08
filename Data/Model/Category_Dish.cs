namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Category_Dish
    {
        public int Id { get; set; }

        public Guid CategoryId { get; set; }

        public Guid DishId { get; set; }

        public string Description { get; set; }

        public virtual Category Category { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
