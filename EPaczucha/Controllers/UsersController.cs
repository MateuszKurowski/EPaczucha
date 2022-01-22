using System.Collections.Generic;
using System.Linq;

using EPaczucha.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczucha.Controllers
{
    public class UsersController : Controller
    {
        private List<Users> _users = new()
        {
            new Users()
            {
                Id= 1,
                Name = "Mateusz Nosel",
            },
            new Users()
            {
                Id = 2,
                Name = "Kuba Kurek",
            },
            new Users()
            {
                Id = 3,
                Name = "Maciek Michał",
            },
        };

        public IActionResult Index()
        {
            return View(_users);
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);

            return View(user);
        }

        public IActionResult Edit(Users newUser)
        {
            var user = _users.FirstOrDefault(x => x.Id == newUser.Id);

            user.Name = newUser.Name;

            return View("Index", _users);
        }

        public IActionResult Delete(int userId)
        {
            _users.Remove(_users.FirstOrDefault(x => x.Id == userId));

            return View("Index", _users);
        }

        public IActionResult Details(int userId)
        {
            var user = _users.FirstOrDefault(x => x.Id == userId);

            return View(user);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Users user)
        {
            var id = _users.Select(x => x.Id).Max() + 1;
            _users.Add(new Users
            {
                Id = id,
                Name = user.Name,
            });

            return View("Index", _users);
        }
    }
}