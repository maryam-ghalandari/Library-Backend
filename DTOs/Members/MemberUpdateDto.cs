using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using novin_library_backend.Enums;

namespace novin_library_backend.DTOs.Members
{
    public class MemberUpdateDto
    {
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public double NationalCode { get; set; }
        public int Phone { get; set; }
        public double Mobile { get; set; }
        public String? Address { get; set; }
        public Gender Gender { get; set; }
    }
}