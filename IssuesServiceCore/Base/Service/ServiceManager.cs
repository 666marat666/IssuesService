using Castle.MicroKernel.Registration;
using Castle.Windsor;
using IssuesServiceCore.Abstract;
using IssuesServiceCore.Abstract.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Base.Service
{
    public static class ServiceManager
    {
        public static IWindsorContainer container = new WindsorContainer();
        public static WebServiceHost host;
        static ServiceEndpoint endPoint;

        public static void Initialize(string hostname, int port)
        {
            #region DI registration
            container.Register(
                    Component.For<IIssuesService>().ImplementedBy<IssuesService>(),
                    Component.For<IIssuesRepository>().ImplementedBy<IssuesFilesRepository>()
                );
            #endregion
            host = new WebServiceHost(container.Resolve<IIssuesService>().GetType(), 
                new Uri(
                    String.Format("http://{0}:{1}/", hostname, port.ToString())
                    )
                    );
            endPoint = host.AddServiceEndpoint(typeof(IIssuesService), new WebHttpBinding(), String.Format("http://{0}:{1}/", hostname, port.ToString()));
        }
    }
}
