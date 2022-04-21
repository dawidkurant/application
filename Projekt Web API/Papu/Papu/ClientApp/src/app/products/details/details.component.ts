import { Component, OnInit } from '@angular/core';

import { Product } from "../product";
import { ProductsService } from '../products.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})

export class DetailsComponent implements OnInit {

  productId: number;
  product: Product;

  constructor(
    public productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router) {
  }

  ngOnInit(): void {
    this.productId = this.route.snapshot.params['productId'];
    this.productsService.getProduct(this.productId).subscribe((data: Product) => {
      this.product = data;
    });
  }

}
