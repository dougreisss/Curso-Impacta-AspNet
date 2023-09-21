import { TestBed } from '@angular/core/testing';

import { EstudanteApiService } from './estudante-api.service';

describe('EstudanteApiService', () => {
  let service: EstudanteApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EstudanteApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
