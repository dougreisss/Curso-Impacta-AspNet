import { Component, OnInit } from '@angular/core';
import { EstudanteCursoService } from 'src/app/service/estudante-curso.service';

@Component({
  selector: 'app-estudante-curso',
  templateUrl: './estudante-curso.component.html',
  styleUrls: ['./estudante-curso.component.css']
})
export class EstudanteCursoComponent implements OnInit {

  title = "Lista de estudantes com curso";

  lstEstudanteCurso: any = [];

  constructor(private estudanteCursoService: EstudanteCursoService) {

  }

  ngOnInit(): void {
    this.getEstudantesCurso();
  }

  getEstudantesCurso(): void {
    this.estudanteCursoService.getEstudantesCurso().subscribe((dados: any) => {
      this.lstEstudanteCurso = dados;
    });
  }
}
