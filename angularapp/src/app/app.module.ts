import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { RegisterComponent } from './Register/register.component';
import { ApproveComponent } from './Register/approve.component';

@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    ApproveComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  exports: [
    RegisterComponent,
    ApproveComponent

  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
