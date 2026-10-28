import { CanActivateChildFn } from '@angular/router';

export const dashChildGuard: CanActivateChildFn = (childRoute, state) => {
  const isLoggedIn = true
  return isLoggedIn;
};
