namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ShoppingList")]
    public partial class ShoppingList
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public Guid TransactionId { get; set; }

        public Guid DishId { get; set; }

        public Guid IngredientId { get; set; }

        public string Description { get; set; }

        public double? Amount { get; set; }

        public int? Status { get; set; }

        public virtual Dish Dish { get; set; }

        public virtual Ingredient Ingredient { get; set; }

        public virtual Transaction Transaction { get; set; }

        public virtual User User { get; set; }
    }
}
