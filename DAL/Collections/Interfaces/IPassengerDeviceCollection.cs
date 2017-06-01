

using DAL.DBContext;
using DAL.Models;

namespace DAL.Collections.Interfaces
{
    interface IPassengerDeviceCollection : IBaseCollection<PassengerDevice, IDbContext>
    {
    }
}
