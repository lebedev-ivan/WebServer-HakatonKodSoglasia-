using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        [HttpPost("export")]
        public async Task<IActionResult> ExportLogs([FromBody] LogData logData)
        {
            // Создаем CSV контент с правильной кодировкой UTF-8
            var csvBuilder = new StringBuilder();

            // Добавляем BOM для корректного распознавания UTF-8 в редакторах
            csvBuilder.Append("\uFEFF");

            // Заголовки CSV
            csvBuilder.AppendLine("Session Start,Session End,Session Duration,IP Address,User Agent");
            csvBuilder.AppendLine($"{logData.SessionStart},{logData.SessionEnd},{logData.SessionDuration},{logData.IpAddress},{logData.UserAgent}");

            // Логи
            csvBuilder.AppendLine();
            csvBuilder.AppendLine("Log Type,Log Message,Log Time");
            foreach (var log in logData.Logs)
            {
                csvBuilder.AppendLine($"{log.Type},{log.Message},{log.Time}");
            }

            // Преобразуем строку в массив байтов для создания файла с кодировкой UTF-8
            byte[] buffer = Encoding.UTF8.GetBytes(csvBuilder.ToString());

            // Возвращаем CSV файл
            return File(buffer, "text/csv; charset=utf-8", "session_logs.csv");
        }
    }

    // Классы для данных сессии и логов
    public class LogData
    {
        public string SessionStart { get; set; }
        public string SessionEnd { get; set; }
        public string SessionDuration { get; set; }
        public string IpAddress { get; set; }
        public string UserAgent { get; set; }
        public Log[] Logs { get; set; }
    }

    public class Log
    {
        public string Type { get; set; }
        public string Message { get; set; }
        public string Time { get; set; }
    }
}