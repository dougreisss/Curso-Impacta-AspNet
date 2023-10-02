import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Curso } from 'src/app/model/curso';
import { CursoApiService } from 'src/app/service/curso-api.service';

@Component({
  selector: 'app-inserir-curso',
  templateUrl: './inserir-curso.component.html',
  styleUrls: ['./inserir-curso.component.css']
})
export class InserirCursoComponent {

  constructor(
    private cursoService: CursoApiService,
    private roteador: Router) {
  }

  title = "Inserir curso";

  insertCurso: Curso = {
    cursoId: 0,
    cursoNome: '',
    cursoMensalidade: 0,
    estudanteId: 0,
    estudanteRA: 0
  }

  inserirCurso(): void {
    this.cursoService.inserirRegistro(this.insertCurso).subscribe(() => {
      this.roteador.navigate(['/listar-curso']);
    });
  }

  // validaCampos(): booelan {

  // }

}
