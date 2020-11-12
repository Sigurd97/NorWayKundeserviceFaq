import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Category } from '../models/category';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  myAppUrl: string;
  myApiUrl: string;
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json; charset=utf-8'
    })
  };
  constructor(private http: HttpClient) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/Faq/';
  }

  getCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(this.myAppUrl + this.myApiUrl);
  }

  getCategory(categoryId: number): Observable<Category> {
    return this.http.get<Category>(this.myAppUrl + this.myApiUrl + categoryId);
  }

  saveCategory(category: any): Observable<Category> {
    return this.http.post<Category>(this.myAppUrl + this.myApiUrl, JSON.stringify(category), this.httpOptions);
  }
}
