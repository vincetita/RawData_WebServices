using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;


namespace MySqlDatabase
{
    public class DataService : IDataService

    {

        IList<Category> GetCategories(int page, int pagesize);
        Category GetCategory(int id);
        void AddCategory(Category category);
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
        int GetNumberOfCategories();

    }
}
