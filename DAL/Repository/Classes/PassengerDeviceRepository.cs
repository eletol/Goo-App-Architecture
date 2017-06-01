
using DAL.Collection.Classes;
using DAL.DBContext;
using DAL.Models;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Classes
{
    public class PassengerDeviceRepository : BaseRepository<PassengerDeviceCollection, PassengerDevice>, IPassengerDeviceRepository
    {
        public PassengerDeviceRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
}