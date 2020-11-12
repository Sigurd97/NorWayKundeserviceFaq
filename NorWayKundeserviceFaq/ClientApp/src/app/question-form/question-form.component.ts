import { Component, OnInit, Input } from '@angular/core';
import { FormGroup, FormBuilder, FormControl, NgForm, Validators } from '@angular/forms';
import { UserQuestionDTO } from '../models/user-question';
import { Category } from '../models/category';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { UserQuestionService } from '../services/user-question.service';

@Component({
  selector: 'app-question-form',
  templateUrl: './question-form.component.html',
  styleUrls: ['./question-form.component.css']
})
export class QuestionFormComponent implements OnInit {
  userQuestionForm: FormGroup;
  myAppUrl: string;
  myApiUrl: string;

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json',
    })
  };

  constructor(private _http: HttpClient, private fb: FormBuilder, private userQuestionService: UserQuestionService) {
    this.userQuestionForm = fb.group({
      id: [0],
      firstname: [null, Validators.compose([Validators.required, Validators.pattern('[a-zA-ZøæåØÆÅ ]{1,30}')])],
      lastname: [null, Validators.compose([Validators.required, Validators.pattern('[a-zA-ZøæåØÆÅ\\-. ]{1,30}')])],
      question: [null, Validators.compose([Validators.required, Validators.pattern('[0-9a-zA-ZøæåØÆÅ\\-. ?!#%&,_<>\"@$()=\/]{2,}')])],
      categoryId: [null, Validators.compose([Validators.required, Validators.pattern('[0-9]')])],
    });
    this.myAppUrl = environment.appUrl;
    this.myApiUrl = 'api/UserQuestions/';
  }

  @Input() categories: Category[];

  ngOnInit() {
  }

  onSubmit() {
    const userQuestion = new UserQuestionDTO();

    userQuestion.id = +0;
    userQuestion.firstname = this.userQuestionForm.value.firstname;
    userQuestion.lastname = this.userQuestionForm.value.lastname;
    userQuestion.question = this.userQuestionForm.value.question;
    userQuestion.categoryId = +this.userQuestionForm.value.categoryId;

    const body: string = JSON.stringify(userQuestion);

    this._http.post('http://localhost:5000/api/UserQuestions/', body, this.httpOptions)
      .subscribe(
        data => console.log(data),
        (error) => console.log(error)
      );
    this.userQuestionForm.reset();
  }

  resetForm() {
    this.userQuestionForm.reset();
  }

  // TODO: Remove this when we're done
  get diagnostic() { return JSON.stringify(this.userQuestionForm.value); }

}
