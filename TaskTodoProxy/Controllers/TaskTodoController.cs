using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskTodoProxy.Data;
using TaskTodoProxy.Entities;

namespace TaskTodoProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTodoController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public TaskTodoController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }


        [HttpGet]

        public async Task<ActionResult<TaskTodo>> GetAllTaskTodo()
        {
            var tasks = await _dataContext.TaskTodoTable.ToListAsync();
        return Ok(tasks);
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<List<TaskTodo>>> GetTaskTodoById(int id)
        {
            var task = await _dataContext.TaskTodoTable.FindAsync(id);
            if(task == null)
            {
                return BadRequest("Task not found");    
            }

            return Ok(task);
        }

        [HttpPost]

        public async Task<ActionResult<List<TaskTodo>>> CreateTaskTodo(TaskTodo task)
        {
            _dataContext.TaskTodoTable.Add(task);
            await _dataContext.SaveChangesAsync();


            return Ok(await _dataContext.TaskTodoTable.ToListAsync());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskTodo(int id, [FromBody] TaskTodo updatedTask)
        {
            var existingTask = await _dataContext.TaskTodoTable.FindAsync(id);
            if (existingTask == null)
            {
                return BadRequest("Task not found");
            }

            existingTask.Department = updatedTask.Department;
            existingTask.Title = updatedTask.Title;
            existingTask.Description = updatedTask.Description;
            existingTask.ClientUrl = updatedTask.ClientUrl;
            existingTask.ClientBudget = updatedTask.ClientBudget;
            existingTask.Deadline = updatedTask.Deadline;
            existingTask.Priority = updatedTask.Priority;

            await _dataContext.SaveChangesAsync();

            return Ok(existingTask);
        }

        [HttpDelete]

        public async Task<ActionResult<List<TaskTodo>>> DeleteTaskTodo(int id)
        {
           var  dbTask = await _dataContext.TaskTodoTable.FindAsync(id);

            if (dbTask == null)
            {
                return BadRequest("Task not found");
            }
            _dataContext.TaskTodoTable.Remove(dbTask);
            await _dataContext.SaveChangesAsync();


            return Ok(await _dataContext.TaskTodoTable.ToListAsync());
        }

    }
}
