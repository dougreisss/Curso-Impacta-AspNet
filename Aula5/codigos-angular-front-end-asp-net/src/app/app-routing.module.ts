import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
// importando os componentes
import { InserirCadastroComponent } from './componentes/inserir-cadastro/inserir-cadastro.component';
import { AtualizarCadastroComponent } from './componentes/atualizar-cadastro/atualizar-cadastro.component';
import { ListarCadastrosComponent } from './componentes/listar-cadastros/listar-cadastros.component';
import { DetalheCadastroComponent } from './componentes/detalhe-cadastro/detalhe-cadastro.component';

const routes: Routes = [
  // definir as rotas
  //http://localhost:4200/listar
  {path: '', redirectTo: 'listar', pathMatch: 'full'},
  {path: 'inserir', component: InserirCadastroComponent},
  {path: 'atualizar/:id', component: AtualizarCadastroComponent},
  {path: 'listar', component: ListarCadastrosComponent},
  {path: 'detalhe/:id', component: DetalheCadastroComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
