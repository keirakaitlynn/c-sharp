using Microsoft.EntityFrameworkCore;

namespace TodoApi.Models
{
    public class TodoContextKW : DbContext
    {
        public TodoContextKW(DbContextOptions<TodoContextKW> options)
            : base(options)
        {
        }

        public DbSet<TodoItemKW> TodoItems { get; set; }
    }
}