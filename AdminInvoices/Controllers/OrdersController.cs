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
            //needs toget orders where invoiced= true AND disptched= false

           //where order.invoiced = rue && where order.Dispatched = False

            return View(await .ToListAsync());
        }



        }
}