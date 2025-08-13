using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using novin_library_backend.DbContextes;
using novin_library_backend.DTOs.Books;
using novin_library_backend.DTOs.Common;
using novin_library_backend.Entities.Base;

namespace novin_library_backend.Endpoints
{
    public static class BookEndpoints
    {
        public static void MapBookEndpoints(this WebApplication app)
        {
            app.MapGet("books/list", async ([FromServices] LibraryDB db) =>
{
    var result = await db.Books.Select(b => new BookListDto

    {
        Id = b.Guid,
        Title = b.Title,
        Writer = b.Writer,
        Publisher = b.Publisher,
        Price = b.Price
    }).ToListAsync();
    return result;
});
            app.MapPost("books/creat", async (
                [FromServices] LibraryDB db,
                [FromBody] BookAddDto bookAddDto) =>
            {
                var book = new Book
                {
                    Title = !string.IsNullOrEmpty(bookAddDto.Title) ? bookAddDto.Title : "بدون عنوان",
                    Writer = bookAddDto.Writer,
                    Publisher = bookAddDto.Publisher,
                    Price = bookAddDto.Price
                };
                await db.Books.AddAsync(book);
                await db.SaveChangesAsync();
                return new CommandResultDto
                {
                    Successful = true,
                    Message = "Book Created!"
                };
            });
            app.MapPut("books/update/{Guid}", async (
                [FromServices] LibraryDB db,
                [FromRoute] string Guid,
                [FromBody] BookUpdateDto bookUpdateDto) =>
            {
                var b = await db.Books.FirstOrDefaultAsync(m => m.Guid == Guid);
                if (b == null)
                {
                    return new CommandResultDto
                    {
                        Successful = false,
                        Message = "Book Not Found"
                    };
                }
                b.Title = bookUpdateDto.Title ?? "بدون عنوان";
                b.Writer = bookUpdateDto.Writer;
                b.Publisher = bookUpdateDto.Publisher;
                b.Price = bookUpdateDto.Price;
                await db.SaveChangesAsync();
                return new CommandResultDto
                {
                    Successful = true,
                    Message = "Book updated!"
                };
            });
            app.MapDelete("books/remove/{Guid}", async (
                [FromServices] LibraryDB db,
                [FromRoute] string Guid) =>
            {
                var book = await db.Books.FirstOrDefaultAsync(b => b.Guid == Guid);
                if (book == null)
                {
                    return new CommandResultDto
                    {
                        Successful = false,
                        Message = "Book Not Found"
                    };
                }
                db.Books.Remove(book);
                await db.SaveChangesAsync();
                return new CommandResultDto
                {
                    Successful = true,
                    Message = "Book removed!"
                };
            });
        }
    }
}