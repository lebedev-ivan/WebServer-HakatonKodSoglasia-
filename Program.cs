using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using System.IO;

var builder = WebApplication.CreateBuilder(args);


// Добавляем контроллеры с представлениями
builder.Services.AddControllersWithViews();

// Добавляем настройки CORS, чтобы разрешить все источники, методы и заголовки
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

// Конфигурация HTTP-запросов для среды не разработки
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Разрешаем использование статических файлов
app.UseStaticFiles();

// Настраиваем страницу по умолчанию (например, index.html)
app.UseDefaultFiles(new DefaultFilesOptions
{
    DefaultFileNames = new List<string> { "index.html" } // Проверьте наличие этого файла
});

// Включаем маршрутизацию
app.UseRouting();

// Применяем политику CORS
app.UseCors("AllowAll");

app.UseAuthorization(); // Добавляем авторизацию (если требуется)

// Добавляем маршрутизацию для контроллеров
app.MapControllers();

// Путь к вашей папке Hakatон (для отображения HTML файлов)
app.MapGet("/Hakaton/{*path}", async context =>
{
    var filePath = Path.Combine("wwwroot", "Hakaton", context.Request.Path.Value.TrimStart('/'));
    if (File.Exists(filePath))
    {
        await context.Response.SendFileAsync(filePath); // Отправляем файл при его наличии
    }
    else
    {
        context.Response.StatusCode = 404; // Если файл не найден, возвращаем 404
    }
});

// Запускаем приложение
app.Run();