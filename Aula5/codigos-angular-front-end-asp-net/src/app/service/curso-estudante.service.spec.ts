import { TestBed } from '@angular/core/testing';

import { CursoEstudanteService } from './curso-estudante.service';

describe('CursoEstudanteService', () => {
  let service: CursoEstudanteService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CursoEstudanteService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
