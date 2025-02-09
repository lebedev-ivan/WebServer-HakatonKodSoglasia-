using Aspose.Cells;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.IO;
using WebServer.Models;
using System.Text;
using SkiaSharp;

namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        // Этот метод обрабатывает GET запрос для скачивания файла
        [HttpGet("download")]
        public IActionResult Download()
        {
            // Указываем путь к файлу
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Hakaton", "Пример базового файла.xlsx");

            // Проверяем, существует ли файл
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Возвращаем 404, если файл не найден
            }

            // Читаем содержимое файла
            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            // Возвращаем файл как ответ
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Пример базового файла.xlsx");
        }
    }

    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly string _excelFilePath = "D:\\projects\\WebServer\\wwwroot\\Hakaton\\Пример базового файла.xlsx"; // Укажите путь к файлу на компьютере

        [HttpPost("updateexcel")]
        public IActionResult UpdateExcel([FromForm] Project project)
        {
            if (project == null)
            {
                return BadRequest("Данные проекта не были получены.");
            }

            try
            {
                // Загружаем Excel файл
                Workbook workbook = new Workbook(_excelFilePath);
                Worksheet worksheet = workbook.Worksheets["Базовый Файл"];

                if (worksheet == null)
                {
                    return NotFound("Такого листа не существует.");
                }

                // Находим первую пустую строку, начиная с 4
                int firstEmptyRow = FindFirstEmptyRow(worksheet);

                // Заполняем данные в первой пустой строке
                worksheet.Cells[$"A{firstEmptyRow}"].PutValue(project.PortfolioYear);             // Портфель года
                worksheet.Cells[$"B{firstEmptyRow}"].PutValue(project.Status);                   // Статус
                worksheet.Cells[$"C{firstEmptyRow}"].PutValue(project.Code);                     // Код
                worksheet.Cells[$"D{firstEmptyRow}"].PutValue(project.ProjectName);              // Название проекта
                worksheet.Cells[$"E{firstEmptyRow}"].PutValue(project.Stage);                    // Этап
                worksheet.Cells[$"F{firstEmptyRow}"].PutValue(project.Priority);                 // Приоритет
                worksheet.Cells[$"G{firstEmptyRow}"].PutValue(project.PostProjectMonitoring);    // Постпроектный мониторинг
                worksheet.Cells[$"H{firstEmptyRow}"].PutValue(project.ActivityDirection);        // Направление деятельности
                worksheet.Cells[$"I{firstEmptyRow}"].PutValue(project.Category);                 // Категория
                worksheet.Cells[$"J{firstEmptyRow}"].PutValue(project.Program);                  // Программа
                worksheet.Cells[$"K{firstEmptyRow}"].PutValue(project.StrategyAffiliation);       // Принадлежность к Стратегии
                worksheet.Cells[$"L{firstEmptyRow}"].PutValue(project.RgT);                      // R/G/T
                worksheet.Cells[$"M{firstEmptyRow}"].PutValue(project.ShortDescription);         // Краткое описание
                worksheet.Cells[$"N{firstEmptyRow}"].PutValue(project.Dependencies);             // Зависимости
                worksheet.Cells[$"O{firstEmptyRow}"].PutValue(project.RealizationPercentage);     // % реализации
                worksheet.Cells[$"P{firstEmptyRow}"].PutValue(project.OverallStatus);            // Общий статус
                worksheet.Cells[$"Q{firstEmptyRow}"].PutValue(project.BusinessGoals);            // Бизнес-цели
                worksheet.Cells[$"R{firstEmptyRow}"].PutValue(project.Timelines);                // Сроки
                worksheet.Cells[$"S{firstEmptyRow}"].PutValue(project.Budget);                   // Бюджет
                worksheet.Cells[$"T{firstEmptyRow}"].PutValue(project.Content);                  // Содержание
                worksheet.Cells[$"U{firstEmptyRow}"].PutValue(project.ReportLink);               // Ссылка на отчет
                worksheet.Cells[$"V{firstEmptyRow}"].PutValue(project.Customer);                 // Заказчик
                worksheet.Cells[$"W{firstEmptyRow}"].PutValue(project.Mpi);                      // МпИ
                worksheet.Cells[$"X{firstEmptyRow}"].PutValue(project.ProjectManager);           // Руководитель проекта
                worksheet.Cells[$"Y{firstEmptyRow}"].PutValue(project.TeamLead);                 // Тимлид
                worksheet.Cells[$"Z{firstEmptyRow}"].PutValue(project.BusinessAnalyst);          // Бизнес-аналитик
                worksheet.Cells[$"AA{firstEmptyRow}"].PutValue(project.UkComposition);            // Состав УК
                worksheet.Cells[$"AB{firstEmptyRow}"].PutValue(project.InterestedDepartments);    // Заинтересованные подразделения
                worksheet.Cells[$"AC{firstEmptyRow}"].PutValue(project.ExternalPersons);          // Внешние лица
                worksheet.Cells[$"AD{firstEmptyRow}"].PutValue(project.ProgramManager);           // Руководитель программы
                worksheet.Cells[$"AF{firstEmptyRow}"].PutValue(project.Cfo);                      // ЦФО
                worksheet.Cells[$"AG{firstEmptyRow}"].PutValue(project.BusinessLines);            // Линии бизнеса
                worksheet.Cells[$"AH{firstEmptyRow}"].PutValue(project.StartPP);                  // Начало ПП
                worksheet.Cells[$"AI{firstEmptyRow}"].PutValue(project.CurrentCompletionPP);      // Текущее/фактическое завершение ПП
                worksheet.Cells[$"AJ{firstEmptyRow}"].PutValue(project.DurationMonths);           // Длительность (мес)
                worksheet.Cells[$"AK{firstEmptyRow}"].PutValue(project.CompletionApplicationPP);  // Завершение по заявке на ПП
                worksheet.Cells[$"AL{firstEmptyRow}"].PutValue(project.DeviationApplicationDays); // Отклонение от заявки (дней)
                worksheet.Cells[$"AM{firstEmptyRow}"].PutValue(project.Start);                     // Начало
                worksheet.Cells[$"AN{firstEmptyRow}"].PutValue(project.Completion);                // Завершение
                worksheet.Cells[$"AO{firstEmptyRow}"].PutValue(project.DurationMonths2);           // Длительность (мес)
                worksheet.Cells[$"AP{firstEmptyRow}"].PutValue(project.Start2);                   // Начало
                worksheet.Cells[$"AQ{firstEmptyRow}"].PutValue(project.Completion2);               // Завершение
                worksheet.Cells[$"AR{firstEmptyRow}"].PutValue(project.DeviationDays);             // Отклонение (дней)
                worksheet.Cells[$"AS{firstEmptyRow}"].PutValue(project.CompletionPassport);        // Завершение по паспорту
                worksheet.Cells[$"AT{firstEmptyRow}"].PutValue(project.DeviationPassportDays);    // Отклонение от паспорта (дней)
                worksheet.Cells[$"AU{firstEmptyRow}"].PutValue(project.StartYear);                // Год начала реализации
                worksheet.Cells[$"AV{firstEmptyRow}"].PutValue(project.CompletionYear);            // Год завершения
                worksheet.Cells[$"AW{firstEmptyRow}"].PutValue(project.Profitability);            // Доходность
                worksheet.Cells[$"AX{firstEmptyRow}"].PutValue(project.CapexExternal);            // CAPEX (внешний)
                worksheet.Cells[$"AY{firstEmptyRow}"].PutValue(project.FotCapex);                 // ФОТ (внешний)
                worksheet.Cells[$"AZ{firstEmptyRow}"].PutValue(project.Opex);                     // OPEX
                worksheet.Cells[$"BA{firstEmptyRow}"].PutValue(project.ActualCapexExternal);      // Фактический CAPEX (внешний)
                worksheet.Cells[$"BB{firstEmptyRow}"].PutValue(project.DeltaPercentage);          // Δ %
                worksheet.Cells[$"BC{firstEmptyRow}"].PutValue(project.CapexExternal2);           // CAPEX (внешний)
                worksheet.Cells[$"BD{firstEmptyRow}"].PutValue(project.FotCapex2);                // ФОТ (capex)
                worksheet.Cells[$"BE{firstEmptyRow}"].PutValue(project.Opex2);                    // OPEX
                worksheet.Cells[$"BF{firstEmptyRow}"].PutValue(project.DeltaCapexExternal);       // Δ CAPEX (внешний)
                worksheet.Cells[$"BG{firstEmptyRow}"].PutValue(project.DeltaPercentage2);         // Δ %
                worksheet.Cells[$"BH{firstEmptyRow}"].PutValue(project.CapexExternal3);           // CAPEX (внешний)
                worksheet.Cells[$"BI{firstEmptyRow}"].PutValue(project.FotCapex3);                // ФОТ (capex)
                worksheet.Cells[$"BJ{firstEmptyRow}"].PutValue(project.Opex3);                    // OPEX
                worksheet.Cells[$"BK{firstEmptyRow}"].PutValue(project.DeltaCapexExternal2);      // Δ CAPEX (внешний)
                worksheet.Cells[$"BL{firstEmptyRow}"].PutValue(project.DeltaPercentage3);         // Δ %
                worksheet.Cells[$"BM{firstEmptyRow}"].PutValue(project.DecisionStartPreProject);   // Решение о начале предпроекта
                worksheet.Cells[$"BN{firstEmptyRow}"].PutValue(project.DecisionStartImplementation); // Решение о начале реализации
                worksheet.Cells[$"BO{firstEmptyRow}"].PutValue(project.Timelines2);              // Сроки
                worksheet.Cells[$"BP{firstEmptyRow}"].PutValue(project.ReasonZNI_S);             // Причина ЗНИ Сроки
                worksheet.Cells[$"BQ{firstEmptyRow}"].PutValue(project.Budget2);                // Бюджет
                worksheet.Cells[$"BR{firstEmptyRow}"].PutValue(project.ReasonZNI_B);            // Причина ЗНИ Бюджет
                worksheet.Cells[$"BS{firstEmptyRow}"].PutValue(project.Content2);               // Содержание
                worksheet.Cells[$"BT{firstEmptyRow}"].PutValue(project.ReasonZNI_C);            // Причина ЗНИ Содержание
                worksheet.Cells[$"BU{firstEmptyRow}"].PutValue(project.Conclusion);             // Заключение
                worksheet.Cells[$"BV{firstEmptyRow}"].PutValue(project.Creator);                // Создатель
                worksheet.Cells[$"BW{firstEmptyRow}"].PutValue(project.Comment);                // Комментарий
                worksheet.Cells[$"BX{firstEmptyRow}"].PutValue(project.Responsibility);         // Ответственность
                worksheet.Cells[$"BY{firstEmptyRow}"].PutValue(project.DecisionCompletionClosure); // Решение о завершении / закрытии
                worksheet.Cells[$"BZ{firstEmptyRow}"].PutValue(project.ReasonSuspension);       // Причина приостановки
                worksheet.Cells[$"CA{firstEmptyRow}"].PutValue(project.ReasonClosureCancellation); // Причина закрытия (отмены)
                worksheet.Cells[$"CB{firstEmptyRow}"].PutValue(project.ImplementationCriteria);  // Критерии реализации
                worksheet.Cells[$"CC{firstEmptyRow}"].PutValue(project.ProjectProduct);         // Продукт проекта
                worksheet.Cells[$"CD{firstEmptyRow}"].PutValue(project.GoalsStatus);            // Статус целей
                worksheet.Cells[$"CE{firstEmptyRow}"].PutValue(project.ProjectBusinessGoals);   // Бизнес-цели проекта
                worksheet.Cells[$"CF{firstEmptyRow}"].PutValue(project.AchievementCriteria);    // Критерии достижения
                worksheet.Cells[$"CG{firstEmptyRow}"].PutValue(project.BusinessGoalsStatus);    // Статус бизнес-целей
                worksheet.Cells[$"CH{firstEmptyRow}"].PutValue(project.MonitoringSign);         // Признак мониторинга
                worksheet.Cells[$"CI{firstEmptyRow}"].PutValue(project.MonitoringStatus);       // Статус мониторинга
                worksheet.Cells[$"CJ{firstEmptyRow}"].PutValue(project.YearMonitoringStatus);
                worksheet.Cells[$"CK{firstEmptyRow}"].PutValue(project.Product24);
                worksheet.Cells[$"CL{firstEmptyRow}"].PutValue(project.MenegerProduct24);
                worksheet.Cells[$"CM{firstEmptyRow}"].PutValue(project.Haracter);
                worksheet.Cells[$"CN{firstEmptyRow}"].PutValue(project.ShortName);              // Краткое наименование

                // Сохраняем изменения в файл
                workbook.Save(_excelFilePath);

                return Ok("Данные проекта успешно обновлены.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ошибка при обновлении Excel файла: {ex.Message}");
            }
        }

        private int FindFirstEmptyRow(Worksheet worksheet)
        {
            int row = 4; // Начинаем с 4 строки
            while (worksheet.Cells[$"A{row}"].Value != null && !string.IsNullOrWhiteSpace(worksheet.Cells[$"A{row}"].StringValue))
            {
                row++;
            }
            return row;
        }
    }
}

