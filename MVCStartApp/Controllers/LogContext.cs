using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.DB;
using System.Collections.Generic;

namespace MVCStartApp.Controllers
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class LogContext : DbContext
    {
        // Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; }

        // Логика взаимодействия с таблицами в БД
        public LogContext(DbContextOptions<LogContext> options) : base(options)
        {            
            Database.EnsureCreated();
        }        
    }
}
