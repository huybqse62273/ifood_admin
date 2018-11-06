using Data;
using OtakuStore.ViewModels;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace OtakuStore.Controllers
{
    public class CartController : Controller
    {
        #region field
        IAccountService _accountService;
        IProductService _productService;
        IImageService _imageService;
        IManufactorService _manufactorService;
        ICategoryService _categoryService;
        IAnimeService _animeService;
        ITagService _tagService;
        IOrderProductService _orderProductService;
        IOrderService _orderService;
        #endregion

        #region ctor
        public CartController(IAccountService _accountService, IProductService _productService, IImageService _imageService,
            IManufactorService _manufactorService, ICategoryService _categoryService, IAnimeService _animeService, ITagService _tagService, IOrderProductService _orderProductService,
             IOrderService _orderService)
        {
            this._accountService = _accountService;
            this._productService = _productService;
            this._imageService = _imageService;
            this._manufactorService = _manufactorService;
            this._categoryService = _categoryService;
            this._animeService = _animeService;
            this._orderProductService = _orderProductService;
            this._orderService = _orderService;
        }
        #endregion

        private List<OrderProduct> cart;

        public ActionResult CartPartial()
        {
            if(Session["image"] == null)
            {
                Session["image"] = _imageService.GetAll().ToList<Image>();
            }
            if (Session["cart"] == null)
            {
                Session["cart"] = new List<OrderProduct>();
            }
            return PartialView("_CartPartialView");
        }
        public ActionResult viewCart()
        {
            //CartViewModel model = new CartViewModel();
            //cart = Session["cart"] as List<OrderProduct>;
            //if (cart == null)
            //{
            //    cart = new List<OrderProduct>();
            //}
            //model.list = cart;
            return View();
        }

        public ActionResult addToCart(int id, int? quantity, string callbackURL)
        {
            cart = Session["cart"] as List<OrderProduct>;
            if (cart == null)
            {
                cart = new List<OrderProduct>();
            }
            if(quantity == null)
            {
                quantity = 1;
            }
            bool flag = false;
            foreach(var item in cart){
                if(item.ProductID == id)
                {
                    item.Quantity = item.Quantity + quantity;
                    flag = true;
                }
            }
            if (!flag)
            {
                OrderProduct product = new OrderProduct();
                product.ProductID = id;
                product.Quantity = quantity;
                product.Name = _productService.GetById(id).Name;
                product.Price = _productService.GetById(id).Price;
                cart.Add(product);
            }  
            Session["cart"] = cart;
            if (callbackURL == null)
            {
                return PartialView();
            }
            return Redirect(callbackURL);
        }

        public ActionResult Delete(int id)
        {
            cart = Session["cart"] as List<OrderProduct>;
            foreach (var item in cart)
            {
                if (item.ProductID == id)
                {
                    cart.Remove(item);
                    break;
                }
            }
            return RedirectToAction("showCart");
        }

        public ActionResult showCart()
        {
            ShowCartViewModel model = new ShowCartViewModel();
            cart = Session["cart"] as List<OrderProduct>;
            if (cart == null)
            {
                cart = new List<OrderProduct>();
            }
            model.list = cart;
            model.image = _imageService.GetAll().ToList();
            model.manufactor = _manufactorService.GetAll().ToList();
            return PartialView(model);
        }

        public ActionResult plus(int id)
        {
            cart = Session["cart"] as List<OrderProduct>;
            foreach(var item in cart)
            {
                if(item.ProductID == id)
                {
                    item.Quantity++;
                    break;
                }
            }
            return PartialView();
        }

        public ActionResult minus(int id)
        {
            cart = Session["cart"] as List<OrderProduct>;
            foreach (var item in cart)
            {
                if (item.ProductID == id)
                {
                    item.Quantity--;
                    break;
                }
            }
            return PartialView();
        }

        public ActionResult checkOut()
        {
            ViewBag.UserName = User.Identity.GetUserName();
            List<OrderProduct> cart = Session["cart"] as List<OrderProduct>;
            if (!cart.Any())
            {
                return Redirect("/Error/noneCartCheckOut");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult checkOut(string address, string phone, string cartID, string description)
        {
            double? total = 0;
            foreach (var item in Session["cart"] as List<Data.OrderProduct>)
            {
                total = total + (item.Quantity + item.Price);
            }
            string userID = User.Identity.GetUserName();
            Order order = new Order
            {
                UserID = userID,
                DateOrder = DateTime.Now,
                Address = address,
                Phone = phone,
                CardID = cartID,
                Description = description,
                Status = false,
                Total = total
            };
            _orderService.createOrder(order);
            return RedirectToAction("addOrderProducts");
        }

        public ActionResult addOrderProducts()
        {
            foreach (var item in Session["cart"] as List<Data.OrderProduct>)
            {
                item.OrderID = _orderService.GetAll().OrderByDescending(d => d.DateOrder).FirstOrDefault().Id;
                _orderProductService.createOrderProduct(item);
                Product product = _productService.GetById(item.ProductID);
                product.OrderCounter++;
                _productService.editProduct(product);
            }
            Session["cart"] = new List<OrderProduct>();
            return Redirect("/Home/Index");
        }
    }
}