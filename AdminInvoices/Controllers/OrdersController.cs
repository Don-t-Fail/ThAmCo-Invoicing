using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AdminInvoices.Controllers
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            //needs to get all orders <- is that needed, usefull or practical ????


            return View();
        }


        public async Task<IActionResult> Pending()
        {
            //needs to get orders where invoiced= true AND disptched= false

           //where order.invoiced = True && where order.Dispatched = False

            return View(await .ToListAsync());
        }



        }
}