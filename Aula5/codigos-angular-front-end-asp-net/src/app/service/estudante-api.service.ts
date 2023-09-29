import { Injectable } from '@angular/core';
// 1ª dependencia: importar o model
import { Estudante } from '../model/estudante';
// 2ª dependencia: importar os recursos que auxiliarão nas implementações das requisições http
import { HttpClient, HttpHeaders } from '@angular/common/http';

// 3ª dependencia: importar o recurso que auxiliará na construção das requisições http de forma assincrona
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Injectable()

export class EstudanteApiService {
  /*==================================================================
      1º PEDAÇO DO SERVICE - DEFINIR "RECURSOS DE OPERAÇÃO" DO SERVICE
    ==================================================================*/
  // 1ª etapa: estabelecer uma prop para receber como valor o "endereço" da estrutura de back-end na qual este front será integrado
  //apiUrlBase: string = 'http://localhost:1234/api/Estudante'
  apiUrlBase: string = 'http://localhost:5191/api/Estudante'

  // 2ª etapa: praticar a referencia de instancia - a partir do construtor da classe - para gerar o objeto referencial que fará parte das requisições http
  constructor(private httpReq: HttpClient) { }

  // 3ª etapa: definição das "credenciais de acesso" da aplicação client para a aplicação server com o intuito de alterar a base de dados
  cruzamentoDominio = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  /*=================================================================
      2º PEDAÇO DO SERVICE - ESTABELECER O FLUXO DE DADOS A PARTIR DA CHAMADA DA API NO BACKEND
   ==================================================================*/
  // Objetivo: trabalhar e definir o uso dos verbos/métodos/requisições http  -get() para leitura, post() para inserção, put() para re-inserção/atualização/alteração, delete() para a exclusão de registros da base.

  // 1ª parte: estabelecer o método/requisição http - de forma assincrona - para chamar do backend e recuperar todos os dados da base
  recTodosOsRegistros(): Observable<Estudante> {
    // acessamos o objeto referencial para usar a injeção de dependencia de HttpClient

    // http://localhost:1234/api/Estudante/TodosOsDados

    return this.httpReq.get<Estudante>(this.apiUrlBase + '/GetAll').pipe(
      // pipe estabelece um fluxo de "comunicação direta" entre elementos assincronos 
      retry(1),
      catchError(this.observarBug)
    )

    // return this.httpReq.get<Estudante>(this.apiUrlBase + '/estudantes')
    //   .pipe(
    //     // pipe estabelece um fluxo de "comunicação direta" entre elementos assincronos 
    //     retry(1),
    //     catchError(this.observarBug)
    //   )
  }

  // 2ª parte: estabelecer o método/requisição http - de forma assincrona - para chamar do backend e recuperar um dado especifico - a partir de seu armazenamento e identificação
  recUmRegistro(id: any): Observable<Estudante> {
    // http://localhost:1234/api/Estudante/RecUmDado
    return this.httpReq.get<Estudante>(this.apiUrlBase + '/GetOne/' + id).pipe(
      retry(1),
      catchError(this.observarBug)
    )

    //   return this.httpReq.get<Estudante>(this.apiUrlBase + '/estudantes/' + id)
    //     .pipe(
    //       retry(1),
    //       catchError(this.observarBug)
    //     )
  }

  // 3ª parte: estabelecer o método/requisição http - de forma assincrona - para chamar do backend e inserir um registro especifico - a partir de seu armazenamento e identificação
  inserirRegistro(dadosRecebidos: any): Observable<Estudante> {
    // http://localhost:1234/api/Estudante/AdicionarRegistro

    return this.httpReq.post<Estudante>(this.apiUrlBase + '/AddRegister',
      JSON.stringify(dadosRecebidos), this.cruzamentoDominio).pipe(
        retry(1),
        catchError(this.observarBug)
      )

    // return this.httpReq.post<Estudante>(this.apiUrlBase + '/estudantes', JSON.stringify(dadosRecebidos), this.cruzamentoDominio)
    //   .pipe(
    //     retry(1),
    //     catchError(this.observarBug)
    //   )
  }

  // 4ª parte: estabelecer o método/requisição http - de forma assincrona - para chamar do backend e atualizar/alterar um registro especifico - a partir de seu armazenamento e identificação
  atualizarRegistro(id: any, dadosAlterados: any): Observable<Estudante> {
    // http://localhost:1234/api/Estudante/RegistroAtual/:id

    return this.httpReq.put<Estudante>(this.apiUrlBase + '/UpRegister/' + id,
      JSON.stringify(dadosAlterados), this.cruzamentoDominio).pipe(
        retry(1),
        catchError(this.observarBug)
      )

    // return this.httpReq.put<Estudante>(this.apiUrlBase + '/estudantes/' + id, JSON.stringify(dadosAlterados), this.cruzamentoDominio)
    //   .pipe(
    //     retry(1),
    //     catchError(this.observarBug)
    //   )
  }

  // 5ª parte: estabelecer o método/requisição http - de forma assincrona - para chamar do backend e excluir um registro especifico - a partir de seu armazenamento e identificação
  exclusaoRegistro(id: any) {
    // http://localhost:1234/api/Estudante/DeletarRegistro/:id

    return this.httpReq.delete<Estudante>(this.apiUrlBase + '/delRegister/' + id, this.cruzamentoDominio).pipe(
      retry(1),
      catchError(this.observarBug)
    )

    // return this.httpReq.delete<Estudante>(this.apiUrlBase + '/estudantes/' + id, this.cruzamentoDominio)
    //   .pipe(
    //     retry(1),
    //     catchError(this.observarBug)
    //   )
  }

  // 6ª parte - parte final: definir  método/função que pode observar eventuais problemas uqe podem ocorrer no front ou no backend da aplicação
  observarBug(bug: any) {
    // definir uma prop para receber o valor que descreve as infos sobre o bug que, eventualmente, possa ter ocorrido
    let infosBug: any = ''

    // verificar, de forma simples, em qual "pedaço" da aplicação o problema possa ter ocorrido
    if (bug.error instanceof ErrorEvent) {
      // observação do problema - se ocorrer no front
      infosBug = bug.error.message
    } else {
      // observação do problema - se ocorrer no backend
      infosBug = `Codigo do erro: ${bug.status}\nMensagem do erro: ${bug.message}`
    }
    // criar a estrutura lógica de exibição do eventual erro
    alert(infosBug)

    // definir uma expressão de retorno que possa "lançar" o problema e, dessa forma, seja lido no front
    return throwError(() => infosBug)
  }
}
