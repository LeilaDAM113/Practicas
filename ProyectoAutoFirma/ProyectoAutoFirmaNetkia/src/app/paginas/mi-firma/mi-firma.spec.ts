import { ComponentFixture, TestBed } from '@angular/core/testing';
import { MiFirma } from './mi-firma';

describe('MiFirma', () => {
  let component: MiFirma;
  let fixture: ComponentFixture<MiFirma>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MiFirma],
    }).compileComponents();

    fixture = TestBed.createComponent(MiFirma);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
