import { Component, OnInit } from '@angular/core';
import { Curso } from 'src/app/model/curso';
import { CursoApiService } from 'src/app/service/curso-api.service';

@Component({
  selector: 'app-listar-curso',
  templateUrl: './listar-curso.component.html',
  styleUrls: ['./listar-curso.component.css']
})
export class ListarCursoComponent implements OnInit {

  constructor(private cursoService: CursoApiService) {

  }

  title = "Lista de cursos";

  listaCurso: Array<Curso> = [];

  ngOnInit(): void {
    this.listarCursos();
  }

  listarCursos(): void {
    this.cursoService.recTodosOsRegistros().subscribe((dados: any) => {
      this.listaCurso = dados;
    })
  }

  excluirCurso(idCurso: number): void {
    this.cursoService.exclusaoRegistro(idCurso).subscribe(() => {
      this.listarCursos();
    });
  }
}
