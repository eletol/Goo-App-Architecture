using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSIntegration
{
    public static class Keys
    {
        public static string SMSAccountIdentification = ConfigurationManager.AppSettings["Twilio.SMSAccountIdentification"];
        public static string SMSAccountPassword = ConfigurationManager.AppSettings["Twilio.SMSAccountPassword"];
        public static string SMSAccountFrom = ConfigurationManager.AppSettings["Twilio.SMSAccountFrom"];
    }
}
    