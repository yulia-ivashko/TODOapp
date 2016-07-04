using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODO.domain.Abstract;
using TODO.domain.Concrete;
using TODO.domain.Entities;
using TODO.domain.UOF;

namespace WebUI.Controllers
{
    public class TaskController : Controller
    {
        private GenericRepository<Task> _repository;
        private IUnitOfWork _unitOfWork;
        public TaskController(IUnitOfWork UnitOfWork)
        {
            _unitOfWork = UnitOfWork;
        }

        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();
            base.Dispose(disposing);
        }
        // GET: Task
       // public ActionResult View1()
       // {
           // return View(_repository.Tasks);
        //}

        // GET: Task
        public ViewResult List()
        {
            try
            {
                return View(_unitOfWork.Tasks.GetAll());
            }
            catch (ArgumentNullException e)
            {
                return null;
            }
        }

        public ActionResult CreateEditTask(int? id)
        {
            Task model = new Task();
            if (id.HasValue)
            {
                model = _repository.GetById(id.Value);
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult CreateEditTask(Task model)
        {
            if (model != null)
            {
                if (model.TaskId == 0)
                {
                   // model.Date = System.DateTime.Now;
                    _repository.Insert(model);
                }
                else
                {
                    var editModel = _repository.GetById(model.TaskId);
                    editModel.Name = model.Name;
                    editModel.Priority = model.Priority;
                    editModel.Date = model.Date;
                    editModel.Comment = model.Comment;
                    editModel.IsCompleted = model.IsCompleted;
                    _repository.Update(editModel);
                }

                if (model.TaskId > 0)
                {
                    return RedirectToAction("List");
                }
                return View(model);
            }
            else return null;
        }






        // GET: All tasks
        public JsonResult GetAllTasks()
        {
            using (EFDbContext contextObj = new EFDbContext())
            {
                var taskList = contextObj.Tasks.ToList();
                return Json(taskList, JsonRequestBehavior.AllowGet);
            }
        }
        //GET: Task by Id
        public JsonResult GetTaskById(int id)
        {
            using (EFDbContext contextObj = new EFDbContext())
            {
                var taskId = Convert.ToInt32(id);
                var getTaskById = contextObj.Tasks.Find(taskId);
                return Json(getTaskById, JsonRequestBehavior.AllowGet);
            }
        }
        //Update Task
        public string UpdateTask(Task task)
        {
            if (task != null)
            {
                using (EFDbContext contextObj = new EFDbContext())
                {
                    int taskId = Convert.ToInt32(task.TaskId);
                    Task _task = contextObj.Tasks.Where(b => b.TaskId == taskId).FirstOrDefault();
                    _task.Name = task.Name;
                    _task.Priority = task.Priority;
                    _task.Date = task.Date;
                    _task.Comment = task.Comment;
                    _task.IsCompleted = task.IsCompleted;
                    contextObj.SaveChanges();
                    return "Task record updated successfully";
                }
            }
            else
            {
                return "Invalid task record";
            }
        }
        
        // Add task
        public ActionResult AddTask(Task task)
        {
            
                using (EFDbContext contextObj = new EFDbContext())
                {
                    try
                    {
                        if (ModelState.IsValid)
                        {
                            contextObj.Tasks.Add(task);
                            contextObj.SaveChanges();
                             return RedirectToAction("List");
                    }

                    }
                    catch (DataException)
                {
                    ModelState.AddModelError("", "Unable to save changes."); }
                }
            return View(task);
        }
        // Delete task
        public string DeleteTask(string taskId)
        {

            if (!String.IsNullOrEmpty(taskId))
            {
                try
                {
                    int _taskId = Int32.Parse(taskId);
                    using (EFDbContext contextObj = new EFDbContext())
                    {
                        var _task = contextObj.Tasks.Find(_taskId);
                        contextObj.Tasks.Remove(_task);
                        contextObj.SaveChanges();
                        return "Selected task record deleted sucessfully";
                    }
                }
                catch (Exception)
                {
                    return "Task details not found";
                }
            }
            else
            {
                return "Invalid operation";
            }
        }
    }

}