using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Data;
using OtakuStore.ViewModels;
using Data.Model;
using PagedList;
using Microsoft.AspNet.Identity;

namespace OtakuStore.Controllers
{   

    public class HomeController : Controller
    {

        #region field
        IAccountService _accountService;
        IProductService _productService;
        IImageService _imageService;
        IManufactorService _manufactorService;
        ICategoryService _categoryService;
        IAnimeService _animeService;
        ITagService _tagService;
        IBlogService _blogService;
        IWishListService _wishListService;
        IProductTagService _productTagService;
        IMessageSendingService _messageSendingService;
        IWebsiteAttributeService _websiteAttributeService;
        IFAQService _faqService;
        #endregion

        #region ctor
        public HomeController(IAccountService _accountService, IProductService _productService, IImageService _imageService,
            IManufactorService _manufactorService, ICategoryService _categoryService, IAnimeService _animeService,
            IWishListService _wishListService, IProductTagService _productTagService,ITagService _tagService, IBlogService _blogService,
            IMessageSendingService _messageSendingService, IWebsiteAttributeService _websiteAttributeService,
            IFAQService _faqService)
        {
            this._accountService = _accountService;
            this._productService = _productService;
            this._imageService = _imageService;
            this._manufactorService = _manufactorService;
            this._categoryService = _categoryService;
            this._animeService = _animeService;
            this._wishListService = _wishListService;
            this._blogService = _blogService;
            this._tagService = _tagService;
            this._productTagService = _productTagService;
            this._messageSendingService = _messageSendingService;
            this._websiteAttributeService = _websiteAttributeService;
            this._faqService = _faqService;
        }
        #endregion
        public ActionResult Index(string contactValue)
        {
            HomeViewModel model = new HomeViewModel();
            List<Product> products = _productService.Get().ToList();
            List<Image> images = _imageService.GetAll().ToList();
            List<Manufactor> manufactors = _manufactorService.GetAll().ToList();
            IEnumerable<Category> categories = _categoryService.GetAll().ToList();
            IEnumerable<Anime> animes = _animeService.GetAll().ToList();
            model.products = products;
            model.images = images;
            model.manufactors = manufactors;
            model.categories = categories;
            model.animes = animes;
            model.wishLists = User.Identity.IsAuthenticated ? _wishListService.GetAll().Where(m => m.UserID == User.Identity.GetUserId()) : null;

            if (contactValue != null)
            {
                ViewBag.ContactSuccessfull = "Your message was submit. We will contact you later!";
            }
            return View(model);
        }

        public PartialViewResult RecentlyReview()
        {
            RecentlyReviewViewModel model = new RecentlyReviewViewModel();
            List<Product> products = _productService.Get().ToList();
            List<Image> images = _imageService.GetAll().ToList();
            List<Manufactor> manufactors = _manufactorService.GetAll().ToList();
            
            model.products = products;
            model.images = images;
            model.manufactors = manufactors;
            model.wishLists = User.Identity.IsAuthenticated ? _wishListService.GetAll().Where(m => m.UserID == User.Identity.GetUserId()) : null;

            return PartialView("_RecentlyReview", model);
        }

        public PartialViewResult TopBrand()
        {
            IEnumerable<Manufactor> manufactors = _manufactorService.GetAll();
            return PartialView("_TopBrands",manufactors);
        }

        public PartialViewResult WebsiteAttributes(string partialName)
        {
            WebsiteAttribute websiteAttribute = _websiteAttributeService.GetAll().First();
            WebsiteAttributeViewModel model = new WebsiteAttributeViewModel();
            model.websiteAttribute = websiteAttribute;

            return PartialView(partialName, model);
        }

        public int WishList()
        {
            int count = 0;
            IEnumerable<WishList> model = new List<WishList>();
            if (User.Identity.IsAuthenticated)
            {
                model = _wishListService.GetAll().Where(m => m.UserID == User.Identity.GetUserId());
            }
            count = model.Count();
            return count;
        }
        public ActionResult Product()
        {

            return View();
        }

        public ActionResult CategoryGrid()
        {

            return View();
        }

        public ActionResult Login()
        {

            return View();
        }

        public ActionResult Register()
        {

            return View();
        }
        [Authorize(Roles="User")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }
        [Authorize(Roles = "User")]
        public ActionResult Contact()
        {
            
            WebsiteAttributeViewModel model = new WebsiteAttributeViewModel();
            WebsiteAttribute websiteAttribute = _websiteAttributeService.GetAll().First();
            model.websiteAttribute = websiteAttribute;
            if (User.Identity.IsAuthenticated)
            {
                Account account = _accountService.GetByUserId(User.Identity.GetUserId());
                model.websiteAttribute.email = account.Email;
                model.websiteAttribute.phone = account.PhoneNumber;
                model.websiteAttribute.name = account.UserName;
            }
            return View(model);
        }

        public ActionResult FAQ()
        {
            IEnumerable<FAQ> model = _faqService.Get().Where(m => !m.isHidden);
            return View(model);
        }
        public ActionResult Blog()
        {
            List<Blog> list = _blogService.GetAll().OrderByDescending(d => d.DateCreated).ToList();
            BlogViewModel model = new BlogViewModel();
            model.listBlog = list;
            return View(model);
        }
        
        public ActionResult BlogIndex(int id)
        {
            Blog blog = _blogService.GetById(id);
            List<Blog> listBlog = _blogService.GetAll().OrderByDescending(d => d.DateCreated).ToList();
            BlogViewModel model = new BlogViewModel();
            model.blog = blog;
            model.listBlog = listBlog;

            return View(model);
        }

        public ActionResult Search(string keyword, int? page,int? chkBrand,double? price)
        {
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            if (keyword == null)
            {
                keyword = "";
            }
            else
            {
                keyword = keyword.ToLower();
            }
            List<Data.Product> list = new List<Data.Product>();
            IEnumerable<Image> images = _imageService.GetAll().ToList();
            IEnumerable<Manufactor> manufactors = _manufactorService.GetAll().ToList();
            IEnumerable<Category> categorys = _categoryService.GetAll();
            IEnumerable<Tag> tags = _tagService.GetAll();
            IEnumerable<Category> categories = _categoryService.GetAll();
            IEnumerable<Anime> animes = _animeService.GetAll();
            SearchViewModel model = new SearchViewModel();
            if (keyword == null)
            {
                
            }else if (keyword.Equals("featured"))//more product theo key
            {
                list = _productService.Get().Where(p => p.isDelete == false).OrderByDescending(d => d.C_View).ToList();
            }else if (keyword.Equals("new-arrivals"))
            {
                list = _productService.Get().Where(p => p.isDelete == false).OrderByDescending(d => d.DateCreated).ToList();
            }else if (keyword.Equals("top-sales"))
            {
                list = _productService.Get().Where(p => p.isDelete == false).OrderByDescending(d => d.SaleRate).ToList();
            }
            else if (manufactors.Where(m => m.Name.ToLower().Equals(keyword)).Any())//search theo manufactors
            {
                Manufactor manufactor = manufactors.Where(m => m.Name.ToLower().Equals(keyword)).FirstOrDefault();
                list = _productService.Get().Where(p => p.isDelete == false).Where(m => m.ManufactorID == manufactor.Id).ToList();
            }
            else if (categorys.Where(m => m.title.ToLower().Equals(keyword)).Any())//search theo type
            {
                Category type = categorys.Where(m => m.title.ToLower().Equals(keyword)).FirstOrDefault();
                list = _productService.Get().Where(p => p.isDelete == false).Where(m => m.CategoryID == type.id).ToList();
            }else if (tags.Where(m => m.Name.ToLower().Equals(keyword)).Any())
            {
                Tag tag = tags.Where(m => m.Name.ToLower().Equals(keyword)).FirstOrDefault();
                IEnumerable<ProductTag> productTags = _productTagService.GetAll().Where(m => m.TagID == tag.Id);
                foreach (var item in productTags)
                {
                    if(_productService.GetById(item.ProductID).isDelete == false)
                    {
                        list.Add(_productService.GetById(item.ProductID));
                    }
                }
            }
            else //search theo name san pham
            {
                var allProduct = _productService.Get().Where(p => p.isDelete == false);
                foreach (var item in allProduct)
                {
                    if (item.Name.ToLower().Contains(keyword))
                    {
                        list.Add(item);
                    }
                }
            }
            model.productAll = list;//danh cho filter para luu tru tat ca cac sp da search ra
            if (chkBrand.HasValue)//filter cho brand
            {
                list = list.Where(m => m.ManufactorID == chkBrand.Value).ToList();
                ViewBag.Brand = chkBrand.Value ;
            }
            if (price.HasValue)//filter cho price
            {
                double Price = price.HasValue ? price.Value : 50000;
                list = list.Where(m => m.Price > Price).ToList();
                ViewBag.Price = price.Value;
            }

            model.list = list.ToPagedList(pageNumber, pageSize);
            model.categories = categories;
            model.animes = animes;
            model.images = images;
            model.manufactors = manufactors;
            model.wishLists = User.Identity.IsAuthenticated ? _wishListService.GetAll().Where(m => m.UserID == User.Identity.GetUserId()) : null;
            ViewBag.Size = list.Count;
            ViewBag.keyword = keyword;
            ViewBag.page = page.HasValue ? page.Value : 1;
            
            return View(model);
        }

        public ActionResult SendMessage(string nameInput, string mailInput, string phoneInput, string subjectInput, string messageInput)
        {
            MessageSending messageInfo = new MessageSending();
            messageInfo.name = nameInput;
            messageInfo.email = mailInput;
            messageInfo.phone = phoneInput;
            messageInfo.subject = subjectInput;
            messageInfo.message = messageInput;
            messageInfo.time = DateTime.Now;

            _messageSendingService.createMessageSending(messageInfo);

            return RedirectToAction("Index", "Home", new { contactValue = "successful" });
        }

        public ActionResult CheckOrderByCode()
        {

            return View();
        }
    }
}