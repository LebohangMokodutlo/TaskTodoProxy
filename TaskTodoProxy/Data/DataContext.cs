using Microsoft.EntityFrameworkCore;
using TaskTodoProxy.Entities;

namespace TaskTodoProxy.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<TaskTodo> TaskTodoTable { get; set; }
    }
}
