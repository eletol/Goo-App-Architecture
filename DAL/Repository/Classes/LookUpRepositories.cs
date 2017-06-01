
using DAL.Collection.Classes;
using DAL.DBContext;
using DAL.Models;
using DAL.Repository.Interfaces;

namespace DAL.Repository.Classes
{
    public class PaymentMethodRepository : BaseRepository<PaymentMethodCollection, PaymentMethod>, IPaymentMethodRepository
    {
        public PaymentMethodRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
    public class CarTypeRepository : BaseRepository<CarTypeCollection, CarType>, ICarTypeRepository
    {
        public CarTypeRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
    public class TripStatusRepository : BaseRepository<TripStatusCollection, TripStatus>, ITripStatusRepository
    {
        public TripStatusRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
    public class DriverStatusRepository : BaseRepository<DriverStatusCollection, DriverStatus>, IDriverStatusRepository
    {
        public DriverStatusRepository(IDbContext context) : base(context)
        {
            Context = context;

        }

        public IDbContext Context { get; set; }
    }
}