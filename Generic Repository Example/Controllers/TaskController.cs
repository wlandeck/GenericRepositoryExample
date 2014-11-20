using Entities;
using GenericRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic_Repository_Example.Controllers
{
    public class TaskController : Controller
    {
        //
        // GET: /Task/
        public ActionResult Index()
        {
            IEnumerable<MyTask> tasks;
            using (var uow = new MyUnitOfWork(new MyDataContext()))
            {
                tasks = uow.Repository<MyTask>().Query().Filter( t=> t.Task.Contains("1")).Get();
            }
            return View(tasks);

        }

        //
        // GET: /Task/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Task/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Task/Create
        [HttpPost]
        public ActionResult Create(MyTask newTask)
        {
            try
            {
                using(var uow = new MyUnitOfWork(new MyDataContext()))
                {
                   // newTask.IdKey = null;
                    uow.Repository<MyTask>().Insert(newTask);
                    uow.Commit();
                }

                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        //
        // GET: /Task/Edit/5
        public ActionResult Edit(Guid id)
        {
            using (var uow = new MyUnitOfWork(new MyDataContext()))
            {
                var task = uow.Repository<MyTask>().FindById(id);
                return View(task);
            }
            throw new Exception("Object Not Found");
        }

        //
        // POST: /Task/Edit/5
        [HttpPost]
        public ActionResult Edit(MyTask taskToUpdate)
        {
            try
            {
                using (var uow = new MyUnitOfWork(new MyDataContext()))
                {
                    uow.Repository<MyTask>().Update(taskToUpdate);
                    uow.Commit();
                }
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Task/Delete/5
        public ActionResult Delete(Guid id)
        {
            using(var uow = new MyUnitOfWork(new MyDataContext()))
            {
                uow.Repository<MyTask>().Delete(id);
                uow.Commit();
            }
            return RedirectToAction("Index");
        }



        //
        // POST: /Task/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
