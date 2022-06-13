import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DishesRoutingModule } from './dishes-routing.module';
import { ListDishesComponent } from './list/listDishes.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NgxPaginationModule } from 'ngx-pagination';

@NgModule({
  declarations: [
    ListDishesComponent
  ],
  imports: [
    CommonModule,
    DishesRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgxPaginationModule
  ]
})
export class DishesModule { }
