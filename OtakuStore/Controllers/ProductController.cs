using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Data;
using OtakuStore.Models;
using OtakuStore.ViewModels;
using Data.Model;
using Microsoft.AspNet.Identity;

namespace OtakuStore.Controllers
{
    public class ProductController : Controller
    {
        #region field
        IProductService _productService;
        ITagService _tagService;
        ICategoryService _categoryService;
        IProductTagService _productTagService;
        IManufactorService _manufactorService;
        IStatusService _statusService;
        IImageService _imageService;
        ICommentService _commentService;
        IAccountService _accountService;
        INotificationService _notificationService;
        IWishListService _wishListService;
        #endregion

        #region ctor
        public ProductController(IProductService _productService, ITagService _tagService,
            ICategoryService _categoryService, IProductTagService _productTagService, 
            IManufactorService _manufactorService, IStatusService _statusService, IImageService _imageService,
            ICommentService _commentService, IAccountService _accountService, INotificationService _notificationService
            , IWishListService _wishListService)
        {
            this._productService = _productService;
            this._tagService = _tagService;
            this._categoryService = _categoryService;
            this._productTagService = _productTagService;
            this._manufactorService = _manufactorService;
            this._statusService = _statusService;
            this._imageService = _imageService;
            this._commentService = _commentService;
            this._accountService = _accountService;
            this._notificationService = _notificationService;
            this._wishListService = _wishListService;
        }
        #endregion
        // GET: Product
        //Product/ProductDetail/id
        public ActionResult ProductDetail(int? id)
        {
            Product product = _productService.GetById(id.HasValue ? id.Value : 0);

            if (product != null && !product.isDelete)//check xem product co tren db ko va product da bi xoa ?
            {
                //khoi tao para cho filter Models
                IEnumerable<Category> categories = _categoryService.GetAll();
                IEnumerable<Manufactor> manufactors = _manufactorService.GetAll();
                IEnumerable<Status> status = _statusService.GetAll();
                IEnumerable<ProductTag> productTags = _productTagService.GetAll().Where(m => m.ProductID == product.Id);
                IEnumerable<Image> images = _imageService.GetAll().Where(m => m.ProductID == product.Id);

                ProductIndex p = new ProductIndex();//xu ly va fill du lieu vao Models
                p.product = product;
                List<Tag> tags = new List<Tag>();
                foreach (var item in productTags)
                {
                    tags.Add(_tagService.GetAll().FirstOrDefault(m => m.Id == item.TagID));
                }
                p.tags = tags;
                Category category = categories.FirstOrDefault(m => m.id == product.CategoryID);
                p.category = category;
                Manufactor manufactor = manufactors.FirstOrDefault(m => m.Id == product.ManufactorID);
                p.manufactor = manufactor;
                Status s = status.FirstOrDefault(m => m.Id == product.StatusID);
                p.status = s;
                p.images = images;
                p.comments = _commentService.GetAll().Where(m => m.ProductID == product.Id && m.Type == 1 && m.isDelete == false).OrderByDescending(m => m.dateCreate).AsEnumerable();
                p.wishLists = User.Identity.IsAuthenticated ? _wishListService.GetAll().Where(m => m.UserID == User.Identity.GetUserId()) : null;
                product.C_View += 1;//tang luot view len 1
                _productService.editProduct(product);
                return View(p);
            }
            else
                return HttpNotFound();//trang view loi~
        }

        //GET: /Product/MoreComment/
        //comment ajax
        //partial view
        public ActionResult MoreComments(int? offset,int productID)
        {
            int offsetPage = offset.HasValue ? offset.Value : 0;//index tiep theo de lay
            int sizePage = 3; //chi lay 3 comment
            IEnumerable<Comment> comments = _commentService.GetAll().Where(m => m.ProductID == productID && m.Type == 1 && m.isDelete == false).OrderByDescending(m => m.dateCreate).AsEnumerable();
            IEnumerable<Comment> c = comments.Skip(offsetPage * sizePage).Take(sizePage).Select(m => m);//cat Array tu vi tri tiep theo + 3
            MoreCommentViewModel models = new MoreCommentViewModel();
            models.comments = c;
            offsetPage++;
            if(offsetPage == 0)//neu la vi tri mac dinh 0 thi vi tri tiep theo dc set se la 1
            {
                offsetPage = sizePage;
            }
            models.offset = offsetPage;
            models.size = sizePage;
            models.productId = productID;
            models.isNext = false;
            if (comments.Count() > (offsetPage * sizePage)) //check xem con comment tiep theo ko?
            {
                models.isNext = true;
            }
            return PartialView(models);
        }

        //GET: Product/StartComment/
        //test login to comment the product
        [Authorize]
        public ActionResult StartComment(int id)
        {

            return RedirectToAction("ProductDetail", "Product", new { id = id});
        }

        //Post:Product/Commemt/
        [Authorize]
        [HttpPost]
        public ActionResult Comment(string txtUsername,int txtProductId,int score,string txtComment)
        {
            Comment comment = new Comment(txtProductId, User.Identity.GetUserId(), score, txtComment);
            _commentService.createComment(comment);//gui comment len DB

            //update lai Rate cua san pham
            IEnumerable<Comment> comments = _commentService.GetAll().Where(m => m.ProductID == txtProductId && m.Type == 1).AsEnumerable();
            int totalRate = 0;//tong so sao
            foreach (var item in comments)
            {
                totalRate += item.Rate.HasValue ? item.Rate.Value : 0;
            }
            int totalComment = comments.Count();//tong luot comment
            int newRate = 0;
            if(totalComment != 0)
            newRate = totalRate / totalComment;

            //update rate len product
            Product product = _productService.GetById(txtProductId);
            product.Rate = newRate;
            _productService.editProduct(product);
            return RedirectToAction("ProductDetail", "Product", new { id = txtProductId });
        }

        [Authorize(Roles = "User")]
        public ActionResult addToWishList(int id,string urlCallBack)
        {

            //tim thu la th product nay da add vao wish list chua
            WishList w = _wishListService.GetAll().Where(m => m.ProductID == id && m.UserID == User.Identity.GetUserId()).FirstOrDefault();
            if(w != null)
            {
                _wishListService.deleteWishList(w.Id);
            }
            else
            {
                WishList newWishList = new WishList
                {
                    ProductID = id,
                    UserID = User.Identity.GetUserId()
                };
                _wishListService.createWishList(newWishList);
            }

            if(urlCallBack != null)
            {
                return RedirectToLocal(urlCallBack);
            }
            return PartialView();
        }

        public ActionResult RedirectToLocal(string urlCallBack)
        {
            if (Url.IsLocalUrl(urlCallBack))
            {
                return Redirect(urlCallBack);
            }
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "User")]
        public ActionResult viewWishList()
        {
            WishListViewModel model = new WishListViewModel
            {
                images = _imageService.GetAll(),
                products = _productService.Get().Where(m => !m.isDelete),
                status = _statusService.GetAll(),
                wishList = _wishListService.GetAll().Where(m => m.UserID == User.Identity.GetUserId()).ToList()
            };
            return View(model);
        }
    }
}