using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Contracts;

namespace TwoWebAPIs.Common
{
    public class PaginationHelper
    {
        public static PaginationResults<T> CreatePagedResults<T>(IEnumerable<T> Items, int page, int pageSize)
        {
            var skipAmount = pageSize * (page - 1);

            var projection = Items
                .Skip(skipAmount)
                .Take(pageSize);

            var totalNumberOfRecords = Items.Count();
            var results = projection;

            var mod = totalNumberOfRecords % pageSize;
            var totalPageCount = (totalNumberOfRecords / pageSize) + (mod == 0 ? 0 : 1);

            //Need to form the new URL
            var nextPageUrl = string.Empty;

            return new PaginationResults<T>
            {
                Results = results,
                PageNumber = page,
                PageSize = results.Count(),
                TotalNumberOfPages = totalPageCount,
                TotalNumberOfRecords = totalNumberOfRecords,
                NextPageUrl = nextPageUrl
            };
        }
    }

}
