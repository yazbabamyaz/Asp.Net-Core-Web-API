using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Entities.ErrorModel
{
    public class ErrorDetails
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        //Ve Tostring metodunu override edeceğiz.yukarıdaki 2 ifadeyi serilize edeceğiz.
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);//this ifadesi classın tamamını kapsar.
        }
    }
}
