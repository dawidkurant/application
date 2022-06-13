import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListDishesComponent } from './list/listDishes.component';
import { AuthGuardService } from '../services/auth-guard.service';


const routes: Routes = [
  { path: 'dishes', redirectTo: 'dishes/list', pathMatch: 'full' },
  { path: 'dishes/list', component: ListDishesComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  providers: [AuthGuardService],
  exports: [RouterModule]
})
export class DishesRoutingModule { }
