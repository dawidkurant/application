import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-getall-product',
  templateUrl: './getall-product.component.html',
  styleUrls: ['./getall-product.component.css']
})

export class GetAllProductComponent {
  public result: Product[];
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string) {
  }
  ngOnInit() {
    this.http.get<Product[]>(this.baseUrl + 'api/product').subscribe(result => {
      this.result = result;
    }, error => console.error(error));
  }
}


interface Product {
  productName: string;
  categoryName: string;
  groups: string[];
  unitName: string;
  weight: number;
  productImagePath: string;
}
