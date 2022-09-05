import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders, HttpResponse} from "@angular/common/http";
import { Observable, throwError, map } from "rxjs";
import { retry, catchError } from "rxjs";
import { Jogo } from "../model/jogo.model";
import { environment } from "src/environments/environment";
import { Desenvolvedora } from "../model/Desenvolvedora.model";
import { Requisicao } from "../model/requisicao";

@Injectable({
    providedIn:'root'
})

export class DesenvolvedorasService {
    constructor(private httpclient: HttpClient){}
    public requisicaoRetorno!: Array<Requisicao>[];
    //obtem todas as desenvolvedoras
    RetornaDesenvolvedoras(): Observable<HttpResponse<Desenvolvedora[]>> {
        return this.httpclient.get<Desenvolvedora[]>(`${environment.URL}` + 'desenvolvedora/RetornaDesenvolvedoras', {observe: 'response'})
        .pipe(
            retry(3),
            catchError(this.handleError)
        ).pipe(
            map((retorno: any) => retorno)
        )
    }

    //cadastra nova desenvolvedora
    salvarDesenvolvedora(desenvolvedora: Desenvolvedora): Observable<HttpResponse<Desenvolvedora[]>> {
        return this.httpclient.post<Desenvolvedora[]>(`${environment.URL}` + 'desenvolvedora/NovaDesenvolvedora', desenvolvedora, {observe: 'response'})
        .pipe(
            retry(2),
            catchError(this.handleError)
        ).pipe(
            map((retorno: any) => retorno)
        )
    }

    editaDesenvolvedora(desenvolvedora: Desenvolvedora): Observable<HttpResponse<Desenvolvedora[]>> {
        return this.httpclient.post<Desenvolvedora[]>(`${environment.URL}` + 'desenvolvedora/AlterarDesenvolvedora', desenvolvedora, {observe: 'response'})
        .pipe(
            retry(2),
            catchError(this.handleError)
        ).pipe(
            map((retorno: any) => retorno.status)
        )
    }

    deletaDesenvolvedora(desenvolvedora: Desenvolvedora){
       return this.httpclient.delete(`${environment.URL}` + 'desenvolvedora/DeletarDesenvolvedora/'+ desenvolvedora.id,{observe: 'response'})
       .pipe(
            catchError(this.handleError)
       )
    }

    handleError(error: HttpErrorResponse) {
        let errorMessage = '';

        if(error.error instanceof ErrorEvent){
            errorMessage = error.error.message;
        }else{
            errorMessage = `Código de erro: ${error.status}, ` + `mensagem: ${error.message}`;
        }
        return throwError(errorMessage);
    };
}