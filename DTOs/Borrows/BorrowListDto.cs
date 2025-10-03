using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using novin_library_backend.Entities.Base;

namespace novin_library_backend.DTOs.Borrows
{
    public class BorrowListDto
    {
        public string? Id { get; set; }
        public required Book Book { get; set; }
        public required Member Member { get; set; }
        public DateTime BorrowTime { get; set; }
        public DateTime ReturnTime { get; set; }
    }
}