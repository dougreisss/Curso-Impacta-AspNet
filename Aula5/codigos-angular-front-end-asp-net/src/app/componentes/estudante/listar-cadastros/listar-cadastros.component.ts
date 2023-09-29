import { Component, OnInit } from '@angular/core';
// importar o service
import { EstudanteApiService } from '../../../service/estudante-api.service';

@Component({
  selector: 'app-listar-cadastros',
  templateUrl: './listar-cadastros.component.html',
  styleUrls: ['./listar-cadastros.component.css']
})
export class ListarCadastrosComponent implements OnInit {
  // 1º passo: definir o titulo do comp
  tituloComp: string = 'Lista de Estudantes'

  // 2º passo: praticar a referencia de instancia - a partir do service
  constructor(
    private estudApi: EstudanteApiService
  ) { }

  // 3º passo: definir a prop que receberá os dados
  listaDeEstudantes: any = []

  // 4º passo: definir o Angular Hook para "priorizar" o carregamento dos dados no componente/view
  ngOnInit(): void {
    //??
    this.exibirListaEstudantes()
  }

  // 5º passo: criar um método/função para acessar o service que possui a requisição assincrona de recuperação de cadastros
  exibirListaEstudantes(): void {
    // chamar a injeção de dependencia e acessar a requisição para executa-la
    this.estudApi.recTodosOsRegistros().subscribe((chegandoDados: any) => {
      this.listaDeEstudantes = chegandoDados
    })
  }

  // 6º passo: consiste e criar um método/função para acessar o service e chamar à execução a requisição assincrona de exclusão de cadastro
  excluirCadastroEstudante(id: any): any {
    // verificar se o usuario, realmente, deseja excluir o cadastro
    if (confirm('Deseja, realmente, excluir este cadastro?')) {
      // chamar a injeção de dependencia e acessar a requisição
      this.estudApi.exclusaoRegistro(id).subscribe(() => {
        this.exibirListaEstudantes()
      })
    }
  }
}
