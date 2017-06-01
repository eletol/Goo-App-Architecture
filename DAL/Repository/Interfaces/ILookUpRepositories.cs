using DAL.Models;

namespace DAL.Repository.Interfaces
{
    public interface IPaymentMethodRepository : IBaseRepository<PaymentMethod>
    {

    }
    public interface ICarTypeRepository : IBaseRepository<CarType>
    {

    }
    public interface ITripStatusRepository : IBaseRepository<TripStatus>
    {

    }
    public interface IDriverStatusRepository : IBaseRepository<DriverStatus>
    {

    }
}