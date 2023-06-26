import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Status, Priority } from '../../_models/TaskModels/Task';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-task-form',
  templateUrl: './task-form.component.html',
  styleUrls: ['./task-form.component.css']
})
export class TaskFormComponent implements OnInit {
  taskForm!: FormGroup;

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
    private formBuilder: FormBuilder
  ) { }

   ngOnInit(): void {
    this.initializeForm();
    
  }

  initializeForm(): void {
    this.taskForm = this.formBuilder.group({
      // Define your form controls here
      title: ['', Validators.required],
      description: [''],
      status: [''],
      priority: [''],
      startDate: [''],
      dueDate: ['']
    });
  }

  onCancel(): void {
    this.dialogRef.close();
  }

}
