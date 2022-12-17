import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AddCustomerDialogComponent } from './home/components/add-customer-dialog/add-customer-dialog.component';
import { UpdateCustomerDialogComponent } from './home/components/update-customer-dialog/update-customer-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AddCustomerDialogComponent,
    UpdateCustomerDialogComponent
  ],
  imports: [
    CommonModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
