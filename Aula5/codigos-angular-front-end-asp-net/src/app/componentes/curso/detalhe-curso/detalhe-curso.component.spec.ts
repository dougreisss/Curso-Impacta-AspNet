import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DetalheCursoComponent } from './detalhe-curso.component';

describe('DetalheCursoComponent', () => {
  let component: DetalheCursoComponent;
  let fixture: ComponentFixture<DetalheCursoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DetalheCursoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DetalheCursoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
