import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ProjectDTO } from '../_models/TaskModels/ProjectDTO';
import { ITask } from '../_models/TaskModels/Task';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  apiUrl = environment.apiUrl;
  
  constructor(private http: HttpClient) { }

  getTasksByProjectId(projectId: number): Observable<ProjectDTO> {
    const url = `${this.apiUrl}/tasks/${projectId}`;
    return this.http.get<ProjectDTO>(url);
  }

  getAllTasksWithoutProject() : Observable<ITask> {
    const url = `${this.apiUrl}/tasks`;
    return this.http.get<ITask>(url);
  }

  updateTask(task: ITask): Observable<void> {
    const url = `${this.apiUrl}/tasks`;
    return this.http.patch<void>(url, { task });
  }

}
