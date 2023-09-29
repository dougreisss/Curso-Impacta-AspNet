import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InserirCadastroComponent } from './inserir-cadastro.component';

describe('InserirCadastroComponent', () => {
  let component: InserirCadastroComponent;
  let fixture: ComponentFixture<InserirCadastroComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InserirCadastroComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InserirCadastroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
