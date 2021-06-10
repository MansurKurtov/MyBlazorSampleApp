using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public class AuthParams
    {
        public const int EXPIRE_MINUTES = 2000; //access token expire 20 min
        public const int EXPIRE_MINUTES_REFRESH = 2000; //refresh token expire 200 min
        public const string PARAM_ISS = "HostAuth";
        public const string PARAM_AUD = "HR";
        public const string PARAM_SECRET_KEY = "Y2F0Y2hlciUyMHdvbmclMjBsb3ZlJTIwLm5ldA==";
        public const int MAX_DEVICE_COUNT = 3;
    }
}
