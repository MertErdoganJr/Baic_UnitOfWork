﻿using BusinessLayer.Abstract;
using EntityLayer.Concreate;
using Microsoft.AspNetCore.Mvc;
using UowProject.Models;

namespace UowProject.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly ICustomerService _customerService;

        public SendMoneyController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(CustomerViewModel model)
        {
            var value1 = _customerService.TGetByID(model.SenderID);
            var value2 = _customerService.TGetByID(model.ReceiverID);

            value1.CustomerBalance -= model.Amount; 
            value2.CustomerBalance += model.Amount;

            List<Customer> modifiedCustomer = new List<Customer>()
            {
                value1, value2
            };

            _customerService.TMultiUpdate(modifiedCustomer);
            return View();
        }
    }
}

//Process Kısmı tamamlanacak - işlem tarihi eklenebilir - kullanıcı hareketleri sınıfı eklenebilir - 
