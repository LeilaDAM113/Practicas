import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SelectorModo } from './selector-modo';

describe('SelectorModo', () => {
  let component: SelectorModo;
  let fixture: ComponentFixture<SelectorModo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SelectorModo],
    }).compileComponents();

    fixture = TestBed.createComponent(SelectorModo);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
