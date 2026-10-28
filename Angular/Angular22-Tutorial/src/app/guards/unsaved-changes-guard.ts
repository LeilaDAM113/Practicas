import { CanDeactivateFn } from '@angular/router';

export const unsavedChangesGuard: CanDeactivateFn<any> = (
  component
) => {
  if(component.hasUnsavedChanges()){
    return confirm('You have unsaved changes. Are you sure you want to leave?')
  }
  return true;
};
