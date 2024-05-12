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
    public class CustomersController : Controller
    {
        private readonly ICustomersRepo customersRepo1;
        private readonly IOrdersRepo ordersRepo1;


        public CustomersController(ICustomersRepo customersRepo, IOrdersRepo ordersRepo,IPaymentRepo paymentRepo)
        {
            customersRepo1 = customersRepo;
            ordersRepo1 = ordersRepo;
        }

        // GET: Customers
        public IActionResult Index()
        {

            return View(customersRepo1.GetAll());
        }

        // GET: Customers/Details/5
        public IActionResult Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo1.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewBag.OrderidList = ordersRepo1.GetAll();
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,Password,PhoneNumber,Address,Orderid")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                customersRepo1.insert(customer);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.OrderidList = ordersRepo1.GetAll();
            return View(customer);
        }

        // GET: Customers/Edit/5
        public  IActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo1.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewBag.OrderidList = ordersRepo1.GetAll();
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, [Bind("Id,Name,Email,Password,PhoneNumber,Address,Orderid")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customersRepo1.update(customer);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Orderid"] = ordersRepo1.GetAll();
            return View(customer);
        }

        // GET: Customers/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = customersRepo1.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string id)
        {
            var customer = customersRepo1.GetById(id);
            if (customer != null)
            {
                customersRepo1.delete(customer);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(string id)
        {
            return customersRepo1.GetAll().Any(e => e.Id == id);
        }
    }
}
