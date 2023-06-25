import { Component, OnInit } from '@angular/core';
import { ProjectServiceService } from '../project-service.service';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.css']
})
export class ProjectListComponent implements OnInit {
  products: any;

  constructor(private projectService: ProjectServiceService) { }

  ngOnInit(): void {
    this.projectService.getProjects().subscribe(
      (data) => {
        this.products = data;
      },
      (error) => {
        console.error('Error:', error);
      }
    );
  }

}
