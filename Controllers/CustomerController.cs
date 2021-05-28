using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortraitBoxPhotoConverter.Controllers
{
    public class CustomerController : Controller
    {
        // GET: CustomerController
        private readonly ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }
        public ActionResult Index()
        {
            _repo.InsertOrder("Sam", "Smith", "email@email.com", "555-555-5555", "small", "1234 house st", "Columbus", "OH", 43215, 12.50);
            
            return View();
        }

       
       
    }
}
