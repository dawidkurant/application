import { Component, Injectable, OnInit } from '@angular/core';

import { Product } from "../product";
import { ProductsService } from '../products.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})

@Injectable({
  providedIn: 'root'
})

export class ListComponent implements OnInit {
  products: Product[] = [];

  constructor(public productsService: ProductsService) {
  }

  totalLenght: any;
  page: number = 1;

  productName: any;

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((data: Product[]) => {
      this.products = data;

      console.log(this.products);

      this.totalLenght = data.length;

    });
  }

  Search() {
    if(this.productName == ""){
      this.ngOnInit();
    }else{
      this.products = this.products.filter(res =>{
        return res.productName.toLocaleLowerCase().match(this.productName.toLocaleLowerCase());
      })
    }
  }

  deleteProduct(productId) {
    this.productsService.deleteProduct(productId).subscribe(res => {
      this.products = this.products.filter(item => item.productId !== productId);
    });
  }

}
