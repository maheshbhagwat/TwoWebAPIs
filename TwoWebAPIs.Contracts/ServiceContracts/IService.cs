using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Contracts;
using TwoWebAPIs.Contracts.Models;

namespace TwoWebAPIs.Interfaces.ServiceContracts
{
    public interface IService
    {
        void RemoveCategory(int id);

        PaginationResults<Items> GetItemsByName(string name);
    }
}
