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

  desenvolvedoras: Array<Desenvolvedora> = [];
  desenvolvedoraEdicao!: Desenvolvedora;
  desenvolvedoraForm!: FormGroup;
  
  displayApagar = "none";
  editaRegistro: boolean = true;
  displayForm: boolean = false;

  //paginação
  contador = 10;
  pag = 1;

  constructor(private desenvolvedoraService: DesenvolvedorasService, 
              private toastrService: ToastrService, 
              private formBuilder: FormBuilder ) { }

  ngOnInit(): void {
   this.retornaDesenvolvedoras();
   this.geraFormulario(new Desenvolvedora);
  }

  geraFormulario(desenvolvedora: Desenvolvedora) {
    this.desenvolvedoraForm = this.formBuilder.group({
      id: new FormControl(desenvolvedora.id),
      nome: new FormControl(desenvolvedora.nome, [Validators.required]),
      pais: new FormControl(desenvolvedora.pais, [Validators.required])
    })
  }

  onSubmit(){
    if(this.desenvolvedoraForm.valid){
      this.desenvolvedoraEdicao = {
        nome: this.desenvolvedoraForm.controls['nome'].value,
        pais: this.desenvolvedoraForm.controls['pais'].value,
        id: 0
      }
      
      const idDesenvolvedora = this.desenvolvedoraForm.controls['id'].value;
      if( idDesenvolvedora != '' && idDesenvolvedora > 0){
         this.desenvolvedoraEdicao.id = parseInt(idDesenvolvedora);
        
        this.editaDesenvolvedora(this.desenvolvedoraEdicao);
      }else
        this.cadastraDesenvolvedora(this.desenvolvedoraEdicao);
    }
    this.desenvolvedoraEdicao = new Desenvolvedora();
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
  mostraFormularioCadastro(){
    this.displayForm = !this.displayForm;
  }

  deleteDesenvolvedora(desenvolvedora: Desenvolvedora){
      if(desenvolvedora.id === null)
          this.toastrService.error("Selecione um registro para apagar");
      else
          this.desenvolvedoraService.deletaDesenvolvedora(desenvolvedora).subscribe();
          this.fecharModalApagar();
          this.retornaDesenvolvedoras();
  }

  editar(desenvolvedora: Desenvolvedora){
    this.geraFormulario(desenvolvedora);
  }
  editaDesenvolvedora(desenvolvedora: Desenvolvedora){
      this.desenvolvedoraService.editaDesenvolvedora(this.desenvolvedoraEdicao).subscribe(
        resp => {
          this.toastrService.success(resp.statusText);
          this.retornaDesenvolvedoras();    
        },
        (error: any) => {
          this.toastrService.error(error);
        },
        () => {
          this.desenvolvedoraForm.reset();
        }
      );
  }

}
