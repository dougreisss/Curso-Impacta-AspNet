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

  title = "Atualizar cadastro"

  rotaCopiada: any = this.copiandoRota.snapshot.params['id'];

  atualizarCurso: Curso = {
    curso_Id: 0,
    curso_Nome: '',
    curso_Mensalidade: 0,
    estudante_Id: 0,
    estudante_RA: 0
  }

  ngOnInit(): void {
    this.cursoService.recUmRegistro(this.rotaCopiada).subscribe((dadosChegaram: Curso) => {
      this.atualizarCurso = dadosChegaram
    });
  }

}