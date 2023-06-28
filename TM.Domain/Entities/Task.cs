using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using TM.Domain.Primitives;
using FluentValidation;
using TM.Domain.Entities.Enums;

namespace TM.Domain.Entities
{
    public class Task
    {
        
        public TaskId TaskId { get; set; }
        public ProjectId? ProjectId { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public Status Status { get; set; }
        public UserId? UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? DueDate { get; set; }
        
        public Priority Priority { get; set; }

        public Project? Project { get; set; }
        public User? User { get; set; }

        public Task(TaskId taskId, ProjectId projectId, UserId userId, string title, DateTime startDate, string description)
        {
            TaskId = taskId;
            ProjectId = projectId;
            UserId = userId;
            Title = title;
            StartDate = startDate;
            Description = description;
        }

        public Task(TaskId taskId, ProjectId? projectId, string title, string? description, Status status, UserId? userId, DateTime startDate, DateTime? dueDate, Priority priority)
        {
            TaskId = taskId;
            ProjectId = projectId;
            Title = title;
            Description = description;
            Status = status;
            UserId = userId;
            StartDate = startDate;
            DueDate = dueDate;
            Priority = priority;
        }

        public static Task Create(Task task)
        {
            var taskCreated = new Task(
                new TaskId(Guid.NewGuid()),
                task.ProjectId,
                task.Title,
                task.Description,
                task.Status,
                task.UserId,
                task.StartDate,
                task.DueDate,
                task.Priority
                );

            return taskCreated;
        }

        public void updateTask(Task task)
        {
            
            ProjectId = task.ProjectId;
            Title = task.Title;
            Description = task.Description;
            Status = task.Status;
            UserId = task.UserId;
            StartDate = task.StartDate;
            DueDate = task.DueDate;
            Priority = task.Priority;
        }

        public void AssignToUser(UserId userId)
        {
            UserId = userId;
        }

        public void SetToProject(ProjectId projectId)
        {
            ProjectId = projectId;
        }


    }
    public record TaskId(Guid Id);
}
