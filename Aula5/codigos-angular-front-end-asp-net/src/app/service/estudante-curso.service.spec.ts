import { TestBed } from '@angular/core/testing';

import { EstudanteCursoService } from './estudante-curso.service';

describe('EstudanteCursoService', () => {
  let service: EstudanteCursoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EstudanteCursoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
