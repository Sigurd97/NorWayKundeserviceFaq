import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient, HttpErrorResponse } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Question } from '../models/question';
import { Observable, of, throwError } from 'rxjs';
import { tap, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class RatingService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/Rating/';
  }

  like(id: number): Boolean {
    let returnFlag = true;
    this.http.get<Question>(this.myAppUrl + this.myApiUrl + 'Like/' + id)
      .pipe(
        tap(data => console.log(data)),
        catchError((error: HttpErrorResponse) => {
          returnFlag = false;
          if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
          } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(
              `Backend returned code ${error.status}, ` +
              `body was: ${error.error}`);
          }
          // return an observable with a user-facing error message
          return throwError(
            'Something bad happened; please try again later.');
        })
      ).subscribe();

    return returnFlag;
  }

  dislike(id: number): Boolean {
    let returnFlag = true;
    this.http.get<Question>(this.myAppUrl + this.myApiUrl + 'Dislike/' + id)
      .pipe(
        tap(data => console.log(data)),
        catchError((error: HttpErrorResponse) => {
          returnFlag = false;
          if (error.error instanceof ErrorEvent) {
            // A client-side or network error occurred. Handle it accordingly.
            console.error('An error occurred:', error.error.message);
          } else {
            // The backend returned an unsuccessful response code.
            // The response body may contain clues as to what went wrong,
            console.error(
              `Backend returned code ${error.status}, ` +
              `body was: ${error.error}`);
          }
          // return an observable with a user-facing error message
          return throwError(
            'Something bad happened; please try again later.');
        })
      ).subscribe();

    return returnFlag;
  }
}
