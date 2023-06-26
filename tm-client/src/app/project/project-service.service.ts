import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProject } from '../_models/IProject';

@Injectable({
  providedIn: 'root'
})
export class ProjectServiceService {
  apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  public getProjects(): Observable<any> {
    return this.http.get<any>(`${this.apiUrl}/projects`);
  }

  createProject(project: IProject): Observable<IProject> {
    return this.http.post<IProject>(`${this.apiUrl}/projects`, project);
  }
}
