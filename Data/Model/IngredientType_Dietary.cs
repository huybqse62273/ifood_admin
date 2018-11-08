namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class IngredientType_Dietary
    {
        public int Id { get; set; }

        public int IngredientTypeId { get; set; }

        public int DietaryId { get; set; }

        public string Description { get; set; }

        public virtual DietaryPreference DietaryPreference { get; set; }

        public virtual IngredientType IngredientType { get; set; }
    }
}
