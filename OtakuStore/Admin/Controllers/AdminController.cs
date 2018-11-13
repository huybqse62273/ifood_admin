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
            try {
                model.listCourse = db.Courses.ToList<Course>();
            }
            catch(Exception e)
            {

            }
            

            return View(model);
        }

        public ActionResult EditDish(string id)
        {
            var db = new IFood();
            EditDishViewModel model = new EditDishViewModel();
            model.dish = db.Dishes.Where(d => d.Id.ToString().Equals(id)).FirstOrDefault<Dish>();
            model.listCategory = db.Categories.ToList<Category>();
            model.listIngredient = db.Ingredients.ToList<Ingredient>();
            model.listUnit = db.Units.ToList<Unit>();
            model.listCourse = db.Courses.ToList<Course>();

            return View(model);
        }

        public ActionResult EditDishAction(string dish_id, string dish_title, string dish_image, string[] dish_ingredient, int[] dish_ingredient_amount
            , string[] dish_step, string[] dish_tag, int dish_timecooking, string dish_category, string dish_description)
        {
            var db = new IFood();
            Dish dish = db.Dishes.Where(d => d.Id.ToString().Equals(dish_id)).FirstOrDefault<Dish>();
            try
            {
                dish.Name = dish_title;
                dish.ImageLink = dish_image;
                dish.Description = dish_description;
                dish.TimeCooking = dish_timecooking + " minutes";

                for (int i = 0; i < dish_ingredient.Length; i++)
                {
                    var ingredient = dish_ingredient[i].ToString();
                    if (i >= dish.Dish_Ingredient.Count())
                    {
                        Dish_Ingredient dish_Ingredient = new Dish_Ingredient();
                        dish_Ingredient.IngredientId = Guid.Parse(dish_ingredient[i]);
                        dish_Ingredient.Amount = dish_ingredient_amount[i];
                        dish_Ingredient.UnitId = int.Parse(db.Ingredients.Where(ing => ing.Id.ToString().Equals(ingredient)).First().UnitId.Trim());
                        dish_Ingredient.DishId = dish.Id;
                        dish_Ingredient.Description = "";
                        dish.Dish_Ingredient.Add(dish_Ingredient);
                    }
                    else
                    {
                        dish.Dish_Ingredient.ElementAt(i).IngredientId = Guid.Parse(dish_ingredient[i]);
                        dish.Dish_Ingredient.ElementAt(i).Amount = dish_ingredient_amount[i];
                        dish.Dish_Ingredient.ElementAt(i).UnitId = int.Parse(db.Ingredients.Where(ing => ing.Id.ToString().Equals(ingredient)).First().UnitId.Trim());
                    }
                }

                for (int i = 0; i < dish_step.Length; i++)
                {
                    if (i >= dish.StepBySteps.Count())
                    {
                        StepByStep step = new StepByStep();
                        step.DishId = dish.Id;
                        step.Title = "Step" + (i + 1);
                        step.Description = dish_step[i];
                        dish.StepBySteps.Add(step);
                    }
                    else
                    {
                        dish.StepBySteps.ElementAt(i).Description = dish_step[i];
                    }
                }

                for (int i = 0; i < dish_tag.Length; i++)
                {
                    if( i>= dish.Course_Dish.Count())
                    {
                        Course_Dish course = new Course_Dish();
                        course.CourseId = Guid.Parse(dish_tag[i]);
                        course.DishId = dish.Id;
                        dish.Course_Dish.Add(course);
                    }
                    else
                    {
                        dish.Course_Dish.ElementAt(i).CourseId = Guid.Parse(dish_tag[i]);
                    }             
                }

                dish.Category_Dish.First().Description = dish_description;
                db.SaveChanges();
            }
            catch (Exception e)
            {
               
            }
            return RedirectToAction("AdminIndex");
        }

        public ActionResult AddDishAction(string dish_title, string dish_image, string[] dish_ingredient, int[] dish_ingredient_amount
            , string[] dish_step, string[] dish_tag, int dish_timecooking , string dish_category, string dish_description)
        {
            var db = new IFood();
            Dish dish = new Dish();
            try
            {
                dish.Id = Guid.NewGuid();
                dish.Name = dish_title;
                dish.ImageLink = dish_image;
                dish.AuthorId = db.Users.FirstOrDefault().Id;
                dish.IsActive = true;
                dish.IsDelete = false;
                dish.Rate = 0;
                dish.TimeCooking = dish_timecooking + " minutes";
       

                dish.CreateOn = DateTime.Now;
                dish.Description = dish_description;

                for (int i = 0; i < dish_ingredient.Length; i++)
                {
                    Dish_Ingredient dish_Ingredient = new Dish_Ingredient();
                    dish_Ingredient.IngredientId = Guid.Parse(dish_ingredient[i]);
                    dish_Ingredient.Amount = dish_ingredient_amount[i];
                    var ingredient = dish_ingredient[i].ToString();
                    dish_Ingredient.UnitId = int.Parse(db.Ingredients.Where(ing => ing.Id.ToString().Equals(ingredient)).First().UnitId.Trim());
                    dish_Ingredient.DishId = dish.Id;
                    dish_Ingredient.Description = "";
                    dish.Dish_Ingredient.Add(dish_Ingredient);
                }

                for (int i = 0; i < dish_step.Length; i++)
                {
                    StepByStep step = new StepByStep();
                    step.DishId = dish.Id;
                    step.Title = "Step" + (i + 1);
                    step.Description = dish_step[i];
                    dish.StepBySteps.Add(step);
                }

                for (int i = 0; i < dish_tag.Length; i++)
                {
                    Course_Dish course = new Course_Dish();
                    course.CourseId = Guid.Parse(dish_tag[i]);
                    course.DishId = dish.Id;
                    dish.Course_Dish.Add(course);
                }

                Category_Dish category = new Category_Dish();
                category.CategoryId = Guid.Parse(dish_category);
                category.DishId = dish.Id;
                category.Description = dish_description;
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

        public ActionResult clickAddIngredient()
        {
            //var db = new IFood();
            //List<Unit> model = new List<Unit>();
            //model = db.Units.ToList<Unit>();
            return View();
        }

        public ActionResult AddIngredient( string txtName, string txtType, string txtDesc, string txtUnit,
            string txtPrice)
        {
            try
            {
                var db = new IFood();
                Ingredient model = new Ingredient();
                model.Id = Guid.NewGuid();
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
        //----------UserList
        public ActionResult ListUser()
        {
            var db = new IFood();
            UserViewModel model = new UserViewModel();/// can dung order model
            model.userList = db.Users.Select(d => d).ToList<User>();
            return View(model);
        }
    }
}