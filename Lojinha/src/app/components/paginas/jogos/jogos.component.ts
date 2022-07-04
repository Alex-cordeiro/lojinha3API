import { Component, OnInit } from '@angular/core';
import { JogoService } from 'src/app/service/jogos.service';

@Component({
  selector: 'app-jogos',
  templateUrl: './jogos.component.html',
  styleUrls: ['./jogos.component.sass']
})
export class JogosComponent implements OnInit {

  constructor(private jogosService: JogoService) { }
  public jogos!: Array<any>;

  ngOnInit(): void {
    this.jogosService.getJogos().subscribe((retornoJogos) =>{
      this.jogos = retornoJogos;
      console.log(this.jogos);
    })
  }
}
