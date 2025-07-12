using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using novin_library_backend.DbContextes;
using novin_library_backend.DTOs.Books;
using novin_library_backend.DTOs.Common;
using novin_library_backend.DTOs.Members;
using novin_library_backend.Entities.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddDbContext<LibraryDB>(options =>
options.LogTo(Console.WriteLine));
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors(policy =>
{
    policy
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowAnyOrigin();
});
app.UseHttpsRedirection();

app.MapGet("books/list", ([FromServices] LibraryDB db) =>
{
    return db.Books.Select(b => new BookListDto
    {
        Id = b.Guid,
        Title = b.Title,
        Writer = b.Writer,
        Publisher = b.Publisher,
        Price = b.Price
    }).ToList();
});
app.MapPost("books/creat", (
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
    db.Books.Add(book);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successful = true,
        Message = "Book Created!"
    };
});
app.MapPut("books/update/{Guid}", (
    [FromServices] LibraryDB db,
    [FromRoute] string Guid,
    [FromBody] BookUpdateDto bookUpdateDto) =>
{
    var b = db.Books.FirstOrDefault(m => m.Guid == Guid);
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
    db.SaveChanges();
    return new CommandResultDto
    {
        Successful = true,
        Message = "Book updated!"
    };
});
app.MapDelete("books/remove/{Guid}", (
    [FromServices] LibraryDB db,
    [FromRoute] string Guid) =>
{
    var book = db.Books.FirstOrDefault(b => b.Guid == Guid);
    if (book == null)
    {
        return new CommandResultDto
        {
            Successful = false,
            Message = "Book Not Found"
        };
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successful = true,
        Message = "Book removed!"
    };
});
app.MapGet("members/list", ([FromServices] LibraryDB db) =>
{
    return db.Members.Select(m => new MemberListDto
    {
        Id = m.Guid,
        Firstname = m.Firstname,
        Lastname = m.Lastname,
        Gender = m.Gender
    }).ToList();
});
app.MapPost("members/Creat", (
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
    db.Members.Add(member);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successful = true,
        Message = "member created!"
    };
});
app.MapPut("members/update/{guid}", (
    [FromServices] LibraryDB db,
    [FromRoute] string Guid,
    [FromBody] MemberUpdateDto memberUpdateDto) =>
{
    var m = db.Members.FirstOrDefault(m => m.Guid == Guid);
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
    db.SaveChanges();
    return new CommandResultDto
    {
        Successful = true,
        Message = "Member Updated!"
    };
});
app.MapDelete("members/remove/{Guid}", (
    [FromServices] LibraryDB db,
    [FromRoute] string Guid) =>
{
    var member = db.Members.FirstOrDefault(m => m.Guid == Guid);
    if (member == null)
    {
        return new CommandResultDto
        {
            Successful = false,
            Message = "Member Not Found!"
        };
    }
    db.Members.Remove(member);
    db.SaveChanges();
    return new CommandResultDto
    {
        Successful = true,
        Message = "Member Removed!"
    };
});
app.Run();

