using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace SMart
{
    public class UnityBootStrapper : IDependencyResolver
    {
        protected IUnityContainer unitycontainer;

        public UnityBootStrapper(IUnityContainer container)
        {
            if(container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.unitycontainer = container;
        }

        public IDependencyScope BeginScope()
        {
            var childcontainer = unitycontainer.CreateChildContainer();
            return new UnityBootStrapper(childcontainer);
        }

        public object GetService(Type serviceType)
        {
            try
            {
                return unitycontainer.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return unitycontainer.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }

        public void Dispose()
        {
            unitycontainer.Dispose();
        }
    }
}