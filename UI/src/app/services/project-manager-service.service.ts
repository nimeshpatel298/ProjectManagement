import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http'

import { Observable, of, Subject} from 'rxjs'
import { map, catchError, filter, scan } from 'rxjs/operators'
import { webSocket } from 'rxjs/webSocket';
import { User } from '../models/user';
import { Project } from '../models/project';
import { Task } from '../models/task';

const endpoint = 'http://localhost:8081/api/';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ProjectManagerServiceService {

  isResponseReceived: boolean;
  serviceResponseReceived: Subject<boolean> = new Subject<boolean>();

  constructor(private http:HttpClient) { }

  getUsers(): Observable<User[]>  {
    return this.http.get<User[]>(endpoint + 'User');
  }

  getProjects(): Observable<Project[]>  {
    return this.http.get<Project[]>(endpoint + 'ProjectManager');
  }

  getParentTasks(): Observable<Task[]>  {
    return this.http.get<Task[]>(endpoint + 'ParentTask');
  }

  getTasks(): Observable<Task[]>  {
    return this.http.get<Task[]>(endpoint + 'Task');
  }

  createTask(task : Task) {
    let body = JSON.stringify(task);
    console.log(body);
    let returnObject = false;
    this.http.post(endpoint + "Task",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("POST Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("POST Error", error);
            }
        ); 
    return returnObject;
  }

  createParentTask(task : Task) {
    let body = JSON.stringify(task);
    console.log(body);
    let returnObject = false;
    this.http.post(endpoint + "ParentTask",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("POST Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("POST Error", error);
            }
        ); 
    return returnObject;
  }

  createUser(task : User) {
    let body = JSON.stringify(task);
    console.log(body);
    let returnObject = false;
    this.http.post(endpoint + "User",
        body, httpOptions)
        .subscribe(
            data => {
                
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("POST Error", error);
            }
        ); 
    return returnObject;
  }

  createProject(project : Project) {
    let body = JSON.stringify(project);
    console.log(body);
    let returnObject = false;
    this.http.post(endpoint + "ProjectManager",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("POST Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("POST Error", error);
            }
        ); 
    return returnObject;
  }

  updateParentTask(task : Task)  {
    let body = JSON.stringify(task);

    let returnObject = false;
    this.http.put(endpoint + "ParentTask",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("PUT Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("Error", error);
            }
        ); 
    return returnObject;
  }

  updateTask(task : Task)  {
    let body = JSON.stringify(task);

    let returnObject = false;
    this.http.put(endpoint + "Task",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("PUT Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("Error", error);
            }
        ); 
    return returnObject;
  }

  updateUser(task : User)  {
    let body = JSON.stringify(task);

    let returnObject = false;
    this.http.put(endpoint + "User",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("PUT Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("Error", error);
            }
        ); 
    return returnObject;
  }

  updateProject(task : Project)  {
    let body = JSON.stringify(task);

    let returnObject = false;
    this.http.put(endpoint + "ProjectManager",
        body, httpOptions)
        .subscribe(
            data => {
                console.log("PUT Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("Error", error);
            }
        ); 
    return returnObject;
  }

  getUserById(id) : Observable<User> {
    return this.http.get<User>(endpoint + 'User/' + id);
  }

  getTaskById(id) : Observable<Task> {
    return this.http.get<Task>(endpoint + 'Task/' + id);
  }

  getParentTaskById(id) : Observable<Task> {
    return this.http.get<Task>(endpoint + 'ParentTask/' + id);
  }

  deleteUser(id)  {
    
    this.http.delete(endpoint + "User/" + id).subscribe(data=> {
      this.serviceResponseReceived.next(true);
    });
  }

  endTask(id)  {
    let returnObject = false;
    let body = JSON.stringify(id);
    this.http.put(endpoint + "Task/" + id,
        body, httpOptions)
        .subscribe(
            data => {
                console.log("End Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("POST Error", error);
            }
        ); 
        return returnObject;
  }

  suspendProject(id)  {
    let returnObject = false;
    let body = JSON.stringify(id);
    this.http.post(endpoint + "Project/" + id,
        body, httpOptions)
        .subscribe(
            data => {
                console.log("End Request is successful ", data);
                returnObject = true;
                this.serviceResponseReceived.next(true);
            },
            error => {
                console.log("POST Error", error);
            }
        ); 
        return returnObject;
  }

}
