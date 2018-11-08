namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Dish_Ingredient
    {
        public int Id { get; set; }

        public Guid DishId { get; set; }

        public Guid IngredientId { get; set; }

        public double? Amount { get; set; }

        public int? UnitId { get; set; }

        public string Description { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Ingredient Ingredient { get; set; }
    }
}
