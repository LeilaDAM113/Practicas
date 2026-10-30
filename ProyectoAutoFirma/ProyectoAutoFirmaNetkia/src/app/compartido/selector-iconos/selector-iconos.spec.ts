import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SelectorIconos } from './selector-iconos';

describe('SelectorIconos', () => {
  let component: SelectorIconos;
  let fixture: ComponentFixture<SelectorIconos>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectorIconos],
    }).compileComponents();

    fixture = TestBed.createComponent(SelectorIconos);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
