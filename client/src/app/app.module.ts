import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { ColUserLoginComponent } from './col-user-login/col-user-login.component';
import { CollegeComponent } from './college/college.component';
import { CollegeDetailComponent } from './college-detail/college-detail.component';
import { CollegeEditComponent } from './college-edit/college-edit.component';
import { CollegeRegisterComponent } from './college-register/college-register.component';
import { ColmemberCardComponent } from './colmembers/colmember-card/colmember-card.component';
import { ColmemberListComponent } from './colmembers/colmember-list/colmember-list.component';
import { PhotoEditorComponent } from './colmembers/photo-editor/photo-editor.component';
import { HomeComponent } from './home/home.component';
import { HsDetailComponent } from './hs-detail/hs-detail.component';
import { HsEditComponent } from './hs-edit/hs-edit.component';
import { HsRegisterComponent } from './hs-register/hs-register.component';
import { HsStudentComponent } from './hs-student/hs-student.component';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorsComponent } from './errors/test-errors/test-errors.component';
import { MessagesComponent } from './messages/messages.component';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    ColUserLoginComponent,
    CollegeComponent,
    CollegeDetailComponent,
    CollegeEditComponent,
    CollegeRegisterComponent,
    ColmemberCardComponent,
    ColmemberListComponent,
    PhotoEditorComponent,
    HomeComponent,
    HsDetailComponent,
    HsEditComponent,
    HsRegisterComponent,
    HsStudentComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorsComponent,
    MessagesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
