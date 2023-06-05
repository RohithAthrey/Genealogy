import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RegisterComponent } from './Register/register.component';
import { ApproveComponent } from './Register/approve.component';
import { LoginComponent } from './Register/login.component';
import { ProfileComponent } from './Register/profile.component';
import { myClanComponent } from './Register/myClan.component';
import { familyTreeComponent } from './Register/familyTree.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    ApproveComponent,
    LoginComponent,
    ProfileComponent,
    myClanComponent,
    familyTreeComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    RegisterComponent,
    ApproveComponent,
    LoginComponent,
    ProfileComponent,
    myClanComponent,
    familyTreeComponent
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
