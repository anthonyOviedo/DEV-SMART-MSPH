import { Component, OnInit } from '@angular/core';
import { Department, Persona } from 'src/app/models/model.index';
declare function init_sidebar();
declare var $: any;
@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styles: []
})
export class SidebarComponent implements OnInit {

  Departments: Department[] = [];

  constructor() { }

  ngOnInit() {
    init_sidebar();
    this.Start();
  }

  Start() {
    this.loadDepartments();
  }

  loadDepartments() {
    let Department1 = new Department(1, 'Gestion Ambiental');
    let Department2 = new Department(2, 'Informatica');
    let Department3 = new Department(3, 'Recursos Humanos');
    let Department4 = new Department(4, 'Otro');
    this.Departments.push(Department1);
    this.Departments.push(Department2);
    this.Departments.push(Department3);
    this.Departments.push(Department4);

  }


openModal(){
  $('#OpcionModal').modal('show');
  console.log('entro')
}



}