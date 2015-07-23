using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesServiceCore.Abstract.Service
{
    public struct ServiceResponse
    {
        public ServiceStatus Status { get; set; }
        public string Message { get; set; }

        public ServiceResponse(ServiceStatus status, string message = "")
            : this()
        {
            this.Status = status;
            this.Message = message;
        }
    }
}
