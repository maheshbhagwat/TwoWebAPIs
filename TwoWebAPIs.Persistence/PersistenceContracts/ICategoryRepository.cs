using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Contracts.Models;

namespace TwoWebAPIs.Persistence.PersistenceContracts
{
    public interface ICategoryRepository
    {
        IEnumerable<Items> GetItems();

        void DeleteCategory(int id);
    }
}
