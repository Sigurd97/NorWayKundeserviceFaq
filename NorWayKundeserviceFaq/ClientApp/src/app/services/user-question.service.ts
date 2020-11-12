import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserQuestion } from '../models/user-question';

@Injectable({
  providedIn: 'root'
})
export class UserQuestionService {
  myAppUrl: string;
  myApiUrl: string;

  constructor(private _http: HttpClient, private fb: FormBuilder) {
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/UserQuestions/';
  }

  getAllUserQuestions(): Observable<UserQuestion[]> {
    return this._http.get<UserQuestion[]>(this.myAppUrl + this.myApiUrl);
  }
}
