using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Primitives;

namespace TM.Domain.Entities
{
    public class Project
    {
        public Project()
        {

        }
        public Project(ProjectId projectId)
        {
            Id = projectId;
        }

        
        public ProjectId Id { get; set; } 
        public string Name { get; set; }  = string.Empty;
       
        private readonly List<Task> _tasks = new();

        public IReadOnlyList<Task> Tasks => _tasks.ToList();

        public static Project Create(string name)
        {
            var project = new Project
            {
                Id = new ProjectId(Guid.NewGuid()),
                Name = name
            };

            return project;
        }

        public void Add(Task task)
        {
            var newTask = new Task(
                new TaskId(Guid.NewGuid()), 
                Id, 
                new UserId(Guid.NewGuid()), 
                task.Title, 
                task.StartDate,
                task.Description);

            _tasks.Add(newTask);
        }

        public void RemoveTask(TaskId taskId)
        {
            var task = _tasks.FirstOrDefault(t => t.TaskId == taskId);

            if (task is null)
                return;

            _tasks.Remove(task);
        }
    }

    public record ProjectId(Guid Id);
}
