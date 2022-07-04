import { Injectable } from "@angular/core";
import {HttpClient, HttpErrorResponse, HttpHeaders} from "@angular/common/http";
import { Observable, throwError } from "rxjs";
import { retry, catchError } from "rxjs";
import { Jogo } from "../model/jogo.model";
import { environment } from "src/environments/environment";

@Injectable({
    providedIn:'root'
})

export class JogoService {
    constructor(private httpclient: HttpClient){}


    //configuração dos headers
    httpOptions = {
        Headers: new HttpHeaders({'Content-Type': 'application/json'})
    }

    //obtem todos os jogos 
    getJogos(): Observable<Jogo[]> {
        return this.httpclient.get<Jogo[]>(`${environment.URL}` + 'jogo')
        .pipe(
            retry(2),
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
        console.log(errorMessage);
        return throwError(errorMessage);
    };
}