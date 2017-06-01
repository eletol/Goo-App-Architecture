
using DAL.Collection.Classes;
using DAL.DBContext;
using DAL.Models;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Classes
{
    public class DriverDeviceRepository : BaseRepository<DriverDeviceCollection, DriverDevice>, IDriverDeviceRepository
    {
        public DriverDeviceRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
}