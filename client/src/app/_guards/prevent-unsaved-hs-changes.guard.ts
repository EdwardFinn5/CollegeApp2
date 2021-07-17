import { Injectable } from '@angular/core';
import {
  CanDeactivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { HsEditComponent } from '../hs-edit/hs-edit.component';

@Injectable({
  providedIn: 'root',
})
export class PreventUnsavedHsChangesGuard implements CanDeactivate<unknown> {
  canDeactivate(component: HsEditComponent): boolean {
    if (component.editForm.dirty) {
      return confirm(
        'Are you sure you want to continue? Any unsaved changes will be lost'
      );
    }
    return true;
  }
}
