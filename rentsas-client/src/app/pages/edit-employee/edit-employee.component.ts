import { CommonModule } from '@angular/common';
import { Component, effect, EventEmitter, inject, input, Output } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { EmployeeService } from '../../Services/employee.service';
import { EmployeeForm } from '../../Types/employee-types';

@Component({
  selector: 'app-edit-employee',
  imports: [CommonModule, ReactiveFormsModule, MatFormFieldModule, MatInputModule, MatButtonModule],
  templateUrl: './edit-employee.component.html',
  styleUrl: './edit-employee.component.scss'
})
export class EditEmployeeComponent {
  constructor() {
    effect(() => {

      if (!this.employeeId())
        return;

      this.#employeeService.getById(this.employeeId()!)
        .subscribe(res => this.form.patchValue(res))
    });
  }

  form: EmployeeForm = this.createFrom();
  employeeId = input.required<number | null>();
  #employeeService = inject(EmployeeService);
  @Output() onAddOrEdit = new EventEmitter<number>();

  createFrom() {
    return this.form = new FormGroup({
      id: new FormControl(0),
      email: new FormControl('', [Validators.required, Validators.email, Validators.maxLength(150)]),
      firstName: new FormControl('', [Validators.required, Validators.maxLength(150)]),
      lastName: new FormControl('', [Validators.required, Validators.maxLength(150)]),
      position: new FormControl('', [Validators.required, Validators.maxLength(150)])
    });
  }
  submit() {

    const value = this.form.getRawValue();

    if (value.id > 0)
      this.#employeeService.update(value)
        .subscribe(res => {

         this.createFrom();
          this.resetFormErrors();
          this.onAddOrEdit.emit(value.id);
        });
    else
      this.#employeeService.add(value)
        .subscribe({next:res => {

          this.createFrom();
         this.resetFormErrors();
          this.onAddOrEdit.emit(value.id);
        },
      error:err=>this.onAddOrEdit.emit(-1)});


  }

  resetFormErrors()
  {
    Object.values(this.form.controls).forEach(control => {
      control.setErrors(null);
      control.markAsPristine();
      control.markAsUntouched();
    });
  }

}
