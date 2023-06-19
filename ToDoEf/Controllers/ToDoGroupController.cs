using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Linq;
using ToDoEf.Models;

namespace ToDoEf.Controllers
{
    public class ToDoGroupController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoGroupController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public IActionResult Index()
        {
            var groups = _context.Groups;
            return View(groups.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name")] ToDoGroup toDoGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Groups.Add(toDoGroup);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(toDoGroup);
        }
    }
}
