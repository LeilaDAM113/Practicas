import { TestBed } from '@angular/core/testing';
import { CanMatchFn } from '@angular/router';
import { dashboardMatchGuard } from './dashboard-match-guard';

describe('dashboardMatchGuard', () => {
  const executeGuard: CanMatchFn = (...guardParameters) =>
    TestBed.runInInjectionContext(() => dashboardMatchGuard(...guardParameters));

  beforeEach(() => {
    TestBed.configureTestingModule({});
  });

  it('should be created', () => {
    expect(executeGuard).toBeTruthy();
  });
});
