using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVc.Models;
using SalesWebMVc.Models.ViewModels;
using SalesWebMVc.Services;

namespace SalesWebMVc.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService; _departmentService = departmentService;

        }
        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            return View(list);
        }

        public IActionResult Create()
        {
            var department = _departmentService.FindAll();
            var ViewModel = new SellerFormViewModel { Departments = department };

            return View(ViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SellerFormViewModel obj)
        {
            Seller seller = new Seller
            {
                Name = obj.Seller.Name.ToUpper(),
                BirthDate = obj.Seller.BirthDate,
                DepartmentId = obj.Seller.DepartmentId,
                BaseSalary = obj.Seller.BaseSalary
            };
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));


        }

        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(Id.Value);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            _sellerService.Remove(Id);
            return RedirectToAction(nameof(Index));

        }
    }
}