using Admin_Scope.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Admin_Scope.Controllers
{
    public class AdminController : Controller
    {

        Context db;
        public AdminController(Context context)
        {
            db = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var prods = db.products.ToList();
            return View(prods);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid) 
            {
                db.products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Edit(int id)
        {
            var prod = db.products.Find(id);
            return View(prod);
        }
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State= Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpGet]
        public IActionResult Details(int id) 
        {
            var prod = db.products.Find(id);
            return View(prod);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var prod = db.products.Find(id);
            if (prod != null) 
            {
                db.Entry(prod).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }






        [HttpGet]
        public IActionResult Orders() 
        {
            var ordrs = db.orders.Include(ww=>ww.OrderItems).ThenInclude(aa=>aa.Product).ToList();
            return View(ordrs);
        }

        [HttpGet]
        public IActionResult EditOrder(int id)
        {
            var ordrs = db.orders.Include(ww => ww.OrderItems).ThenInclude(aa => aa.Product).FirstOrDefault(ww => ww.Order_Id == id);
            return View(ordrs);
        }


        [HttpPost]
        public IActionResult EditOrder(Order order, decimal qq,decimal pric)
        {
            var ordrs = db.orders.Include(ww => ww.OrderItems).ThenInclude(aa => aa.Product).FirstOrDefault(ww => ww.Order_Id == order.Order_Id);
           
            foreach (var item in ordrs.OrderItems)
            {
                item.Quantity = qq;
                item.Price = pric;
                order.Order_Id = item.Order_Id;

                
                db.orders.Add(ordrs);
            }

            Order oo = new Order();
            
            db.orders.Remove(order);

            db.SaveChanges();
            return RedirectToAction("orders");
        }



        [HttpGet]
        public IActionResult EditOrderDetails(int id)
        {

            var ordrs = db.OrderItem.Include(w => w.Product).FirstOrDefault(ww=>ww.Order_Id==id);
            return View(ordrs);
        }



        [HttpPost]
        public IActionResult EditOrderDetails(OrderItem orders)
        {
            if (orders !=null)
            {
                db.Entry(orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("orders");
            }
            return View();
        }

        [HttpGet]
        public IActionResult OrderDetails(int id)
        {
            var ordrs = db.orders.Include(w => w.OrderItems).ThenInclude(q => q.Product).Where(x=>x.Order_Id==id);
            return View(ordrs);
        }


        [HttpGet]
        public IActionResult OrderDelete(int id)
        {

            var ordrs = db.orders.Find(id);
            if (ordrs != null)
            {
                db.Entry(ordrs).State = EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            else
                return View();
        }





    }
}
