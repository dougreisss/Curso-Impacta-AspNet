import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Curso } from 'src/app/model/curso';
import { CursoApiService } from 'src/app/service/curso-api.service';

@Component({
  selector: 'app-detalhe-curso',
  templateUrl: './detalhe-curso.component.html',
  styleUrls: ['./detalhe-curso.component.css']
})
export class DetalheCursoComponent implements OnInit {

  constructor(
    private roteador: Router,
    private copiandoRota: ActivatedRoute,
    private cursoService: CursoApiService
  ) {

  }

  title = "Detalhes de um curso";

  curso: Curso = {
    cursoId: 0,
    cursoMensalidade: 0,
    cursoNome: '',
    estudanteId: 0,
    estudanteRA: 0
  };

  rotaCopiada: any = this.copiandoRota.snapshot.params['id'];

  ngOnInit(): void {
    this.getCurso();
  }

  getCurso(): void {
    this.cursoService.recUmRegistro(this.rotaCopiada).subscribe((dadosChegaram: Curso) => {
      this.curso = dadosChegaram;
    });
  }

  excluirCurso(): void {
    this.cursoService.exclusaoRegistro(this.rotaCopiada).subscribe(() => {
      this.roteador.navigate(['/listar-curso']);
    });
  }


}
