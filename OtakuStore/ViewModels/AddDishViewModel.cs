using Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OtakuStore.ViewModels
{
    public class AddDishViewModel
    {
        public List<Category> listCategory { get; set; }
        public List<Ingredient> listIngredient { get; set; }
        public List<Unit> listUnit { get; set; }
    }
}