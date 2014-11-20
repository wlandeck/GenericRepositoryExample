using Entities;
using EntityFrameworkRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data.Initialization
{
    public class RepoMasterDbInitialize : DropCreateDatabaseAlways<BaseDataContext>
    {
        protected override void Seed(BaseDataContext context)
        {
            ICollection<Product> myProducts = new List<Product>();
            ICollection<MyTask> myTasks = new List<MyTask>();
            myProducts.Add(new Product { Name = "Entity Framework", Description = "Entity Framework Description" });
            myProducts.Add(new Product { Name = "Unity", Description = "MS IOC" });
            myProducts.Add(new Product { Name = "Angular", Description = "Google Angular Javascript file" });

            for (int i = 1; i < 100; i++)
            {
                myProducts.Add(new Product { Name = "Product " + i, Description = "Product description for Product " + i });    
            }

            for (int i = 1; i < 100; i++)
            {
                myTasks.Add(new MyTask { Task = "Task " + i, Description = "Task description for Task " + i });
            }
 
            
            foreach (var product in myProducts)
            {
                context.Set<Product>().Add(product);
            }
            foreach(var task in myTasks)
            {
                context.Set<MyTask>().Add(task);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
