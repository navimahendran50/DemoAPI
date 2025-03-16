using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Dtos
{
    public class ErrorResponse
    {
        public int StatusCode { get; set; }
        public string ErrorId { get; set; } = default!;
        public string ErrorMessage { get; set; } = default!;
    }
}