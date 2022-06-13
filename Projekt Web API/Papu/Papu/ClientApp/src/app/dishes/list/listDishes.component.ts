import { Component, Injectable, OnInit } from '@angular/core';

import { Dish } from "../dish";
import { DishesService } from '../dishes.service';
import { Ng2OrderModule } from 'ng2-order-pipe';

@Component({
  selector: 'app-list',
  templateUrl: './listDishes.component.html',
  styleUrls: ['./listDishes.component.css']
})

@Injectable({
  providedIn: 'root'
})

export class ListDishesComponent implements OnInit {
  dishes: Dish[] = [];

  constructor(public dishesService: DishesService) {
  }

  totalLenght: any;
  page: number = 1;

  dishName: any;

  order = false;
  isDesc: boolean = false;

  kindOfName: boolean = false;
  typeName: boolean = false;
  productName: boolean = false;
  
  ngOnInit(): void {
    this.dishesService.getDishes().subscribe((data: Dish[]) => {
      this.dishes = data;

      console.log(this.dishes);

      this.totalLenght = data.length;

    });
  }

  search() {
    if(this.dishName == ""){
      this.ngOnInit();
    }else{
      this.dishes = this.dishes.filter(res =>{
        return res.dishName.toLocaleLowerCase().match(this.dishName.toLocaleLowerCase());
      })
    }
  }

  sortBySize() {
    if(this.order) {
      let newarr = this.dishes.sort((a, b) => a.size - b.size);
      this.dishes = newarr;
    }
    else {
      let newarr = this.dishes.sort((a, b) => b.size - a.size);
      this.dishes = newarr;
    }

    this.order = !this.order;
  }

  sortByPortions() {
    if(this.order) {
      let newarr = this.dishes.sort((a, b) => a.portions - b.portions);
      this.dishes = newarr;
    }
    else {
      let newarr = this.dishes.sort((a, b) => b.portions - a.portions);
      this.dishes = newarr;
    }

    this.order = !this.order;
  }

  sortByTime() {
    if(this.order) {
      let newarr = this.dishes.sort((a, b) => a.preparationTime - b.preparationTime);
      this.dishes = newarr;
    }
    else {
      let newarr = this.dishes.sort((a, b) => b.preparationTime - a.preparationTime);
      this.dishes = newarr;
    }

    this.order = !this.order;
  }

  sortByString(property) {
    this.isDesc = !this.isDesc;

    let direction = this.isDesc ? 1: -1;

    this.dishes.sort(function (a, b) {
      if(a[property] < b[property]) {
        return -1 * direction;
      }
      else if(a[property] > b[property]) {
        return 1 * direction;
      }
      else {
        return 0;
      }
    });
  }

  showKindsOf() {
    this.kindOfName = !this.kindOfName;
  }

  showTypes() {
    this.typeName = !this.typeName;
  }

  showProducts() {
    this.productName = !this.productName;
  }

  deleteDish(dishId) {
    this.dishesService.deleteDish(dishId).subscribe(res => {
      this.dishes = this.dishes.filter(item => item.dishId !== dishId);
    });
  }

}
