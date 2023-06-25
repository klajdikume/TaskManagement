import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProjectListComponent } from './product-list/project-list.component';
import { ProjectServiceService } from './project-service.service';


@NgModule({
  declarations: [
    ProjectListComponent
  ],
  imports: [
    CommonModule
  ],
  providers: [
    ProjectServiceService
  ]
})
export class ProductModule { }
