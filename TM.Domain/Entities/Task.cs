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

        public Task(TaskId taskId, ProjectId projectId, UserId userId, string title, DateTime startDate, string description)
        {
            TaskId = taskId;
            ProjectId = projectId;
            UserId = userId;
            Title = title;
            StartDate = startDate;
            Description = description;
        }

        public Task(TaskId taskId, string title) 
        {
            TaskId = taskId;
            Title = title;
        }

        public static Task Create(string title)
        {
            var task = new Task(new TaskId(Guid.NewGuid()), title);

            return task;
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
