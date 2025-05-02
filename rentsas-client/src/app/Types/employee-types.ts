import { FormGroup } from "@angular/forms";
import { ControlsOf } from "../Helpers/reactive-form-helper";
import { EditEmployee } from "../Models/edit-employee";
import { EmployeeFilter } from "../Models/employee-filter";

export type EmployeeForm  = FormGroup<ControlsOf<EditEmployee>>;
export type FilterEmployeeForm = FormGroup<ControlsOf<EmployeeFilter>>;
