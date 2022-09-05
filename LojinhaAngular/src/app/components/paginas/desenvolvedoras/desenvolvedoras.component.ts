import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Desenvolvedora } from 'src/app/model/Desenvolvedora.model';
import { DesenvolvedorasService } from 'src/app/service/desenvolvedora.service';
import {FormGroup, FormControl, FormBuilder, Validators} from '@angular/forms'

@Component({
  selector: 'app-desenvolvedoras',
  templateUrl: './desenvolvedoras.component.html',
  styleUrls: ['./desenvolvedoras.component.sass']
})
export class DesenvolvedorasComponent implements OnInit {

  desenvolvedoras: Array<Desenvolvedora> | undefined;
  desenvolvedoraEdicao!: Desenvolvedora;
  arrayany?: Array<any> = [];
  desenvolvedoraForm!: FormGroup;
  
  displayApagar = "none";
  displayEditar = "none";

  constructor(private desenvolvedoraService: DesenvolvedorasService, 
              private toastrService: ToastrService, 
              private formBuilder: FormBuilder ) { }

  ngOnInit(): void {
   this.retornaDesenvolvedoras();
   this.geraFormulario(new Desenvolvedora);
  }

  geraFormulario(desenvolvedora: Desenvolvedora) {
    this.desenvolvedoraForm = this.formBuilder.group({
      nome: new FormControl(desenvolvedora.nome, [Validators.required]),
      pais: new FormControl(desenvolvedora.pais, [Validators.required])
    })
  }

  onSubmit(){
    if(this.desenvolvedoraForm.valid){
      const novaDesenvolvedora = {
        nome: this.desenvolvedoraForm.controls['nome'].value,
        pais: this.desenvolvedoraForm.controls['pais'].value
      }

      this.cadastraDesenvolvedora(novaDesenvolvedora);
    }else{
      this.toastrService.error("Revise as informações do formulario!");
    }
    
  }
  retornaDesenvolvedoras(){
    this.desenvolvedoraService.RetornaDesenvolvedoras().subscribe( 
      resp => {
      this.desenvolvedoras = <Desenvolvedora[]>resp.body;
      this.toastrService.success("Retornou os dados com sucesso!");
      },
      (erro: any) => {
        this.toastrService.error(erro);
      },
      () => {
        
      }
    );
  }

  cadastraDesenvolvedora(desenvolvedora: Desenvolvedora){
    this.desenvolvedoraForm.disable();
     this.desenvolvedoraService.salvarDesenvolvedora(desenvolvedora).subscribe(
      resp => {
        var retorno = resp;
        this.desenvolvedoraForm.reset();
        this.desenvolvedoraForm.enable();
        this.toastrService.success("Nova desenvolvedora cadastrada!");
      },
      (erro: any) => {
        this.desenvolvedoraForm.reset();
        this.desenvolvedoraForm.enable();
        this.toastrService.error(erro);
      },
      () => {
        this.retornaDesenvolvedoras();
      }
     )
  }

  
  abrirModalApagar(desenvolvedora: Desenvolvedora){
    this.desenvolvedoraEdicao = {id: desenvolvedora.id, nome: desenvolvedora.nome, pais: desenvolvedora.pais};
    this.displayApagar = "block";
  }

  fecharModalApagar() {
    this.displayApagar = "none";
  }
  
  abrirModalEditar(desenvolvedora: Desenvolvedora){
    this.desenvolvedoraEdicao = {id: desenvolvedora.id, nome: desenvolvedora.nome, pais: desenvolvedora.pais};
    this.displayEditar = "block";
  }

  fecharModalEditar() {
    this.displayEditar = "none";
  }
  

  deleteDesenvolvedora(){
      if(this.desenvolvedoraEdicao.id === null)
          this.toastrService.error("Selecione um registro para apagar");
      else
          this.desenvolvedoraService.deletaDesenvolvedora(this.desenvolvedoraEdicao).subscribe();
          this.fecharModalApagar();
          this.retornaDesenvolvedoras();
    this.desenvolvedoraEdicao = new Desenvolvedora();
  }

  editaDesenvolvedora(){
    if(this.desenvolvedoraEdicao.id === null)
      this.toastrService.error("Selecione um registro para editar!");
    else
      this.desenvolvedoraService.editaDesenvolvedora(this.desenvolvedoraEdicao).subscribe(
        resp => {
          var retorno = resp;
          this.fecharModalEditar();
          this.retornaDesenvolvedoras();
        },
        (error: any) => {
          this.toastrService.error(error);
        },
        () => {

        }
      );
    this.desenvolvedoraEdicao = new Desenvolvedora();
  }

}
