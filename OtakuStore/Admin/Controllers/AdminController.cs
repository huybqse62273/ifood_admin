using Data;
using Data.Model;
using OtakuStore.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Microsoft.AspNet.Identity;

namespace OtakuStore.Admin.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        #region field
        IAccountService _accountService;
        IProductService _productService;
        IImageService _imageService;
        IManufactorService _manufactorService;
        ICategoryService _categoryService;
        IAnimeService _animeService;
        IStatusService _statusService;
        IBlogService _blogService;
        IProductTagService _productTagService;
        ITagService _tagService;
        IWebsiteAttributeService _websiteAttributeService;
        IMessageSendingService _messageSendingService;
        IFAQService _faqService;
        #endregion

        #region ctor
        public AdminController(IAccountService _accountService, IProductService _productService, IImageService _imageService,
            IManufactorService _manufactorService, ICategoryService _categoryService, IAnimeService _animeService, IStatusService _statusService
            , IBlogService _blogService, IProductTagService _productTagService, ITagService _tagService, IWebsiteAttributeService _websiteAttributeService
            , IMessageSendingService _messageSendingService, IFAQService _faqService)
        {
            this._accountService = _accountService;
            this._productService = _productService;
            this._imageService = _imageService;
            this._manufactorService = _manufactorService;
            this._categoryService = _categoryService;
            this._animeService = _animeService;
            this._statusService = _statusService;
            this._blogService = _blogService;
            this._productTagService = _productTagService;
            this._tagService = _tagService;
            this._websiteAttributeService = _websiteAttributeService;
            this._messageSendingService = _messageSendingService;
            this._faqService = _faqService;
        }
        #endregion


        //=============Admin Index action=============//
        public ActionResult AdminIndex()
        {
            var db = new IFood();
            AdminIndexViewModel model = new AdminIndexViewModel();
            model.listDish = db.Dishes.Select(d=> d).ToList<Dish>();
            return View(model);
        }

        public ActionResult DisableDish(string id)
        {
            var db = new IFood();
            db.Dishes.Where(d => d.Id.ToString().Equals(id)).FirstOrDefault<Dish>().IsActive = false;
            db.SaveChanges();

            return RedirectToAction("AdminIndex" , "Admin");
        }

        public ActionResult EnableDish(string id)
        {
            var db = new IFood();
            db.Dishes.Where(d => d.Id.ToString().Equals(id)).FirstOrDefault<Dish>().IsActive = true;
            db.SaveChanges();

            return RedirectToAction("AdminIndex", "Admin");
        }

        //=============New Dish action=============//
        public ActionResult AddIndex()
        {
            var db = new IFood();
            AddDishViewModel model = new AddDishViewModel();
            model.listCategory = db.Categories.ToList<Category>();
            model.listIngredient = db.Ingredients.ToList<Ingredient>();
            model.listUnit = db.Units.ToList<Unit>();

            return View(model);
        }

        public ActionResult AddDishAction(string dish_title, string dish_image, string[] dish_ingredient, int[] dish_ingredient_amount
            , int[] dish_ingredient_unit, string[] dish_step, string dish_category, string dish_description)
        {
            try
            {
                var db = new IFood();
                Dish dish = new Dish();
                dish.Id = Guid.NewGuid();
                dish.Name = dish_title;
                dish.ImageLink = dish_image;
                for (int i = 0; i < dish_ingredient.Length; i++)
                {
                    Dish_Ingredient dish_Ingredient = new Dish_Ingredient();
                    dish_Ingredient.IngredientId = Guid.Parse(dish_ingredient[i]);
                    dish_Ingredient.Amount = dish_ingredient_amount[i];
                    dish_Ingredient.UnitId = dish_ingredient_unit[i];
                    dish_Ingredient.DishId = dish.Id;
                    dish_Ingredient.Description = "";
                    dish.Dish_Ingredient.Add(dish_Ingredient);
                }
                dish.CreateOn = DateTime.Now;
                dish.Description = "";
                for (int i = 0; i < dish_step.Length; i++)
                {
                    StepByStep step = new StepByStep();
                    step.DishId = dish.Id;
                    step.Title = "Step" + (i + 1);
                    step.Description = dish_step[i];
                    dish.StepBySteps.Add(step);
                }
                Category_Dish category = new Category_Dish();
                category.CategoryId = Guid.Parse(dish_category);
                category.DishId = dish.Id;
                category.Description = "";
                dish.Category_Dish.Add(category);

                db.Dishes.Add(dish);
                db.SaveChanges();
            }
            catch(Exception e)
            {

            }
            return RedirectToAction("AdminIndex");
        }

        //=============Orders Index action=============//

        public ActionResult OrdersIndex()
        {
            var db = new IFood();
            OrdersViewModel model = new OrdersViewModel();
            model.listTransasction = db.Transactions.Select(t => t).ToList<Transaction>();
            return View(model);
        }
        public ActionResult clickListOrder()
        {
            var db = new IFood();
            OrdersViewModel model = new OrdersViewModel();/// can dung order model
            model.listTransasction = db.Transactions.Select(d => d).ToList<Transaction>();
            return View("ListOrder", model);
        }

        public ActionResult chageOderStatus(String id, int status)
        {
            status = (status + 1) % 3; // chỗ này click vào status sẽ đổi từ pending -> success -> cancel -> pending
            var db = new IFood();
            db.Transactions.Where(d => d.Id.ToString().Equals(id)).FirstOrDefault<Transaction>().Status = status;
            db.SaveChanges();

            return RedirectToAction("OrdersIndex");
        }

        //=============Login action=============//
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult CheckLogin(string username, string pass)
        {
            if(username.Equals("admin") && pass.Equals("admin"))
            {
                return RedirectToAction("AdminIndex", "Admin", new {username = username });
            }
            ViewBag.ErrorMess = "Invalid username or password";
            return View("Login");
        }

      

        //ingredient  -----------<><><>
        public ActionResult clickListIngredient()
        {
            var db = new IFood();
            IngredientViewModel model = new IngredientViewModel();/// can dung order model
            model.listIngredient = db.Ingredients.Select(d => d).ToList<Ingredient>();
            return View("ListIngredient",model);
        }

        public ActionResult clickEditIngredient(String id)
        {
            var db = new IFood();
            Ingredient model = new Ingredient();
            model = db.Ingredients.First(d => d.Id == new Guid(id));
            return View(model);
        }

        public ActionResult SaveIngredient(string txtId, string txtName, string txtType, string txtDesc, string txtUnit,
            string txtPrice )
        {
            try
            {
                var db = new IFood();
                Ingredient model = new Ingredient();
                model = db.Ingredients.First(d => d.Id == new Guid(txtId));
                model.Name = txtName.Trim(' ');
                int tmp = 0; int.TryParse(txtType, out tmp); model.TypeId = tmp;
                model.Description = txtDesc.Trim(' ');
                model.UnitId = txtUnit.Trim(' ');
                double tmp2 = 0.0; double.TryParse(txtPrice, out tmp2); model.PricePerUnit = tmp2;
                db.SaveChanges();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("clickListIngredient");
        }

        public ActionResult AddIngredient( string txtName, string txtType, string txtDesc, string txtUnit,
            string txtPrice)
        {
            try
            {
                var db = new IFood();
                Ingredient model = new Ingredient();
                model.Id = new Guid();
                model.Name = txtName.Trim(' ');
                int tmp = 0; int.TryParse(txtType, out tmp); model.TypeId = tmp;
                model.Description = txtDesc.Trim(' ');
                model.UnitId = txtUnit.Trim(' ');
                double tmp2 = 0.0; double.TryParse(txtPrice, out tmp2); model.PricePerUnit = tmp2;
                db.Ingredients.Add(model);
                db.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return RedirectToAction("clickListIngredient");
        }
    }
}