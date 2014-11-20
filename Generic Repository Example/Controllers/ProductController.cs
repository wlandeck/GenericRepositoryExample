using Entities;
using GenericRepository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Generic_Repository_Example.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        public ActionResult Index()
        {
            IEnumerable<Product> products;
            using (var uow = new MyUnitOfWork(new MyDataContext()))
            {
                products = uow.Repository<Product>().Query().Get();
            }
            return View(products);
        }

        //
        // GET: /Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Product/Create
        [HttpPost]
        public ActionResult Create(Product newProduct)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (var uow = new MyUnitOfWork(new MyDataContext()))
                    {
                        var repository = uow.Repository<Product>();
                        repository.Insert(newProduct);
                        uow.Commit();
                    }
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                    using (var uow = new MyUnitOfWork(new MyDataContext()))
                    {
                        var repository = uow.Repository<Product>();
                        var product = repository.FindById(id);
                        return View(product);
                    }
                    throw new Exception("Object Not Found");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product updatedProduct)
        {
            try
            {
                using (var uow = new MyUnitOfWork(new MyDataContext()))
                {
                    var repository = uow.Repository<Product>();
                    repository.Update(updatedProduct);
                    uow.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Product/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (var uow = new MyUnitOfWork(new MyDataContext()))
                {
                    var repository = uow.Repository<Product>();
                    repository.Delete(id);
                    uow.Commit();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Product/Delete/5
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
