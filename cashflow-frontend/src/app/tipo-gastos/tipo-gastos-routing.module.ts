import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TipoGastosListComponent } from './tipo-gastos-list/tipo-gastos-list.component';
import { TipoGastosFormComponent } from './tipo-gastos-form/tipo-gastos-form.component';

const routes: Routes = [
  { path: '', component: TipoGastosListComponent },
  { path: 'nuevo', component: TipoGastosFormComponent },
  { path: ':id', component: TipoGastosFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TipoGastosRoutingModule { }