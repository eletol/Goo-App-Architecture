
using BL.BussinessMangers.Interfaces;
using BL.Domain.BussinessMangers.Classes;
using DAL;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using DAL.Models;

namespace BL.BussinessMangers.Classes
{
    public class PassengerDeviceBussinessManger
        <TRepository> : BaseBussinessManger<PassengerDevice, TRepository>,
            IPassengerDeviceBussinessManger where TRepository : IPassengerDeviceRepository
    {
        public PassengerDeviceBussinessManger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}