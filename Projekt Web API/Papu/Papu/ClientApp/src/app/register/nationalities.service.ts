import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

import { Nationality } from "./nationality";

@Injectable({
  providedIn: 'root'
})
export class NationalitiesService {

  nationalities: Nationality[] = [{
    nationalityId: 1,
    nationality: 'German'
  },
  {
    nationalityId: 2,
    nationality: 'Polish'
  }];
  
  constructor() { }

  getNationalities() {
    return this.nationalities;
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
