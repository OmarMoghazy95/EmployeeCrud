import { Component, EventEmitter, Input, input, Output, output } from '@angular/core';
import { FilterEmployeeForm } from '../../../Types/employee-types';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-employee-filter',
  imports: [CommonModule,ReactiveFormsModule,MatFormFieldModule,MatInputModule,MatButtonModule],
  templateUrl: './employee-filter.component.html',
  styleUrl: './employee-filter.component.scss'
})
export class EmployeeFilterComponent {

  @Input() FilterForm!:FilterEmployeeForm;
  @Output()onFilterChange = new EventEmitter();
}
