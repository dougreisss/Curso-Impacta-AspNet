import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { EstudanteCursoService } from 'src/app/service/estudante-curso.service';

@Component({
  selector: 'app-unico-estudante-curso',
  templateUrl: './unico-estudante-curso.component.html',
  styleUrls: ['./unico-estudante-curso.component.css']
})
export class UnicoEstudanteCursoComponent implements OnInit {

  constructor(
    private estudanteCursoService: EstudanteCursoService,
    private copiandoRota: ActivatedRoute
  ) {

  }

  title = "Unico estudante com cursos";

  unicoEstudante: any = {};

  rotaCopiada: any = this.copiandoRota.snapshot.params['id'];

  ngOnInit(): void {
    this.getUnicoEstudante();
  }

  getUnicoEstudante(): void {
    this.estudanteCursoService.getUnicoEstudanteCurso(this.rotaCopiada).subscribe((dados) => {
      this.unicoEstudante = dados;
      console.log(this.unicoEstudante);
    })
  }

}
