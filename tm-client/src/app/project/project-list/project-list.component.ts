import { Component, OnInit } from '@angular/core';
import { ProjectServiceService } from '../project-service.service';
import { IProject } from 'src/app/_models/IProject';
import { MatDialog } from '@angular/material/dialog';
import { ProjectFormComponent } from '../project-form/project-form.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  projects: any;
  PROJECTS: IProject[] = [
    { Id: 1, name: 'Project A', numberOfTasks: 5 },
    { Id: 2, name: 'Project B', numberOfTasks: 10 },
    { Id: 3, name: 'Project C', numberOfTasks: 3 },
    
  ];

  displayedColumns: string[] = ['name', 'numberOfTasks', 'actions'];
  
  clickedRows = new Set<IProject>();

  constructor(private projectService: ProjectServiceService, private dialog: MatDialog, private router: Router) { }

  ngOnInit(): void {
    
  }

  createProject(): void {
    const dialogRef = this.dialog.open(ProjectFormComponent, {
      width: '400px',
      data: {} // You can pass initial data to the form if needed
    });
  
    dialogRef.afterClosed().subscribe((result: IProject) => {
      if (result) {
        /*
         this.projectService.createProject(result).subscribe(
          (response) => {
            // Handle successful response
            console.log('Project created:', response);
            // Refresh the project list if necessary
            this.getProjects();
          },
          (error) => {
            // Handle error
            console.error('Error creating project:', error);
          }
          
        );
        */
      }
    });
  }

  editProject(element: IProject) {
    const dialogRef = this.dialog.open(ProjectFormComponent, {
      width: '400px',
      data: { ...element } 
    });
  
    dialogRef.afterClosed().subscribe(result => {
      
      if (result) {
        
        console.log(result);
      }
    });
  }

  viewProjectTasks(element: IProject) {
    console.log('', element.Id)
    this.router.navigate(['/tasks', element.Id]);
  }

  getProjects() {
    this.projectService.getProjects().subscribe(
      (data) => {
        this.projects = data;
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }

}
