
using DAL.Collections.Classes;
using DAL.Collections.Interfaces;
using DAL.DBContext;
using DAL.Models;

namespace DAL.Collection.Classes
{
    public class PaymentMethodCollection : BaseCollection<PaymentMethod, IDbContext>, IPaymentMethodCollection
    {
  
    }
    public class CarTypeCollection : BaseCollection<CarType, IDbContext>, ICarTypeCollection
    {

    }
    public class TripStatusCollection : BaseCollection<TripStatus, IDbContext>, ITripStatusCollection
    {

    }
    public class DriverStatusCollection : BaseCollection<DriverStatus, IDbContext>, IDriverStatusCollection
    {

    }
}