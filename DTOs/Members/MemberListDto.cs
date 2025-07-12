using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using novin_library_backend.Enums;

namespace novin_library_backend.DTOs.Members
{
    public class MemberListDto
    {
        public string? Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public Gender Gender { get; set; }
    }
}