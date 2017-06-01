

using DAL.DBContext;
using DAL.Models;

namespace DAL.Collections.Interfaces
{
    interface IDriverDeviceCollection : IBaseCollection<DriverDevice, IDbContext>
    {
    }
}
