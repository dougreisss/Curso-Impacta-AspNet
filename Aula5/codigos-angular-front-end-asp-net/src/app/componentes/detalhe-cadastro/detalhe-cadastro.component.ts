import { Component, OnInit } from '@angular/core';

// importar o service
import { EstudanteApiService } from '../../service/estudante-api.service';

// importar o ActivatedRoute
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalhe-cadastro',
  templateUrl: './detalhe-cadastro.component.html',
  styleUrls: ['./detalhe-cadastro.component.css']
})
export class DetalheCadastroComponent implements OnInit {

  // 1º passo: definir o titulo do comp
  tituloComp: string = 'Detalhes de informações do estudante'

  // 1ºb passo: definir o objeto que receberá os dados para, então, vincula-los à view
  cadastroUnico: any = {}

  // 2º passo: praticar a referencia de instancia das classes de recurso
  constructor(
    private estudApi: EstudanteApiService,
    private roteador: Router,
    private copiandoRota: ActivatedRoute
  ) { }

  // 3º passo: fazer a "cópia" da rota pelo qual os dados circularão
  rotaCopiada: any = this.copiandoRota.snapshot.params['id']

  // 4º passo: implementar o Angular Hook para "priorizar" algum conteudo/funcionalidade
  ngOnInit(): void {
    this.acessandoUmCadastro()
  }

  // 5º passo: criar um método/função para acessar o service que possui a tarefa assincrona que recupera um unico registro da base
  acessandoUmCadastro(): void {
    // chamar a injeção de dependencia e, dessa forma, acessar a requisição assincrona e executa-la
    this.estudApi.recUmRegistro(this.rotaCopiada).subscribe((dadosChegaram: {}) => {
      this.cadastroUnico = dadosChegaram
    })
  }

  // 6º passo: consiste e criar um método/função para acessar o service e chamar à execução a requisição assincrona de exclusão de cadastro
  excluirCadastroEstudante(id: any): any {
    // verificar se o usuario, realmente, deseja excluir o cadastro
    if (confirm('Deseja, realmente, excluir este cadastro?')) {
      // chamar a injeção de dependencia e acessar a requisição
      this.estudApi.exclusaoRegistro(id).subscribe(() => {
        this.roteador.navigate(['/listar'])
      })
    }
  }
}
