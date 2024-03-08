namespace TaskTodoProxy.Dto
{
    public class TaskTodoDto
    {
        public string Department { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public string Priority { get; set; }
        public string TaskStatus { get; set; }
        public string ClientUrl { get; set; }
        public string ClientBudget { get; set; }
    }
}

