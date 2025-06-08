import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FondoMonListComponent } from './fondo-mon-list/fondo-mon-list.component';
import { FondoMonFormComponent } from './/fondo-mon-form/fondo-mon-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { FondoMonetarioRoutingModule } from './fondo-monetario-routing.module';

@NgModule({
  declarations: [
    FondoMonListComponent,
    FondoMonFormComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FondoMonetarioRoutingModule
  ]
})
export class FondoMonetarioModule { }
