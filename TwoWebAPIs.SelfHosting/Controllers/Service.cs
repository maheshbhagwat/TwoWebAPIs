using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using TwoWebAPIs.Common;
using TwoWebAPIs.Contracts;
using TwoWebAPIs.Contracts.Models;
using TwoWebAPIs.Interfaces.ServiceContracts;
using TwoWebAPIs.ModuleService.ModuleServiceContracts;

namespace TwoWebAPIs.Controllers
{
    [ActionInfoLogFilter]
    public class ServiceController : ApiController, IService
    {
        private readonly ICategoryModuleService categoryModuleSevice;

        public ServiceController(ICategoryModuleService categoryModuleSevice)
        {
            this.categoryModuleSevice = categoryModuleSevice;
        }
        public void RemoveCategory(int id)
        {
            categoryModuleSevice.DeleteCategory(id);
        }

        public PaginationResults<Items> GetItemsByName(string name)
        {
            var items = categoryModuleSevice.GetItems();
            //Need to retrieve teh Pagesize from config files.
            return PaginationHelper.CreatePagedResults<Items>(items, 10, 10);
        }
    }
}
