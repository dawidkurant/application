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

  ngOnInit(): void {
    this.productsService.getProducts().subscribe((data: Product[]) => {
      this.products = data;
    });
  }

  deleteProduct(productId) {
    this.productsService.deleteProduct(productId).subscribe(res => {
      this.products = this.products.filter(item => item.productId !== productId);
    });
  }

}
