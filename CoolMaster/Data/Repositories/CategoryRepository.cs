using CoolMaster.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoolMaster.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>
    {
        public CategoryRepository(string connectionString) : base(connectionString) { }
    }
}
