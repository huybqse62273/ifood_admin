namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CookBook_Dish
    {
        public int Id { get; set; }

        public Guid DishId { get; set; }

        public Guid CookbookId { get; set; }

        public virtual CookBook CookBook { get; set; }

        public virtual Dish Dish { get; set; }
    }
}
