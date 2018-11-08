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
        public ActionResult AdminIndex()
        {
            //var db = new IFood();
            //User user = new User();
            //user.Id = Guid.NewGuid();
            //user.Name = "testcuahuy";
            //user.Email = "huybqse@gamial.com";
            //user.Password = "123";
            //user.PhoneNumber = "01665169260";
            //user.City = "HCM";
            //user.District = "Quan tan binh";
            //user.Address = "asf";
            //user.IsDelete = false;

            //db.Users.Add(user);
            //db.SaveChanges();

            return View();
        }
    }
}