using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using novin_library_backend.DbContextes;
using novin_library_backend.Entities.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
builder.Services.AddCors();
builder.Services.AddDbContext<LibraryDB>();
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
    return db.Books.ToList();
});
app.MapPost("books/creat", (
    [FromServices] LibraryDB db, [FromBody] Book book) =>
{
    db.Books.Add(book);
    db.SaveChanges();
    return new { IsOk = true, Result = "Book created!" };
});
app.MapPut("books/update/{id}", (
    [FromServices] LibraryDB db,
    [FromRoute] int id,
    [FromBody] Book book) =>
{
    var b = db.Books.Find(id);
    if (b == null)
    {
        return new { IsOk = false, Result = "Book Not Found" };
    }
    b.Title = book.Title;
    b.Writer = book.Writer;
    b.Publisher = book.Publisher;
    b.Price = book.Price;
    db.SaveChanges();
    return new { IsOk = true, Result = "Book updated!" };
});
app.MapDelete("books/remove/{id}", (
    [FromServices] LibraryDB db,
    [FromRoute] int id) =>
{
    var book = db.Books.Find(id);
    if (book == null)
    {
        return new { IsOk = false, Result = "Book Not Found" };
    }
    db.Books.Remove(book);
    db.SaveChanges();
    return new { IsOk = true, Result = "Book removed!" };
});


app.MapGet("members/list", ([FromServices] LibraryDB db) =>
{
    return db.Members.ToList();

});

app.MapPost("members/Creat", (
    [FromServices] LibraryDB db,
    [FromBody] Member member) =>
{
    db.Members.Add(member);
    db.SaveChanges();
    return new { IsOk = true, Result = "member created!" };
});
app.MapPut("members/update/{id}", (
    [FromServices] LibraryDB db,
    [FromRoute] int id,
    [FromBody] Member member) =>
{
    var m = db.Members.Find(id);
    if (m == null)
    {
        return new { IsOk = false, Result = "Member Not Found" };
    }
    m.Firstname = member.Firstname;
    m.Lastname = member.Lastname;
    m.Gender = member.Gender;
    db.SaveChanges();
    return new { IsOk = true, Result = "Member Updated!" };
});

app.MapDelete("members/remove/{id}", (
    [FromServices] LibraryDB db,
    [FromRoute] int id) =>
{
    var m = db.Members.Find(id);
    if (m == null)
    {
        return new { IsOk = false, Result = "Member Not Found!" };
    }
    db.Members.Remove(m);
    db.SaveChanges();
    return new { IsOk = true, Result = "Member Removed!" };
});

app.Run();

