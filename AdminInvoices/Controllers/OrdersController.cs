using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdminInvoices.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Windows;

namespace AdminInvoices.Controllers
{
    public class OrdersController : Controller
    {
        private readonly InvoicesDbContext _context;

        public OrdersController(InvoicesDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            //needs to get all orders <- is that needed, usefull or practical ????

            return View();
        }
        
        public async Task<IActionResult> Pending()
        {
            //needs to get orders where invoiced= true AND disptched= false
            //where order.invoiced = True && where order.Dispatched = False

            var invoicesDbContext = _context.Orders
                .Where(g => g.Invoiced == true)
                .Where(g => g.Dispatched == false);

            return View(await invoicesDbContext.ToListAsync());
            
        }
    }
}