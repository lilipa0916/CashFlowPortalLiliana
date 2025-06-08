import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { TipoGastosListComponent } from './tipo-gastos-list/tipo-gastos-list.component';
import { TipoGastosFormComponent } from './tipo-gastos-form/tipo-gastos-form.component';
import { TipoGastosRoutingModule } from './tipo-gastos-routing.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule }     from '@angular/material/input';
import { MatButtonModule }    from '@angular/material/button';
import { MatIconModule }      from '@angular/material/icon';

import { MatTableModule } from '@angular/material/table';

@NgModule({
  declarations: [TipoGastosListComponent, TipoGastosFormComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    TipoGastosRoutingModule,
     MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule
  ]
})

export class TipoGastosModule  {}