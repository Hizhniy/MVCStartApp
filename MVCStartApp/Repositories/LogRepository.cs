using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.DB;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using MVCStartApp.Controllers;

namespace MVCStartApp.Repositories
{
    public class LogRepository : ILogRepository
    {
        // ссылка на контекст
        private readonly BlogContext _context;

        // Метод-конструктор для инициализации
        public LogRepository(BlogContext context)
        {
            _context = context;
        }

        public async Task AddLog(Request request)
        {
            // Добавление реквеста-лога в таблицу БД
            var entry = _context.Entry(request);
            if (entry.State == EntityState.Detached)
                await _context.Requests.AddAsync(request);

            // Сохранение изенений
            await _context.SaveChangesAsync();
        }

        public async Task<Request[]> GetLogs()
        {
            // Получим все логи
            return await _context.Requests.ToArrayAsync();
        }
    }
}
