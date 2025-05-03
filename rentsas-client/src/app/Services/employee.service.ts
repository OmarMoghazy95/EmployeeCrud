import { PaginationResponse } from './../Models/pagination-response';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { EditEmployee } from '../Models/edit-employee';
import { EmployeeFilter } from '../Models/employee-filter';
import { GetEmployee } from '../Models/get-employee';
import { HttpClient, HttpParams } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private baseUrl = 'https://localhost:7179/api/employees';

  #http=inject(HttpClient);

  add(dto: EditEmployee): Observable<EditEmployee> {
    return this.#http.post<EditEmployee>(`${this.baseUrl}/`, dto);
  }

  update(dto: EditEmployee): Observable<EditEmployee> {
    return this.#http.put<EditEmployee>(`${this.baseUrl}/`, dto);
  }

  delete(id: number): Observable<boolean> {
    return this.#http.delete<boolean>(`${this.baseUrl}/${id}`);
  }

  getById(id: number): Observable<EditEmployee> {
    return this.#http.get<EditEmployee>(`${this.baseUrl}/${id}`);
  }

  getAll(filter: EmployeeFilter): Observable<PaginationResponse<GetEmployee>> {
    let params = new HttpParams();
    Object.entries(filter).forEach(([key, value]) => {
      if (value !== null && value !== undefined && value !== '') {
        params = params.set(key, value.toString());
      }
    });

    return this.#http.get<PaginationResponse<GetEmployee>>(`${this.baseUrl}/`, { params });
  }
}
