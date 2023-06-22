using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using ToDoEf.Models;

namespace ToDoEf.Controllers
{
    public class ToDoItemsController : Controller
    {
        private readonly AppDbContext _context;

        public ToDoItemsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public IActionResult Index()
        {
            var items = _context.Groups;
            return View(items.ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            IEnumerable<ToDoItems> items = _context.Items
                .Include(i => i.Group)
                .Where(x => x.GroupId == id)
                .AsEnumerable();

            string groupName = items.FirstOrDefault()?.Group?.Name;

            //.FirstOrDefault(m => m.GroupId == id);
            if (items == null)
            {
                return NotFound();
            }
            ViewBag.GroupName = groupName;
            return View(items);
        }
    }
}
