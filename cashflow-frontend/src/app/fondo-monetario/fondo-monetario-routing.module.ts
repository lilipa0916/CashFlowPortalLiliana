import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FondoMonListComponent } from '../fondo-monetario/fondo-mon-list/fondo-mon-list.component';
import { FondoMonFormComponent } from '../fondo-monetario/fondo-mon-form/fondo-mon-form.component';
// ./tipo-gastos-list/tipo-gastos-list.component';
const routes: Routes = [
  { path: '', component: FondoMonListComponent },
  { path: 'nuevo', component: FondoMonFormComponent },
  { path: ':id', component: FondoMonFormComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FondoMonetarioRoutingModule { }