import { Component, OnInit } from '@angular/core';

//importação de svgs do font awesome
import {FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import {faBars} from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.sass']
})
export class MenuComponent implements OnInit {
  
  faBars = faBars;
  constructor() { }

  ngOnInit(): void {
  }

}
