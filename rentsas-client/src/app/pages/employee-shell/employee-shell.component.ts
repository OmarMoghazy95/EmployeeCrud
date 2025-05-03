import { Component, inject, OnInit, signal, WritableSignal } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { GetEmployee } from '../../Models/get-employee';
import { PaginationResponse } from '../../Models/pagination-response';
import { EmployeeService } from '../../Services/employee.service';
import { FilterEmployeeForm } from '../../Types/employee-types';
import { EditEmployeeComponent } from '../edit-employee/edit-employee.component';
import { EmployeeListComponent } from '../employee-list/employee-list.component';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-employee-shell',
  imports: [EditEmployeeComponent, EmployeeListComponent],
  templateUrl: './employee-shell.component.html',
  styleUrl: './employee-shell.component.scss'
})
export class EmployeeShellComponent implements OnInit {
  ngOnInit(): void {
    this.getEmployees();
  }
  #employeesList: WritableSignal<PaginationResponse<GetEmployee>> = signal({ totalCount: 0, data: [] });
  #employeeIdForEdit: WritableSignal<number | null> = signal(null);
  filterForm: FilterEmployeeForm = this.createEmployeeFilterForm();
  #employeeService = inject(EmployeeService);

  createEmployeeFilterForm() {
    return this.filterForm = new FormGroup({
      pageNumber: new FormControl(1),
      pageSize: new FormControl(5),
      position: new FormControl(null),
      search: new FormControl(null)
    });
  }
  title = 'rentsas-client';

  getEmployees() {
    const filterValues = this.filterForm.getRawValue();

    this.#employeeService.getAll(filterValues)
      .subscribe(response => {
        this.#employeesList.update(a => response)
      })
  }

  onEditFormSubmit(id:number) {
    if (id==0)
      this.filterForm.controls.pageNumber.setValue(1);
    else if(id>0)
      this.#employeeIdForEdit.update(a => null);

    if(id==0 || id>0)
      Swal.fire({
        icon: 'success',
        title: 'Success!',
        text: id? 'Employee updated successfully.' : 'Employee added successfully.',
        confirmButtonColor: '#3085d6'
      });
      else
      this.errorAlert();

    this.getEmployees();
  }

  private errorAlert() {
    Swal.fire({
      icon: 'error',
      title: 'Error!',
      text: 'an error occured while proccessing your request! \n please try again later',
      confirmButtonColor: '#3085d6'
    });
  }

  onDeleteEmployee(id:number){
    Swal.fire({
      title: 'Are you sure?',
      text: 'You will not be able to recover this employee data  again!',
      icon: 'warning',
      confirmButtonText: 'Yes, I am sure!',
      showCancelButton: true,
      cancelButtonText: 'No, cancel it!',
    }).then(res=>{
      if(!res.isConfirmed)
        return;

      this.#employeeService.delete(id).subscribe({next:res=>
        {
          if(!res){
            this.errorAlert();
            return;
          }

          Swal.fire({
            icon: 'success',
            title: 'Success!',
            text:  'Employee deleted successfully.',
            confirmButtonColor: '#3085d6'
          });

          this.#employeesList.update(a=>({totalCount:a.totalCount-1,data:a.data.filter(data=>data.id!=id)}));

        },error:err=>this.errorAlert()});
    });
  }
  get employeeList() {
    return this.#employeesList.asReadonly();
  }

  get employeeId() {
    return this.#employeeIdForEdit.asReadonly();
  }

  onEdit(id: number) {
    this.#employeeIdForEdit.update(a => id);
  }
}
