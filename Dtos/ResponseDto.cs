using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Dtos
{
    public class ResponseDto<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; } = default!;
        public T? Data { get; set; } = default!;
    }
}