using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTodoProxy.Dto;
using TaskTodoProxy.Entities;
using TaskTodoProxy.Repositories;

namespace TaskTodoProxy.Services
{
    public class TaskTodoService
    {
        private readonly TaskTodoRepository _repository;

        public TaskTodoService(TaskTodoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TaskTodo>> GetAllTasks()
        {
            return await _repository.GetAllTasks();
        }

        public async Task<TaskTodo> GetTaskById(int id)
        {
            return await _repository.GetTaskById(id);
        }

        public async Task CreateTask(TaskTodoDto taskDto)
        {
            var task = MapDtoToEntity(taskDto);
            await _repository.CreateTask(task);
        }

        public async Task<TaskTodo> UpdateTask(int id, TaskTodoDto updatedTaskDto)
        {
            var existingTask = await _repository.GetTaskById(id);

            if (existingTask == null)
            {
                return null;
            }

            // Update existingTask properties based on updatedTaskDto
            existingTask.Department = updatedTaskDto.Department;
            existingTask.Title = updatedTaskDto.Title;
            existingTask.TaskStatus = updatedTaskDto.TaskStatus;
            existingTask.Description = updatedTaskDto.Description;
            existingTask.ClientUrl = updatedTaskDto.ClientUrl;
            existingTask.ClientBudget = updatedTaskDto.ClientBudget;
            existingTask.Deadline = updatedTaskDto.Deadline;
            existingTask.Priority = updatedTaskDto.Priority;

            await _repository.UpdateTask(id, existingTask);

            return existingTask;
        }

        public async Task DeleteTask(int id)
        {
            await _repository.DeleteTask(id);
        }

        private TaskTodo MapDtoToEntity(TaskTodoDto dto)
        {
            return new TaskTodo
            {
                Department = dto.Department,
                Title = dto.Title,
                TaskStatus = dto.TaskStatus,
                Description = dto.Description,
                ClientUrl = dto.ClientUrl,
                ClientBudget = dto.ClientBudget,
                Deadline = dto.Deadline,
                Priority = dto.Priority
            };
        }
    }
}
