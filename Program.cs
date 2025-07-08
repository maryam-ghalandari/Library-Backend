using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using novin_library_backend.DbContextes;
using novin_library_backend.Entities.Base;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("books/list", () =>
{
    using var db = new LibraryDB();
    return db.Books.ToList();
});
app.MapPost("books/creat", (Book book) =>
{
    using var db = new LibraryDB();
    db.Books.Add(book);
    db.SaveChanges();
    return "Book created!";
});
app.MapPut("books/update/{id}", (int id, Book book) =>
{
    using var db = new LibraryDB();
    var b = db.Books.Find(id);
    if (b == null)
    {
        return "لطفا مقدار صحیح را وارد کنیذ";
    }
    b.Title = book.Title;
    b.Writer = book.Writer;
    b.Publisher = book.Publisher;
    b.Price = book.Price;
    db.SaveChanges();
    return "Book updated!";
});
app.MapDelete("books/remove/{id}", (int id) =>
{
    using var db = new LibraryDB();
    var b = db.Books.Find(id);
    if (b == null)
    {
        return "Book Not Found";
    }
    db.Books.Remove(b);
    db.SaveChanges();
    return "Book removed!";
});


app.MapGet("members/list", () =>
{
    using var db = new LibraryDB();
    return db.Members.ToList();

});

app.MapPost("members/Creat", (Member member) =>
{
    using var db = new LibraryDB();
    db.Members.Add(member);
    db.SaveChanges();
    return "New Member Created";
});
app.MapPut("members/update/{id}", (int id, Member member) =>
{
    using var db = new LibraryDB();
    var m = db.Members.Find(id);
    if (m == null)
    {
        return "Member Not Found";
    }
    m.Firstname = member.Firstname;
    m.Lastname = member.Lastname;
    m.Gender = member.Gender;
    db.SaveChanges();
    return "مشخصات به روز رسانی شد";
});

app.MapDelete("members/remove/{id}", (int id) =>
{
    using var db = new LibraryDB();
    var m = db.Members.Find(id);
    if (m == null)
    {
        return "Member Not Found!";
    }
    db.Members.Remove(m);
    db.SaveChanges();
    return "Member Removed!";
});

app.Run();

