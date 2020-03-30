using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SalesWebMVc.Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SalesWebMVc.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordsService _salesRecordsService;
        public SalesRecordsController(SalesRecordsService salesRecordsService)
        {
            _salesRecordsService = salesRecordsService;
        }
        // GET: /<controller>/
        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");
            var result =  await _salesRecordsService.FindByDate(minDate, maxDate);

            return View(result);
        }
        public async Task<IActionResult> GroupingSearch()
        {
            return View();
        }
    }
}
