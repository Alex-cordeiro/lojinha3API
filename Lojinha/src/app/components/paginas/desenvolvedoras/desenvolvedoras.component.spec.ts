import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesenvolvedorasComponent } from './desenvolvedoras.component';

describe('DesenvolvedorasComponent', () => {
  let component: DesenvolvedorasComponent;
  let fixture: ComponentFixture<DesenvolvedorasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DesenvolvedorasComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(DesenvolvedorasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
