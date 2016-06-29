using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODO.domain.Abstract;
using TODO.domain.Entities;

namespace WebUI.Controllers
{
    public class TaskController : Controller
    {
        private ITasksRepository repository;
        public TaskController(ITasksRepository TaskRepository)
        {
            this.repository = TaskRepository;
        }
       // public TaskController() { }
        // GET: Task
        public ViewResult List()
        {
            try
            {
                return View(repository.tasks);
            }
            catch (ArgumentNullException e)
            {
                return e;
            }
        }
    }
}