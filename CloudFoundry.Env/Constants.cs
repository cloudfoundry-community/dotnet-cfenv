using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudFoundry.Env
{
    public class Constants
    {
        public static readonly string PORT_ENV_VARIABLE_NAME = "PORT";
        public static readonly string IP_ENV_VARIABLE_NAME = "CF_INSTANCE_IP";
        public static readonly string INSTANCE_GUID_ENV_VARIABLE_NAME = "INSTANCE_GUID";
        public static readonly string INSTANCE_INDEX_ENV_VARIABLE_NAME = "CF_INSTANCE_INDEX";
        public static readonly string BOUND_SERVICES_ENV_VARIABLE_NAME = "VCAP_SERVICES";
        public static readonly string NOT_ON_CLOUD_FOUNDRY_MESSAGE = "Not running in cloud foundry.";
        public static readonly string APPLICATION_ENV_VARIABLE_NAME = "VCAP_APPLICATION";
    }
}
