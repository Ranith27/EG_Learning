using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using StudentManagement.Models;
using Abp.Web.Mvc.Models;
using Abp.Web.Models;

namespace StudentManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            ViewBag.StudentID = id;
            return View();
        }
        public IActionResult Add()
        {
            return View();
        }
    }
}