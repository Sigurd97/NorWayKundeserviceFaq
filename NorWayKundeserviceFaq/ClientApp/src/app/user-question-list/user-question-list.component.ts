import { Component, OnInit } from '@angular/core';
import { UserQuestionService } from '../services/user-question.service';
import { UserQuestion } from '../models/user-question';

@Component({
  selector: 'app-user-question-list',
  templateUrl: './user-question-list.component.html',
  styleUrls: ['./user-question-list.component.css']
})
export class UserQuestionListComponent implements OnInit {
  userQuestionList: UserQuestion[];

  constructor(private userQuestionService: UserQuestionService) { }

  ngOnInit() {
    this.userQuestionService.getAllUserQuestions().subscribe(data => {
      this.userQuestionList = data;
    });
  }

}
