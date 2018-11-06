namespace Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        public Comment()
        {

        }
        public Comment(int ProductId,string UserID,int Rate,string Comment)//ctor for comment Product
        {
            this.ProductID = ProductId;
            this.UserID = UserID;
            this.Rate = Rate;
            this.Comment1 = Comment;
            this.BlogID = 0;//kf la comment cua th blog
            this.Type = 1; //1 la comment cua product 2 la cua th blog
            this.dateCreate = DateTime.Now;
            this.isDelete = false;
        }
        public int Id { get; set; }

        public int ProductID { get; set; }

        [StringLength(128),Required]
        public string UserID { get; set; }

        public int? Rate { get; set; }

        [Column("Comment")]
        public string Comment1 { get; set; }

        public int BlogID { get; set; }

        public int? Type { get; set; }

        public DateTime dateCreate { get; set; }

        public bool isDelete { get; set; }

        public virtual Account Account { get; set; }
    }
}
