using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using CustomTagHelper.Models;

namespace CustomTagHelper.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IEnumerable<SelectListItem> _items = new SelectList(Enumerable.Range(7, 13));
        private static readonly Dictionary<int, User> _users = new Dictionary<int, User>();
        private static int _next;

        public IActionResult Index()
        {
            return View(new List<User>(_users.Values));
        }

        // GET: /Home/Create
        public IActionResult Create()
        {
            ViewBag.Items = _items;
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (user != null && ModelState.IsValid)
            {
                var id = _next++;
                user.Id = id;
                _users[id] = user;
                return RedirectToAction("Index");
            }

            ViewBag.Items = _items;
            return View();
        }

        // GET: /Home/Edit/5
        public IActionResult Edit(int id)
        {
            User user;
            _users.TryGetValue(id, out user);

            ViewBag.Items = _items;
            return View(user);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            if (user != null && id == user.Id && _users.ContainsKey(id) && ModelState.IsValid)
            {
                _users[id] = user;
                return RedirectToAction("Index");
            }

            ViewBag.Items = _items;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
