using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult CreateProduct(Customer customer)
        {
            return View(customer);
        }

        public IActionResult AddProductToDatabase()
        {
            return View();
        }
    }
}
