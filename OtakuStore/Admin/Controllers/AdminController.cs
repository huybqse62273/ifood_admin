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
        public ActionResult AdminIndex(string username)
        {
            var db = new IFood();

            AdminIndexViewModel model = new AdminIndexViewModel();
            model.list = db.Dishes.Select(x =>x).ToList<Dish>();
            ViewBag.UserName = username;
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
    }
}