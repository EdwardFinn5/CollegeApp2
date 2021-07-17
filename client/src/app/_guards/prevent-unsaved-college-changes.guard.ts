import { Injectable } from '@angular/core';
import {
  CanDeactivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
} from '@angular/router';
import { Observable } from 'rxjs';
import { CollegeEditComponent } from '../college-edit/college-edit.component';

@Injectable({
  providedIn: 'root',
})
export class PreventUnsavedCollegeChangesGuard
  implements CanDeactivate<unknown>
{
  canDeactivate(component: CollegeEditComponent): boolean {
    if (component.editForm.dirty) {
      return confirm(
        'Are you sure you want to continue? Any unsaved changes will be lost'
      );
    }
    return true;
  }
}
