import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, input, Output } from '@angular/core';
import { MatIconModule } from '@angular/material/icon';
import { MatPaginatorModule, PageEvent } from '@angular/material/paginator';
import { GetEmployee } from '../../Models/get-employee';
import { PaginationResponse } from '../../Models/pagination-response';
import { FilterEmployeeForm } from '../../Types/employee-types';
import { EmployeeFilterComponent } from "./employee-filter/employee-filter.component";

@Component({
  selector: 'app-employee-list',
  imports: [CommonModule, MatPaginatorModule, MatIconModule, EmployeeFilterComponent],
  templateUrl: './employee-list.component.html',
  styleUrl: './employee-list.component.scss'
})
export class EmployeeListComponent {

  employees = input.required<PaginationResponse<GetEmployee>>();
  @Input() FilterForm!: FilterEmployeeForm;
  @Output() onFilterChange = new EventEmitter();
  @Output() onEmployeeEdit = new EventEmitter<number>();
  @Output() onEmployeeDelete = new EventEmitter<number>();
  onPageChange(event: PageEvent): void {
    this.FilterForm.controls.pageSize.setValue(event.pageSize);
    this.FilterForm.controls.pageNumber.setValue(event.pageIndex + 1);
    this.onFilterChange.emit();
  }

  onFilter()
  {
    this.FilterForm.controls.pageNumber.setValue(1);
    this.onFilterChange.emit();
  }


  get skip() {
    return this.FilterForm.controls.pageNumber.value >= 1 ?
      (+this.FilterForm.controls.pageNumber.value - 1) * +this.FilterForm.controls.pageSize.value : 1;
  }
}
