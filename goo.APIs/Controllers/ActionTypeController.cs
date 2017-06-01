//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web.Http;
//using BL.BussinessMangers.Interfaces;
//using FireBaseNotificationIntegrations;
//using Ninject;

//namespace goo.Api.Controllers
//{
//    [Authorize(Roles = "Passenger")]
//    public class ActionTypeController : ApiController
//    {
//        private readonly IActionTypeBussinessManger _actionTypeBussinessManger;
//        [Inject]
//        public ActionTypeController(IActionTypeBussinessManger actionTypeBussinessManger)
//        {
//            _actionTypeBussinessManger = actionTypeBussinessManger;
//        }

//        public ActionTypeController()
//        {
//        }
//        public HttpResponseMessage Get()
//        {
//            FireBase.SendPushNotification(FireBase.SendToAll,"hi","hello");
//            return Request.CreateResponse(HttpStatusCode.OK, _actionTypeBussinessManger.Get());

//        }

//        // GET api/values/5
//        public string Get(int id)
//        {
//            return "value";
//        }

//        // POST api/values
//        public void Post([FromBody]string value)
//        {
//        }

//        // PUT api/values/5
//        public void Put(int id, [FromBody]string value)
//        {
//        }

//        // DELETE api/values/5
//        public void Delete(int id)
//        {
//        }
//    }
//}
