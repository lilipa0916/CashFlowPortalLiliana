import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from '../app/auth/login.component';
import { AuthGuard } from '../app/auth/auth.guard';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: 'tipo-gastos',
    loadChildren: () => import('./tipo-gastos/tipo-gastos.module').then(m => m.TipoGastosModule),
    canActivate: [AuthGuard]
  },
  {
    path: 'fondo-monetario',
    loadChildren: () => import('./fondo-monetario/fondo-monetario.module').then(m => m.FondoMonetarioModule),
    canActivate: [AuthGuard]
  },
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: '**', redirectTo: 'login' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
