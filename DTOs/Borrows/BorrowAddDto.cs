using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace novin_library_backend.DTOs.Borrows
{
    public class BorrowAddDto
    {
        public required string BookGuid { get; set; }
        public required string MemberGuid { get; set; }
    }
}