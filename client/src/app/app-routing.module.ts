import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CollegeDetailComponent } from './college-detail/college-detail.component';
import { CollegeComponent } from './college/college.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { HomeComponent } from './home/home.component';
import { HsEditComponent } from './hs-edit/hs-edit.component';
import { CollegeEditComponent } from './college-edit/college-edit.component';
import { ColUserLoginComponent } from './col-user-login/col-user-login.component';
import { HsStudentComponent } from './hs-student/hs-student.component';
import { HsRegisterComponent } from './hs-register/hs-register.component';
import { CollegeRegisterComponent } from './college-register/college-register.component';
import { ColmemberListComponent } from './colmembers/colmember-list/colmember-list.component';
// import { AuthGuard } from './_guards/auth.guard';
import { HsDetailComponent } from './hs-detail/hs-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { ListsComponent } from './lists/lists.component';
import { PreventUnsavedHsChangesGuard } from './_guards/prevent-unsaved-hs-changes.guard';
import { PreventUnsavedCollegeChangesGuard } from './_guards/prevent-unsaved-college-changes.guard';
// import { PreventUnsavedHsChangesGuard } from './_guards/prevent-unsaved-hs-changes.guard';
// import { PreventUnsavedCollegeChangesGuard } from './_guards/prevent-unsaved-college-changes.guard';

const routes: Routes = [
  { path: '', component: HomeComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'colmembers', component: ColmemberListComponent },
      {
        path: 'hsmemberedit',
        component: HsEditComponent,
        canDeactivate: [PreventUnsavedHsChangesGuard],
      },
      { path: 'hsdetail/:colusername', component: HsDetailComponent },
      { path: 'hsdetail/:id', component: HsDetailComponent },
      { path: 'hsedit', component: HsEditComponent },
      {
        path: 'collegeedit',
        component: CollegeEditComponent,
        canDeactivate: [PreventUnsavedCollegeChangesGuard],
      },
      { path: 'collegedetail/:colusername', component: CollegeDetailComponent },
      { path: 'collegedetail/:id', component: CollegeDetailComponent },
      { path: 'messages', component: MessagesComponent },
      { path: 'lists', component: ListsComponent },
    ],
  },
  { path: 'hsstudent', component: HsStudentComponent },
  { path: 'college', component: CollegeComponent },
  { path: 'coluserlogin', component: ColUserLoginComponent },
  { path: 'collegeregister', component: CollegeRegisterComponent },
  { path: 'hsregister', component: HsRegisterComponent },
  { path: 'errors', component: TestErrorsComponent },
  { path: 'not-found', component: NotFoundComponent },
  { path: 'server-error', component: ServerErrorComponent },
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
