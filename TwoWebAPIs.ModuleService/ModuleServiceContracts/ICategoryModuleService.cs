using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Contracts.Models;

namespace TwoWebAPIs.ModuleService.ModuleServiceContracts
{
    public interface ICategoryModuleService
    {
        void DeleteCategory(int id);

        IEnumerable<Items> GetItems();
    }
}
