import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from './employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private getUrl = "https://localhost:5001/api/Employees";

  constructor(private http: HttpClient) { }

  getEmployees() : Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.getUrl}`);
  }
}
