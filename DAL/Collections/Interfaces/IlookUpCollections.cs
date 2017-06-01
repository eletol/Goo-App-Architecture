

using DAL.DBContext;
using DAL.Models;

namespace DAL.Collections.Interfaces
{
    interface IPaymentMethodCollection : IBaseCollection<PaymentMethod, IDbContext>
    {
    }
    interface ICarTypeCollection : IBaseCollection<CarType, IDbContext>
    {
    }
    interface ITripStatusCollection : IBaseCollection<TripStatus, IDbContext>
    {
    }
    interface IDriverStatusCollection : IBaseCollection<DriverStatus, IDbContext>
    {
    }
}
