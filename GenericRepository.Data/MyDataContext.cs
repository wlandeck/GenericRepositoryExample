using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityFrameworkRepository;
using System.Configuration;
using System.Data.Entity;
using GenericRepository.Data.Interfaces;
using GenericRepository.Data.ConfigurationMappings;
using Entities;
using GenericRepository.Data.Initialization;

namespace GenericRepository.Data
{
    public class MyDataContext : BaseDataContext, IMyDataContext
    {
        public static string ConnectionStringName
        {
            get
            {
                if(ConfigurationManager.ConnectionStrings[Constants.AppSettings.MyDataConnectionStringName] != null)
                {
                    return ConfigurationManager.ConnectionStrings[Constants.AppSettings.MyDataConnectionStringName].ToString();
                }
                else if(ConfigurationManager.ConnectionStrings[Constants.AppSettings.DefaultConnectionStringName] != null)
                {
                    return ConfigurationManager.ConnectionStrings[Constants.AppSettings.DefaultConnectionStringName].ToString();

                }

                throw new Exception("Connection string not found!");
            }
        }

        static MyDataContext()
        {
            Database.SetInitializer<BaseDataContext>(new RepoMasterDbInitialize());
            
        }

        public MyDataContext():
            base(nameOrConnectionString: MyDataContext.ConnectionStringName)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public override void AddModelBuilderConfiguration(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ProductConfiguration());
            modelBuilder.Configurations.Add(new MyTaskConfiguration());
            modelBuilder.Configurations.Add(new ProductReviewConfiguration());
            modelBuilder.Configurations.Add(new TaskListConfiguration());
        }

    }

}
