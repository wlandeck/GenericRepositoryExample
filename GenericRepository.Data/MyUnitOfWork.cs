using EntityFrameworkRepository;
using GenericRepository.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericRepository.Data
{
    public class MyUnitOfWork : UnitOfWork<IMyDataContext>, IDisposable
    {
        public MyUnitOfWork(IMyDataContext context )
            : base(context)
        {

        }
    }
}
