import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// importando os componentes
import { InserirCadastroComponent } from './componentes/estudante/inserir-cadastro/inserir-cadastro.component';
import { AtualizarCadastroComponent } from './componentes/estudante/atualizar-cadastro/atualizar-cadastro.component';
import { ListarCadastrosComponent } from './componentes/estudante/listar-cadastros/listar-cadastros.component';
import { DetalheCadastroComponent } from './componentes/estudante/detalhe-cadastro/detalhe-cadastro.component';
import { ListarCursoComponent } from './componentes/curso/listar-curso/listar-curso.component';
import { DetalheCursoComponent } from './componentes/curso/detalhe-curso/detalhe-curso.component';
import { InserirCursoComponent } from './componentes/curso/inserir-curso/inserir-curso.component';
import { AtualizarCursoComponent } from './componentes/curso/atualizar-curso/atualizar-curso.component';
import { CursoEstudanteComponent } from './componentes/curso-estudante/curso-estudante/curso-estudante.component';

const routes: Routes = [
  // definir as rotas

  { path: '', redirectTo: 'listar', pathMatch: 'full' },
  { path: 'inserir', component: InserirCadastroComponent },
  { path: 'atualizar/:id', component: AtualizarCadastroComponent },
  { path: 'listar', component: ListarCadastrosComponent },
  { path: 'detalhe/:id', component: DetalheCadastroComponent },
  { path: 'listar-curso', component: ListarCursoComponent },
  { path: 'detalhe-curso/:id', component: DetalheCursoComponent },
  { path: 'inserir-curso', component: InserirCursoComponent },
  { path: 'atualizar-curso/:id', component: AtualizarCursoComponent },
  { path: 'curso-estudante', component: CursoEstudanteComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
