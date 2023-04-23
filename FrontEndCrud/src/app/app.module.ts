import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// To work with Angular reactive forms 
import {ReactiveFormsModule} from '@angular/forms';

// To work with Http peticions
import {HttpClientModule} from '@angular/common/http';

// To work with Angular Material components 
          // (Tables)
import {MatTableModule} from '@angular/material/table';         // tables
import {MatPaginatorModule} from '@angular/material/paginator'; // paginator tables
          // (Forms)
import {MatButtonModule} from '@angular/material/button';        // buttons
import {MatFormFieldModule} from '@angular/material/form-field'; // forms
import {MatInputModule} from '@angular/material/input';          // inputs
import {MatSelectModule} from '@angular/material/select';        // selects
import {MatDatepickerModule} from '@angular/material/datepicker';// datepickers
import {MatNativeDateModule} from '@angular/material/core';      // native dates
import { MomentDateModule } from '@angular/material-moment-adapter'; // date format
          // (Alerts)
import {MatSnackBarModule} from '@angular/material/snack-bar';  // snack bar 
          // (Icons)
import {MatIconModule} from '@angular/material/icon';           // Icons
          // (Modals)
import {MatDialogModule} from '@angular/material/dialog';       // Modals
          // (Grids)
import {MatGridListModule} from '@angular/material/grid-list';  // Grids

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
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatDatepickerModule,
    MatNativeDateModule, 
    MomentDateModule,
    MatSnackBarModule, 
    MatIconModule,
    MatDialogModule,
    MatGridListModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
