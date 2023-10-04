import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UnicoEstudanteCursoComponent } from './unico-estudante-curso.component';

describe('UnicoEstudanteCursoComponent', () => {
  let component: UnicoEstudanteCursoComponent;
  let fixture: ComponentFixture<UnicoEstudanteCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UnicoEstudanteCursoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(UnicoEstudanteCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
