using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using novin_library_backend.Entities.Base;

namespace novin_library_backend.DTOs.Borrows
{
    public class BorrowListDto
    {
        public required string? Guid { get; set; }
        public required string BookTitle { get; set; }
        public required string MemberFirstname { get; set; }
        public required string MemberLastname { get; set; }
    }
}