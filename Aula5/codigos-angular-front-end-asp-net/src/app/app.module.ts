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
import { InserirCadastroComponent } from './componentes/inserir-cadastro/inserir-cadastro.component';
import { AtualizarCadastroComponent } from './componentes/atualizar-cadastro/atualizar-cadastro.component';
import { ListarCadastrosComponent } from './componentes/listar-cadastros/listar-cadastros.component';
import { DetalheCadastroComponent } from './componentes/detalhe-cadastro/detalhe-cadastro.component';

@NgModule({
  declarations: [
    AppComponent,
    InserirCadastroComponent,
    AtualizarCadastroComponent,
    ListarCadastrosComponent,
    DetalheCadastroComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [EstudanteApiService],
  bootstrap: [AppComponent]
})
export class AppModule { }
