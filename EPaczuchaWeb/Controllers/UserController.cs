using System;
using System.Collections.Generic;
using System.Linq;

using EPaczucha.database;

using EPaczuchaWeb.Models;

using Microsoft.AspNetCore.Mvc;

namespace EPaczuchaWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly ICustomerRepository _userRepository;
        private readonly IServiceProvider _serviceProvider;
        private readonly UserMapper _userMapper;

        public UserController(IServiceProvider serviceProvider, ICustomerRepository userRepository, UserMapper userMapper)
        {
            _serviceProvider = serviceProvider;
            _userRepository = userRepository;
            _userMapper = userMapper;
        }

        public IActionResult Index()
        {
            return View(_userRepository.GetAll());
        }

        [HttpGet]
        public IActionResult Edit(int userId)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Id == userId);

            return View(user);
        }

        public IActionResult Edit(CustomerViewModel user)
        {
            _userRepository.Update(_userMapper.Map(user));
            _userRepository.SaveChanges();

            return View("Index", _userRepository.GetAll());
        }

        public IActionResult Delete(int userId)
        {
            _userRepository.GetAll().Remove(_userRepository.GetAll().FirstOrDefault(x => x.Id == userId));
            _userRepository.SaveChanges();

            return View("Index", _userRepository.GetAll());
        }

        public IActionResult Details(int userId)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.Id == userId);

            return View(user);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Models.CustomerViewModel user)
        {
            var id = _userRepository.GetAll().Select(x => x.Id).Max() + 1;

            _userRepository.Create(_userMapper.Map(user));

            return View("Index", _userRepository.GetAll());
        }
    }
}