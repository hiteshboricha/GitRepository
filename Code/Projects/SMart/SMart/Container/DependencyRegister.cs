using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SMart.Business;
using SMart.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMart.Container
{
    public class DependencyRegister : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component
                .For<IProductDL>()
                .ImplementedBy<ProductDL>()
                .LifestylePerWebRequest());

            container.Register(Component
                .For<IProductBL>()
                .ImplementedBy<ProductBL>()
                .LifestylePerWebRequest());
        }
    }
}