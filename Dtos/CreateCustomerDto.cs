using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoAPI.Dtos
{
    public class CreateCustomerDto
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Name must be less than 30 characters")]
        public string Name { get; set; } = default!;
    }
}