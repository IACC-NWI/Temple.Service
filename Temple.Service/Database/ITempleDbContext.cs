using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temple.Service.Database
{
    public interface ITempleDbContext
    {

        Task<int> SaveChangesAsync();
    }
}
