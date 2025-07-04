using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novin_library_backend.Entities.Base
{
    public class Book : Thing
    {
        public required string Title { get; set; }
        public string? Writer { get; set; }
        public string? Publisher { get; set; } 
        public double Price { get; set; }                  
    }
}