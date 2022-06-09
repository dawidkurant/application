import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Type } from "./type";

@Injectable({
  providedIn: 'root'
})
export class TypesService {

  private apiURL = "https://localhost:5001/api";

  constructor(private httpClient: HttpClient) { }

  getTypes(): Observable<Type[]> {
    return this.httpClient.get<Type[]>(this.apiURL + '/type')
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
