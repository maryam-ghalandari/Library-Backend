using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novin_library_backend.DTOs.Common
{
    public class CommandResultDto
    {
        public bool Successful { get; set; }
        public string? Message { get; set; }

    }
}