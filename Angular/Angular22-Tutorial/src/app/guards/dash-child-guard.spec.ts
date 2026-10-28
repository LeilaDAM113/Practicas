import { TestBed } from '@angular/core/testing';
import { CanActivateChildFn } from '@angular/router';
import { dashChildGuard } from './dash-child-guard';

describe('dashChildGuard', () => {
  const executeGuard: CanActivateChildFn = (...guardParameters) =>
    TestBed.runInInjectionContext(() => dashChildGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
