using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BLL.FreelanceMusicStore.EntityDTO 
{ 
    public class ServerRequest
    {
        public bool ErrorOccured { get; set; } = false;
        public string Message { get; set; }
        public string ResponseObject { get; set; }
    }
}