﻿using Microsoft.EntityFrameworkCore;
using MVCStartApp.Models.DB;
using System.Collections.Generic;

namespace MVCStartApp.Controllers
{
    /// <summary>
    /// Класс контекста, предоставляющий доступ к сущностям базы данных
    /// </summary>
    public sealed class BlogContext : DbContext
    {
        // Ссылка на таблицу Users
        public DbSet<User> Users { get; set; }

        // Ссылка на таблицу UserPosts
        public DbSet<UserPost> UserPosts { get; set; }

        // Ссылка на таблицу Requests
        public DbSet<Request> Requests { get; set; }

        // Логика взаимодействия с таблицами в БД
        public BlogContext(DbContextOptions<BlogContext> options) : base(options)
        {                       
            Database.EnsureCreated();            
        }
    }
}
