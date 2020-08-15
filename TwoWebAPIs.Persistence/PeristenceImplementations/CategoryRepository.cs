using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwoWebAPIs.Contracts.Models;
using TwoWebAPIs.Persistence.PersistenceContracts;
using System.Data.SQLite;
using System.Data;
using System.Reflection;
using System.IO;

namespace TwoWebAPIs.Persistence.PeristenceImplementations
{

    public class CategoryRepository : ICategoryRepository
    {
        private string basePath, dbPath;
        public CategoryRepository()
        {
            //basePath = AppDomain.CurrentDomain.BaseDirectory;
            basePath = Directory.GetParent(Directory.GetParent(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).FullName).FullName;
            dbPath = basePath + @"\DB\database.db";
        }


        public void DeleteCategory(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Items> GetItems()
        {
            List<Items> items = new List<Items>();
            using (SQLiteConnection conread = new SQLiteConnection("Data Source=" + dbPath))
            {
                conread.Open();
                SQLiteDataAdapter DB = new SQLiteDataAdapter("select * from Item", conread);
                DataSet DS = new DataSet();
                DB.Fill(DS, "Items");
                foreach (DataRow row in DS.Tables["Items"].Rows)
                {
                    items.Add(new Items() {
                        Id = Convert.ToInt32(row["Id"]),
                        SubCategoryId = Convert.ToInt32(row["SubCategoryId"]),
                        Name = row["Name"].ToString(),
                        Description = row["Description"].ToString()

                    }) ;
                }
            }
            return items;
        }
    }
}
