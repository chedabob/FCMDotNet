using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FCMDotNet.Model;

namespace FCMDotNet
{
    class FCMException : Exception
    {
        private readonly FCMResponse _response;

        public FCMException(FCMResponse response)
        {
            _response = response;
        }
    }
}
