using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApplication.Reponse
{
    public class ApiNotFoundResponse : ApiResponseBase
    {
        public ApiNotFoundResponse(int statusCode = 404, string message = null) : base(statusCode, message)
        {
        }
    }
}
