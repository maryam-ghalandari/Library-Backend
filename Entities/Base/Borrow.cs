using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novin_library_backend.Entities.Base
{
    public class Borrow : Thing
    {
        public required Book Book { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}