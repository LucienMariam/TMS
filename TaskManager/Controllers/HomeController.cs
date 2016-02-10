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
using System.Web.Security;
using WebMatrix.WebData;

namespace TaskManager.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ITaskUserService tasks;

        public HomeController(ITaskUserService tasks)
        {
            this.tasks = tasks;
        }        

        [HttpPost]
        public ActionResult Index(RegisterModel model, string id)
        {
            
            return View();
        }

        
        public ActionResult Index()
        {
            
            ViewBag.Title = "MY TASKS";

            var userTasks = tasks.GetTaskByUser(User.Identity.Name);

            IEnumerable<TaskEntity> myTasks = userTasks.Select(t => tasks.GetTaskEntity(t.TaskId));

            IEnumerable<UserTask> tasksViewModel = myTasks.Select(t => new UserTask
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Progress = userTasks.Where(ut=>ut.TaskId == t.Id).FirstOrDefault().Progress
                });
            ViewBag.Tasks = tasksViewModel;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
        
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            return View();
        }
        public ActionResult UserProfile()
        {
            
            return View();
        }

        public ActionResult ResolveTask(Guid id)
        {
            tasks.ResolveTask(id, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public ActionResult ReopenTask(Guid id)
        {
            tasks.ReopenTask(id, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteTask(Guid id)
        {
            tasks.DeleteTask(id, User.Identity.Name);
            return RedirectToAction("Index");
        }

        public ActionResult AddTask()
        {
            ViewBag.Title = "MY TASKS";

            var userTasks = tasks.GetAll().Distinct();

            IEnumerable<TaskEntity> myTasks = userTasks.Select(t => tasks.GetTaskEntity(t.TaskId));

            IEnumerable<UserTask> tasksViewModel = myTasks.Select(t => new UserTask
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                Progress = userTasks.Where(ut => ut.TaskId == t.Id).FirstOrDefault().Progress
            });
            ViewBag.Tasks = tasksViewModel;
            return View();
        }

        public ActionResult AddToMyTasks(Guid id)
        {
            try
            {
                tasks.CreateTask(id, User.Identity.Name);
            }
            catch(Exception ex)
            {

            }
            return RedirectToAction("Index");
        }
    }
}
