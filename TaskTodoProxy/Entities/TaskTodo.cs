using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskTodoProxy.Entities
{
    public class TaskTodo
    {
        public int Id { get; set; }
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateOnly Deadline { get; set; }
        public string Priority { get; set; }
        public string TaskStatus { get; set; }
        public string ClientUrl { get; set; }
        public string ClientBudget { get; set; }

    }
}
