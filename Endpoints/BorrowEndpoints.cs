using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novin_library_backend.DbContextes;
using novin_library_backend.DTOs.Borrows;
using novin_library_backend.DTOs.Common;
using novin_library_backend.Entities.Base;

namespace novin_library_backend.Endpoints
{
    public static class BorrowEndpoints
    {
        public static void MapBorrowEndpoints(this WebApplication app)
        {

            app.MapPost("borrows/creat", async Task<CommandResultDto> ([FromServices] LibraryDB db,
           [FromBody] BorrowAddDto dto) =>
           {
               var book = await db.Books.FirstOrDefaultAsync(m => m.Guid == dto.BookGuid);
               if (book == null)
               {
                   return new CommandResultDto
                   {
                       Message = "Book Not Found!",
                       Successful = false
                   };
               }
               var member = await db.Members.FirstOrDefaultAsync(m => m.Guid == dto.MemberGuid);
               if (member == null)
               {
                   return new CommandResultDto
                   {
                       Message = "Member Not Found!",
                       Successful = false
                   };
               }
               var borrow = new Borrow
               {
                   Book = book,
                   Member = member,
                   BorrowTime = DateTime.Now
               };
               await db.Borrows.AddAsync(borrow);
               await db.SaveChangesAsync();
               return new CommandResultDto
               {
                   Successful = true
               };
           });
            app.MapGet("borrows/list", async Task<List<BorrowListDto>> (
            [FromServices] LibraryDB db) =>
            {
                var result = await db
                .Borrows
                .Include(m => m.Book)
                .Include(m => m.Member)
                .Select(m => new BorrowListDto
                {
                    Id = m.Guid,
                    Book = m.Book,
                    Member = m.Member,
                    BorrowTime = m.BorrowTime,
                    ReturnTime = m.ReturnTime
                }).ToListAsync();
                return result;
            });
        }
    }
}