import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Status, Priority, ITask } from '../../_models/TaskModels/Task';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TaskService } from '../task.service';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {
  taskForm!: FormGroup;
  task!: ITask;
  
  statusOptions: { value: number, label: string }[] = [
    { value: Status.Todo, label: 'Todo' },
    { value: Status.InProgress, label: 'In Progress' },
    { value: Status.InTest, label: 'In Test' },
    { value: Status.Done, label: 'Done' }
  ];

  priorityOptions: { value: number, label: string }[] = [
    { value: Priority.Low, label: 'Low' },
    { value: Priority.Medium, label: 'Medium' },
    { value: Priority.High, label: 'High' },
    { value: Priority.Highest, label: 'Highest' }
  ];

  projects: { id: number, name: string }[] = [
    { id: 1, name: 'Project 1' },
    { id: 2, name: 'Project 2' },
    { id: 3, name: 'Project 3' }
  ];

  users: { id: number, name: string }[] = [
    { id: 1, name: 'User 1' },
    { id: 2, name: 'User 2' },
    { id: 3, name: 'User 3' }
  ];

  constructor(
    public dialogRef: MatDialogRef<TaskFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private formBuilder: FormBuilder,
    public taskService: TaskService
  ) { }

   ngOnInit(): void {
    this.initializeForm();
    
  }

  initializeForm(): void {
    const task = this.data; 

    console.log(task);

    this.taskForm = this.formBuilder.group({
      title: [task?.title || '', Validators.required],
      description: [task?.description || ''],
      status: [task?.status || ''],
      priority: [task?.priority || ''],
      startDate: [task?.startDate || '', Validators.required],
      dueDate: [task?.dueDate || '']
    }, {
      validators: [this.validateDateRange('startDate', 'dueDate')]
    });
  }

  validateDateRange(startDateKey: string, dueDateKey: string) {
    return (group: FormGroup) => {
      const startDate = group.controls['startDate'];
      const dueDate = group.controls['dueDate'];

      if (startDate.value && dueDate.value && startDate.value > dueDate.value) {
        dueDate.setErrors({ dateRange: true });
      } else {
        dueDate.setErrors(null);
      }
    };
  }

  updateTask(): void {
    if (this.taskForm.invalid) {
      return;
    }

    this.task.title = this.taskForm.value.title;
    this.task.description = this.taskForm.value.description;
    this.task.userId = this.taskForm.value.userId;
    this.task.projectId = this.taskForm.value.projectId;
    this.task.priority = this.taskForm.value.priority;
    this.task.status = this.taskForm.value.status;
    this.task.startDate = this.taskForm.value.startDate;
    this.task.dueDate = this.taskForm.value.dueDate;

    this.taskService.updateTask(this.task).subscribe(() => {
      
      this.dialogRef.close();
    }, (error) => {
      
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

}
