
using BL.BussinessMangers.Interfaces;
using BL.Domain.BussinessMangers.Classes;
using DAL;
using DAL.Repository.Interfaces;
using DAL.UnitOfWork;
using DAL.Models;

namespace BL.BussinessMangers.Classes
{
    public class DriverDeviceBussinessManger
        <TRepository> : BaseBussinessManger<DriverDevice, TRepository>,
            IDriverDeviceBussinessManger where TRepository : IDriverDeviceRepository
    {
        public DriverDeviceBussinessManger(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}