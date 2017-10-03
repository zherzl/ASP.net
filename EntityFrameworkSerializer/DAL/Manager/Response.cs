using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Manager
{
    public class ResponseBase
    {
        public string Message { get; set; } = "";
        public bool Success { get; set; } = true;
    }
}
