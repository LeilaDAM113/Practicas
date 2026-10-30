import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FirmaDepartamento } from './firma-departamento';

describe('FirmaDepartamento', () => {
  let component: FirmaDepartamento;
  let fixture: ComponentFixture<FirmaDepartamento>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FirmaDepartamento],
    }).compileComponents();

    fixture = TestBed.createComponent(FirmaDepartamento);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
