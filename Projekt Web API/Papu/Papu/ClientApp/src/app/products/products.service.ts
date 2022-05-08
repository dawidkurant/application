import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

import { Product } from "./product";
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private apiURL = "https://localhost:5001/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient, private authService: AuthService) { }

  getProducts(): Observable<Product[]> {
    return this.httpClient.get<Product[]>(this.apiURL + '/product')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getProduct(productId): Observable<Product> {
    return this.httpClient.get<Product>(this.apiURL + '/product/' + productId)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createProduct(product): Observable<Product> {
    return this.httpClient.post<Product>(this.apiURL + '/product', product, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateProduct(productId, product): Observable<Product> {
    return this.httpClient.put<Product>(this.apiURL + '/product/' + productId, product, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteProduct(productId) {
    return this.httpClient.delete<Product>(this.apiURL + '/product/' + productId, this.httpOptions)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  errorHandler(error) {
    let errorMessage = '';

    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    return throwError(errorMessage);
  }
}
