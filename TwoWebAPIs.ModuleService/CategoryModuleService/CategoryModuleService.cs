using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Contracts.Models;
using TwoWebAPIs.ModuleService.ModuleServiceContracts;
using TwoWebAPIs.Persistence.PersistenceContracts;

namespace TwoWebAPIs.ModuleService.CategoryModuleService
{
    public class CategoryModuleService : ICategoryModuleService
    {
        private readonly ICategoryRepository CategoryRepository;

        public CategoryModuleService(ICategoryRepository CategoryRepository)
        {
            this.CategoryRepository = CategoryRepository;
        }

        public void DeleteCategory(int id)
        {
            CategoryRepository.DeleteCategory(id);
        }

        public IEnumerable<Items> GetItems()
        {
            return CategoryRepository.GetItems();
        }
    }
}
