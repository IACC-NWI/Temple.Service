using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Temple.Service.Database.Model;

namespace Temple.Service.Database
{
    public interface ITempleDbContext
    {
        DbSet<Festival> Festivals { get; set; }
        DbSet<OfferedService> OfferedServices { get; set; }
        Task<int> SaveChangesAsync();
    }
}
