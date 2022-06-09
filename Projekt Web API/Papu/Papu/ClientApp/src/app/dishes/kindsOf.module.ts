import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
 
import { KindOf } from "./kindOf";
 
@Injectable({
  providedIn: 'root'
})
export class KindsOfService {
 
  private apiURL = "https://localhost:5001/api";
   
  constructor(private httpClient: HttpClient) { }
 
  getKindsOf(): Observable<KindOf[]> {
    return this.httpClient.get<KindOf[]>(this.apiURL + '/kindOf')
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
