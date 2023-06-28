import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ITask, Priority, Status } from 'src/app/_models/TaskModels/Task';
import { TaskService } from '../task.service';
import { MatTableDataSource } from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { TaskFormComponent } from '../task-form/task-form.component';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {
  dataSource!: MatTableDataSource<ITask>;
  displayedColumns: string[] = ['title', 'description', 'status', 'priority', 'actions'];

  tasks: ITask[] = [];

  projectId: number | undefined;

  constructor(
    private route: ActivatedRoute,
    private taskService: TaskService,
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.getRouteId();
  }

  getRouteId() {
    this.route.params.subscribe(params => {
       const projectId = params['Id'];

      if (projectId) {
        this.projectId = +projectId;
        this.getTasksByProjectId(this.projectId);
      }
      else if(projectId === undefined || projectId === null){
        this.getAllTasksWithoutProject();
      } 
    });
  }
  

  createNewTask(): void {
    const dialogRef = this.dialog.open(TaskFormComponent, {
      width: '500px',
      data: {
        task: null, // Initialize with null or default values
        projectId: null,
        assignTo: null,
        priority: null,
        startDate: null,
        dueDate: null
      }
    });
  
    dialogRef.afterClosed().subscribe((newTask: ITask | undefined) => {
      if (newTask) {
        // Handle the newly created task
      }
    });
  }

  getAllTasksWithoutProject(){
    this.tasks = [
    {
      taskId: '2',
      projectId: 'null',
      title: 'Task 2',
      description: 'Description for Task 2',
      status: Status.Todo,
      userId: null,
      startDate: '2023-06-25',
      dueDate: null,
      priority: Priority.Medium
    },
    {
      taskId: '3',
      projectId: null,
      title: 'Task 3',
      description: 'Description for Task 3',
      status: Status.Done,
      userId: 'user2',
      startDate: '2023-06-25',
      dueDate: '2023-07-05',
      priority: Priority.Low
    },
    {
      taskId: '4',
      projectId: null,
      title: 'Task 4',
      description: 'Description for Task 4',
      status: Status.InTest,
      userId: null,
      startDate: '2023-06-25',
      dueDate: '2023-07-02',
      priority: Priority.High
    }
  ];
    this.dataSource = new MatTableDataSource(this.tasks);
  }

  

  getTasksByProjectId(projectId: number) {
    // this.taskService.getTasksByProjectId(projectId).subscribe(tasks => {
    //   this.tasks = tasks;
    //   this.dataSource = new MatTableDataSource(this.tasks);
    // });
    this.tasks = [{
      taskId: '1',
      projectId: '1',
      title: 'Task 1',
      description: 'Description for Task 1',
      status: Status.InProgress,
      userId: 'user1',
      startDate: '2023-06-25',
      dueDate: '2023-06-30',
      priority: Priority.High
    },
    {
      taskId: '2',
      projectId: '2',
      title: 'Task 2',
      description: 'Description for Task 2',
      status: Status.Todo,
      userId: null,
      startDate: '2023-06-25',
      dueDate: null,
      priority: Priority.Medium
    },
    {
      taskId: '3',
      projectId: '1',
      title: 'Task 3',
      description: 'Description for Task 3',
      status: Status.Done,
      userId: 'user2',
      startDate: '2023-06-25',
      dueDate: '2023-07-05',
      priority: Priority.Low
    },
    {
      taskId: '4',
      projectId: '3',
      title: 'Task 4',
      description: 'Description for Task 4',
      status: Status.InTest,
      userId: null,
      startDate: '2023-06-25',
      dueDate: '2023-07-02',
      priority: Priority.High
    }
  ];
    this.dataSource = new MatTableDataSource(this.tasks);
  }

  editTask(task: ITask) {
    const dialogRef = this.dialog.open(TaskFormComponent, {
      width: '500px',
      data: {
        title: task.title, // Initialize with null or default values
        projectId: task.projectId,
        assignTo: task.userId,
        priority: task.priority,
        startDate: task.startDate,
        dueDate: task.dueDate,
        description: task.description
      }
    });
  
    dialogRef.afterClosed().subscribe((newTask: ITask | undefined) => {
      if (newTask) {
        // Handle the newly created task
      }
    });
  }

}
