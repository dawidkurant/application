import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { environment } from '../../environments/environment';

import { Dish } from "./dish";
import { AuthService } from '../services/auth.service';

@Injectable({
  providedIn: 'root'
})
export class DishesService {

  private apiURL = "https://localhost:5001/api";
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(private httpClient: HttpClient, private authService: AuthService) { }

  getDishes(): Observable<Dish[]> {
    return this.httpClient.get<Dish[]>(this.apiURL + '/dish')
      .pipe(
        catchError(this.errorHandler)
      );
  }

  getDish(dishId): Observable<Dish> {
    return this.httpClient.get<Dish>(this.apiURL + '/dish/' + dishId)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  createDish(dish): Observable<Dish> {
    return this.httpClient.post<Dish>(this.apiURL + '/dish', dish)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  updateDish(dishId, dish): Observable<Dish> {
    return this.httpClient.put<Dish>(this.apiURL + '/dish/' + dishId, dish)
      .pipe(
        catchError(this.errorHandler)
      );
  }

  deleteDish(dishId) {
    return this.httpClient.delete<Dish>(this.apiURL + '/dish/' + dishId)
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

