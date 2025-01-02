using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment1.Models;

namespace Assessment1.Controllers
{
    public class CodeController : Controller
    {
        // GET: Code
        NorthwindEntities nw = new NorthwindEntities();
        public ActionResult Index()
        {
            return View(nw.Customers.ToList());
        }
        public ActionResult In_Germany()
        {
            var customersInGermany = nw.Customers
                                 .Where(c => c.Country == "Germany")
                                 .ToList();
            return View(customersInGermany);
        }
        public ActionResult CustomersByOrderId(int orderId = 10248)
        {
            var cust = nw.Customers.Where(c => c.Orders.Any(o => o.OrderID == orderId));
            if (cust == null)
            {
                return HttpNotFound();
            }
            return View(cust);
        }
       
    }
}