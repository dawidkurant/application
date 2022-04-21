import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
 
import { Group } from "./group";
 
@Injectable({
  providedIn: 'root'
})
export class GroupsService {
 
  private apiURL = "https://localhost:5001/api";
   
  constructor(private httpClient: HttpClient) { }
 
  getGroups(): Observable<Group[]> {
    return this.httpClient.get<Group[]>(this.apiURL + '/group')
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
