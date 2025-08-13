using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novin_library_backend.DbContextes;
using novin_library_backend.DTOs.Common;
using novin_library_backend.DTOs.Members;
using novin_library_backend.Entities.Base;

namespace novin_library_backend.Endpoints
{
    public static class MemberEndpoints
    {
        public static void MapMemberEndpoints(this WebApplication app)
        {
            app.MapGet("members/list", async ([FromServices] LibraryDB db) =>
            {
                var result = await db.Members.Select(m => new MemberListDto
                {
                    Id = m.Guid,
                    Firstname = m.Firstname,
                    Lastname = m.Lastname,
                    Gender = m.Gender
                }).ToListAsync();
                return result;
            });
            app.MapPost("members/Creat", async (
                [FromServices] LibraryDB db,
                [FromBody] MemberAddDto memberAddDto) =>
            {
                var member = new Member
                {
                    Firstname = !String.IsNullOrEmpty(memberAddDto.Firstname) ? memberAddDto.Firstname : "عضو ناشناخته",
                    Lastname = !String.IsNullOrEmpty(memberAddDto.Lastname) ? memberAddDto.Lastname : "عضو ناشناخته",
                    NationalCode = memberAddDto.NationalCode,
                    Phone = memberAddDto.Phone,
                    Mobile = memberAddDto.Mobile,
                    Address = memberAddDto.Address,
                    Gender = memberAddDto.Gender
                };
                await db.Members.AddAsync(member);
                await db.SaveChangesAsync();
                return new CommandResultDto
                {
                    Successful = true,
                    Message = "member created!"
                };
            });
            app.MapPut("members/update/{guid}", async (
                [FromServices] LibraryDB db,
                [FromRoute] string Guid,
                [FromBody] MemberUpdateDto memberUpdateDto) =>
            {
                var m = await db.Members.FirstOrDefaultAsync(m => m.Guid == Guid);
                if (m == null)
                {
                    return new CommandResultDto
                    {
                        Successful = false,
                        Message = "Member Not Found"
                    };
                }
                m.Firstname = !String.IsNullOrEmpty(memberUpdateDto.Firstname) ? memberUpdateDto.Firstname : "عضو ناشناخته";
                m.Lastname = !String.IsNullOrEmpty(memberUpdateDto.Lastname) ? memberUpdateDto.Lastname : "عضو ناشناخته";
                m.NationalCode = memberUpdateDto.NationalCode;
                m.Phone = memberUpdateDto.Phone;
                m.Mobile = memberUpdateDto.Mobile;
                m.Gender = memberUpdateDto.Gender;
                await db.SaveChangesAsync();
                return new CommandResultDto
                {
                    Successful = true,
                    Message = "Member Updated!"
                };
            });
            app.MapDelete("members/remove/{Guid}", async (
                [FromServices] LibraryDB db,
                [FromRoute] string Guid) =>
            {
                var member = await db.Members.FirstOrDefaultAsync(m => m.Guid == Guid);
                if (member == null)
                {
                    return new CommandResultDto
                    {
                        Successful = false,
                        Message = "Member Not Found!"
                    };
                }
                db.Members.Remove(member);
                await db.SaveChangesAsync();
                return new CommandResultDto
                {
                    Successful = true,
                    Message = "Member Removed!"
                };
            });
        }
    }
}