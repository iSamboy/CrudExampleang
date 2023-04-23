import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// To work with Angular reactive forms 
import {ReactiveFormsModule} from '@angular/forms';

// To work with Http peticions
import {HttpClientModule} from '@angular/common/http';

// To work with Angular Material components
import {MatButtonModule} from '@angular/material/button';       // buttons
import {MatTableModule} from '@angular/material/table';         // tables
import {MatPaginatorModule} from '@angular/material/paginator'; // paginator tables


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatButtonModule,
    MatTableModule, 
    MatPaginatorModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
