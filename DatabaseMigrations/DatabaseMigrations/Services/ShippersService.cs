using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DatabaseMigrations.Services.Abstractions;

namespace DatabaseMigrations.Services
{
    public class ShippersService : BaseDataService<ApplicationDbContext>, IShipperService
    {
    }
}
