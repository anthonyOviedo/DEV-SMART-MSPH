import { Component, OnInit } from '@angular/core';

declare function init_sidebar ();

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styles: []
})
export class SidebarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    init_sidebar();
  }

}
