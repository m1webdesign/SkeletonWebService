using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Turton.Service.Interfaces;
using Turton.Service.Services;

namespace Turton.Core.Ninject
{
    public class WebInjectModule: NinjectModule
    {
        public override void Load()
        {
            /*link iservice to concrete service implementation*/
            Bind<INewsEntryService>().To<NewsEntryService>();
            Bind<INewsletterService>().To<NewsletterService>();
        }
    }
}
