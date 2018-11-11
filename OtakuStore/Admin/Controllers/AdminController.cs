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

        //=============Orders Index action=============//

        public ActionResult OrdersIndex()
        {
            var db = new IFood();
            OrdersViewModel model = new OrdersViewModel();
            model.listTransasction = db.Transactions.Select(t => t).ToList<Transaction>();
            return View(model);
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

        //ingredient  -----------<><><>
        public ActionResult clickListIngredient()
        {
            var db = new IFood();
            IngredientViewModel model = new IngredientViewModel();/// can dung order model
            model.listIngredient = db.Ingredients.Select(d => d).ToList<Ingredient>();
            return View("ListIngredient",model);
        }
    }
}