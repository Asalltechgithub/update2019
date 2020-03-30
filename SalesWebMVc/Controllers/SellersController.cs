using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVc.Models;
using SalesWebMVc.Models.ViewModels;
using SalesWebMVc.Services;
using SalesWebMVc.Services.Exceptions;

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
        public async Task<IActionResult> Index()
        {
            var list = await _sellerService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {

            var department = await _departmentService.FindAllAsync();
            var ViewModel = new SellerFormViewModel { Departments = department };

            return View(ViewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SellerFormViewModel obj)
        {
            if (!ModelState.IsValid)
            {
                var department = await _departmentService.FindAllAsync();
                var ViewModel = new SellerFormViewModel { Seller = obj.Seller, Departments = department };
                return View(ViewModel);
            }
            Seller seller = new Seller
            {
                Name = obj.Seller.Name.ToUpper(),
                BirthDate = obj.Seller.BirthDate,
                DepartmentId = obj.Seller.DepartmentId,
                BaseSalary = obj.Seller.BaseSalary
            };
            await _sellerService.InsertAsync(seller);
            return RedirectToAction(nameof(Index));


        }

        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Provider" });
            }
            var obj = await _sellerService.FindByIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                await _sellerService.RemoveAsync(Id);
                return RedirectToAction(nameof(Index));
            }
            catch(IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }


        }
        public async Task<IActionResult> Details(int? Id)
        {

            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }
            var obj = await _sellerService.FindByIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);


        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not Provided" });
            }

            var obj = await _sellerService.FindByIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });

            }
            List<Department> departments = await _departmentService.FindAllAsync();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = await _departmentService.FindAllAsync();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (Id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
            }
            try
            {
                await _sellerService.UpdateAsync(seller);

                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }




        }
        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}