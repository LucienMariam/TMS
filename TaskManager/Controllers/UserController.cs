using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interfaces;
using TaskManager.Models;
using TaskManager.Infrastructure;
using System.Net.Mail;
using TaskManager.Authentification;


namespace TaskManager.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        //
        // GET: /User/
        private readonly IKeyService<UserEntity> users;

        public UserController(IKeyService<UserEntity> users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
