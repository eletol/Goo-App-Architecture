using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL.DBContext;
using DAL.UnitOfWork;
using Ninject;

using Ninject.Modules;

namespace Assistance.APIs.Domain.NinjectModules
{
    public class HelperModule : NinjectModule
    {
        public override void Load()
        {
            //TODO: Divid them to multiapule modules
            Bind<IUnitOfWork>().To<UnitOfWork<DbGooContext>>();
            Bind<IDbContext>().To<DbGooContext>();
            Bind<UnitOfWork<DbGooContext>>().ToSelf().InSingletonScope();
            Bind<DbGooContext>().ToSelf().InSingletonScope();

        }
    }
}