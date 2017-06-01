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
    public class DriverDeviceController : ApiController
    {
        private readonly IDriverDeviceBussinessManger _driverDeviceBussinessManger;
        [Inject]
        public DriverDeviceController(IDriverDeviceBussinessManger driverDeviceBussinessManger)
        {
            _driverDeviceBussinessManger = driverDeviceBussinessManger;
        }

        public DriverDeviceController()
        {
        }

        // GET: api/ 
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _driverDeviceBussinessManger.Get());

        }

        // GET: api/ /5
        [ResponseType(typeof(DriverDevice))]
        public IHttpActionResult Get(int id)
        {
            var driverDevice = _driverDeviceBussinessManger.GetById(id);
            if (driverDevice == null)
            {
                return NotFound();
            }

            return Ok(driverDevice);

        }

        // PUT: api/ /5
        [ResponseType(typeof(void))]
        public IHttpActionResult Put (string id, DriverDevice driverDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != driverDevice.DeviceId)
            {
                return BadRequest();
            }


            try
            {
                _driverDeviceBussinessManger.Update(driverDevice);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DriverDeviceExists(id))
                {
                    return NotFound();
                }
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ 
        [ResponseType(typeof(DriverDevice))]
        public IHttpActionResult Post (DriverDevice driverDevice)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _driverDeviceBussinessManger.Save(driverDevice);

            return CreatedAtRoute("DefaultApi", new { id = driverDevice.DeviceId }, driverDevice);
        }

        // DELETE: api/ /5
        [ResponseType(typeof(DriverDevice))]
        public IHttpActionResult Delete (int id)
        {
            var driverDevice = _driverDeviceBussinessManger.GetById(id);
            if (driverDevice== null)
            {
                return NotFound();
            }

            _driverDeviceBussinessManger.Delete(id);

            return Ok(driverDevice);
        }


        private bool DriverDeviceExists(string id)
        {
            return _driverDeviceBussinessManger.Get().Count(e => e.DeviceId == id) > 0;
        }
    }

}
