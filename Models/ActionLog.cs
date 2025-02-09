// Models/ActionLog.cs
namespace WebServer.Models
{
    public class ActionLog
    {
        public int Id { get; set; } // Предполагаем, что Id - это первичный ключ
        public string Message { get; set; } // Сообщение лога
        public DateTime CreatedAt { get; set; } // Дата и время создания лога
                                                // Добавьте другие поля, которые вам нужны
    }
}