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

        public async Task<ActionResult<TaskTodo>> UpdateTaskTodo(TaskTodo updatedTaskTodo)
        {
            var dbTask = await _dataContext.TaskTodoTable.FindAsync(updatedTaskTodo.Id);
            if (dbTask == null)
            {
                return BadRequest("Task not found");
            }

            dbTask.Department = updatedTaskTodo.Department;
            dbTask.Title = updatedTaskTodo.Title;
            dbTask.Description = updatedTaskTodo.Description = updatedTaskTodo.Title;

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.TaskTodoTable.ToListAsync());
        }

    }
}
