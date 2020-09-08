import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PontoComponent } from './ponto/ponto.component';

const routes: Routes = [
  {path: 'ponto', component: PontoComponent},
  {path: '', redirectTo: 'ponto', pathMatch: 'full'},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
