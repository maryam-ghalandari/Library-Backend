using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using novin_library_backend.Enums;

namespace novin_library_backend.Entities.Base
{
    public class Member : Thing
    {
        public required string Firstname { get; set; }
        public required string Lastname { get; set; }
        public Gender Gender { get; set; }
    }
}