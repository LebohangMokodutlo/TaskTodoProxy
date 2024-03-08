using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TaskTodoProxy.Dto;
using TaskTodoProxy.Entities;
using TaskTodoProxy.Services;

namespace TaskTodoProxy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskTodoController : ControllerBase
    {
        private readonly TaskTodoService _taskTodoService;

        public TaskTodoController(TaskTodoService taskTodoService)
        {
            _taskTodoService = taskTodoService;
        }

        [HttpGet]
        public async Task<ActionResult<TaskTodo>> GetAllTaskTodo()
        {
            var tasks = await _taskTodoService.GetAllTasks();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TaskTodo>>> GetTaskTodoById(int id)
        {
            var task = await _taskTodoService.GetTaskById(id);
            if (task == null)
            {
                return BadRequest("Task not found");
            }

            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<List<TaskTodo>>> CreateTaskTodo(TaskTodoDto taskDto)
        {
            await _taskTodoService.CreateTask(taskDto);
            return Ok(await _taskTodoService.GetAllTasks());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TaskTodo>> UpdateTaskTodo(int id, [FromBody] TaskTodoDto updatedTaskDto)
        {
            var updatedTask = await _taskTodoService.UpdateTask(id, updatedTaskDto);

            if (updatedTask == null)
            {
                return BadRequest("Task not found");
            }

            return Ok(updatedTask);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<List<TaskTodo>>> DeleteTaskTodo(int id)
        {

            var taskExists = await _taskTodoService.GetTaskById(id);
            if (taskExists == null)
            {
                return NotFound($"Task with id {id} not found.");
            }
            await _taskTodoService.DeleteTask(id);
            return Ok(await _taskTodoService.GetAllTasks());
        }
    }
}
