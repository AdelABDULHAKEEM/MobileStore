using Microsoft.AspNetCore.Mvc;
using MobileStore.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileStore.Models;

namespace MobileStore.Controllers
{
    public class MobileDeviceController : Controller
    {
        private readonly IMobileStore _context;
        public MobileDeviceController(IMobileStore context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.GetAllMobileDevices());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreatePost(MobileDeviceEntity mobiledata)
        {
            _context.Create(mobiledata);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(string name)
        {
            var md = _context.GetMobileDevDetails(name);
            return View(md);
        }
        [HttpPost]
        public IActionResult EditPost(string _id , MobileDeviceEntity mobiledata)
        {
            _context.Update(_id , mobiledata);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Details(string name)
        {
            var md = _context.GetMobileDevDetails(name);
            return View(md);
        }
        [HttpGet]
        public IActionResult Delete(string name)
        {
            var md = _context.GetMobileDevDetails(name);
            return View(md);
        }
        [HttpPost]
        public IActionResult DeletePost(string name)
        {
            _context.Delete(name);
            return RedirectToAction("Index");
        }
    }
}
