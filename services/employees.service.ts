import { HttpClient } from '@angular/common/http';
import { Environment } from '@angular/compiler-cli/src/ngtsc/typecheck/src/environment';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from '../models/employee.model';

@Injectable({
    providedIn: 'root'
})

export class EmployeesService {

    baseApiUrl: string = Environment.baseApiUrl;

    constructor(private http: HttpClient){}

        getAllEmployees(): Observable<Employee[]> {
            return this.http.get<Employee[]>(this.baseApiUrl + '/api/employees');
        }

        addEmployee(addEmployeeRequest: Employee): Observable<Employee>{
            addEmployeeRequest.id = '0';
            return this.http.post<Employee>(this.baseApiUrl + '/api/employees',addEmployeeRequest);
        }

        getEmployee(id: string): Observable<Employee> {
            return this.http.get<Employee>(this.baseApiUrl + '/api/employees/' + id);
        }

        updateEmployee(id: string, updateEmployeeRequest: Employee):Observable<Employee> {
            return this.put<Employee>(this.baseApiUrl + '/api/employees/'+id,updateEmployeeRequest);
        }
        deleteEmployee(id: string):Observable<Employee> {
            return this.http.delete<Employee>(this.baseApiUrl + '/api/employees/'+id);
        }

        
}