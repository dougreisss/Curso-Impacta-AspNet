import { Component, OnInit } from '@angular/core';
// importar o service
import { EstudanteApiService } from '../../service/estudante-api.service';
//importar os recursos de roteamento
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-atualizar-cadastro',
  templateUrl: './atualizar-cadastro.component.html',
  styleUrls: ['./atualizar-cadastro.component.css']
})
export class AtualizarCadastroComponent implements OnInit {
  // 1º passo: definir o titulo do comp
  tituloComp: string = 'Atualizar Cadastro'

  // 2º passo: definir uma prop para receber os dados
  dadosAtuaisEstudante: any = {}

  // 3º passo: praticar a referencia de instancia dos recursos importados
  constructor(
    private estudApi: EstudanteApiService,
    private roteador: Router,
    private copiandoRota: ActivatedRoute
  ){}

  // 4º passo: fazer uso do objeto referencial copiandoRota para "tirar uma foto" da rota usada pelo cadastro para chegar ao comp
  rotaCopiada: any = this.copiandoRota.snapshot.params['id']

  // 5º passo: definir o Angular Hook ngOnInit para "priorizar" o acesso ao cadastro que precisa ser recuperado para, então, ser alterado/atualizado
  ngOnInit(): void {
    // é necessário fazer uso da injeção de dependencia do service para acessar o método de recuperação de um unico registro da base - devidamente armazenado e identificado
    this.estudApi.recUmRegistro(this.rotaCopiada).subscribe((dadosRec: any) =>{
      this.dadosAtuaisEstudante = dadosRec
    })
  }

  // 6º passo: criar o método/função para acessar o service chamar a API para atualizar os dados
  atualizarDadosEstudante(): void{
    // chamar a injeção de dependencia
    this.estudApi.atualizarRegistro(this.dadosAtuaisEstudante.id, this.dadosAtuaisEstudante).subscribe(() =>{
      this.roteador.navigate(['/listar'])
    })
  }
}
