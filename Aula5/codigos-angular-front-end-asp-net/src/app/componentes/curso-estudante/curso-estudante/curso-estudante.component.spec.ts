import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CursoEstudanteComponent } from './curso-estudante.component';

describe('CursoEstudanteComponent', () => {
  let component: CursoEstudanteComponent;
  let fixture: ComponentFixture<CursoEstudanteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CursoEstudanteComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CursoEstudanteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
