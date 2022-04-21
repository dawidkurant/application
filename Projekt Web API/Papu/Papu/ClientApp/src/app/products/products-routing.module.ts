import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ListComponent } from './list/list.component';
import { DetailsComponent } from './details/details.component';
import { CreateComponent } from './create/create.component';

const routes: Routes = [
  { path: 'products', redirectTo: 'products/list', pathMatch: 'full' },
  { path: 'products/list', component: ListComponent },
  { path: 'products/:productId/details', component: DetailsComponent },
  { path: 'products/create', component: CreateComponent }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProductsRoutingModule { }
