import { Component, OnInit } from '@angular/core';

@Component({
    selector: 'app-employees-list',
    templateUrl: './employees-list.component.html',
    styleUrls: ['./employees-list.component.css']
})
export class EmployeesListComponent implements OnInit {
    employees: Employee[] = [
        {
            id:'1',
            name:'Srikrishna',
            email:'srikrishna@gmail.com',
            phone:1234567890,
            salary:500000,
            depatment: 'Information Technology'
        },
        {
            id:'2',
            name:'Krishna',
            email:'krishna@gmail.com',
            phone:1234506789,
            salary:500000,
            department:'Human Resources'
        },
        {
            id:'3',
            name:'Rajesh',
            email:'Rajesh@gmail.com',
            phone:6789123450,
            salary:500000,
            department:'Testing'
        }
    ];
    constructor(private employeesService: EmployeesService){}

    ngOnInit(): void {
        this.employeesService.getAllEmployees().subscribe({
            next: (employees) => {
                this.employees = employees;
            },
            error: (response) => {
                console.log(response);
            }
        })
        
    }
}