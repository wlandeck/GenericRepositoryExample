using Entities;
using GenericRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic_Repository_Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            //using(var unitOfWork = new MyUnitOfWork(new MyDataContext()))
            //{
            //    var productsRepository = unitOfWork.Repository<Product>();
            //    var Products = productsRepository.Query().Get().ToList();

            //    var newProduct = new Product { Name = "Trinity", Description = "Slash" };
            //    productsRepository.Insert(newProduct);
            //    unitOfWork.Commit();

            //    var tasksRepository = unitOfWork.Repository<MyTask>();
            //    var Tasks = tasksRepository.Query().Get();

            //    var task2 = tasksRepository.FindById(Tasks.Last().IdKey);

            //}

            return View();

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}