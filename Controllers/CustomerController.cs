﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortraitBoxPhotoConverter.Models;
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
            //this is where they will fill out their name, etc
            return View();
        }
       
        public IActionResult AddCustomer(Customer customer)
        {
            // customer is added customer ID is returned 
            _repo.AddCustomer(customer);
            customer.CustomerID = _repo.GetCustomerID();
            

            ////DateTime dateTime = _repo.GetTimestamp(DateTime.Now);
            return View(customer);
        }

        public IActionResult CreateProduct(Customer customer)
        {
            _repo.AddBilling(customer);
            return View();
        }
       
        public IActionResult AddProductToDatabase()
        {
            return View();
        }


        //public IActionResult Something(Customer a)
        //{
        //    CustomerView info = new CustomerView();
        //    info.NewCustomer = a;
        //    return View(info);
        //}

    }
}
