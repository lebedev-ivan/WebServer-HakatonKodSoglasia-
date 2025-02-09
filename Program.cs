using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);


// ��������� ����������� � ���������������
builder.Services.AddControllersWithViews();

// ��������� ��������� CORS, ����� ��������� ��� ���������, ������ � ���������
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// ������������ HTTP-�������� ��� ����� �� ����������
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// ��������� ������������� ����������� ������
app.UseStaticFiles();

// ����������� �������� �� ��������� (��������, index.html)
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "index.html" } // ��������� ������� ����� �����
});

// �������� �������������
app.UseRouting();

// ��������� �������� CORS
app.UseCors("AllowAll");

app.UseAuthorization(); // ��������� ����������� (���� ���������)

// ��������� ������������� ��� ������������
app.MapControllers();

// ���� � ����� ����� Hakat�� (��� ����������� HTML ������)
app.MapGet("/Hakaton/{*path}", async context =>
{
    var filePath = Path.Combine("wwwroot", "Hakaton", context.Request.Path.Value.TrimStart('/'));
    if (File.Exists(filePath))
    {
        await context.Response.SendFileAsync(filePath); // ���������� ���� ��� ��� �������
    }
    else
    {
        context.Response.StatusCode = 404; // ���� ���� �� ������, ���������� 404
    }
});

// ��������� ����������
app.Run();