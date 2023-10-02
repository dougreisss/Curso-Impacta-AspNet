import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Curso } from 'src/app/model/curso';
import { CursoApiService } from 'src/app/service/curso-api.service';

@Component({
  selector: 'app-atualizar-curso',
  templateUrl: './atualizar-curso.component.html',
  styleUrls: ['./atualizar-curso.component.css']
})
export class AtualizarCursoComponent implements OnInit {

  constructor(
    private cursoService: CursoApiService,
    private roteador: Router,
    private copiandoRota: ActivatedRoute
  ) { }

  title = "Atualizar Curso"

  rotaCopiada: any = this.copiandoRota.snapshot.params['id'];

  atualizarCurso: Curso = {
    cursoId: 0,
    cursoNome: '',
    cursoMensalidade: 0,
    estudanteId: 0,
    estudanteRA: 0
  }

  ngOnInit(): void {
    this.cursoService.recUmRegistro(this.rotaCopiada).subscribe((dadosChegaram: Curso) => {
      this.atualizarCurso = dadosChegaram
    });
  }

  updateCurso() {
    this.cursoService.atualizarRegistro(this.rotaCopiada, this.atualizarCurso).subscribe(() => {
      this.roteador.navigate(['/listar-curso'])
    });
  }

}
