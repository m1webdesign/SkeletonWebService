using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Ninject.Modules;
using Turton.DAL.Repositories;
using Turton.DAL.UnitOfWork;
using Turton.Domain.DAL;
using Turton.Domain.Models;

namespace Turton.Core.Ninject
{
    public class DALInjectModule : NinjectModule
    {
        public override void Load()
        {
            //ensure that the same DbContext instance is used for all dependencies in a single http request
            //with inscope
            Bind<IUnitOfWork>().To<InMemoryUnitOfWork>().InScope(ctx => HttpContext.Current);

        }
    }
}
