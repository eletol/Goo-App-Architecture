
using DAL.Collections.Classes;
using DAL.Collections.Interfaces;
using DAL.DBContext;
using DAL.Models;

namespace DAL.Collection.Classes
{
    public class PassengerDeviceCollection : BaseCollection<PassengerDevice, IDbContext>, IPassengerDeviceCollection
    {
  
    }
}