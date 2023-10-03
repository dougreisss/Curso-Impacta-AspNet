import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EstudanteCursoComponent } from './estudante-curso.component';

describe('EstudanteCursoComponent', () => {
  let component: EstudanteCursoComponent;
  let fixture: ComponentFixture<EstudanteCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EstudanteCursoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EstudanteCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
