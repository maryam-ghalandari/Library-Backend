using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using novin_library_backend.DbContextes;
using novin_library_backend.DTOs.Books;
using novin_library_backend.DTOs.Common;
using novin_library_backend.DTOs.Members;
using novin_library_backend.Endpoints;
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
app.MapBookEndpoints();
app.MapMemberEndpoints();
app.Run();

