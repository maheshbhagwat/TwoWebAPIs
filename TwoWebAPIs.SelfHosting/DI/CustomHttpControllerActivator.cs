using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using TwoWebAPIs.ModuleService.CategoryModuleService;
using TwoWebAPIs.Persistence.PeristenceImplementations;

namespace TwoWebAPIs.SelfHosting
{
    public class CustomHttpControllerActivator : IHttpControllerActivator
    {
        public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
        {
            var controller = controllerType.GetConstructors()[0].Invoke(new object[] { new CategoryModuleService(new CategoryRepository()) }); ;
            return (IHttpController)controller;
        }
    }

}
