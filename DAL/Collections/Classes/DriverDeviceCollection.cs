
using DAL.Collections.Classes;
using DAL.Collections.Interfaces;
using DAL.DBContext;
using DAL.Models;

namespace DAL.Collection.Classes
{
    public class DriverDeviceCollection : BaseCollection<DriverDevice, IDbContext>, IDriverDeviceCollection
    {
  
    }
}