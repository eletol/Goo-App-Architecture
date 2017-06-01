using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BL.BussinessMangers.Interfaces;
using FireBaseNotificationIntegrations;
using Ninject;
using BL.BussinessMangers.Classes;
using DAL.Models;

namespace goo.Api.Controllers
{
    public class PassengerDeviceController : ApiController
    {
        private readonly IPassengerDeviceBussinessManger _passengerDeviceBussinessManger;
        [Inject]
        public PassengerDeviceController(IPassengerDeviceBussinessManger PassengerDeviceBussinessManger)
        {
            _passengerDeviceBussinessManger = PassengerDeviceBussinessManger;
        }

        public PassengerDeviceController()
        {
        }

        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _passengerDeviceBussinessManger.Get());

        }

        [ResponseType(typeof(PassengerDevice))]
        public IHttpActionResult Get(int id)
        {
            var passengerDevice = _passengerDeviceBussinessManger.GetById(id);
            if (passengerDevice == null)
            {
                return NotFound();
            }

            return Ok(passengerDevice);

        }

        [ResponseType(typeof(void))]
        public IHttpActionResult Put(string id, PassengerDevice PassengerDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != PassengerDevice.DeviceId)
            {
                return BadRequest();
            }


            try
            {
                _passengerDeviceBussinessManger.Update(PassengerDevice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PassengerDeviceExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [ResponseType(typeof(PassengerDevice))]
        public IHttpActionResult Post(PassengerDevice passengerDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _passengerDeviceBussinessManger.Save(passengerDevice);

            return CreatedAtRoute("DefaultApi", new { id = passengerDevice.DeviceId }, passengerDevice);
        }

        [ResponseType(typeof(PassengerDevice))]
        public IHttpActionResult Delete(int id)
        {
            var passengerDevice = _passengerDeviceBussinessManger.GetById(id);
            if (passengerDevice == null)
            {
                return NotFound();
            }

            _passengerDeviceBussinessManger.Delete(id);

            return Ok(passengerDevice);
        }


        private bool PassengerDeviceExists(string id)
        {
            return _passengerDeviceBussinessManger.Get().Count(e => e.DeviceId == id) > 0;
        }
    }

}
