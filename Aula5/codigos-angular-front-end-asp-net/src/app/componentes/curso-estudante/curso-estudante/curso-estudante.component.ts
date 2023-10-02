import { Component, OnInit } from '@angular/core';
import { cursoEstudante } from 'src/app/model/cursoEstudante';
import { CursoEstudanteService } from 'src/app/service/curso-estudante.service';

@Component({
  selector: 'app-curso-estudante',
  templateUrl: './curso-estudante.component.html',
  styleUrls: ['./curso-estudante.component.css']
})
export class CursoEstudanteComponent implements OnInit {

  lstCursoEstudantes: Array<cursoEstudante> = [];

  title = "Lista de curso e estudantes"

  constructor(private CursoEstudanteService: CursoEstudanteService) {

  }

  ngOnInit(): void {
    this.getAllCursosEstudantes();
  }

  getAllCursosEstudantes() {
    this.CursoEstudanteService.getCursosEstudantes().subscribe((dados: any) => {
      this.lstCursoEstudantes = dados;
      console.log(this.lstCursoEstudantes);
    })
  }



}
