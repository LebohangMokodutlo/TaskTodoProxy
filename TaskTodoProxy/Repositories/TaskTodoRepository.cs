using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTodoProxy.Data;
using TaskTodoProxy.Entities;

namespace TaskTodoProxy.Repositories
{
    public class TaskTodoRepository
    {
        private readonly DataContext _dataContext;

        public TaskTodoRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TaskTodo>> GetAllTasks()
        {
            return await _dataContext.TaskTodoTable.ToListAsync();
        }

        public async Task<TaskTodo> GetTaskById(int id)
        {
            return await _dataContext.TaskTodoTable.FindAsync(id);
        }

        public async Task CreateTask(TaskTodo task)
        {
            _dataContext.TaskTodoTable.Add(task);
            await SaveChangesAsync();
        }

        public async Task UpdateTask(int id, TaskTodo updatedTask)
        {
            var existingTask = await _dataContext.TaskTodoTable.FindAsync(id);
            if (existingTask != null)
            {
                existingTask.Department = updatedTask.Department;
                existingTask.Title = updatedTask.Title;
                existingTask.Description = updatedTask.Description;
                existingTask.ClientUrl = updatedTask.ClientUrl;
                existingTask.ClientBudget = updatedTask.ClientBudget;
                existingTask.TaskStatus = updatedTask.TaskStatus;
                existingTask.Deadline = updatedTask.Deadline;
                existingTask.Priority = updatedTask.Priority;

                await SaveChangesAsync();
            }
        }

        public async Task DeleteTask(int id)
        {
            var dbTask = await _dataContext.TaskTodoTable.FindAsync(id);
            if (dbTask != null)
            {
                _dataContext.TaskTodoTable.Remove(dbTask);
                await SaveChangesAsync();
            }
        }

        private async Task SaveChangesAsync()
        {
            await _dataContext.SaveChangesAsync();
        }
    }
}
