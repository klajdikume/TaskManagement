import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { IProject } from '../../_models/IProject';

@Component({
  selector: 'app-project-form',
  templateUrl: './project-form.component.html',
  styleUrls: ['./project-form.component.css']
})
export class ProjectFormComponent implements OnInit {

  projectForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<ProjectFormComponent>,
    @Inject(MAT_DIALOG_DATA) public data: IProject,
    private formBuilder: FormBuilder
  ) {
    this.projectForm = this.formBuilder.group({
      name: [data.name, Validators.required]
    });
  }

  ngOnInit(): void {
    
  }

  onSave(): void {
    if (this.projectForm.valid) {
      const updatedProject: IProject = {
        ...this.data,
        name: this.projectForm.value.name,
        numberOfTasks: this.projectForm.value.numberOfTasks
      };
      this.dialogRef.close(updatedProject);
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }

}
