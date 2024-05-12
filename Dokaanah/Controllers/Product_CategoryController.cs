using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Dokaanah.Models;
using Dokaanah.Repositories.RepoInterfaces;

namespace Dokaanah.Controllers
{
    
    public class Product_CategoryController : Controller
    {
        private readonly IProduct_CategoryRepo product_Category1;

        public Product_CategoryController(IProduct_CategoryRepo product_Category)
        {
            product_Category1 = product_Category;
        }

        // GET: Product_Category
        public IActionResult Index()
        {
            var dokkanah2Contex = product_Category1.GetAll();
            return View( dokkanah2Contex.ToList());
        }

        public async Task<IActionResult> GetallproductBycategory(int id)
        {
            var dokkanah2Contex = product_Category1.GetAll();
            var vv = dokkanah2Contex.Where(c => c.Cid == id);
            var allproduct = new List<Product>();
            foreach (var item in vv)
            {
                 allproduct.Add(item.P);
            }
            return View(allproduct);
        }


        //// GET: Product_Category/Details/5
        //public async Task<IActionResult> Details(int id)
        //{
        //    if (id == 0)
        //    {
        //        return NotFound();
        //    }

        //    var product_Category = await _context.Product_Categories
        //        .Include(p => p.C)
        //        .Include(p => p.P)
        //        .FirstOrDefaultAsync(m => m.Pid == id);
        //    if (product_Category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product_Category);
        //}

        //// GET: Product_Category/Create
        //public IActionResult Create()
        //{
        //    ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id");
        //    ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id");
        //    return View();
        //}

        //// POST: Product_Category/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Pid,Cid")] Product_Category product_Category)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(product_Category);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", product_Category.Cid);
        //    ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id", product_Category.Pid);
        //    return View(product_Category);
        //}

        //// GET: Product_Category/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product_Category = await _context.Product_Categories.FindAsync(id);
        //    if (product_Category == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", product_Category.Cid);
        //    ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id", product_Category.Pid);
        //    return View(product_Category);
        //}

        //// POST: Product_Category/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Pid,Cid")] Product_Category product_Category)
        //{
        //    if (id != product_Category.Pid)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product_Category);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!Product_CategoryExists(product_Category.Pid))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["Cid"] = new SelectList(_context.Categories, "Id", "Id", product_Category.Cid);
        //    ViewData["Pid"] = new SelectList(_context.Products, "Id", "Id", product_Category.Pid);
        //    return View(product_Category);
        //}

        //// GET: Product_Category/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var product_Category = await _context.Product_Categories
        //        .Include(p => p.C)
        //        .Include(p => p.P)
        //        .FirstOrDefaultAsync(m => m.Pid == id);
        //    if (product_Category == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(product_Category);
        //}

        //// POST: Product_Category/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var product_Category = await _context.Product_Categories.FindAsync(id);
        //    if (product_Category != null)
        //    {
        //        _context.Product_Categories.Remove(product_Category);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool Product_CategoryExists(int id)
        //{
        //    return _context.Product_Categories.Any(e => e.Pid == id);
        //}
    }
}
