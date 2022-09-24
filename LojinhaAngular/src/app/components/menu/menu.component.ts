import { Component, OnInit, ViewChild } from '@angular/core';
import { trigger, state, style, transition, animate } from '@angular/animations';
//importação de svgs do font awesome
import {FaIconLibrary, FontAwesomeModule } from '@fortawesome/angular-fontawesome'
import { MatAccordion } from '@angular/material/expansion';
import { CategoriaMenuAcesso } from 'src/app/model/CategoriaMenuAcesso.model';
import { CategoriaService } from 'src/app/service/categoria.service';
import { ToastrService } from 'ngx-toastr';
import { FormBuilder } from '@angular/forms';
//import {faBars} from '@fortawesome/free-solid-svg-icons'

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.sass']
})
export class MenuComponent implements OnInit {
  events: string[] = [];
  opened!: boolean;
  showFiller = false;
  categorias: Array<CategoriaMenuAcesso> = [];

  @ViewChild(MatAccordion) accordion!: MatAccordion;
  constructor(private categoriaService: CategoriaService,
              private toastrService: ToastrService,
              private formbuilder: FormBuilder) { }

  ngOnInit(): void {
    this.retornaDesenvolvedoras();
  }

  retornaDesenvolvedoras(){
    this.categoriaService.RetornaCategorias().subscribe( 
      resp => {
      this.categorias = <CategoriaMenuAcesso[]>resp.body;
      this.toastrService.success("Retornou os dados com sucesso!");
      },
      (erro: any) => {
        this.toastrService.error(erro);
      },
      () => {
        
      }
    );
  }
}
