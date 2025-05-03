import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { EmployeeShellComponent } from "./pages/employee-shell/employee-shell.component";

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, EmployeeShellComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',

})
export class AppComponent {

}
