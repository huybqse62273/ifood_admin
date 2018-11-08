namespace Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User_Dietary
    {
        public int Id { get; set; }

        public Guid UserId { get; set; }

        public int DietaryId { get; set; }

        public string Description { get; set; }

        public DateTime? CreateOn { get; set; }

        public virtual DietaryPreference DietaryPreference { get; set; }

        public virtual User User { get; set; }
    }
}
