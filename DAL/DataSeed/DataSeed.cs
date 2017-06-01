using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Migrations;
using Assistance.APIs.Domain.NinjectModules;
using DAL.DBContext;
using DAL.Models;
using DAL.Repository.Classes;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using Ninject;

namespace DAL.DataSeed
{
    public static class DataSeed
    {
       
        private static void PaymentMethodsSeed(IPaymentMethodRepository paymentStatusRepository)
        {
            paymentStatusRepository.SaveOrEdit(new PaymentMethod()
            {
                Id = PaymentMethods.CC.Id,
                Name = PaymentMethods.CC.Name
            });
            paymentStatusRepository.SaveOrEdit(new PaymentMethod()
            {
                Id = PaymentMethods.COD.Id,
                Name = PaymentMethods.COD.Name
            });

        }
        private static void CarTypesSeed(ICarTypeRepository carTypeRepository)
        {
            carTypeRepository.SaveOrEdit(new CarType()
            {
                Id = CarTypes.Bussiness.Id,
                Name = CarTypes.Bussiness.Name
            });
            carTypeRepository.SaveOrEdit(new CarType()
            {
                Id = CarTypes.Economy.Id,
                Name = CarTypes.Economy.Name
            });

        }
        private static void TripStatusSeed(ITripStatusRepository tripStatusSeedRepository)
        {
            tripStatusSeedRepository.SaveOrEdit(new TripStatus()
            {
                Id = TripStatuses.Accepted.Id,
                Name = TripStatuses.Accepted.Name
            });
            tripStatusSeedRepository.SaveOrEdit(new TripStatus()
            {
                Id = TripStatuses.Canceled.Id,
                Name = TripStatuses.Canceled.Name
            });
            tripStatusSeedRepository.SaveOrEdit(new TripStatus()
            {
                Id = TripStatuses.Finished.Id,
                Name = TripStatuses.Finished.Name
            });
            tripStatusSeedRepository.SaveOrEdit(new TripStatus()
            {
                Id = TripStatuses.Paid.Id,
                Name = TripStatuses.Paid.Name
            });
            tripStatusSeedRepository.SaveOrEdit(new TripStatus()
            {
                Id = TripStatuses.Pending.Id,
                Name = TripStatuses.Pending.Name
            });
            tripStatusSeedRepository.SaveOrEdit(new TripStatus()
            {
                Id = TripStatuses.Started.Id,
                Name = TripStatuses.Started.Name
            });
        }
        private static void DriverStatusSeed(IDriverStatusRepository driverStatusRepository)
        {
            driverStatusRepository.SaveOrEdit(new DriverStatus()
            {
                Id = DriverStatuses.Busy.Id,
                Name = DriverStatuses.Busy.Name
            });
            driverStatusRepository.SaveOrEdit(new DriverStatus()
            {
                Id = DriverStatuses.OutOfWork.Id,
                Name = DriverStatuses.OutOfWork.Name
            });

        }

        public static void Load()
        {
            IKernel kernel = new StandardKernel(new HelperModule());
            var unitOfWork = kernel.Get<UnitOfWork<DbGooContext>>();
            var paymentMethodRepository = unitOfWork.Repository<PaymentMethod, PaymentMethodRepository>();
            var driverStatusRepository = unitOfWork.Repository<DriverStatus, DriverStatusRepository>();
            var tripStatusRepository = unitOfWork.Repository<TripStatus, TripStatusRepository>();
            var carTypeRepository = unitOfWork.Repository<CarType, CarTypeRepository>();

            PaymentMethodsSeed(paymentMethodRepository);
            DriverStatusSeed(driverStatusRepository);
            TripStatusSeed(tripStatusRepository);
            CarTypesSeed(carTypeRepository);

            unitOfWork.Save();
            
        }

  
    }
}