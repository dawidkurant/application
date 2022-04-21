import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Unit } from "./unit";

@Injectable({
  providedIn: 'root'
})
export class UnitsService {

  private apiURL = "https://localhost:5001/api";

  constructor(private httpClient: HttpClient) { }

  getUnits(): Observable<Unit[]> {
    return this.httpClient.get<Unit[]>(this.apiURL + '/unit')
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
