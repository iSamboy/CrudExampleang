import { Injectable } from '@angular/core';

import {HttpClient} from '@angular/common/http';
import {environment} from 'src/environments/environment';
import {Observable} from 'rxjs';
import { Office } from '../Interfaces/office';


@Injectable({
  providedIn: 'root'
})
export class OfficeService {

  //creating the configuration variables for the API
  private endpoint:string = environment.endPoint;
  private apiUrl:string= this.endpoint + "office/";

  constructor(private http:HttpClient) { }

  getList():Observable<Office>{
    return this.http.get<Office>(`${this.apiUrl}list`);
  }
}
