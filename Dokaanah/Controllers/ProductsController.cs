using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;
using Dokaanah.Repositories.RepoClasses;
using Dokaanah.ViewModels;

namespace Dokaanah.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductsRepo _productRepo;
        private readonly ICategoriesRepo _categoryRepo;

        public ProductController(IProductsRepo productRepo , ICategoriesRepo categoryRepo)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
        
        }

        public IActionResult list()
        {
            // Get the list of products from the repository
            var products = _productRepo.ListProducts();

            // Pass the list of products to the view
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productRepo.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            var categoryNames = product.Product_Categories.Select(pc => pc.C.Name).ToList();
            ViewBag.CategoryNames = categoryNames;
            var productList = _productRepo.GetRandomProducts(5).Where(p => p.Id != id).ToList();
            ViewData["OtherProducts"] = productList;
            return View(product);
        }

        // GET: Product/Random
        public IActionResult RandomProducts()
        {
            var randomProducts = _productRepo.GetRandomProducts(4);
            return View(randomProducts);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int cartId)
        {
            _productRepo.AddProductToCart(productId, cartId);
            return View();
        }



    }
    //public class ProductsController : Controller
    //{
    //    private readonly IProductsRepo productsRepo1;
    //    private readonly IOrdersRepo ordersRepo1;
    //    private readonly ISellersRepo sellersRepo1;

    //    public ProductsController(IProductsRepo productsRepo , IOrdersRepo ordersRepo , ISellersRepo sellersRepo)
    //    {
    //        productsRepo1 = productsRepo;
    //        ordersRepo1 = ordersRepo;
    //        sellersRepo1 = sellersRepo;

    //    }



    //    // GET: Products
    //    public  IActionResult Index(string searchName)
    //    {
    //        if( string.IsNullOrEmpty(searchName) )
    //        {
    //            var dokkanahContex10 = productsRepo1.GetAll();
    //            return View(dokkanahContex10);
    //        }
    //        else
    //        {
    //            var dokkanahContex10 = productsRepo1.SearchByName(searchName.ToLower() );

    //            return View(dokkanahContex10);
    //        }
    //    }


    //    #region new

    //    // GET: Products
    //    public IActionResult searchprice(float STartPrice, float endRange)
    //    {
    //        if ( (STartPrice == 0) && (endRange == 0))
    //        {
    //            var dokkanahContex10 = productsRepo1.GetAll();
    //            return View(dokkanahContex10);
    //        }
    //        else
    //        {
    //            var dokkanahContex10 = productsRepo1.SearchByPrice( STartPrice, endRange);

    //            return View(dokkanahContex10);
    //        }
    //    }


    //    #endregion


    //    public IActionResult GetTopRate()
    //    {
    //        var dokkanahContex10 = productsRepo1.GetAll();
    //        return View(dokkanahContex10);
    //    }

    //    // GET: Products/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        return View();
    //    }

    //    // GET: Products/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["Orderid"] = new SelectList(ordersRepo1.GetAll(), "Id", "Id");
    //        ViewData["Sellerid"] = new SelectList(sellersRepo1.GetAll(), "Id", "Id");
    //        return View();
    //    }

    //    // POST: Products/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,Name,Price,Description,ImgUrl,Quantity,Sellerid,Orderid")] Product product)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //           productsRepo1.insert(product);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["Orderid"] = new SelectList(ordersRepo1.GetAll(), "Id", "Id", product.Orderid);
    //        ViewData["Sellerid"] = new SelectList(sellersRepo1.GetAll(), "Id", "Id", product.Sellerid);
    //        return View(product);
    //    }

    //    // GET: Products/Edit/5
    //    public async Task<IActionResult> Edit(int id)
    //    {
    //        if (id == 0)
    //        {
    //            return NotFound();
    //        }

    //        var product = productsRepo1.GetById(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["Orderid"] = new SelectList(ordersRepo1.GetAll(), "Id", "Id", product.Orderid);
    //        ViewData["Sellerid"] = new SelectList(sellersRepo1.GetAll(), "Id", "Id", product.Sellerid);
    //        return View(product);
    //    }

    //    // POST: Products/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,Description,ImgUrl,Quantity,Sellerid,Orderid")] Product product)
    //    {
    //        if (id != product.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                productsRepo1.update(product);
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!ProductExists(product.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["Orderid"] = new SelectList(ordersRepo1.GetAll(), "Id", "Id", product.Orderid);
    //        ViewData["Sellerid"] = new SelectList(sellersRepo1.GetAll(), "Id", "Id", product.Sellerid);
    //        return View(product);
    //    }

    //    // GET: Products/Delete/5
    //    public async Task<IActionResult> Delete(int id)
    //    {
    //        if (id == 0)
    //        {
    //            return NotFound();
    //        }

    //        var product = productsRepo1.GetById(id);
    //        if (product == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(product);
    //    }

    //    // POST: Products/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        var product = productsRepo1.GetById(id);
    //        if (product != null)
    //        {
    //            productsRepo1.delete(product);
    //        }

    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool ProductExists(int id)
    //    {
    //        return productsRepo1.GetAll().Any(e => e.Id == id);
    //    }
    //}
}
