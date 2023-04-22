import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import {Observable} from 'rxjs';
import { Employee } from '../Interfaces/employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  //creating the configuration variables for the API
  private endpoint:string = environment.endPoint;
  private apiUrl:string= this.endpoint + "employee/";

  constructor(private http:HttpClient) { }

  getList():Observable<Employee>{
    return this.http.get<Employee>(`${this.apiUrl}list`);
  }

  // To add employee
  add(model:Employee):Observable<Employee>{
    return this.http.post<Employee>(`${this.apiUrl}save`, model);
  }

  // To update employee
  update(idPerson:number, model:Employee):Observable<Employee>{
    return this.http.put<Employee>(`${this.apiUrl}update/${idPerson}`, model);
  }

  // To delete employe
  delete(idPerson:number):Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}delete/${idPerson}`);
  }
}
