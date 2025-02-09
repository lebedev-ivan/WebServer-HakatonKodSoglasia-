using System.ComponentModel.DataAnnotations;

namespace WebServer.Models // Убедитесь, что пространство имен соответствует вашему проекту
{
    public class Project
    {
        [Key]
        public string PortfolioYear { get; set; }
        public string Status { get; set; }
        public string Code { get; set; }
        public string ProjectName { get; set; }
        public string Stage { get; set; }
        public string Priority { get; set; }
        public string PostProjectMonitoring { get; set; }
        public string ActivityDirection { get; set; }
        public string Category { get; set; }
        public string Program { get; set; }
        public string StrategyAffiliation { get; set; }
        public string RgT { get; set; }
        public string ShortDescription { get; set; }
        public string Dependencies { get; set; }
        public string RealizationPercentage { get; set; }
        public string OverallStatus { get; set; }
        public string BusinessGoals { get; set; }
        public string Timelines { get; set; }
        public string Budget { get; set; }
        public string Content { get; set; }
        public string ReportLink { get; set; }
        public string Customer { get; set; }
        public string Mpi { get; set; }
        public string ProjectManager { get; set; }
        public string TeamLead { get; set; }
        public string BusinessAnalyst { get; set; }
        public string UkComposition { get; set; }
        public string InterestedDepartments { get; set; }
        public string ExternalPersons { get; set; }
        public string ProgramManager { get; set; }
        public string Cfo { get; set; } // ЦФО
        public string BusinessLines { get; set; } // Линии бизнеса
        public string StartPP { get; set; } // Начало ПП
        public string CurrentCompletionPP { get; set; } // Текущее/фактическое завершение ПП
        public string DurationMonths { get; set; } // Длительность (мес)
        public string CompletionApplicationPP { get; set; } // Завершение по заявке на ПП
        public string DeviationApplicationDays { get; set; } // Отклонение от заявки (дней)
        public string Start { get; set; } // Начало
        public string Completion { get; set; } // Завершение
        public string DurationMonths2 { get; set; } // Длительность (мес)
        public string Start2 { get; set; } // Начало
        public string Completion2 { get; set; } // Завершение
        public string DeviationDays { get; set; } // Отклонение (дней)
        public string CompletionPassport { get; set; } // Завершение по паспорту
        public string DeviationPassportDays { get; set; } // Отклонение от паспорта (дней)
        public string StartYear { get; set; } // Год начала реализации
        public string CompletionYear { get; set; } // Год завершения
        public string Profitability { get; set; } // Доходность
        public string CapexExternal { get; set; } // CAPEX (внешний)
        public string FotCapex { get; set; } // ФОТ (внешний)
        public string Opex { get; set; } // OPEX
        public string ActualCapexExternal { get; set; } // Фактический CAPEX (внешний)
        public string DeltaPercentage { get; set; } // Δ %
        public string CapexExternal2 { get; set; } // CAPEX (внешний)
        public string FotCapex2 { get; set; } // ФОТ (capex)
        public string Opex2 { get; set; } // OPEX
        public string DeltaCapexExternal { get; set; } // Δ CAPEX (внешний)
        public string DeltaPercentage2 { get; set; } // Δ %
        public string CapexExternal3 { get; set; } // CAPEX (внешний)
        public string FotCapex3 { get; set; } // ФОТ (capex)
        public string Opex3 { get; set; } // OPEX
        public string DeltaCapexExternal2 { get; set; } // Δ CAPEX (внешний)
        public string DeltaPercentage3 { get; set; } // Δ %
        public string DecisionStartPreProject { get; set; } // Решение о начале предпроекта
        public string DecisionStartImplementation { get; set; } // Решение о начале реализации
        public string Timelines2 { get; set; } // Сроки
        public string ReasonZNI_S { get; set; } // Причина ЗНИ Сроки
        public string Budget2 { get; set; } // Бюджет
        public string ReasonZNI_B { get; set; } // Причина ЗНИ Бюджет
        public string Content2 { get; set; } // Содержание
        public string ReasonZNI_C { get; set; } // Причина ЗНИ Содержание
        public string Conclusion { get; set; } // Заключение
        public string Creator { get; set; } // Создатель
        public string Comment { get; set; } // Комментарий
        public string Responsibility { get; set; } // Ответственность
        public string DecisionCompletionClosure { get; set; } // Последнее изменение
        public string ReasonSuspension { get; set; }  // Причина приостановки
        public string ReasonClosureCancellation { get; set; }  // Причина закрытия (отмены)
        public string ImplementationCriteria { get; set; }  // Критерии реализации
        public string ProjectProduct { get; set; }  // Продукт проекта
        public string GoalsStatus { get; set; }  // Статус целей
        public string ProjectBusinessGoals { get; set; }  // Бизнес-цели проекта
        public string AchievementCriteria { get; set; }  // Критерии достижения
        public string BusinessGoalsStatus { get; set; }  // Статус бизнес-целей
        public string MonitoringSign { get; set; }  // Признак мониторинга
        public string MonitoringStatus { get; set; } // Статус мониторинга
        public string YearMonitoringStatus { get; set; }
        public string Product24 { get; set; }
        public string MenegerProduct24 { get; set; }
        public string Haracter { get; set; }
        public string ShortName { get; set; } // Краткое наименование
    }
}
