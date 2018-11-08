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
            , IMessageSendingService _messageSendingService,IFAQService _faqService)
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
            var db = new IFood();
            Category c = new Category
            {
                Id = Guid.NewGuid(),

            };
           
            return View();
        }

        //=============Website Attributes=============//

        public ActionResult WebsiteAttributeInfo(string notify)
        {
            WebsiteAttribute websiteAttribute = _websiteAttributeService.GetAll().First();
            WebsiteAttributeViewModel model = new WebsiteAttributeViewModel();
            model.websiteAttribute = websiteAttribute;

            if (notify != null)
            {
                ViewBag.notify = "Successful";
            }

            return View(model);
        }

        public ActionResult EditWebsiteAttributes(int id, string name, string email, string logo, string description, string address,
            string country, string city, string district, string phone, string x_cor, string y_cor)
        {
            WebsiteAttribute websiteAttribute = _websiteAttributeService.GetById(id);
            websiteAttribute.name = name; websiteAttribute.email = email; websiteAttribute.phone = phone;
            websiteAttribute.description = description; websiteAttribute.address = address; websiteAttribute.country = country;
            websiteAttribute.city = city; websiteAttribute.district = district; websiteAttribute.location = x_cor + "," + y_cor;
            if (!logo.Equals(""))
            {
                websiteAttribute.logo = "/Content/Images/BG/" + logo;
            }


            _websiteAttributeService.editWebsiteAttribute(websiteAttribute);

            return RedirectToAction("WebsiteAttributeInfo", "Admin", new { notify = "successful" });
        }

        //=============Blog=============//

        public ActionResult BlogManagement(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;

            IPagedList<Blog> listBlog = _blogService.GetAll().OrderByDescending(d => d.DateCreated).ToList().ToPagedList(pageNumber, pageSize);
            BlogViewModel model = new BlogViewModel();
            model.PagedList = listBlog;

            return View(model);
        }

        public ActionResult BlogInfo(int id)
        {
            Blog blog = _blogService.GetById(id);
            BlogViewModel model = new BlogViewModel();
            model.blog = blog;

            return View(model);
        }

        public ActionResult NewBlog()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddNewBlog(string blog_title, string blog_image, string blog_description, string publisher)
        {
            Blog blog = new Blog();
            blog.Title = blog_title;
            blog.BlogImage = "/Content/Images/blog-post/" + blog_image;
            blog.Description = blog_description;
            blog.Publisher = "Admin";
            blog.DateCreated = DateTime.Now;

            _blogService.createBlog(blog);
            return RedirectToAction("BlogManagement");
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult EditBlog(int blog_id, string blog_title, string blog_image, string blog_description)
        {
            Blog blog = _blogService.GetAll().Where(d => d.Id == blog_id).First();
            blog.Title = blog_title;
            blog.BlogImage = "/Content/Images/blog-post/" + blog_image;
            blog.Description = blog_description;
            _blogService.editBlog(blog);

            return RedirectToAction("BlogManagement");
        }

        public ActionResult HideBlog(int id)
        {
            Blog blog = _blogService.GetById(id);
            if (blog.IsHidden)
            {
                blog.IsHidden = false;
            }
            else
            {
                blog.IsHidden = true;
            }
            _blogService.editBlog(blog);
            return RedirectToAction("BlogManagement");
        }

        public ActionResult FAQManagement(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;

            IPagedList<FAQ> listFAQ = _faqService.Get().ToList().ToPagedList(pageNumber, pageSize);
            FAQViewModel model = new FAQViewModel();
            model.PagedList = listFAQ;

            return View(model);
        }
        public ActionResult addFAQ()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult addFAQ(string FAQ_title,string FAQ_description)
        {
            FAQ faq = new FAQ
            {
                Title = FAQ_title,
                Description = FAQ_description,
                isHidden = false
            };
            _faqService.createFAQ(faq);
            return RedirectToAction("FAQManagement","Admin");
        }

        public ActionResult editFAQ(int Id)
        {
            FAQ model = _faqService.GetById(Id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult editFAQ(FAQ model)
        {
            if (ModelState.IsValid)
            {
                _faqService.editFAQ(model);
                return RedirectToAction("FAQManagement", "Admin");
            }
            return View(model);
        }

        public ActionResult HideFAQ(int id)
        {
            FAQ faq = _faqService.GetById(id);
            if (faq.isHidden)
            {
                faq.isHidden = false;
            }
            else
            {
                faq.isHidden = true;
            }
            
            _faqService.editFAQ(faq);
            return RedirectToAction("FAQManagement", "Admin");
        }
        //===================Products=================//

        public ActionResult ProductManagement(int? page, string notify)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;
            IPagedList<Product> products = _productService.Get().OrderByDescending(d => d.DateCreated).ToPagedList(pageNumber, pageSize);
            List<Status> status = _statusService.GetAll().ToList();
            ProductsViewModel model = new ProductsViewModel();
            model.products = products;
            model.status = status;

            if (notify != null)
            {
                ViewBag.notify = "successful";
            }

            return View(model);
        }

        public ActionResult NewProduct()
        {
            List<Status> status = _statusService.GetAll().ToList();
            List<Category> categories = _categoryService.GetAll().ToList();
            List<Manufactor> manufactors = _manufactorService.GetAll().ToList();
            List<Tag> listTag = _tagService.GetAll().ToList();

            ProductsViewModel model = new ProductsViewModel();
            model.status = status;
            model.categories = categories;
            model.manufactors = manufactors;
            model.tags = listTag;

            return View(model);
        }

        public ActionResult AddNewProduct(string title, int manufactor, string description, double price, int status,
            int category, string size, int saleRate, string[] img, string tags)
        {
            Product newProduct = new Product();
            newProduct.Name = title;
            newProduct.ManufactorID = manufactor;
            newProduct.Description = description;
            newProduct.Price = price;
            newProduct.StatusID = status;
            newProduct.CategoryID = category;
            newProduct.Size = size;
            newProduct.SaleRate = saleRate;
            newProduct.Rate = 0;
            newProduct.OrderCounter = 0;
            newProduct.C_View = 0;
            newProduct.DateCreated = DateTime.Now;
            newProduct.isDelete = false;

            _productService.createProduct(newProduct);
            int newProductId = _productService.Get().LastOrDefault().Id;

            Image image = new Image();
            string pathImage = "/Content/Images/Figure/";
            for (int i = 0; i < img.Length; i++)
            {
                if (!img[i].Equals(""))
                {
                    image.Link = pathImage + img[i];            
                }else
                {
                    image.Link = pathImage + "No-image-available.jpg";
                }
                image.ProductID = newProductId;
                _imageService.createImage(image);
            }

            string[] listTag = tags.Split(',');

            for (int i = 0; i < listTag.Length; i++)
            {
                Tag empTag = _tagService.GetAll().Where(d => d.Name.ToLower().Trim() == listTag[i].ToLower().Trim()).FirstOrDefault();
                if (empTag != null)
                {
                    ProductTag pt = new ProductTag();
                    pt.ProductID = newProductId;
                    pt.TagID = empTag.Id;
                    _productTagService.createProductTag(pt);
                }
                else
                {
                    Tag t = new Tag();
                    t.Name = listTag[i].Trim();
                    _tagService.createTag(t);

                    int newTagId = _tagService.GetAll().Last().Id;
                    ProductTag pt = new ProductTag();
                    pt.ProductID = newProductId;
                    pt.TagID = newTagId;
                    _productTagService.createProductTag(pt);
                }
            }

                return RedirectToAction("ProductManagement");
        }

        public ActionResult ProductInfo(int id)
        {
            Product product = _productService.GetById(id);
            List<Manufactor> manufactors = _manufactorService.GetAll().ToList();
            List<Status> status = _statusService.GetAll().ToList();
            List<Category> categories = _categoryService.GetAll().ToList();
            List<Image> images = _imageService.GetAll().Where(d => d.ProductID == id).ToList();
            List<Tag> listTag = _tagService.GetAll().ToList();
            List<ProductTag> productTagsList = _productTagService.GetAll().Where(d => d.ProductID == id).ToList();
            string productTags = "";
            for (int i = 0; i < productTagsList.Count(); i++)
            {
                if (i == 0)
                {
                    productTags = productTags + _tagService.GetAll().Where(d => d.Id == productTagsList.ElementAt(i).TagID).First().Name;
                }
                else
                {
                    productTags = productTags + "," + _tagService.GetAll().Where(d => d.Id == productTagsList.ElementAt(i).TagID).First().Name;
                }

            }

            ProductsViewModel model = new ProductsViewModel();
            model.product = product;
            model.manufactors = manufactors;
            model.status = status;
            model.categories = categories;
            model.images = images;
            model.product_tags = productTags;
            model.tags = listTag;

            return View(model);
        }

        public ActionResult EditProduct(int product_id, string title, int manufactor, string description,
            double price, int status, int category, string size, int saleRate, string[] images, string tags)
        {
            Product product = _productService.GetById(product_id);
            product.Name = title;
            product.ManufactorID = manufactor;
            product.Description = description;
            product.Price = price;
            product.StatusID = status;
            product.CategoryID = category;
            product.Size = size;
            product.SaleRate = saleRate;
            _productService.editProduct(product);

            int totalImageInDatabase = _imageService.GetAll().Where(d => d.ProductID == product_id).ToList().Count();
            for (int i = 0; i < images.Length; i++)
            {
                if (!images[i].Equals(""))
                {

                    if (i < totalImageInDatabase)
                    {
                        Image img = _imageService.GetAll().Where(d => d.ProductID == product_id).ToList().ElementAt(i);
                        img.Link = "/Content/Images/Figure/" + images[i];
                        img.ProductID = product_id;
                        _imageService.editImage(img);
                    }
                    else
                    {
                        Image img = new Image();
                        img.Link = "/Content/Images/Figure/" + images[i];
                        img.ProductID = product_id;
                        _imageService.createImage(img);
                    }
                }
            }
            string[] listTag = tags.Split(',');

            for (int i = 0; i < listTag.Length; i++)
            {
                Tag empTag = _tagService.GetAll().Where(d => d.Name.ToLower().Trim() == listTag[i].ToLower().Trim()).FirstOrDefault();
                if (empTag != null)
                {
                    ProductTag pt = _productTagService.GetAll().Where(d => d.ProductID == product_id && d.TagID == empTag.Id).FirstOrDefault();                   
                    if (pt == null)
                    {
                        pt = new ProductTag();
                        pt.ProductID = product_id;
                        pt.TagID = empTag.Id;
                        _productTagService.createProductTag(pt);
                    }
                }
                else
                {
                    Tag t = new Tag();
                    t.Name = listTag[i].Trim();
                    _tagService.createTag(t);

                    int newTagId = _tagService.GetAll().Last().Id;
                    ProductTag pt = new ProductTag();
                    pt.ProductID = product_id;
                    pt.TagID = newTagId;
                    _productTagService.createProductTag(pt);
                }
            }


            return RedirectToAction("ProductManagement", "Admin", new { notify = "successful" });
        }


        public ActionResult DeleteProduct(int id)
        {
            Product product = _productService.GetById(id);
            if (product != null)
            {
                if (product.isDelete == false)
                {
                    product.isDelete = true;
                    
                } else
                {
                    product.isDelete = true;

                }
                _productService.editProduct(product);
            }
            return RedirectToAction("ProductManagement");
        }

        //--------------User Management--------------//

        public ActionResult UserManagement(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 4;

            List<Account> listAccount = _accountService.GetAll().OrderByDescending(d => d.TimeCreated).ToList();
            UserViewModel model = new UserViewModel();
            model.accounts = listAccount.ToPagedList(pageNumber, pageSize);


            return View(model);
        }

        public ActionResult BlockUser(string id)
        {

            Account account = _accountService.GetByUserId(id);
            if (account.IsDeleted == true)
            {
                account.IsDeleted = false;
            }else
            {
                account.IsDeleted = true;
            }
            
            _accountService.editAccount(account);
            return RedirectToAction("UserManagement");
        }

        //===========Message management=================//

        public ActionResult MessageManagement(int? page)
        {
            int pageNumber = page ?? 1;
            int pageSize = 6;
            IPagedList<MessageSending> listMs = _messageSendingService.GetAll().OrderByDescending(d => d.time).ToPagedList(pageNumber, pageSize);
            MessageSendingViewModel model = new MessageSendingViewModel();
            model.listMessage = listMs;

            return View(model);
        }
    }
}