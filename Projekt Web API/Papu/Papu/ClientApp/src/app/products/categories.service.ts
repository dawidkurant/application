import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
 
import { Category } from "./category";
 
@Injectable({
  providedIn: 'root'
})
export class CategoriesService {
 
  private apiURL = "https://localhost:5001/api";
   
  constructor(private httpClient: HttpClient) { }
 
  getCategories(): Observable<Category[]> {
    return this.httpClient.get<Category[]>(this.apiURL + '/category')
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
