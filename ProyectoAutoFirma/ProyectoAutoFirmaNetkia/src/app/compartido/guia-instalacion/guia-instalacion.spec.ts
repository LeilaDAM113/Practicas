import { ComponentFixture, TestBed } from '@angular/core/testing';
import { GuiaInstalacion } from './guia-instalacion';

describe('GuiaInstalacion', () => {
  let component: GuiaInstalacion;
  let fixture: ComponentFixture<GuiaInstalacion>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GuiaInstalacion],
    }).compileComponents();

    fixture = TestBed.createComponent(GuiaInstalacion);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
