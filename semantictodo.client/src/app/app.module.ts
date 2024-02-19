import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { API_BASE_URL, Client } from '../data-access/dataAccessClient';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule
  ],
  providers: [Client, {provide: API_BASE_URL, useValue: "https://localhost:7098"}],
  bootstrap: [AppComponent]
})
export class AppModule { }
