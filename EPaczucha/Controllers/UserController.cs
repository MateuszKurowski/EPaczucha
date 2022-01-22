using System.Collections.Generic;
using System.Linq;

using EPaczucha.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczucha.Controllers
{
    public class UserController : Controller
    {
        private List<User> _users = new()
        {
            new User()
            {
                Id= 1,
                Name = "Mateusz Nosel",
            },
            new User()
            {
                Id = 2,
                Name = "Kuba Kurek",
            },
            new User()
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

        public IActionResult Edit(User newUser)
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
        public IActionResult Add(User user)
        {
            var id = _users.Select(x => x.Id).Max() + 1;
            _users.Add(new User
            {
                Id = id,
                Name = user.Name,
            });

            return View("Index", _users);
        }
    }
}