import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
// importar o FormsModule 
import { FormsModule } from '@angular/forms';
// importar o módulo de recursos de requisição http
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
// importar o service
import { EstudanteApiService } from './service/estudante-api.service';
// componentes
import { InserirCadastroComponent } from './componentes/estudante/inserir-cadastro/inserir-cadastro.component';
import { AtualizarCadastroComponent } from './componentes/estudante/atualizar-cadastro/atualizar-cadastro.component';
import { ListarCadastrosComponent } from './componentes/estudante/listar-cadastros/listar-cadastros.component';
import { DetalheCadastroComponent } from './componentes/estudante/detalhe-cadastro/detalhe-cadastro.component';
import { ListarCursoComponent } from './componentes/curso/listar-curso/listar-curso.component';
import { DetalheCursoComponent } from './componentes/curso/detalhe-curso/detalhe-curso.component';
import { InserirCursoComponent } from './componentes/curso/inserir-curso/inserir-curso.component';
import { AtualizarCursoComponent } from './componentes/curso/atualizar-curso/atualizar-curso.component';
import { CursoApiService } from './service/curso-api.service';
import { CursoEstudanteComponent } from './componentes/curso-estudante/curso-estudante/curso-estudante.component';
import { EstudanteCursoComponent } from './componentes/estudante-curso/estudante-curso/estudante-curso.component';
import { UnicoEstudanteCursoComponent } from './componentes/estudante-curso/unico-estudante-curso/unico-estudante-curso.component';

@NgModule({
  declarations: [
    AppComponent,
    InserirCadastroComponent,
    AtualizarCadastroComponent,
    ListarCadastrosComponent,
    DetalheCadastroComponent,
    ListarCursoComponent,
    DetalheCursoComponent,
    InserirCursoComponent,
    AtualizarCursoComponent,
    CursoEstudanteComponent,
    EstudanteCursoComponent,
    UnicoEstudanteCursoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [EstudanteApiService, CursoApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
