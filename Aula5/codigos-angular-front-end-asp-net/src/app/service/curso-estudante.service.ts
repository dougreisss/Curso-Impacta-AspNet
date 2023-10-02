import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, retry, throwError } from 'rxjs';
import { cursoEstudante } from '../model/cursoEstudante';

@Injectable({
  providedIn: 'root'
})
export class CursoEstudanteService {

  apiUrlBase: string = 'http://localhost:5191/api/Join/'

  cruzamentoDominio = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  constructor(private httpReq: HttpClient) { }

  getCursosEstudantes(): Observable<cursoEstudante> {
    return this.httpReq.get<cursoEstudante>(this.apiUrlBase + 'GetJoinTodosCursos').pipe(
      retry(1),
      catchError(this.observarBug)
    )
  }

  observarBug(bug: any) {
    let infosBug: any = ''

    if (bug.error instanceof ErrorEvent) {
      infosBug = bug.error.message
    } else {
      infosBug = `Codigo do erro: ${bug.status}\nMensagem do erro: ${bug.message}`
    }

    alert(infosBug)

    return throwError(() => infosBug)
  }
}
