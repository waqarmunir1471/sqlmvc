using System.Data.Common;
using System.Security;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SQLMVC.Models;

namespace SQLMVC.Controllers
{
    public class HomeController : Controller
    {
        private MyContext DbContext;
        public HomeController(MyContext context){
            DbContext = context;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            List<User> AllUsers= DbContext.Users.ToList();

            return View(AllUsers);
        }
        [HttpGet("add")]
        public IActionResult Add()
        {

            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid){
                DbContext.Users.Add(newUser);
                DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
            return View("Add");

            }
        }
        [HttpGet("Edit/{UserId}")]
        public IActionResult Edit(int UserId)
        {
            User GetUser = DbContext.Users.SingleOrDefault(User=>User.UserId == UserId);

            return View("Edit",GetUser);
        }
        [HttpPost("update/{UserId}")]
        public IActionResult Update(int UserId,User user)
        {
            User GetUser = DbContext.Users.SingleOrDefault(User=>User.UserId == UserId);
            GetUser.FirstName = user.FirstName;
            GetUser.LastName = user.LastName;
            GetUser.Email = user.Email;
            GetUser.Password = user.Password;
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("Delete/{UserId}")]
        public IActionResult Delete(int UserId)
        {
            User GetUser = DbContext.Users.SingleOrDefault(User=>User.UserId == UserId);
            DbContext.Users.Remove(GetUser);
            DbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet("Details/{UserId}")]
        public IActionResult Detials()
        {

            return View("Details");
        }
        // public IActionResult Privacy()
        // {
        //     return View();
        // }

        // [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        // public IActionResult Error()
        // {
        //     return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        // }
    }
}
