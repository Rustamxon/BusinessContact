using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessContact.Service.Helpers
{
    public class GenericResponce<TValue>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public TValue Value { get; set; }
    }
}
